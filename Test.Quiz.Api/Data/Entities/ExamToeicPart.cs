using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamToeicPart: EntityBase
    {
        public int Id { get; set; }
        public int ExamToeicId { get; set; }
        public int PartToeicId { get; set; }

        public virtual ExamToeic ExamToeic { get; set; }

        public virtual PartToeic PartToeic { get; set; }
    }
}
