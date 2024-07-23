using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Models.Comment;
using Test.Quiz.Api.Models.Exam;

namespace Test.Quiz.Api.Mappers
{
    public class CommentMapper:Profile
    {
        public CommentMapper() {

            CreateMap<Comment, CreateCommentRequest>();
            CreateMap<CreateCommentRequest, Comment>();
            CreateMap<Comment, GetCommentRequest>();
            CreateMap<GetCommentRequest, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
