using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotBecomex.Domain;
using RobotBecomex.Domain.Enums;

namespace RobotBecomex.Repository.Interfaces
{
    public interface IRobotHeadRepository
    {
        Task<Robot> Increase<T>();
        Task<Robot> Decrease<T>();
    }
}
