using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.GroupToeic;
using Test.Quiz.Api.Models.QuestionGroup;

namespace Test.Quiz.Api.Mappers
{
    public class GroupToeicMapper:Profile
    {
        public GroupToeicMapper()
        {
            CreateMap<GroupToeic, CreateGroupToeicRequest>();
            CreateMap<CreateGroupToeicRequest, GroupToeic>();

            CreateMap<GroupToeic, GroupToeicDto>();
            CreateMap<GroupToeicDto, GroupToeic>();
        }
    }
}
