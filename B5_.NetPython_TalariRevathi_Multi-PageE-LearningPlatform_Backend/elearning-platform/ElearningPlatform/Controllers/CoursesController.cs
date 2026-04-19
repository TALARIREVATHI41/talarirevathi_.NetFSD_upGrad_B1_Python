using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _service.GetById(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.CourseId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto dto)
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