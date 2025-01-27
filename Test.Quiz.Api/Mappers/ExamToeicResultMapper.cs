﻿using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.ExamToeicResult;


namespace Test.Quiz.Api.Mappers
{
    public class ExamToeicResultMapper:Profile
    {
        public ExamToeicResultMapper()
        {
            CreateMap<ExamToeicResult, CreateExamToeicResultRequest>();
            CreateMap<CreateExamToeicResultRequest, ExamToeicResult>();

            CreateMap<ExamToeicResult, ExamToeicResultDto>();
            CreateMap<ExamToeicResultDto, ExamToeicResult>();

        }
    }
}
