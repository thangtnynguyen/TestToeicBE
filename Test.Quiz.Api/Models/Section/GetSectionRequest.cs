using Test.Quiz.Api.Models.Common;

namespace Test.Quiz.Api.Models.Section
{
    public class GetSectionRequest : PagingRequest
    {
        public string? Title { get; set; }
    }
}
