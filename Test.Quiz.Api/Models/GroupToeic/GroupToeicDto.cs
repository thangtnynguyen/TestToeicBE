using Test.Quiz.Api.Models.Question;

namespace Test.Quiz.Api.Models.GroupToeic
{
    public class GroupToeicDto
    {
        public int Id { get; set; }

        public int PartToeicId { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Paragraph { get; set; }

        public string? Audio { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}
