using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.QuestionAnswer;

namespace Test.Quiz.Api.Mappers
{
    public class QuestionAnswerMapper : Profile
    {
        public QuestionAnswerMapper()
        {
            CreateMap<QuestionAnswerDto, QuestionAnswer>();

            CreateMap<QuestionAnswer, QuestionAnswerDto>();
        }
    }
}
