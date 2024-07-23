
using Test.Quiz.Api.Models.QuestionAnswer;

namespace Test.Quiz.Api.Models.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public int? Number { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Audio { get; set; }

        public string? Paragraph { get; set; }

        public int Score { get; set; }

        public int? SectionId { get; set; }

        public int QuestionCategoryId { get; set; }

        public int Difficulty { get; set; }

        public int TypeForm { get; set; }

        public int TypeKind { get; set; }

        public string QuestionCategoryName { get; set; }

        public Data.Entities.Section Section { get; set; }

        public List<QuestionAnswerDto> QuestionAnswers { get; set; }


    }
}
