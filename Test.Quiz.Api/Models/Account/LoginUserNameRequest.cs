namespace Test.Quiz.Api.Models.Account
{
    public class LoginUserNameRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public int Type { get; set; }

    }
}
