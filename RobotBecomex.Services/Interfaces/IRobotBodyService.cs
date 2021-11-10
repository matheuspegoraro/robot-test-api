using RobotBecomex.Domain;
using RobotBecomex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Service.Interfaces
{
    public interface IRobotBodyService
    {
        Task<Robot> IncreaseElbow(ArmEnum arm);
        Task<Robot> DecreaseElbow(ArmEnum arm);
        Task<Robot> IncreaseWrist(ArmEnum arm);
        Task<Robot> DecreaseWrist(ArmEnum arm);
    }
}
