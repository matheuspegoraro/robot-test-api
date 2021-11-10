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
    public class RobotBodyService : IRobotBodyService
    {
        private readonly IRobotBodyRepository robotBodyRepository;

        public RobotBodyService(IRobotBodyRepository _robotBodyRepository)
        {
            robotBodyRepository = _robotBodyRepository;
        }
        
        public async Task<Robot> IncreaseElbow(ArmEnum arm)
        {
            return await robotBodyRepository.Increase<ElbowMovimentationEnum>(arm);
        }

        public async Task<Robot> DecreaseElbow(ArmEnum arm)
        {
            return await robotBodyRepository.Decrease<ElbowMovimentationEnum>(arm);
        }

        public async Task<Robot> IncreaseWrist(ArmEnum arm)
        {
            return await robotBodyRepository.Increase<WristMovimentationEnum>(arm);
        }

        public async Task<Robot> DecreaseWrist(ArmEnum arm)
        {
            return await robotBodyRepository.Decrease<WristMovimentationEnum>(arm);
        }
    }
}
