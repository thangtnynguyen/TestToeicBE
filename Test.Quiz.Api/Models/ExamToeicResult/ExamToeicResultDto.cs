using Test.Quiz.Api.Data.Entities;

namespace Test.Quiz.Api.Models.ExamToeicResult
{
    public class ExamToeicResultDto
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

        //điểm chuẩn toeic
        public int? TotalToeicScore { get; set; }

        public int? ReadingToeicScore { get; set; }

        public int? ListeningToeicScore { get; set; }

        //
        public int? NumberChangeTab { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Test.Quiz.Api.Data.Entities.ExamToeic ExamToeic { get; set; }

        public List<Test.Quiz.Api.Data.Entities.ExamToeicResultDetail> ExamToeicResultDetails { get; set; }

    }
}
