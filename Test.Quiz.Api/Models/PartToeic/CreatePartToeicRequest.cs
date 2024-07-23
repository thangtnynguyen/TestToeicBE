using Test.Quiz.Api.Models.QuestionGroup;

namespace Test.Quiz.Api.Models.Part
{
    public class CreatePartToeicRequest
    {
        public int Id { get; set; }

        public int ExamToeicId { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public List<CreateGroupToeicRequest> GroupToeics { get; set; }
    }
}
