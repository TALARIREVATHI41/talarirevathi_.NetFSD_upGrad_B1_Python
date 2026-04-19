namespace ElearningPlatform.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class LessonDto
    {
        public int LessonId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int OrderIndex { get; set; }
    }
}