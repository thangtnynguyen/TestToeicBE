using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.Question
{
    public class GetQuestionRequest : PagingRequest
    {

        public string? Title { get; set; }

        public int? QuestionCategoryId { get; set; }

        public int? TypeForm { get; set; }

        public int? TypeKind { get; set; }

        public int? Difficulty { get; set; }

        public int? SectionId { get; set; }
    }
}
