using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class PartToeicGroup: EntityBase
    {
        public int Id { get; set; }

        public int PartToeicId { get; set; }

        public int GroupToeicId { get; set; }

        public virtual PartToeic PartToeic { get; set; }

        public virtual GroupToeic GroupToeic { get; set; }
    }
}
