using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class Comment : EntityBase
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? CommentsCount { get; set; }

        public Guid? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ExamId { get; set; }

        public int? ParentCommentId { get; set; }

        public virtual User? User { get; set;}

    }
}
