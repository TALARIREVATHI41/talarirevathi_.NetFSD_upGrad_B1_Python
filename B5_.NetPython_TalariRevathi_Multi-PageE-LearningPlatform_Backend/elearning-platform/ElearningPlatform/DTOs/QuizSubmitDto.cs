namespace ElearningPlatform.DTOs
{
    public class QuizSubmitDto
    {
        public int UserId { get; set; }
        public required Dictionary<int, string> Answers { get; set; }
    }
}