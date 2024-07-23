
namespace Test.Quiz.Api.Models.Comment
{
    public class ApproveMultipleCommentResult<T>
    {
        public List<T>? SuccessfulItems { set; get; }

        public List<T>? FailedItems { set; get; }


    }
}
