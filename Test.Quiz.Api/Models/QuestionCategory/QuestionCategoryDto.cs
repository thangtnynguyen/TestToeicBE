﻿

namespace Test.Quiz.Api.Models.QuestionCategory
{
    public class QuestionCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int? ParentQuestionCategoryId { get; set; }

        public int Priority { get; set; }

        public bool IsDefault { get; set; }

        public List<QuestionCategoryDto>? QuestionCategories { get; set; }
    }
}
