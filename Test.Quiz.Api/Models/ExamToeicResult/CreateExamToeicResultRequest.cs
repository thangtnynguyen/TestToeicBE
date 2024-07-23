namespace Test.Quiz.Api.Models.ExamToeicResult
{
    public class CreateExamToeicResultRequest
    {
        public int? ExamToeicId { get; set; }

        public Guid? UserId { get; set; }

        public int? Score { get; set; }

        public DateTime? StartTime { get; set; }

        public TimeSpan? DurationTime { get; set; }

        public int? NumberCorrectOverallAnswers { get; set; }

        public int? NumberCorrectReadingAnswers { get; set; }

        public int? NumberCorrectListeningAnswers { get; set; }

        public int? NumberChangeTab { get; set; }

    }
}
