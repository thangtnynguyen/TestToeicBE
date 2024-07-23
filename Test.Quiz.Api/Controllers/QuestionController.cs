using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Question;
using Test.Quiz.Api.Services;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/question")]

    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly QuestionService _questionService;
        private readonly FileService _fileService;

        public QuestionController(QuestionService questionService, FileService fileService)
        {
            _questionService = questionService;
            _fileService = fileService; 
        }



        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<QuestionDto>>> Get([FromQuery] GetQuestionRequest request)
        {
            var result = await _questionService.Get(request);

            return new ApiResult<PagingResult<QuestionDto>>()
            {
                Status = true,
                Message = "Lấy thông tin danh sách câu hỏi thành công!",
                Data = result
            };
        }

        [HttpGet("get-by-id")]
        public async Task<ApiResult<QuestionDto>> GetById([FromQuery] int id)
        {
            var result = await _questionService.GetById(id);

            return new ApiResult<QuestionDto>()
            {
                Status = true,
                Message = "Lấy thông tin câu hỏi  thành công!",
                Data = result
            };
        }

        [HttpGet("get-radom")]
        public async Task<ApiResult<QuestionDto>> GetRadom()
        {
            var result = await _questionService.GetRandomQuestion();

            return new ApiResult<QuestionDto>()
            {
                Status = true,
                Message = "Lấy thông tin câu hỏi  thành công!",
                Data = result
            };
        }

        [HttpPost("create")]
        public async Task<ApiResult<bool>> Create([FromForm] CreateQuestionRequest request)
        {

            var result = await _questionService.Create(request);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Tạo mới câu hỏi thành công!",
                Data = true
            };
        }

        [HttpPost("edit")]
        public async Task<ApiResult<bool>> Edit([FromBody] EditQuestionRequest request)
        {
            var result = await _questionService.Edit(request);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Cập nhật mới câu hỏi thành công!",
                Data = true
            };
        }

        [HttpPost("delete")]
        public async Task<ApiResult<QuestionDto>> Delete([FromBody] DeleteQuestionRequest request)
        {
            var result = await _questionService.Delete(request.Id);

            return new ApiResult<QuestionDto>()
            {
                Status = true,
                Message = "Xoá câu hỏi thành công!",
                Data = result
            };
        }

        [HttpPost("delete-multiple")]
        public async Task<ApiResult<bool>> DeleteMultiple([FromBody] ListEntityIdentityRequest<int?> request)
        {
            var result = await _questionService.DeleteMultiple(request.Ids);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Đã xóa các question",
                Data = true
            };
        }

        [HttpPost("import-questions-excel")]
        public async Task<ApiResult<bool>> ImportQuestionsExcel([FromForm] ImportQuestionsRequest request)
        {
            await _questionService.ImportQuestionsExcel(request);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Import file thành công!",
                Data = true
            };
        }

        [HttpPost("check-one-answer")]
        public async Task<ApiResult<CheckOneQuestionResult>> CheckOneAnswers([FromBody] CheckOneAnswerRequest request)
        {
            var result =await _questionService.CheckOneAnswers(request);

            return new ApiResult<CheckOneQuestionResult>()
            {
                Status = true,
                Message = "Kiểm tra thành công!",
                Data = result
            };
        }



    }
}
