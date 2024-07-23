using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class QuestionCategory : EntityBase, IDefaultAttribute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int? ParentQuestionCategoryId { get; set; }

        public int Priority { get; set; }

        public bool IsDefault { get; set; }

        public virtual List<Question>? Questions { get; set; }

        //public virtual List<QuestionCategory>? QuestionCategories { get; set; }
    }
}
