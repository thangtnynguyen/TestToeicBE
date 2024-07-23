using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.Part;
using Test.Quiz.Api.Models.PartToeic;

namespace Test.Quiz.Api.Mappers
{
    public class PartToeicMapper:Profile
    {
        public PartToeicMapper()
        {
            CreateMap<PartToeic, CreatePartToeicRequest>();
            CreateMap<CreatePartToeicRequest, PartToeic>()
            .ForMember(dest => dest.GroupToeics, opt => opt.Ignore());

            CreateMap<PartToeic, PartToeicDto>();
            CreateMap<PartToeicDto, PartToeic>();
        }
    }
}
