using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.Exam
{
    public class GetExamRequest: PagingRequest
    {
        public string? Title { get; set; }
    }
}
