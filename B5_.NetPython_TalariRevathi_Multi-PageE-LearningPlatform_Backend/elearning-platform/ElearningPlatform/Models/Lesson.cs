public class Lesson
{
    public int LessonId { get; set; }
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    public required string Title { get; set; }
    public required string Content { get; set; }

    public int OrderIndex { get; set; }
}