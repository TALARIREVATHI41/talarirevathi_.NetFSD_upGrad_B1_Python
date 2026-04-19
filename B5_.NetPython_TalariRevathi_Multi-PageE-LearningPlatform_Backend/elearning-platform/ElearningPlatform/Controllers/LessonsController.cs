using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonsController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet("/api/courses/{courseId}/lessons")]
public async Task<IActionResult> GetByCourse(int courseId)
{
    return Ok(await _service.GetByCourse(courseId));
}

[HttpPost]
public async Task<IActionResult> Create([FromBody] LessonDto dto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.Create(dto);

        return CreatedAtAction(nameof(GetByCourse),
            new { courseId = dto.CourseId }, result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}

[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] LessonDto dto)
{
    var updated = await _service.Update(id, dto);
    if (!updated) return NotFound();

    return Ok("Updated Successfully");
}

[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var deleted = await _service.Delete(id);
    if (!deleted) return NotFound();

    return Ok("Deleted Successfully");
}
    }
}