using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.User;

namespace Test.Quiz.Api.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
