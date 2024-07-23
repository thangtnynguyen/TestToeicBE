
using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.QuestionCategory
{
    public class GetQuestionCategoryTreeRequest : PagingRequest
    {
        public List<int>? ParentQuestionCategories { get; set; }

        public string? Name { get; set; }
    }
}
