namespace Test.Quiz.Api.Models.Question
{
    public class CheckOneAnswerRequest
    {

        public int? QuestionId { get; set; }

        public int? AnswerId { get; set; }
    }
}
