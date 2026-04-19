using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _service;

        public QuizController(IQuizService service)
        {
            _service = service;
        }

        // ✅ GET /api/quizzes/{courseId}
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByCourse(int courseId)
        {
            return Ok(await _service.GetByCourse(courseId));
        }

        // ✅ POST /api/quizzes
       [HttpPost]
public async Task<IActionResult> Create([FromBody] QuizDto dto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.Create(dto);

        return CreatedAtAction(nameof(GetByCourse),
            new { courseId = result.CourseId }, result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
        // ✅ GET /api/quizzes/{quizId}/questions
        [HttpGet("{quizId}/questions")]
        public async Task<IActionResult> GetQuestions(int quizId)
        {
            return Ok(await _service.GetQuestions(quizId));
        }

        // ✅ POST /api/quizzes/{quizId}/submit
        [HttpPost("{quizId}/submit")]
public async Task<IActionResult> Submit(int quizId, [FromBody] QuizSubmitDto dto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.SubmitQuiz(quizId, dto);

        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
    }
}