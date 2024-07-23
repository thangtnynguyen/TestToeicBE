using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Comment;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Services;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<CommentDto>>> Get([FromQuery] GetCommentRequest request)
        {
            var result = await _commentService.Get(request);

            return new ApiResult<PagingResult<CommentDto>>()
            {
                Status = true,
                Message = "Lấy thông tin comment trò thành công!",
                Data = result
            };
        }


        [HttpPost("create")]
        public async Task<ApiResult<Comment>> Create([FromBody] CreateCommentRequest request)
        {
            var result = await _commentService.Create(request);

            return new ApiResult<Comment>()
            {
                Status = true,
                Message = "Thêm comment thành công!",
                Data = result
            };
        }

        [HttpPost("delete")]
        public async Task<ApiResult<Comment>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            var result = await _commentService.Delete(request.Id);

            return new ApiResult<Comment>()
            {
                Status = true,
                Message = "Đã xóa comment!",
                Data = result
            };
        }
    }
}
