namespace ElearningPlatform.Services
{
    public interface IResultService
    {
        Task<int> SubmitQuiz(int quizId, int userId);
        Task<object> GetByUser(int userId);   
    }
}