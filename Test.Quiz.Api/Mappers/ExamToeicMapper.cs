using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.ExamToeic;

namespace Test.Quiz.Api.Mappers
{
    public class ExamToeicMapper:Profile
    {
        public ExamToeicMapper()
        {
            CreateMap<ExamToeic, CreateExamToeicRequest>();
            CreateMap<CreateExamToeicRequest, ExamToeic>();
            CreateMap<ExamToeic, ExamToeicDto>();
            CreateMap<ExamToeicDto, ExamToeic>();
            CreateMap<ExamToeic, GetExamToeicRequest>();
            CreateMap<GetExamToeicRequest, ExamToeic>();

        }
    }
}
