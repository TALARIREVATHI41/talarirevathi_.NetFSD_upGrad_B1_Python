using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetByQuiz(int quizId);
        Task<QuestionDto> Create(QuestionDto dto);
    }
}