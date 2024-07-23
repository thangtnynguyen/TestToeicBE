namespace Test.Quiz.Api.Models.Question
{
    public class CheckQuestionResult
    {
        
        public List<CheckQuestions> CheckQuestions {  get; set; }

        public int TotalCountReadingFalse { get; set; }

        public int TotalCountReadingTrue { get; set; }

        public int TotalCountListeningFalse { get; set; }

        public int TotalCountListeningTrue { get; set; }

        public int TotalCountFalse { get; set; }

        public int TotalCountTrue { get; set;}

        public int TotalScore { get; set; }





    }

    public class CheckQuestions
    {
        public int QuestionId { get; set; }
        public int QuestionAnswerId { get; set; }

        public int QuestionAnswerCorrectId { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionAnswerContent { get; set; }

        public string QuestionAnswerCorrectContent { get; set; }
    }

}
