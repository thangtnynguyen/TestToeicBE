using Newtonsoft.Json;
namespace Test.Quiz.Api.Models.User
{
    public class EditUserInfoRequest
    {
        public Guid Id { get; set; }    

        public string? PhoneNumber { get; set; }

        public string? Name { get; set; }

        public IFormFile? AvatarFile { get; set; }

        [JsonIgnore]
        public string? AvatarUrl { get; set; }
    }
}
