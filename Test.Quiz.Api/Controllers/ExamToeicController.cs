using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.ExamToeic;
using Test.Quiz.Api.Models.ExamToeicResult;
using Test.Quiz.Api.Models.File;
using Test.Quiz.Api.Models.Part;
using Test.Quiz.Api.Models.Question;
using Test.Quiz.Api.Services;
using UTEHY.DatabaseCoursePortal.Api.Models.Exam;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/exam-toeic")]
    [ApiController]
    public class ExamToeicController : ControllerBase
    {


        private readonly ExamToeicService _examToeicService;
        private readonly FileService _fileService;

        public ExamToeicController(ExamToeicService examToeicService, FileService fileService)
        {
            _examToeicService = examToeicService;
            _fileService = fileService;
        }

        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<ExamToeic>>> Get([FromQuery] GetExamToeicRequest request)
        {
            var result = await _examToeicService.Get(request);

            return new ApiResult<PagingResult<ExamToeic>>()
            {
                Status = true,
                Message = "Lấy thông tin danh sách đề thi toeic  thành công!",
                Data = result
            };
        }

        [HttpGet("get-by-id")]
        public async Task<ApiResult<ExamToeicDto>> GetById([FromQuery] GetExamToeicIdRequest request)
        {
            var result = await _examToeicService.GetById(request);

            return new ApiResult<ExamToeicDto>()
            {
                Status = true,
                Message = "Thông tin bài thi toeic đã được lấy thành công!",
                Data = result
            };
        }

        [HttpGet("get-by-id-async")]
        public async Task<ApiResult<ExamToeicDto>> GetByIdAsync([FromQuery] int id)
        {
            var result = await _examToeicService.GetByIdAsync(id);

            return new ApiResult<ExamToeicDto>()
            {
                Status = true,
                Message = "Thông tin bài thi toeic đã được lấy thành công!",
                Data = result
            };
        }

        [HttpPost("create")]
        public async Task<ApiResult<bool>> Create([FromForm] CreateExamToeicRequest request)
        {
            var result = await _examToeicService.Create(request);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Tạo mới đề thi  thành công!",
                Data = result
            };
        }



        [HttpPost("check-overall-answers")]
        public async Task<ApiResult<CheckQuestionResult>> CheckOverallAnswers(CheckQuestionRequest questionsToCheck)
        {
            var results = await _examToeicService.CheckOverallAnswers(questionsToCheck);

            return new ApiResult<CheckQuestionResult>()
            {
                Status = true,
                Message = "Kiểm tra điểm tổng của bài thi thành công",
                Data = results
            };
        }

        [HttpPost("check-reading-answers")]
        public async Task<ApiResult<CheckQuestionResult>> CheckReadingAnswers(CheckQuestionRequest questionsToCheck)
        {
            var results = await _examToeicService.CheckReadingAnswers(questionsToCheck);

            return new ApiResult<CheckQuestionResult>()
            {
                Status = true,
                Message = "Kiểm tra điểm của bài thi đọc thành công",
                Data = results
            };
        }

        [HttpPost("check-listening-answers")]
        public async Task<ApiResult<CheckQuestionResult>> CheckListeningAnswers(CheckQuestionRequest questionsToCheck)
        {
            var results = await _examToeicService.CheckListeningAnswers(questionsToCheck);

            return new ApiResult<CheckQuestionResult>()
            {
                Status = true,
                Message = "Kiểm tra  tổng của bài thi nghe thành công",
                Data = results
            };
        }

        [HttpPost("add-exam-toeic-result")]
        public async Task<ApiResult<ExamToeicResult>> CreateExamToeicResult([FromBody] CreateExamToeicResultRequest request)
        {
            var result = await _examToeicService.CreateExamToeicResult(request);

            return new ApiResult<ExamToeicResult>()
            {
                Status = true,
                Message = "Nộp bài thành công",
                Data = result
            };
        }

        [HttpPost("add-exam-toeic-result-detail")]
        public async Task<ApiResult<bool>> CreateExamToeicResultDetail([FromBody] CheckQuestionRequest request)
        {
            var result = await _examToeicService.CreateExamToeicResultDetail(request);

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Nộp bài thành công",
                Data = result
            };
        }


        [HttpPost("upload-multiple-file")]
        public async Task<ApiResult<List<string>>> UploadMultipleFile([FromForm] UploadMultipleFileRequest request)
        {
            var results = await _fileService.UploadMultipleFilesAsync(request, PathFolder.ExamToeic);

            return new ApiResult<List<string>>()
            {
                Status = true,
                Message = "Upload tất cả các file thành công ",
                Data = results
            };
        }



        [HttpPost("excel-import-part")]
        public async Task<ApiResult<List<CreatePartToeicRequest>>> ImportPartAsync([FromForm] ImportGroupQuestion file)
        {
            var results = await _examToeicService.ImportPartsAsync(file.File,"upload");

            return new ApiResult<List<CreatePartToeicRequest>>()
            {
                Status = true,
                Message = "Import thành công  thành công",
                Data = results
            };
        }

        //result
        [HttpGet("get-exam-toeic-result-by-user-id")]
        public async Task<ApiResult<List<ExamToeicResultDto>>> GetExamToeicResult([FromQuery] GetExamToeicByUser request)
        {
            var result = await _examToeicService.GetExamToeicResult(request.UserId);

            return new ApiResult<List<ExamToeicResultDto>>()
            {
                Status = true,
                Message = "Thành công",
                Data = result
            };
        }

        [HttpGet("get-exam-toeic-result-by-id")]
        public async Task<ApiResult<ExamToeicResultDto>> GetExamToeicResultById([FromQuery] DeleteRequest request)
        {
            var result = await _examToeicService.GetExamToeicResultById(request.Id);

            return new ApiResult<ExamToeicResultDto>()
            {
                Status = true,
                Message = "Thành công",
                Data = result
            };
        }

    }
}
