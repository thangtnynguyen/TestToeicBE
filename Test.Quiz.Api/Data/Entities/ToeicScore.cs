using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ToeicScore: EntityBase
    {
        public int? Id { get; set; }

        public int? NumberOfCorrect { get; set; }

        public int? Score { get; set; }

        public int? Type { get; set; }


    }
}
