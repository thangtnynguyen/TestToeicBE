using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.User;
using Test.Quiz.Api.Services;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Test.Quiz.Api.Data.Entities.User> _userManager;
        private readonly UserService _userService;

        public UserController(UserManager<Test.Quiz.Api.Data.Entities.User> userManager, UserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }


        [HttpGet]
        [Route("user-info")]
        public async Task<ApiResult<UserDto>> GetUserInfo()
        {
            var user = await _userService.GetUserInfo(HttpContext);

            if (user == null)
            {
                return new ApiResult<UserDto>()
                {
                    Status = false,
                    Message = "Không tìm thấy thông tin người dùng hợp lệ!",
                    Data = null
                };
            }

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Lấy thông tin người dùng thành công!",
                Data = user
            };
        }

        [HttpGet]
        [Route("user-info-async")]
        public async Task<ApiResult<UserDto>> GetUserInfoAsync()
        {
            var user = await _userService.GetUserInfoAsync();

            if (user == null)
            {
                return new ApiResult<UserDto>()
                {
                    Status = false,
                    Message = "Không tìm thấy thông tin người dùng hợp lệ!",
                    Data = null
                };
            }

            return new ApiResult<UserDto>()
            {
                Status = true,
                Message = "Lấy thông tin người dùng thành công!",
                Data = user
            };
        }


        [HttpPost("edit-user-info")]
        public async Task<ApiResult<User>> EditUserInfo([FromForm] EditUserInfoRequest request)
        {
            var result = await _userService.EditUserInfo(request);

            return new ApiResult<User>()
            {
                Status = true,
                Message = "Cập nhật thông tin người dùng thành công!",
                Data = result
            };
        }


        //[HttpGet]
        //[Route("user-current-async")]
        //public async Task<ApiResult<Test.Quiz.Api.Data.Entities.User>> GetCurrentUserAsync()
        //{
        //    var user = await _userService.GetCurrentUserAsync();

        //    if (user == null)
        //    {
        //        return new ApiResult<Test.Quiz.Api.Data.Entities.User>()
        //        {
        //            Status = false,
        //            Message = "Không tìm thấy thông tin người dùng hợp lệ!",
        //            Data = null
        //        };
        //    }

        //    return new ApiResult<Test.Quiz.Api.Data.Entities.User>()
        //    {
        //        Status = true,
        //        Message = "Lấy thông tin người dùng thành công!",
        //        Data = user
        //    };
        //}
    }
}
