using System.Text.Json.Serialization;

namespace Test.Quiz.Api.Models.Comment
{
    public class CreateCommentRequest
    {

        public string? Content { get; set; }

        public Guid? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ExamId { get; set; }

        public int? ParentCommentId { get; set; }



    }
}
