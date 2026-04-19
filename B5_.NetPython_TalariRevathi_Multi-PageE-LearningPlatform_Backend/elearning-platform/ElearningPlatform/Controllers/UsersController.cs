using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
public async Task<IActionResult> Register([FromBody] UserDto dto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.Register(dto);
        return CreatedAtAction(nameof(Get), new { id = result.UserId }, result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
[HttpGet("{id}")]
public async Task<IActionResult> Get(int id)
{
    var user = await _service.GetById(id);
    if (user == null) return NotFound();

    return Ok(user);
}

        [HttpPut("{id}")]
       public async Task<IActionResult> Update(int id, [FromBody] UserDto dto)
        {
            var updated = await _service.Update(id, dto);
            if (!updated) return NotFound();

            return Ok();
        }
    }
}