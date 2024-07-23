using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Models.Account;
using System.Security.Claims;
using Test.Quiz.Api.Constants;
using UTEHY.DatabaseCoursePortal.Api.Models.Auth;
using UTEHY.DatabaseCoursePortal.Api.Enums;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using UTEHY.DatabaseCoursePortal.Api.Constants;
using Test.Quiz.Api.Models.User;

namespace Test.Quiz.Api.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly UserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public AuthService(ApplicationDbContext dbContext, IConfiguration config, UserService userService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _config = config;
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;

        }

        //register
        public async Task<string> RegisterUserAsync(RegisterUserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = new User
            {
                Name=request.Name,
                UserName = request.UserName,
                Email = request.Email,
                
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "user");
                if (!roleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user);
                    return "Đăng kí thất bại ";
                }
            }

            return "Đăng kí thành công";
        }



        //login by user
        public async Task<LoginResult> LoginByUserName(LoginUserNameRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new BadHttpRequestException("Tên người dùng không tồn tại trong hệ thống!");
            }

            UserType userType = (UserType)request.Type;
            string typeRole = Enum.GetName(typeof(UserType), userType).ToLower().Trim();

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains(typeRole))
            {
                throw new UnauthorizedAccessException($"Người dùng không có vai trò {typeRole}!");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if (!result.Succeeded)
            {
                throw new BadHttpRequestException("Tên tài khoản hoặc mật khẩu không chính xác!");
            }

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimType.UserName, user.UserName),
                new Claim(ClaimType.Email, user.Email),
            };

            if (userClaims != null)
            {
                claims.AddRange(userClaims);
            }

            //Create token
            var token = this.CreateToken(claims);
            var refreshToken = this.CreateRefreshToken();

            var refreshTokenValidityInDays = _config["Jwt:RefreshTokenValidityInDays"];

            if (string.IsNullOrEmpty(refreshTokenValidityInDays))
            {
                throw new ArgumentNullException(nameof(refreshTokenValidityInDays), "Không thể tải cấu hình RefreshTokenValidityInDays Jwt!");
            }

            var refreshTokenExpiryTime = DateTime.Now.AddDays(int.Parse(refreshTokenValidityInDays));

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiryTime;

            await _userManager.UpdateAsync(user);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var loginResult = new LoginResult()
            {
                AccessToken = tokenString,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

            return loginResult;
        }


        //logout
        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();

            return true;
        }


        //create token user
        public async Task<string> CreateToken(User user)
        {
            var key = _config["Jwt:Key"];

            var role = await _userService.GetRoleAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimType.UserName, user.UserName),
                new Claim(ClaimType.Email, user.Email),
                new Claim(ClaimType.Role,role),


            };

            var subject = new ClaimsIdentity(claims);
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddDays(30);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        //create token claims
        public JwtSecurityToken CreateToken(List<Claim> claims)
        {
            var key = _config["Jwt:Key"];

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Không thể tải cấu hình Key Jwt!");
            }

            var minuteValidToken = _config["Jwt:TokenValidityInMinutes"];

            if (string.IsNullOrEmpty(minuteValidToken))
            {
                throw new ArgumentNullException(nameof(minuteValidToken), "Không thể tải cấu hình TokenValidityInMinutes Jwt!");
            }

            var issuer = _config["Jwt:Issuer"];

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Không thể tải cấu hình Issuer Jwt!");
            }

            var audience = _config["Jwt:Audience"];

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Không thể tải cấu hình Audience Jwt!");
            }

            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(int.Parse(minuteValidToken));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expires,
                claims: claims,
                signingCredentials: creds
             );

            return token;
        }


        //create refresh token
        public string CreateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        //
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var key = _config["Jwt:Key"];

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Không thể tải cấu hình Key Jwt!");
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token không hợp lệ!");
            }

            return principal;

        }
        //refresh token
        public async Task<LoginResult> RefreshToken(string refreshToken)
        {
            var authorizationHeader = _httpContextAccessor?.HttpContext?.Request.Headers[HeaderRequest.Authorization].ToString();

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw new BadHttpRequestException("AccessToken không tồn tại trong yêu cầu!");
            }

            var token = authorizationHeader.Split(' ').LastOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                throw new BadHttpRequestException("AccessToken không hợp lệ!");
            }

            var principal = GetPrincipalFromExpiredToken(token);

            string username = principal.Claims.FirstOrDefault(x => x.Type == ClaimType.UserName).Value;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new BadHttpRequestException("Token chứa thông tin người dùng không tồn tại trong hệ thống!");
            }

            if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new BadHttpRequestException("RefreshToken không hợp lệ hoặc đã hết hạn!");
            }

            var newAccessToken = this.CreateToken(principal.Claims.ToList());
            var newRefreshToken = this.CreateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

            var loginResult = new LoginResult()
            {
                AccessToken = tokenString,
                RefreshToken = newRefreshToken,
                Expiration = newAccessToken.ValidTo
            };

            return loginResult;
        }
    }
}
