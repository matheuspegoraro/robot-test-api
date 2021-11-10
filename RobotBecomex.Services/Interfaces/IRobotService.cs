using RobotBecomex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Service.Interfaces
{
    public interface IRobotService
    {
        Task<Robot> Reset();
        Task<Robot> Get();
    }
}
