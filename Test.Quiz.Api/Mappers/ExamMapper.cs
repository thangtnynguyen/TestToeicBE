using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Exam;

namespace Test.Quiz.Api.Mappers
{
    public class ExamMapper : Profile
    {
        public ExamMapper()
        {
            CreateMap<Exam, CreateExamRequest>();
            CreateMap<CreateExamRequest, Exam>();
            CreateMap<Exam, GetExamRequest>();
            CreateMap<GetExamRequest, Exam>();
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();


        }
    }
}
