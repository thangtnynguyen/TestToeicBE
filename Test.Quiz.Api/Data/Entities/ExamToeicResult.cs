using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamToeicResult : EntityBase
    {
        public int? Id { get; set; }

        public int? ExamToeicId { get; set; }

        public Guid? UserId { get; set; }

        public int? Score { get; set; }

        public DateTime? StartTime { get; set; }

        public TimeSpan? DurationTime { get; set; }

        public int? NumberCorrectOverallAnswers { get; set; }

        public int? NumberCorrectReadingAnswers { get; set; }

        public int? NumberCorrectListeningAnswers { get; set; }

        public int? NumberChangeTab { get; set; }

        public virtual List<ExamToeicResultDetail> ExamToeicResultDetails { get; set; }

        public virtual ExamToeic ExamToeic { get; set; }


    }
}
