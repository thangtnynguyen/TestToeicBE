namespace Test.Quiz.Api.Models.Common
{
    public class ListEntityIdentityRequest<T>
    {
        public List<T?>? Ids { get; set; }
    }
}
