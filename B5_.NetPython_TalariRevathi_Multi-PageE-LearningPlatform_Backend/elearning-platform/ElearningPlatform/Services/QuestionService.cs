using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ElearningPlatform.DTOs;
namespace ElearningPlatform.Services {
public class QuestionService : IQuestionService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public QuestionService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionDto>> GetByQuiz(int quizId)
    {
        var questions = await _context.Questions
    .AsNoTracking() // ✅ FIX
    .Where(q => q.QuizId == quizId)
    .ToListAsync();

        return _mapper.Map<List<QuestionDto>>(questions);
    }

    public async Task<QuestionDto> Create(QuestionDto dto)
    {
        var question = _mapper.Map<Question>(dto);

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return _mapper.Map<QuestionDto>(question);
    }
}
}