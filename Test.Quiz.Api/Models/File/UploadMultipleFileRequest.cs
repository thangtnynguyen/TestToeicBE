namespace Test.Quiz.Api.Models.File
{
    public class UploadMultipleFileRequest
    {
        public string? AdditionalString {  get; set; }
        public List<IFormFile>? Files { get; set; }
    }
}
