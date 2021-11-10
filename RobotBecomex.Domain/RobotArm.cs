using RobotBecomex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Domain
{
    public class RobotArm
    {
        public ElbowMovimentationEnum Elbow { get; set; } = ElbowMovimentationEnum.InRest;
        public WristMovimentationEnum Wrist { get; set; } = WristMovimentationEnum.InRest;
    }
}
