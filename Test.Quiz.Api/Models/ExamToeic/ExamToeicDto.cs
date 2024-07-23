using Test.Quiz.Api.Models.ExamToeicResult;
using Test.Quiz.Api.Models.PartToeic;

namespace Test.Quiz.Api.Models.ExamToeic
{
    public class ExamToeicDto
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? IsShowContent { get; set; }

        public bool? IsSeeScore { get; set; }

        public bool? IsMixQuestion { get; set; }

        public bool? IsMixQuestionAnswer { get; set; }

        public bool? IsAllowChangeTab { get; set; }

        public bool? Status { get; set; }

        public int? Type { get; set; }

        public virtual List<PartToeicDto> PartToeics { get; set; }

        public virtual List<ExamToeicResultDto> ExamToeicResults { get; set; }
    }
}
