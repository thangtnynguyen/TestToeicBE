using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.Part;
using Test.Quiz.Api.Models.Question;
using Test.Quiz.Api.Models.QuestionGroup;
using Test.Quiz.Api.Services;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/exam")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly ExamService _examService;

        public ExamController(ExamService examService)
        {
            _examService = examService;

        }

        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<Exam>>> Get([FromQuery] GetExamRequest request)
        {
            var result = await _examService.Get(request);

            return new ApiResult<PagingResult<Exam>>()
            {
                Status = true,
                Message = "Lấy thông tin danh sách đề thi thành công!",
                Data = result
            };
        }

        [HttpGet("get-by-id")]
        public async Task<ApiResult<ExamDto>> GetById([FromQuery] int id)
        {
            var result = await _examService.GetById(id);

            return new ApiResult<ExamDto>()
            {
                Status = true,
                Message = "Thông tin bài thi đã được lấy thành công!",
                Data = result
            };
        }








        //[HttpPost("check-overall-answers")]
        //public async Task<ApiResult<CheckQuestionResult>> CheckOverallAnswers(CheckQuestionRequest questionsToCheck)
        //{
        //    var results = await _examService.CheckOverallAnswers(questionsToCheck);

        //    return new ApiResult<CheckQuestionResult>()
        //    {
        //        Status = true,
        //        Message = "Kiểm tra điểm tổng của bài thi thành công",
        //        Data = results
        //    };
        //}

        //[HttpPost("check-reading-answers")]
        //public async Task<ApiResult<CheckQuestionResult>> CheckReadingAnswers(CheckQuestionRequest questionsToCheck)
        //{
        //    var results = await _examService.CheckReadingAnswers(questionsToCheck);

        //    return new ApiResult<CheckQuestionResult>()
        //    {
        //        Status = true,
        //        Message = "Kiểm tra điểm của bài thi đọc thành công",
        //        Data = results
        //    };
        //}

        //[HttpPost("check-listening-answers")]
        //public async Task<ApiResult<CheckQuestionResult>> CheckListeningAnswers(CheckQuestionRequest questionsToCheck)
        //{
        //    var results = await _examService.CheckListeningAnswers(questionsToCheck);

        //    return new ApiResult<CheckQuestionResult>()
        //    {
        //        Status = true,
        //        Message = "Kiểm tra  tổng của bài thi nghe thành công",
        //        Data = results
        //    };
        //}




        //[HttpPost("excel-import-questiongroup")]
        //public async Task<ApiResult<List<CreateGroupToeicRequest>>> ImportQuestionGroupsAsync([FromForm] ImportGroupQuestion file)
        //{
        //    var results = await _examService.ImportQuestionGroupsAsync(file.File);

        //    return new ApiResult<List<CreateGroupToeicRequest>>()
        //    {
        //        Status = true,
        //        Message = "Import thành công  thành công",
        //        Data = results
        //    };
        //}


        //[HttpPost("excel-import-part")]
        //public async Task<ApiResult<List<CreatePartToeicRequest>>> ImportPartAsync([FromForm] ImportGroupQuestion file)
        //{
        //    var results = await _examService.ImportPartsAsync(file.File);

        //    return new ApiResult<List<CreatePartToeicRequest>>()
        //    {
        //        Status = true,
        //        Message = "Import thành công  thành công",
        //        Data = results
        //    };
        //}
    }
}
