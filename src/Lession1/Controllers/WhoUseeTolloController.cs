using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lession1.Controllers
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
        public string Get()
        {
            return "Steve";
        }
    }

}
