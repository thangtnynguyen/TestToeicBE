namespace Test.Quiz.Api.Models.Question
{
    public class ImportQuestionsRequest
    {

        public IFormFile File { get; set; }

        public List<IFormFile>? Files { get; set; }

    }
}
