using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Services;

namespace ElearningPlatform.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _service;

        public ResultsController(IResultService service)
        {
            _service = service;
        }

        // ✅ GET /api/results/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetResults(int userId)
        {
            var results = await _service.GetByUser(userId);
            return Ok(results);
        }
    }
}