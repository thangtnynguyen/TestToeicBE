using Test.Quiz.Api.Models.GroupToeic;
using Test.Quiz.Api.Models.QuestionGroup;

namespace Test.Quiz.Api.Models.PartToeic
{
    public class PartToeicDto
    {
        public int Id { get; set; }

        public int ExamToeicId { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public List<GroupToeicDto> GroupToeics { get; set; }
    }
}
