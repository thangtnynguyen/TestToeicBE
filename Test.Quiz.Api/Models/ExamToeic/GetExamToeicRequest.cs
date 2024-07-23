using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.ExamToeic
{
    public class GetExamToeicRequest: PagingRequest
    {
        public string? Title { get; set; }
    }
}
