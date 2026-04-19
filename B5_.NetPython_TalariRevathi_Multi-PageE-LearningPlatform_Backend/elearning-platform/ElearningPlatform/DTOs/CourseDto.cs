namespace ElearningPlatform.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class CourseDto
    {
        public int CourseId { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int CreatedBy { get; set; }
    }
}