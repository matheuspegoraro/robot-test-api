using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotBecomex.Domain;
using RobotBecomex.Domain.Enums;
using RobotBecomex.Repository.Interfaces;
using RobotBecomex.Service.Interfaces;

namespace RobotBecomex.Service
{
    public class RobotHeadService : IRobotHeadService
    {
        private readonly IRobotHeadRepository robotHeadRepository;

        public RobotHeadService(IRobotHeadRepository _robotHeadRepository)
        {
            robotHeadRepository = _robotHeadRepository;
        }

        public async Task<Robot> IncreaseRotation()
        {
            return await robotHeadRepository.Increase<HeadRotationEnum>();
        }

        public async Task<Robot> DecreaseRotation()
        {
            return await robotHeadRepository.Decrease<HeadRotationEnum>();
        }

        public async Task<Robot> IncreaseInclination()
        {
            return await robotHeadRepository.Increase<HeadInclinationEnum>();
        }

        public async Task<Robot> DecreaseInclination()
        {
            return await robotHeadRepository.Decrease<HeadInclinationEnum>();
        }
    }
}
