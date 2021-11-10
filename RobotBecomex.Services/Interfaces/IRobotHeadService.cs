using RobotBecomex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Service.Interfaces
{
    public interface IRobotHeadService
    {
        Task<Robot> IncreaseRotation();
        Task<Robot> DecreaseRotation();
        Task<Robot> IncreaseInclination();
        Task<Robot> DecreaseInclination();
    }
}
