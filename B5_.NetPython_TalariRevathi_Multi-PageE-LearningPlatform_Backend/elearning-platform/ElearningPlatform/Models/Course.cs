public class Course
{
    public int CourseId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public int CreatedBy { get; set; }
    public User? User { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}