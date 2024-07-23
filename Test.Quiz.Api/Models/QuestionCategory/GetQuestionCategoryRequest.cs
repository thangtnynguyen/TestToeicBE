
using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.QuestionCategory
{
    public class GetQuestionCategoryRequest : PagingRequest
    {
        public string? Name { get; set; }
    }
}
