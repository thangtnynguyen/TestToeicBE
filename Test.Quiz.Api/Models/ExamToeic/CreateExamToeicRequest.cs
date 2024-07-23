using Newtonsoft.Json;
using Test.Quiz.Api.Converts;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Part;

namespace Test.Quiz.Api.Models.ExamToeic
{
    public class CreateExamToeicRequest
    {
        public IFormFile? FileExel { get; set; }

        public List<IFormFile>? Files { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
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

        public virtual List<CreatePartToeicRequest>? PartToeics { get; set; }
    }
}
