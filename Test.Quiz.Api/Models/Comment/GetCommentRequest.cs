using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.Comment
{
    public class GetCommentRequest: PagingRequest
    {
        public int? ExamId { get; set; }
    }
}
