using Test.Quiz.Api.Models.QuestionAnswer;

namespace Test.Quiz.Api.Models.Question
{
    public class EditQuestionRequest
    {


        public int Id { get ; set; }

        public string? Image { get; set; }

        public string? Audio { get; set; }

        public string? Title { get; set; }

        public string? Paragraph { get; set; }

        public int Score { get; set; }

        public int QuestionCategoryId { get; set; }

        public int Difficulty { get; set; }

        public List<QuestionAnswerDto>? QuestionAnswers { get; set; }

        public int? TypeForm { get; set; }

        public int? TypeKind { get; set; }

        public int? SectionId { get; set; }
    }
}
