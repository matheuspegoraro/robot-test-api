using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotBecomex.Domain;
using RobotBecomex.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotBecomex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;

        private readonly IRobotService robotService;

        public RobotController(ILogger<RobotController> logger, IRobotService _robotService)
        {
            _logger = logger;
            robotService = _robotService;
        }

        [HttpGet]
        public async Task<ActionResult<Robot>> Get()
        {
            return Ok(await robotService.Get());
        }

        [HttpPut("Reset")]
        public async Task<ActionResult<Robot>> Reset()
        {
            return Ok(await robotService.Reset());
        }
    }
}
