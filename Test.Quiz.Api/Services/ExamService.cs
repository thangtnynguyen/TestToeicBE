using AutoMapper;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Models.Common;
using Test.Quiz.Api.Models.Exam;
using Microsoft.EntityFrameworkCore;
using Test.Quiz.Api.Constants;
using Test.Quiz.Api.Exceptions;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data;
using Test.Quiz.Api.Models.Question;
using Test.Quiz.Api.Enums;
using OfficeOpenXml;
using Test.Quiz.Api.Models.QuestionGroup;
using Test.Quiz.Api.Models.Part;
using Test.Quiz.Api.Models.QuestionAnswer;
using Test.Quiz.Api.Models.ExamToeicResult;

namespace Test.Quiz.Api.Services
{
    public class ExamService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public ExamService(ApplicationDbContext dbContext, FileService fileService, IMapper mapper, UserService userService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PagingResult<Exam>> Get(GetExamRequest request)
        {
            try
            {
                var query = _dbContext.Exams.Where(x => x.DeletedAt == null)
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

                var result = new PagingResult<Exam>(items, request.PageIndex.Value, request.PageSize.Value, request.SortBy, request.OrderBy, total, totalPages);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<ExamDto> GetById(int id)
        {
            try
            {
                var query = await _dbContext.Exams
                    .Include(e => e.ExamQuestions)
                        .ThenInclude(eq => eq.Question)
                            .ThenInclude(q => q.QuestionAnswers)
                    .Where(e => e.DeletedAt == null && e.Id == id)
                    .FirstOrDefaultAsync();

                if (query == null)
                {
                    return null;
                }
                var examDto = _mapper.Map<ExamDto>(query);

                examDto.Questions = _mapper.Map<List<QuestionDto>>(query.ExamQuestions.Select(eq => eq.Question).ToList());

                foreach (var eq in query.ExamQuestions)
                {
                    var questionDto = _mapper.Map<QuestionDto>(eq.Question);

                    if (questionDto.TypeForm == 1)
                    {
                        examDto.QuestionReadings.Add(questionDto);
                    }
                    else if (questionDto.TypeForm == 2)
                    {
                        examDto.QuestionListenings.Add(questionDto);
                    }
                }

                return examDto;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }


      


        public async Task<Exam> Delete(int id)
        {
            try
            {
                var exam = await _dbContext.Exams.FindAsync(id);

                if (exam == null)
                {
                    throw new ApiException("Không tìm thấy bài thi hợp lệ!", Constants.HttpStatusCode.InternalServerError);
                }

                var userCurrent = await _userService.GetUserInfoAsync();
                exam.DeletedAt = DateTime.Now;
                exam.CreatedBy = userCurrent?.Id;

                await _dbContext.SaveChangesAsync();

                return exam;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<List<Exam>> DeleteMultiple(List<int?> ids)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var exams = await _dbContext.Exams
                                                   .Where(s => ids.Contains(s.Id) && s.DeletedAt == null)
                                                   .ToListAsync();

                    if (!exams.Any())
                    {
                        throw new ApiException("Không tìm thấy bài thi nào hợp lệ để xoá.", Constants.HttpStatusCode.BadRequest);
                    }

                    foreach (var exam in exams)
                    {
                        exam.DeletedAt = DateTime.Now;
                    }

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return exams;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Lỗi khi xoá các bài thi: {ex.Message}", Constants.HttpStatusCode.InternalServerError, ex);
                }
            }
        }



        //kiểm tra câu đúng
        public async Task<CheckQuestionResult> CheckReadingAnswers(CheckQuestionRequest questionsToCheck)
        {
            return await CheckAnswers(questionsToCheck, (int)QuestionTypeForm.Reading);
        }

        public async Task<CheckQuestionResult> CheckListeningAnswers(CheckQuestionRequest questionsToCheck)
        {
            return await CheckAnswers(questionsToCheck, (int)QuestionTypeForm.Listening);
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
            };

            overallResult.CheckQuestions.AddRange(readingScore.CheckQuestions);
            overallResult.CheckQuestions.AddRange(listeningScore.CheckQuestions);



            var userCurrent = await _userService.GetUserInfoAsync();
            var examResult = new ExamResult
            {
                ExamId = questionsToCheck.ExamId,
                UserId = userCurrent?.Id,
                Score = overallResult.TotalScore,
                StartTime = DateTime.Now, 
                DurationTime = TimeSpan.FromMinutes(30), 
                NumberCorrectAnswers = overallResult.TotalCountTrue,
                NumberChangeTab = 0, 
            };
            var examResultAdd = await CreateExamResult(examResult);


            return overallResult;
        }



        private async Task<CheckQuestionResult> CheckAnswers(CheckQuestionRequest questionsToCheck, int questionTypeForm)
        {
            var result = new CheckQuestionResult
            {
                CheckQuestions = new List<CheckQuestions>(),
                TotalScore = 0,
                TotalCountFalse = 0,
                TotalCountTrue = 0
            };

            foreach (var request in questionsToCheck.checkQuestions)
            {
                var question = await _dbContext.Questions
                    .Include(q => q.QuestionAnswers)
                    .FirstOrDefaultAsync(q => q.Id == request.QuestionId && q.TypeForm == questionTypeForm);

                if (question != null)
                {
                    var correctAnswers = question.QuestionAnswers
                        .Where(a => a.IsCorrect);

                    var totalScore = correctAnswers.Sum(a => a.Score);
                    var isCorrect = correctAnswers.Any(a => a.Id == request.QuestionAnswerId);

                    var checkQuestion = new CheckQuestions
                    {
                        QuestionId = question.Id,
                        QuestionAnswerId = request.QuestionAnswerId,
                        QuestionAnswerCorrectId = correctAnswers.FirstOrDefault(a => a.IsCorrect)?.Id ?? 0,
                        QuestionTitle = question.Title,
                        QuestionAnswerContent = GetAnswerContent(question.QuestionAnswers, request.QuestionAnswerId),
                        QuestionAnswerCorrectContent = GetCorrectAnswerContent(correctAnswers),
                    };

                    result.CheckQuestions.Add(checkQuestion);
                    result.TotalScore += isCorrect ? totalScore : 0;
                    result.TotalCountFalse += isCorrect ? 0 : 1;
                    result.TotalCountTrue += isCorrect ? 1 : 0;
                }
            }

            return result;
        }

        private string GetAnswerContent(List<QuestionAnswer> answers, int answerId)
        {
            return answers.FirstOrDefault(a => a.Id == answerId)?.Content ?? "";
        }

        private string GetCorrectAnswerContent(IEnumerable<QuestionAnswer> correctAnswers)
        {
            return correctAnswers.FirstOrDefault()?.Content ?? "";
        }


        public async Task<ExamResult> CreateExamResult(ExamResult examResult)
        {
            try
            {
                var userCurrent = await _userService.GetUserInfoAsync();
                examResult.CreatedAt = DateTime.Now;
                examResult.CreatedBy = userCurrent?.Id;

                await _dbContext.ExamResults.AddAsync(examResult);
                await _dbContext.SaveChangesAsync();

                return examResult;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError, ex);
            }
        }

        //lấy điểm người thi
        public async Task<ExamResult?> GetScoreExamStudent(Guid userId, int examId)
        {
            try
            {
                var result = await _dbContext.ExamResults.FirstOrDefaultAsync(x => x.UserId == userId && x.ExamId == examId);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, Constants.HttpStatusCode.InternalServerError, ex);
            }
        }














        // /////////////////////////////////

        //lấy câu hỏi ngẫu nhiêm

        // lấy ngẫu nhiên danh sách câu hỏi đọc từ cơ sở dữ liệu
        public List<Question> GetRandomReadingQuestions(int numberOfQuestions)
        {
            var randomReadingQuestions = _dbContext.Questions
                .Where(q => q.TypeForm == (int)QuestionTypeForm.Reading)
                .OrderBy(x => Guid.NewGuid()) // Sắp xếp ngẫu nhiên
                .Take(numberOfQuestions)
                .ToList();

            return randomReadingQuestions;
        }

        // lấy ngẫu nhiên danh sách câu hỏi nghe từ cơ sở dữ liệu
        public List<Question> GetRandomListeningQuestions(int numberOfQuestions)
        {
            var randomListeningQuestions = _dbContext.Questions
                .Where(q => q.TypeForm == (int)QuestionTypeForm.Listening)
                .OrderBy(x => Guid.NewGuid()) // Sắp xếp ngẫu nhiên
                .Take(numberOfQuestions)
                .ToList();

            return randomListeningQuestions;
        }

        //theo cả độ khó
        public List<Question> GetRandomQuestionsByDifficulty(int questionTypeForm, int numberOfEasyQuestions, int numberOfAverageQuestions, int numberOfDifficultQuestions)
        {
            // Lấy tất cả các câu hỏi có loại hình tương ứng từ cơ sở dữ liệu một lần.
            var allQuestions = _dbContext.Questions
                .Where(q => q.TypeForm == questionTypeForm && q.DeletedAt==null)
                .ToList(); 

            // Tạo một trình tạo số ngẫu nhiên để trộn danh sách câu hỏi.
            var rnd = new Random();

            // Lấy và trộn các câu hỏi theo mức độ khó cụ thể.
            var easyQuestions = allQuestions
                .Where(q => q.Difficulty == (int)QuestionTypeDifficulty.Easy)
                .OrderBy(q => rnd.Next())
                .Take(numberOfEasyQuestions);

            var averageQuestions = allQuestions
                .Where(q => q.Difficulty == (int)QuestionTypeDifficulty.Average)
                .OrderBy(q => rnd.Next())
                .Take(numberOfAverageQuestions);

            var difficultQuestions = allQuestions
                .Where(q => q.Difficulty == (int)QuestionTypeDifficulty.Difficult)
                .OrderBy(q => rnd.Next())
                .Take(numberOfDifficultQuestions);

            // Kết hợp các danh sách câu hỏi và chuyển đổi thành một danh sách.
            var randomQuestions = easyQuestions
                .Concat(averageQuestions)
                .Concat(difficultQuestions)
                .ToList();

            return randomQuestions;
        }








        //import group  từ excel
        public async Task<List<CreateGroupToeicRequest>> ImportQuestionGroupsAsync(IFormFile file)
        {
            List<CreateGroupToeicRequest> questionGroups = new List<CreateGroupToeicRequest>();
            CreateGroupToeicRequest currentGroup = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Chuyển đến sheet đầu

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        if (worksheet.Cells[row, 4].Value != null) // Check paragraph tồn tại
                        {
                            if (currentGroup != null)
                            {
                                questionGroups.Add(currentGroup); // Thêm nhóm cũ trc khi khởi tạo nhóm cũ
                            }

                            currentGroup = new CreateGroupToeicRequest
                            {
                                Paragraph = worksheet.Cells[row, 4].Value.ToString(),
                                Questions = new List<CreateQuestionRequest>()
                            };
                        }

                        // lấy dữ liệu câu hỏi
                        if (worksheet.Cells[row, 5].Value != null) // Check tồn tại 
                        {
                            CreateQuestionRequest question = new CreateQuestionRequest
                            {
                                Title = worksheet.Cells[row, 5].Value.ToString(),
                               
                            };
                            var questionDto = _mapper.Map<CreateQuestionRequest>(question);
                            currentGroup?.Questions.Add(questionDto);
                        }
                    }

                    if (currentGroup != null)
                    {
                        questionGroups.Add(currentGroup); // Thêm nhóm cuối cùng
                    }
                }
            }

            return questionGroups;
        }


        //import part từ excel
        public async Task<List<CreatePartToeicRequest>> ImportPartsAsync(IFormFile file)
        {
            List<CreatePartToeicRequest> parts = new List<CreatePartToeicRequest>();
            CreatePartToeicRequest currentPart = null;
            CreateGroupToeicRequest currentGroup = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
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
                        if (paragraph != null)
                        {
                            currentGroup = new CreateGroupToeicRequest
                            {
                                Title = worksheet.Cells[row,5].Value?.ToString(),
                                Image = worksheet.Cells[row,6].Value?.ToString(),
                                Paragraph = paragraph,
                                Audio = worksheet.Cells[row,7].Value?.ToString(),
                                Questions = new List<CreateQuestionRequest>()
                            };
                            currentPart.GroupToeics.Add(currentGroup);
                        }

                        string questionTitle = worksheet.Cells[row, 8].Value?.ToString();
                        if (questionTitle != null)
                        {
                            CreateQuestionRequest question = new CreateQuestionRequest
                            {
                                Title = questionTitle,
                                Image = worksheet.Cells[row,9].Value?.ToString(),
                                Audio = worksheet.Cells[row, 10].Value?.ToString(),
                                Paragraph = worksheet.Cells[row, 11].Value?.ToString(),
                                TypeKind = int.Parse(worksheet.Cells[row, 12].Value?.ToString()),
                                TypeForm = int.Parse(worksheet.Cells[row, 13].Value?.ToString()),
                                QuestionCategoryId=1,
                                SectionId=1,
                                Difficulty=1,
                                Score=1,
                                QuestionAnswers= new List<QuestionAnswerDto>(),
                                

                            };

                            for (int col = 14; col <= worksheet.Dimension.End.Column-1; col++) // Cột N đến Q cho các tùy chọn
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
            }

            return parts;
        }

    }
}
