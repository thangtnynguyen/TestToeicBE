using Microsoft.AspNetCore.Identity;

namespace Test.Quiz.Api.Models.User
{
    public class UserDto : IdentityUser<Guid>
    {
        public string? Name { get; set; }

        public string? AvatarUrl { get; set; }

        //public List<string> Permissions { get; set; }
        public string Role { get; set; }
    }
}
