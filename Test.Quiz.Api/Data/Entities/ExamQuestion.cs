﻿using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class ExamQuestion : EntityBase
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Question Question { get; set; }
    }
}
