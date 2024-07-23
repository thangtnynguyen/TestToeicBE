using Test.Quiz.Api.Data.Entities.Interface;
using Test.Quiz.Api.Models.Question;

namespace Test.Quiz.Api.Data.Entities
{
    public class GroupToeicQuestion: EntityBase
    {
        public int Id { get; set; }

        public int GroupToeicId { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual GroupToeic GroupToeic { get; set; }

    }
}
