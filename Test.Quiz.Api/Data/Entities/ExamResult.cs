using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamResult : EntityBase
    {
        public int? Id { get; set; }

        public int? ExamId { get; set; }

        public Guid? UserId { get; set; }

        public int? Score { get; set; }

        public DateTime? StartTime { get; set; }

        public TimeSpan? DurationTime { get; set; }

        public int? NumberCorrectAnswers { get; set; }

        public int? NumberChangeTab { get; set; }
    }
}
