using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lession2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoUseeTolloController : ControllerBase
    {
        private static readonly string[] Employee = new[]
        {
            "Steve", "Dave"
        };

        private readonly ILogger<WhoUseeTolloController> _logger;

        public WhoUseeTolloController(ILogger<WhoUseeTolloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Employee
            {
                Name = "Steve",
                Gender = 1,
                Age = 40,
                Lucky = rng.Next(-20, 55) + index,
            })
            .ToArray();
        }

    }

}