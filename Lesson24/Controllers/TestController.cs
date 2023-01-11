using Lesson24.Database;
using Lesson24.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lesson24.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TestController> _logger;
        private readonly VDBContext _db;
        public TestController(ILogger<TestController> logger, VDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "User")]
        public IEnumerable<User> Get()
        {
            return _db.Users;
        }
        [HttpPost(Name = "User")]
        public IActionResult Post([FromBody] User s)
        {
            _db.Users.Add(s);
            return Ok();
        }
    }
}