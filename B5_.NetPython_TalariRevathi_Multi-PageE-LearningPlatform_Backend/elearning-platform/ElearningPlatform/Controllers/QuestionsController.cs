using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        // ✅ POST /api/questions
        [HttpPost]
public async Task<IActionResult> Create([FromBody] QuestionDto dto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.Create(dto);

        return CreatedAtAction(nameof(Create), new { id = result.QuestionId }, result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
    }
}