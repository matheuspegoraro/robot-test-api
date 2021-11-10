using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotBecomex.Domain;
using RobotBecomex.Helper.Exceptions;
using RobotBecomex.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotBecomex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotHeadController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;

        private readonly IRobotHeadService robotHeadService;

        public RobotHeadController(ILogger<RobotController> logger, IRobotHeadService _robotHeadService)
        {
            _logger = logger;
            robotHeadService = _robotHeadService;
        }

        [HttpPut("IncreaseInclination")]
        public async Task<ActionResult<Robot>> IncreaseInclination()
        {
            try
            {
                return Ok(await robotHeadService.IncreaseInclination());
            }
            catch (InvalidInclinationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("DecreaseInclination")]
        public async Task<ActionResult<Robot>> DecreaseInclination()
        {
            try
            {
                return Ok(await robotHeadService.DecreaseInclination());
            }
            catch (InvalidInclinationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("IncreaseRotation")]
        public async Task<ActionResult<Robot>> IncreaseRotation()
        {
            try
            {
                return Ok(await robotHeadService.IncreaseRotation());
            }
            catch (InvalidRotationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("DecreaseRotation")]
        public async Task<ActionResult<Robot>> DecreaseRotation()
        {
            try
            {
                return Ok(await robotHeadService.DecreaseRotation());
            }
            catch (InvalidRotationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
