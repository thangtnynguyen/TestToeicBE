using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.File;
using Test.Quiz.Api.Services;

namespace Test.Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
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

        [HttpPost("upload-file")]
        public async Task<ApiResult<string>> UploadFile([FromForm] UploadFileRequest request)
        {
            var results = await _fileService.UploadFileAsync(request.File, PathFolder.ExamToeic);

            return new ApiResult<string>()
            {
                Status = true,
                Message = "Upload file thành công ",
                Data = results
            };
        }
    }
}
