using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;
namespace ElearningPlatform.Services {
public class QuizService : IQuizService
{

    private readonly AppDbContext _context;
private readonly IMapper _mapper;

    public QuizService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QuizDto> Create(QuizDto dto)
    {
        // ✅ Check Course exists
        var course = await _context.Courses.FindAsync(dto.CourseId);
        if (course == null)
            throw new Exception("Invalid CourseId");

        var quiz = _mapper.Map<Quiz>(dto);

        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();

        return _mapper.Map<QuizDto>(quiz);
    }

    public async Task<IEnumerable<QuizDto>> GetByCourse(int courseId)
    {
        var quizzes = await _context.Quizzes
    .AsNoTracking() // ✅ FIX
    .Where(q => q.CourseId == courseId)
    .ToListAsync();

        return _mapper.Map<List<QuizDto>>(quizzes);
    }

    public async Task<IEnumerable<QuestionDto>> GetQuestions(int quizId)
    {
     var questions = await _context.Questions
    .AsNoTracking() // ✅ FIX
    .Where(q => q.QuizId == quizId)
    .ToListAsync();

        return _mapper.Map<List<QuestionDto>>(questions);
    }

  public async Task<object> SubmitQuiz(int quizId, QuizSubmitDto dto)
{
    var questions = await _context.Questions
        .Where(q => q.QuizId == quizId)
        .ToListAsync();

    if (!questions.Any())
        throw new Exception("No questions found");

    var user = await _context.Users.FindAsync(dto.UserId);
    if (user == null)
        throw new Exception("Invalid UserId");

    int score = 0;
    int attempted = 0;

    foreach (var q in questions)
    {
        if (dto.Answers.TryGetValue(q.QuestionId, out var userAnswer))
        {
            attempted++;

            if (!string.IsNullOrWhiteSpace(userAnswer) &&
                userAnswer.Trim().Equals(q.CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                score++;
            }
        }
    }

    // ✅ 👉 PASTE YOUR CODE HERE
    var existingResult = await _context.Results
        .FirstOrDefaultAsync(r => r.UserId == dto.UserId && r.QuizId == quizId);

    if (existingResult != null)
    {
        existingResult.Score = score;
        existingResult.AttemptDate = DateTime.Now;

        _context.Results.Update(existingResult);
    }
    else
    {
        var result = new Result
        {
            UserId = dto.UserId,
            QuizId = quizId,
            Score = score,
            AttemptDate = DateTime.Now
        };

        _context.Results.Add(result);
    }

    await _context.SaveChangesAsync();

    // ✅ response
    return new
    {
        TotalQuestions = questions.Count,
        Attempted = attempted,
        Score = score
    };
}
}
}