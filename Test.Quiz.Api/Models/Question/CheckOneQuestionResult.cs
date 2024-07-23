namespace Test.Quiz.Api.Models.Question
{
    public class CheckOneQuestionResult
    {
        public bool? Status { get; set; }

        public int? QuestionId { get; set; }

        public int? AnswerId { get; set; }
        
        public int? AnswerCorrectId { get; set; }
    }
    
}
