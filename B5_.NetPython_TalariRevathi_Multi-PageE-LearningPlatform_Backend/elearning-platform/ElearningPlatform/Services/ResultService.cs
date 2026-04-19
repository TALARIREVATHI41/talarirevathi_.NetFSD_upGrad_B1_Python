using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Services
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _context;

        public ResultService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetByUser(int userId)
        {
            var results = await _context.Results
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return results.Select(r => new
            {
                r.ResultId,
                r.QuizId,
                r.Score,
                r.AttemptDate
            });
        }

        public async Task<int> SubmitQuiz(int quizId, int userId)
        {
            var questions = await _context.Questions
                .Where(q => q.QuizId == quizId)
                .ToListAsync();

            if (!questions.Any())
                throw new Exception("No questions");

            return questions.Count; // placeholder
        }
    }
}