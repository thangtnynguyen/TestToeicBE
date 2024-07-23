namespace Test.Quiz.Api.Models.Question
{
    public class CheckQuestionRequest
    {
        //public int QuestionId { get; set; }
        //public int QuestionAnswerId { get; set; }

        public int ExamId { get; set; }

        public List<CheckQuestion> checkQuestions { get; set; }
    }

    public class CheckQuestion
    {
        public int QuestionId { get; set; }
        public int QuestionAnswerId { get; set; }
    }
}
