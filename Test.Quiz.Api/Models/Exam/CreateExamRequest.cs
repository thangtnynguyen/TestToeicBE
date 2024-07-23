using Microsoft.AspNetCore.Mvc;
using Test.Quiz.Api.Models.Question;

namespace Test.Quiz.Api.Models.Exam
{
    public class CreateExamRequest
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Duration { get; set; }

        public List<ExamQuestionRequest>? Questions { get; set; }
    }
}
