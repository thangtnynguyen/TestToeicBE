using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class PartToeic: EntityBase
    {
        public int Id { get; set; }

        public int ExamToeicId { get; set; }

        public string? Name { get; set; }

        public int? Type { get; set; }


        public virtual ExamToeic ExamToeics { get; set; }

        public virtual List<GroupToeic> GroupToeics { get; set; }



    }
}
