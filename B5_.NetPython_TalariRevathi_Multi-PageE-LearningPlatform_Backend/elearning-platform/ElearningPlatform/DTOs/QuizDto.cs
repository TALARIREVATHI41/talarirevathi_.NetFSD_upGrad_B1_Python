namespace ElearningPlatform.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class QuizDto
    {
        public int QuizId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}