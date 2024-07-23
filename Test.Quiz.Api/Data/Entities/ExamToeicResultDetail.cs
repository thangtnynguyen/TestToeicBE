using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamToeicResultDetail : EntityBase
    {
        public int? Id { get; set; }

        public int? ExamToeicResultId { get; set; }

        public int? QuestionId { get; set; }

        public int? QuestionAnswerId { get; set; }


        public int? QuestionAnswerCorrectId { get; set; }

        //public virtual ExamToeicResult ExamToeicResult { get; set; }




    }
}
