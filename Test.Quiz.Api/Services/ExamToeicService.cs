using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Enums;
using Test.Quiz.Api.Exceptions;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Exam;
using Test.Quiz.Api.Models.ExamToeic;
using Test.Quiz.Api.Models.ExamToeicResult;
using Test.Quiz.Api.Models.File;
using Test.Quiz.Api.Models.GroupToeic;
using Test.Quiz.Api.Models.Part;
using Test.Quiz.Api.Models.PartToeic;
using Test.Quiz.Api.Models.Question;
using Test.Quiz.Api.Models.QuestionAnswer;
using Test.Quiz.Api.Models.QuestionGroup;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Quiz.Api.Services
{
    public class ExamToeicService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly QuestionService _questionService;

        public ExamToeicService(ApplicationDbContext dbContext, FileService fileService, IMapper mapper, UserService userService, QuestionService questionService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _mapper = mapper;
            _userService = userService;
            _questionService = questionService;
        }

        public async Task<PagingResult<ExamToeic>> Get(GetExamToeicRequest request)
        {
            try
            {
                var query = _dbContext.ExamToeics.Where(x => x.DeletedAt == null)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(request.Title))
                {
                    query = query.Where(b => b.Title.ToLower().Contains(request.Title.ToLower()));
                }

                int total = await query.CountAsync();

                if (request.PageIndex == null) request.PageIndex = 1;
                if (request.PageSize == null) request.PageSize = total;

                int totalPages = (int)Math.Ceiling((double)total / request.PageSize.Value);

                if (string.IsNullOrEmpty(request.OrderBy) && string.IsNullOrEmpty(request.SortBy))
                {
                    query = query.OrderByDescending(b => b.Id);
                }
                else if (string.IsNullOrEmpty(request.OrderBy))
                {
                    if (request.SortBy == SortByConstant.Asc)
                    {
                        query = query.OrderBy(b => b.Id);
                    }
                    else
                    {
                        query = query.OrderByDescending(b => b.Id);
                    }
                }
                else if (string.IsNullOrEmpty(request.SortBy))
                {
                    query = query.OrderByDescending(b => b.Id);
                }
                else
                {
                    if (request.OrderBy == OrderByConstant.Id && request.SortBy == SortByConstant.Asc)
                    {
                        query = query.OrderBy(b => b.Id);
                    }
                    else if (request.OrderBy == OrderByConstant.Id && request.SortBy == SortByConstant.Desc)
                    {
                        query = query.OrderByDescending(b => b.Id);
                    }
                }

                var items = await query
                .Skip((request.PageIndex.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value)
                .ToListAsync();

                var result = new PagingResult<ExamToeic>(items, request.PageIndex.Value, request.PageSize.Value, request.SortBy, request.OrderBy, total, totalPages);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<ExamToeicDto> GetById(GetExamToeicIdRequest request)
        {
            try
            {
                var exam = await _dbContext.ExamToeics
                    .AsNoTracking()
                    .Where(e => e.DeletedAt == null && e.Id == request.ExamToeicId)
                    .FirstOrDefaultAsync();

                if (exam == null)
                {
                    return null;
                }

                var examDto = _mapper.Map<ExamToeicDto>(exam);

                var partToeics = await GetPartToeicsByExamToeicIdAsync(exam.Id, request.PartToeicType);
                examDto.PartToeics = _mapper.Map<List<PartToeicDto>>(partToeics);

                if (examDto.PartToeics != null)
                {
                    foreach (var partToeicDto in examDto.PartToeics)
                    {
                        var groupToeics = await GetGroupToeicsByPartToeicIdAsync(partToeicDto.Id);
                        partToeicDto.GroupToeics = _mapper.Map<List<GroupToeicDto>>(groupToeics);

                        foreach (var groupToeicDto in partToeicDto.GroupToeics)
                        {
                            var questions = await GetQuestionsByGroupToeicIdAsync(groupToeicDto.Id);
                            groupToeicDto.Questions = _mapper.Map<List<QuestionDto>>(questions);
                        }
                    }
                }

                return examDto;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }



        //public async Task<ExamToeicDto> GetById(GetExamToeicIdRequest request)
        //{
        //    try
        //    {
        //        //var exam = await _dbContext.ExamToeics
        //        //.Include(e => e.PartToeics)
        //        //.ThenInclude(p => p.GroupToeics)
        //        //    .ThenInclude(gq => gq.GroupToeicQuestions)
        //        //        .ThenInclude(q => q.Question)
        //        //            .ThenInclude(q => q.QuestionAnswers)
        //        //.FirstOrDefaultAsync(e => e.DeletedAt == null && e.Id == request.ExamToeicId);




        //        var examQuery = _dbContext.ExamToeics.AsNoTracking()
        //        .Include(e => e.PartToeics.Where(pt => request.PartToeicType == null || pt.Type == request.PartToeicType))
        //        .ThenInclude(pt => pt.GroupToeics)
        //            .ThenInclude(gt => gt.GroupToeicQuestions)
        //                .ThenInclude(gtq => gtq.Question)
        //                    .ThenInclude(q => q.QuestionAnswers)
        //        .Where(e => e.DeletedAt == null && e.Id == request.ExamToeicId).AsQueryable();

        //        Console.WriteLine("day là chuoi truy van    :" + examQuery.ToQueryString());

        //        var exam = await examQuery.FirstOrDefaultAsync();


        //        //var examQuery = from ex in _dbContext.ExamToeics
        //        //                where ex.Id == request.ExamToeicId
        //        //                from pt in _dbContext.PartToeics.Where(pt => pt.Type == null || pt.Type == request.PartToeicType).DefaultIfEmpty()
        //        //                from gt in _dbContext.GroupToeics.Where(gt => gt.PartToeicId == pt.Id).DefaultIfEmpty()
        //        //                from gtq in _dbContext.GroupToeicQuestions.Where(gtq => gtq.GroupToeicId == gt.Id).DefaultIfEmpty()
        //        //                from q in _dbContext.Questions.Where(q => q.Id == gtq.QuestionId).DefaultIfEmpty()
        //        //                from qa in _dbContext.QuestionAnswers.Where(qa => qa.QuestionId == q.Id).DefaultIfEmpty()
        //        //                select new
        //        //                {
        //        //                    ExamId = ex.Id,
        //        //                    ex.Title,
        //        //                    ex.Duration,
        //        //                    ex.StartTime,
        //        //                    ex.EndTime,
        //        //                    PartName = pt.Name,
        //        //                    PartType = pt.Type,
        //        //                    GroupAudio = gt.Audio,
        //        //                    GroupImage = gt.Image,
        //        //                    GroupParagraph = gt.Paragraph,
        //        //                    QuestionTitle = q.Title,
        //        //                    QuestionNumber = q.Number,
        //        //                    QuestionImage = q.Image,
        //        //                    QuestionAudio = q.Audio,
        //        //                    QuestionParagraph = q.Paragraph,
        //        //                    AnswerContent = qa.Content,
        //        //                    qa.IsCorrect,
        //        //                    qa.Score
        //        //                };
        //        //var examToeic = await examQuery.Select(x => new ExamToeicDto
        //        //{
        //        //    Id = x.ExamId,
        //        //    Title=x.Title,
        //        //    Duration=x.Duration,
        //        //    StartTime=x.StartTime,
        //        //    EndTime=x.EndTime,

        //        //}).Distinct().ToListAsync();

        //        //foreach(var part in examToeic.)
        //        //var exam = await examQuery.FirstOrDefaultAsync();


        //        if (exam == null)
        //        {
        //            return null;
        //        }

        //        var examDto = _mapper.Map<ExamToeicDto>(exam);

        //        if (examDto != null)
        //        {
        //            foreach (var partToeicDto in examDto.PartToeics)
        //            {
        //                foreach (var groupToeicDto in partToeicDto.GroupToeics)
        //                {
        //                    var questions = await GetQuestionsByGroupToeicIdAsync(groupToeicDto.Id);
        //                    groupToeicDto.Questions = questions;
        //                }
        //            }
        //        }

        //        return examDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
        //    }
        //}
        public async Task<ExamToeicDto> GetByIdAsync(int id)
        {
            try
            {
                var exam = await _dbContext.ExamToeics
                 .Include(e => e.PartToeics)
                     .ThenInclude(p => p.GroupToeics)
                         .ThenInclude(gq => gq.GroupToeicQuestions)
                             .ThenInclude(gtq => gtq.Question)
                                 .ThenInclude(q => q.QuestionAnswers)
                 .FirstOrDefaultAsync(e => e.DeletedAt == null && e.Id == id);

                if (exam == null)
                {
                    return null;
                }

                var examDto = _mapper.Map<ExamToeicDto>(exam);

                var groupToeicIds = examDto.PartToeics
                    .SelectMany(pt => pt.GroupToeics.Select(gt => gt.Id))
                    .ToList();

                var allQuestions = await _dbContext.GroupToeicQuestions
                    .Where(gtq => groupToeicIds.Contains(gtq.GroupToeicId) && gtq.Question.DeletedAt == null)
                    .Include(gtq => gtq.Question)
                        .ThenInclude(q => q.QuestionAnswers)
                    .ToListAsync();

                foreach (var partToeicDto in examDto.PartToeics)
                {
                    foreach (var groupToeicDto in partToeicDto.GroupToeics)
                    {
                        var questionsForGroup = allQuestions
                            .Where(gtq => gtq.GroupToeicId == groupToeicDto.Id)
                            .Select(gtq => _mapper.Map<QuestionDto>(gtq.Question))
                            .ToList();

                        groupToeicDto.Questions = questionsForGroup;
                    }
                }

                return examDto;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }



        //lấy partToeic theo examToeicId
        private async Task<List<PartToeicDto>> GetPartToeicsByExamToeicIdAsync(int examToeicId, int? type)
        {
            var partToeics = await _dbContext.PartToeics
                .Where(pt => pt.ExamToeicId == examToeicId && (type == null || pt.Type == type))
                .ToListAsync();

            return partToeics.Select(pt => _mapper.Map<PartToeicDto>(pt)).ToList();
        }



        //lấy groupToeic theo partToeicId
        private async Task<List<GroupToeicDto>> GetGroupToeicsByPartToeicIdAsync(int partToeicId)
        {
            var groupToeics = await _dbContext.GroupToeics
                .Where(gt => gt.PartToeicId == partToeicId)
                .ToListAsync();

            return groupToeics.Select(gt => _mapper.Map<GroupToeicDto>(gt)).ToList();
        }

        //lấy câu hỏi theo grouptoeicId
        private async Task<List<QuestionDto>> GetQuestionsByGroupToeicIdAsync(int groupToeicId)
        {
            var questions = await _dbContext.GroupToeicQuestions
                .Where(gtq => gtq.GroupToeicId == groupToeicId)
                .Include(gtq => gtq.Question)
                    .ThenInclude(q => q.QuestionAnswers)
                .Select(gtq => gtq.Question)
                .ToListAsync();

            return questions.Select(q => _mapper.Map<QuestionDto>(q)).ToList();
        }



        public async Task<bool> Create(CreateExamToeicRequest request)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var examToeic = _mapper.Map<ExamToeic>(request);
                    examToeic.CreatedAt = DateTime.Now;
                    await _dbContext.ExamToeics.AddAsync(examToeic);
                    await _dbContext.SaveChangesAsync();


                    var partsDto = await ImportPartsAsync(request.FileExel, examToeic.Id.ToString());
                    if (partsDto == null)
                    {
                        return false;
                    }


                    foreach (var partDto in partsDto)
                    {
                        var part = _mapper.Map<PartToeic>(partDto);
                        part.ExamToeicId = examToeic.Id;
                        part.CreatedAt = DateTime.Now;
                        await _dbContext.PartToeics.AddAsync(part);
                        await _dbContext.SaveChangesAsync();
                        foreach (var groupDto in partDto.GroupToeics)
                        {
                            var group = _mapper.Map<GroupToeic>(groupDto);
                            group.PartToeicId = part.Id;
                            group.CreatedAt = DateTime.Now;
                            await _dbContext.GroupToeics.AddAsync(group);
                            await _dbContext.SaveChangesAsync();

                            foreach (var questionDto in groupDto.Questions)
                            {
                                var question = _mapper.Map<Question>(questionDto);
                                question.CreatedAt = DateTime.Now;
                                await _dbContext.Questions.AddAsync(question);
                                await _dbContext.SaveChangesAsync();

                                var groupToeicQuestion = new GroupToeicQuestion
                                {
                                    GroupToeicId = group.Id,
                                    QuestionId = question.Id,
                                    CreatedAt = DateTime.Now,
                                };
                                await _dbContext.GroupToeicQuestions.AddAsync(groupToeicQuestion);

                                foreach (var answerDto in questionDto.QuestionAnswers)
                                {
                                    var answer = _mapper.Map<QuestionAnswer>(answerDto);
                                    answer.QuestionId = question.Id;
                                    answer.CreatedAt = DateTime.Now;
                                    await _dbContext.QuestionAnswers.AddAsync(answer);
                                }
                            }
                        }
                    }

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    var requestFile = new UploadMultipleFileRequest
                    {
                        Files = request.Files,
                        AdditionalString = examToeic.Id.ToString()
                    };
                    await _fileService.UploadMultipleFilesAsync(requestFile, PathFolder.ExamToeic);


                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw new ApiException("Có lỗi xảy ra trong quá trình xử lý!", HttpStatusCode.InternalServerError, ex);

                }
            }
        }




        //import partToeic từ excel
        public async Task<List<CreatePartToeicRequest>> ImportPartsAsync(IFormFile file, string additionalString)
        {
            List<CreatePartToeicRequest> parts = new List<CreatePartToeicRequest>();
            CreatePartToeicRequest currentPart = null;
            CreateGroupToeicRequest currentGroup = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                try
                {
                    await file.CopyToAsync(stream);
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Chuyển đến sheet đầu

                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            string partName = worksheet.Cells[row, 2].Value?.ToString();
                            if (partName != null)
                            {
                                if (currentPart == null || currentPart.Name != partName)
                                {
                                    currentPart = new CreatePartToeicRequest
                                    {
                                        Name = partName,
                                        Type = int.Parse(worksheet.Cells[row, 3].Value?.ToString()),
                                        GroupToeics = new List<CreateGroupToeicRequest>()
                                    };
                                    parts.Add(currentPart);
                                    currentGroup = null; //Đặt lại nhóm hiện tại khi  bắt đầu một phần mới
                                }
                            }

                            string paragraph = worksheet.Cells[row, 4].Value?.ToString();
                            string title = worksheet.Cells[row, 5].Value?.ToString();

                            if (paragraph != null || title != null)
                            {
                                currentGroup = new CreateGroupToeicRequest
                                {
                                    Title = worksheet.Cells[row, 5].Value?.ToString(),
                                    Image = worksheet.Cells[row, 6].Value?.ToString() == null ? null : PathFolder.ExamToeic + "/" + additionalString + "_" + worksheet.Cells[row, 6].Value.ToString(),
                                    Paragraph = paragraph,
                                    Audio = worksheet.Cells[row, 7].Value?.ToString() == null ? null : PathFolder.ExamToeic + "/" + additionalString + "_" + worksheet.Cells[row, 7].Value.ToString(),
                                    Questions = new List<CreateQuestionRequest>()
                                };
                                currentPart.GroupToeics.Add(currentGroup);
                            }

                            string questionTitle = worksheet.Cells[row, 8].Value?.ToString();
                            string questionNumber = worksheet.Cells[row, 1].Value?.ToString();

                            if (questionTitle != null || questionNumber != null)
                            {
                                CreateQuestionRequest question = new CreateQuestionRequest
                                {
                                    Number = int.Parse(worksheet.Cells[row, 1].Value?.ToString()),
                                    Title = questionTitle,
                                    Image = worksheet.Cells[row, 9].Value?.ToString() == null ? null : PathFolder.ExamToeic + "/" + additionalString + "_" + worksheet.Cells[row, 9].Value.ToString(),
                                    Audio = worksheet.Cells[row, 10].Value?.ToString() == null ? null : PathFolder.ExamToeic + "/" + additionalString + "_" + worksheet.Cells[row, 10].Value.ToString(),
                                    Paragraph = worksheet.Cells[row, 11].Value?.ToString(),
                                    TypeKind = int.Parse(worksheet.Cells[row, 12].Value?.ToString()),
                                    TypeForm = int.Parse(worksheet.Cells[row, 13].Value?.ToString()),
                                    QuestionCategoryId = 1,
                                    SectionId = 1,
                                    Difficulty = 1,
                                    Score = 1,
                                    QuestionAnswers = new List<QuestionAnswerDto>(),


                                };

                                for (int col = 14; col <= worksheet.Dimension.End.Column - 1; col++) // Cột N đến Q cho các tùy chọn
                                {
                                    if (worksheet.Cells[row, col].Value != null)
                                    {
                                        bool isCorrect = (worksheet.Cells[row, worksheet.Dimension.End.Column].Value?.ToString() == (col - 13).ToString()); // Cột R cho câu trả lời đúng
                                        question.QuestionAnswers.Add(new QuestionAnswerDto
                                        {
                                            Content = worksheet.Cells[row, col].Value.ToString(),
                                            IsCorrect = isCorrect,
                                            // Set Score for the correct answer if needed
                                            Score = isCorrect ? 1 : 0
                                        });
                                    }
                                };

                                currentGroup?.Questions.Add(question);
                            }
                        }
                    }
                    return parts;

                }
                catch (Exception ex)
                {

                    throw new ApiException("Có lỗi xảy ra trong quá trình xử lý tệp !", HttpStatusCode.InternalServerError, ex);
                }

            }

        }





        //kiểm tra câu đúng
        public async Task<CheckQuestionResult> CheckReadingAnswers(CheckQuestionRequest questionsToCheck)
        {
            return await _questionService.CheckAnswers(questionsToCheck, (int)QuestionTypeForm.Reading);
        }

        public async Task<CheckQuestionResult> CheckListeningAnswers(CheckQuestionRequest questionsToCheck)
        {
            return await _questionService.CheckAnswers(questionsToCheck, (int)QuestionTypeForm.Listening);
        }

        public async Task<CheckQuestionResult> CheckOverallAnswers(CheckQuestionRequest questionsToCheck)
        {
            var readingScore = await CheckReadingAnswers(questionsToCheck);
            var listeningScore = await CheckListeningAnswers(questionsToCheck);

            var overallResult = new CheckQuestionResult
            {
                CheckQuestions = new List<CheckQuestions>(),
                TotalScore = readingScore.TotalScore + listeningScore.TotalScore,
                TotalCountFalse = readingScore.TotalCountFalse + listeningScore.TotalCountFalse,
                TotalCountTrue = readingScore.TotalCountTrue + listeningScore.TotalCountTrue,

                TotalCountListeningFalse = listeningScore.TotalCountFalse,
                TotalCountListeningTrue = listeningScore.TotalCountTrue,
                TotalCountReadingFalse = readingScore.TotalCountFalse,
                TotalCountReadingTrue = readingScore.TotalCountTrue,
            };

            overallResult.CheckQuestions.AddRange(readingScore.CheckQuestions);
            overallResult.CheckQuestions.AddRange(listeningScore.CheckQuestions);


            //thêm examresult (bỏ qua vì đã gọi api bên front end)

            //var userCurrent = await _userService.GetUserInfoAsync();
            //var createExamToeicResultRequest = new CreateExamToeicResultRequest
            //{
            //    ExamToeicId = questionsToCheck.ExamId,
            //    //UserId = userCurrent?.Id,
            //    Score = overallResult.TotalScore,
            //    StartTime = DateTime.Now,
            //    DurationTime = TimeSpan.FromMinutes(30),
            //    NumberCorrectOverallAnswers = overallResult.TotalCountTrue,
            //    NumberCorrectListeningAnswers= overallResult.TotalCountListeningTrue,
            //    NumberCorrectReadingAnswers= overallResult.TotalCountReadingTrue,
            //    NumberChangeTab = 0,
            //};

            //var examResultAdd = await CreateExamToeicResult(createExamToeicResultRequest);


            return overallResult;
        }





        public async Task<ExamToeicResult> CreateExamToeicResult(CreateExamToeicResultRequest request)
        {
            try
            {
                var userCurrent = await _userService.GetUserInfoAsync();
                var examToeicResult = _mapper.Map<ExamToeicResult>(request);

                examToeicResult.CreatedAt = DateTime.Now;
                examToeicResult.CreatedBy = userCurrent?.Id;
                examToeicResult.UserId = userCurrent?.Id;

                await _dbContext.ExamToeicResults.AddAsync(examToeicResult);
                await _dbContext.SaveChangesAsync();

                return examToeicResult;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<bool> CreateExamToeicResultDetail(CheckQuestionRequest request)
        {
            try
            {

                foreach (CheckQuestion checkQuestion in request.checkQuestions)
                {
                    var examToeicResultDetail = new ExamToeicResultDetail
                    {
                        ExamToeicResultId = request.ExamId,
                        QuestionId = checkQuestion.QuestionId,
                        QuestionAnswerId = checkQuestion.QuestionAnswerId,
                        CreatedAt = DateTime.Now,

                    };
                    await _dbContext.ExamToeicResultDetails.AddAsync(examToeicResultDetail);
                    await _dbContext.SaveChangesAsync();

                }
                await _dbContext.SaveChangesAsync();

                return true;


                //var examToeicResultDetail = new ExamToeicResultDetail
                //{
                //    ExamToeicResultId = request.ExamId,

                //};    


                //examToeicResultDetail.CreatedAt = DateTime.Now;

                //await _dbContext.ExamToeicResultDetails.AddAsync(examToeicResultDetail);
                //await _dbContext.SaveChangesAsync();

                //return examToeicResultDetail;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }




        //get theo usr

        //lấy exam result theo userID
        public async Task<List<ExamToeicResultDto>> GetExamToeicResult(Guid userId)
        {
            try
            {
                var results = await _dbContext.ExamToeicResults.Include(er => er.ExamToeicResultDetails).Include(er => er.ExamToeic).Where(x => x.UserId == userId).ToListAsync();

                if (!results.Any())
                {
                    return null;
                }
                return _mapper.Map<List<ExamToeicResultDto>>(results);

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }


        //lấy exam result theo Id
        public async Task<ExamToeicResultDto> GetExamToeicResultById(int Id)
        {
            try
            {

                var result = await _dbContext.ExamToeicResults.Include(er => er.ExamToeicResultDetails).Include(er => er.ExamToeic).Where(x => x.Id == Id).FirstOrDefaultAsync();

                if (result == null)
                {
                    return null;
                }
                var examToeicResultDto = _mapper.Map<ExamToeicResultDto>(result);

                // lấy điểm chuẩn toeic
                //var readingScore = await _dbContext.ToeicScores
                //    .Where(ts => ts.NumberOfCorrect == result.NumberCorrectReadingAnswers && ts.Type == 1)
                //    .Select(ts => ts.Score)
                //    .FirstOrDefaultAsync();

                //var listeningScore = await _dbContext.ToeicScores
                //    .Where(ts => ts.NumberOfCorrect == result.NumberCorrectListeningAnswers && ts.Type == 2)
                //    .Select(ts => ts.Score)
                //    .FirstOrDefaultAsync();

                var toeicScores = await _dbContext.ToeicScores
                .Where(ts => (ts.NumberOfCorrect == result.NumberCorrectReadingAnswers && ts.Type == 1) ||
                        (ts.NumberOfCorrect == result.NumberCorrectListeningAnswers && ts.Type == 2))
                .ToListAsync();

                // lọc
                var readingScore = toeicScores.FirstOrDefault(ts => ts.Type == 1)?.Score;
                var listeningScore = toeicScores.FirstOrDefault(ts => ts.Type == 2)?.Score;


                examToeicResultDto.ReadingToeicScore = readingScore;
                examToeicResultDto.ListeningToeicScore = listeningScore;
                examToeicResultDto.TotalToeicScore = (readingScore ?? 0) + (listeningScore ?? 0);

                return examToeicResultDto;


            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }



    }
}
