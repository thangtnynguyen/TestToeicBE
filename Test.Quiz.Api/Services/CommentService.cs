using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Exceptions;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Comment;
using Test.Quiz.Api.Data.Entities;

namespace Test.Quiz.Api.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public CommentService(ApplicationDbContext dbContext, IMapper mapper, UserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
        }

        //public async Task<List<Comment> 

        public async Task<PagingResult<CommentDto>> Get(GetCommentRequest request)
        {
            try
            {
                var query = _dbContext.Comments.Where(x => x.DeletedAt == null).AsQueryable();

                if (request.ExamId!=null)
                {
                    query = query.Where(b => b.ExamId==request.ExamId);
                }
             
                int total = await query.CountAsync();

                if (request.PageIndex == null) request.PageIndex = 1;
                if (request.PageSize == null) request.PageSize = total;

                int totalPages = (int)Math.Ceiling((double)total / request.PageSize.Value);

                var comments = await query
                    .Include(c => c.User)  // user
                    .OrderByDescending(b => b.Id)
                    .Skip((request.PageIndex.Value - 1) * request.PageSize.Value)
                    .Take(request.PageSize.Value)
                    .ToListAsync();

                var commentParrents = comments.Where(c => c.ParentCommentId == null);

                var commentDtos = _mapper.Map<List<CommentDto>>(commentParrents);

                foreach (var commentDto in commentDtos)
                {
                    commentDto.Children = await this.GetRecursive(commentDto.Id,comments);
                }

                var result = new PagingResult<CommentDto>(commentDtos, request.PageIndex.Value, request.PageSize.Value, total, totalPages);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }

        private async Task<List<CommentDto>> GetRecursive(int? parentCommentId, IEnumerable<Data.Entities.Comment> allComments)
        {
            var children = allComments
                .Where(p => p.ParentCommentId == parentCommentId)
                .ToList();

            var childDtos = new List<CommentDto>();

            foreach (var childComment in children)
            {
                var childDto = _mapper.Map<CommentDto>(childComment);
                childDto.Children = await GetRecursive(childComment.Id, allComments);
                childDtos.Add(childDto);
            }

            return childDtos;
        }



        public async Task<Comment> Create(CreateCommentRequest request)
        {
            try
            {
                var comment = _mapper.Map<Comment>(request);

                var userCurrent = await _userService.GetUserInfoAsync();
                comment.CreatedAt = DateTime.Now;
                comment.CreatedBy = userCurrent?.Id;
                comment.UserId=userCurrent?.Id;
                comment.UserName = userCurrent?.Name;


                await _dbContext.Comments.AddAsync(comment);
                await _dbContext.SaveChangesAsync();

                
                return comment;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<Comment> Delete(int id)
        {
            try
            {
                var comment = await _dbContext.Comments.FindAsync(id);

                if (comment == null)
                {
                    throw new ApiException("Không tìm quyền hợp lệ!", Constants.HttpStatusCode.InternalServerError);
                }

                var userCurrent = await _userService.GetUserInfoAsync();
                comment.DeletedAt = DateTime.Now;
                comment.CreatedBy = userCurrent?.Id;

                await _dbContext.SaveChangesAsync();

                return comment;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}
