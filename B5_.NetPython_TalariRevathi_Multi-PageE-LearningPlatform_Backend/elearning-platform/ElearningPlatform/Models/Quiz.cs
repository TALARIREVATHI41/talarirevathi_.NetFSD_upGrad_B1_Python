public class Quiz
{
    public int QuizId { get; set; }
    public int CourseId { get; set; }

    public required string Title { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}