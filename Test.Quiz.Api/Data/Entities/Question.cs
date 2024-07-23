using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class Question : EntityBase
    {

        public int Id { get; set; }

        public int? Number { get; set; }

        public string? Image { get; set; }

        public string? Audio { get; set; }

        public string? Title { get; set; }

        public string? Paragraph { get; set; }

        public int Score { get; set; }

        public int QuestionCategoryId { get; set; }

        public int Difficulty { get; set; }

        //dạng câu hỏi như : nghe, đọc, viết
        public int TypeForm { get; set; }

        //dạng câu hỏi như : có 2 loại là câu hỏi của đề toeic và câu hỏi của đề quiz/2/1
        public int TypeKind { get; set; }

        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }

        public virtual QuestionCategory QuestionCategory { get; set; }

        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }

        public virtual List<ExamQuestion> ExamQuestions { get; set; }

        public virtual List<GroupToeicQuestion> GroupToeicQuestions { get; set; }


    }
}
