using Test.Quiz.Api.Constants;

namespace Test.Quiz.Api.Exceptions
{
    public class ApiException : Exception
    {
        public int Status { get; }
        public object Data { get; }

        public ApiException(string message, int status = HttpStatusCode.BadRequest, object data = null) : base(message)
        {
            Status = status;
            Data = data;
        }
    }
}