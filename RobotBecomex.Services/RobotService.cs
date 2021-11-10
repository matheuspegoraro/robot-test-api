using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotBecomex.Domain;
using RobotBecomex.Repository.Interfaces;
using RobotBecomex.Service.Interfaces;

namespace RobotBecomex.Service
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository robotRepository;

        public RobotService(IRobotRepository _robotRepository)
        {
            robotRepository = _robotRepository;
        }

        public async Task<Robot> Reset()
        {
            return await robotRepository.Reset();
        }

        public async Task<Robot> Get()
        {
            return await robotRepository.Get();
        }
    }
}
