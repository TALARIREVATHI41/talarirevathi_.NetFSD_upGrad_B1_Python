using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizDto>> GetByCourse(int courseId);
        Task<QuizDto> Create(QuizDto dto);

        Task<IEnumerable<QuestionDto>> GetQuestions(int quizId);
        Task<object> SubmitQuiz(int quizId, QuizSubmitDto dto);
    }
}