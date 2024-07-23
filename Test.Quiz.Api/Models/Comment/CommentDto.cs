namespace Test.Quiz.Api.Models.Comment
{
    public class CommentDto
    {
        public int? Id { get; set; }

        public string? Content { get; set; }

        public int? CommentsCount { get; set; }

        public Guid? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ExamId { get; set; }

        public int? ParentCommentId { get; set; }

        public List<CommentDto>? Children { get; set; }


        public Test.Quiz.Api.Models.User.UserDto User { get; set; }



    }
}
