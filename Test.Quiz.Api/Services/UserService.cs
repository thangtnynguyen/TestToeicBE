using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Exceptions;
using Test.Quiz.Api.Models.User;

namespace Test.Quiz.Api.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly FileService _fileService;
        //private readonly ConfigService _configService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, UserManager<User> userManager, FileService fileService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _fileService = fileService;
            //_configService = configService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<string> GetRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }


        //public async Task<List<string>> GetPermissionAsync(User user)
        //{
        //    var roles = await _userManager.GetRolesAsync(user);

        //    var permissions = await _dbContext.Roles.Where(role => roles.Contains(role.Name))
        //    .SelectMany(role => role.RolePermissions)
        //    .Select(rolePermission => rolePermission.Permission.Name).ToListAsync();

        //    return permissions;
        //}

        //public async Task<User> Create(CreateUserRequest request)
        //{
        //    var existingUser = _dbContext.Users.FirstOrDefault(user =>
        //        (user.PhoneNumber == request.Phone && user.PhoneNumberConfirmed && !string.IsNullOrEmpty(request.Phone)) ||
        //        (user.Email == request.Email && user.EmailConfirmed && !string.IsNullOrEmpty(request.Email)));

        //    var userCreationCountConfig = await _configService.GetConfigValue(ConfigConstant.UserCreationCount);
        //    var userCreationCount = int.Parse(userCreationCountConfig);
        //    var username = Prefix.Username + (userCreationCount + 1);

        //    if (existingUser != null)
        //    {
        //        string duplicateField = existingUser.PhoneNumber == request.Phone ? "Số điện thoại" : "Email";
        //        throw new ApiException($"{duplicateField} đã tồn tại trong hệ thống!", HttpStatusCode.BadRequest);
        //    }

        //    if (request.AvatarFile?.Length > 0)
        //    {
        //        request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarFile, PathFolder.User);
        //    }

        //    var newUser = new User()
        //    {
        //        UserName = username,
        //        Name = request.Name,
        //        Email = request.Email,
        //        PhoneNumber = request.Phone,
        //        AvatarUrl = string.IsNullOrEmpty(request.AvatarUrl) ? ResourceConstant.DefaultAvatarUrl : request.AvatarUrl,
        //        Status = request.Status,
        //    };

        //    if (string.IsNullOrEmpty(request.Password))
        //    {
        //        var result = await _userManager.CreateAsync(newUser);

        //        if (!result.Succeeded)
        //        {
        //            throw new ApiException($"Không thể tạo người dùng. Lỗi: {string.Join(", ", result.Errors)}", HttpStatusCode.BadRequest);
        //        }
        //    }
        //    else
        //    {
        //        var result = await _userManager.CreateAsync(newUser, request.Password);

        //        if (!result.Succeeded)
        //        {
        //            throw new ApiException($"Không thể tạo người dùng. Lỗi: {string.Join(", ", result.Errors)}", HttpStatusCode.BadRequest);
        //        }
        //    }

        //    await _userManager.AddToRoleAsync(newUser, request.Role);

        //    await _configService.UpdateConfigValue(ConfigConstant.UserCreationCount, (userCreationCount + 1).ToString());

        //    return newUser;
        //}

        public async Task<UserDto> GetUserInfo(HttpContext httpContext)
        {
            try
            {

                var email = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimType.Email);
                var userName = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimType.UserName);
                if (email != null && userName != null)
                {
                    var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email.Value && x.UserName == userName.Value);

                    if (user == null)
                    {
                        return null;
                    }

                    var role = await GetRoleAsync(user);

                    var userDto = _mapper.Map<UserDto>(user);


                    userDto.Role = role;

                    return userDto;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, (int)Constants.HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<UserDto> GetUserInfoAsync()
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimType.Email);
                var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimType.UserName);

                //var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.UserName == userName);

                //var userDto = _mapper.Map<UserDto>(user);

                //return userDto;

                if (email != null && userName != null)
                {
                    var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email.Value && x.UserName == userName.Value);

                    var userDto = _mapper.Map<UserDto>(user);
                    return userDto;
                }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, (int)Constants.HttpStatusCode.InternalServerError, ex);
            }
        }


        //public async Task<User> GetUserCurrent()
        //{
        //    var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (userId != null)
        //    {
        //        var user = await _userManager.FindByIdAsync(userId);

        //        return user;
        //    }

        //    return null;
        //}

        //public async Task<User?> GetCurrentUserAsync()
        //{
        //    return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //}

        //public async Task<List<User>> Test()
        //{
        //    var test = await _dbContext.Users.ToListAsync();


        //    return test;
        //}

        public async Task<User> EditUserInfo(EditUserInfoRequest request)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var user = await _dbContext.Users.FindAsync(request.Id);

                    if (user == null)
                    {
                        throw new ApiException("Không tìm thấy user có Id hợp lệ!", Constants.HttpStatusCode.BadRequest);
                    }

                    if (request.AvatarFile?.Length > 0)
                    {
                        request.AvatarUrl = await _fileService.UploadFileAsync(request.AvatarFile, PathFolder.User);
                    }

                    user.Name = request.Name;

                    user.PhoneNumber = request.PhoneNumber;

                    if (request.AvatarUrl != null && request.AvatarUrl != "")
                    {
                        user.AvatarUrl = request.AvatarUrl;

                    }

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                    return user;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw new ApiException("Có lỗi xảy ra trong quá trình xử lý!", Constants.HttpStatusCode.InternalServerError, ex);
                }
            }

        }


        //public async Task<string> GenerateAutoUsername()
        //{
        //    //var userCount = await _dbContext.Users.fi;

        //    return $"User{userCount + 1}";
        //}
    }
}
