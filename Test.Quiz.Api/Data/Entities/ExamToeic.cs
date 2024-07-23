using System.Text.Json.Serialization;
using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamToeic: EntityBase
    {
        public int Id { get; set; }

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

        public virtual List<PartToeic> PartToeics { get; set; }

        [JsonIgnore]
        public virtual List<ExamToeicResult> ExamToeicResults { get; set; }
    }
}
