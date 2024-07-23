using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Services;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Account;
using UTEHY.DatabaseCoursePortal.Api.Models.Auth;
using Test.Quiz.Api.Models.User;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Test.Quiz.Api.Data.Entities.User> _userManager;
        private readonly SignInManager<Test.Quiz.Api.Data.Entities.User> _signInManager;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(UserManager<Test.Quiz.Api.Data.Entities.User> userManager, SignInManager<Test.Quiz.Api.Data.Entities.User> signInManager, IConfiguration config, ApplicationDbContext dbContext, AuthService authService, UserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _dbContext = dbContext;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ApiResult<string>> Register([FromBody] RegisterUserRequest request)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            //    var result = await _authService.RegisterUserAsync(model);

            //    if (result.Succeeded)
            //    {
            //        return Ok(new { message = "User registered successfully" });
            //    }
            //    else
            //    {
            //        return BadRequest(result.Errors);
            //    }

            try
            {
                var result = await _authService.RegisterUserAsync(request);

                return new ApiResult<string>()
                {
                    Status = true,
                    Message = "Đăng kí thành công!",
                    Data = result
                };
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ApiResult<LoginResult>> LoginByUsername([FromBody] LoginUserNameRequest request)
        {
            try
            {
                var loginResult = await _authService.LoginByUserName(request);

                return new ApiResult<LoginResult>()
                {
                    Status = true,
                    Message = "Đăng nhập thành công!",
                    Data = loginResult
                };
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ApiResult<LoginResult>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var loginResult = await _authService.RefreshToken(request.RefreshToken);

                return new ApiResult<LoginResult>()
                {
                    Status = true,
                    Message = "Đăng nhập thành công!",
                    Data = loginResult
                };
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<ApiResult<bool>> Logout()
        {
            try
            {
                var isLogout = await _authService.Logout();

                return new ApiResult<bool>()
                {
                    Status = true,
                    Message = "Đăng xuất thành công!",
                    Data = isLogout
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






        //[HttpPost]
        //[Route("login-by-username")]
        //public async Task<ApiResult<string>> LoginByUsername([FromBody] LoginUserNameRequest request)
        //{
        //    var user = await _userManager.FindByNameAsync(request.UserName);

        //    if (user == null)
        //    {
        //        return new ApiResult<string>()
        //        {
        //            Status = false,
        //            Message = "Tên người dùng không tồn tại!",
        //        };
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

        //    if (!result.Succeeded)
        //    {
        //        return new ApiResult<string>()
        //        {
        //            Status = false,
        //            Message = "Tài khoản hoặc mật khẩu không chính xác!",
        //        };
        //    }

        //    // Tạo token
        //    var token = await _authService.CreateToken(user);

        //    if (token == null)
        //    {
        //        return new ApiResult<string>()
        //        {
        //            Status = false,
        //            Message = "Tạo mã token thất bại!",
        //        };
        //    }

        //    return new ApiResult<string>()
        //    {
        //        Status = true,
        //        Message = "Đăng nhập thành công!",
        //        Data = token
        //    };
        //}

    }
}
