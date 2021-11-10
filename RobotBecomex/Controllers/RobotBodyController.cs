using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotBecomex.Domain;
using RobotBecomex.Domain.Enums;
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
    public class RobotBodyController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;

        private readonly IRobotBodyService RobotBodyService;

        public RobotBodyController(ILogger<RobotController> logger, IRobotBodyService _RobotBodyService)
        {
            _logger = logger;
            RobotBodyService = _RobotBodyService;
        }

        [HttpPut("IncreaseElbow")]
        public async Task<ActionResult<Robot>> IncreaseElbow([FromForm] ArmEnum arm)
        {
            try
            {
                return Ok(await RobotBodyService.IncreaseElbow(arm));
            }
            catch (InvalidElbowMovimentationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("DecreaseElbow")]
        public async Task<ActionResult<Robot>> DecreaseElbow([FromForm] ArmEnum arm)
        {
            try
            {
                return Ok(await RobotBodyService.DecreaseElbow(arm));
            }
            catch (InvalidElbowMovimentationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("IncreaseWrist")]
        public async Task<ActionResult<Robot>> IncreaseWrist([FromForm] ArmEnum arm)
        {
            try
            {
                return Ok(await RobotBodyService.IncreaseWrist(arm));
            }
            catch (InvalidWristMovimentationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("DecreaseWrist")]
        public async Task<ActionResult<Robot>> DecreaseWrist([FromForm] ArmEnum arm)
        {
            try
            {
                return Ok(await RobotBodyService.DecreaseWrist(arm));
            }
            catch (InvalidWristMovimentationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
