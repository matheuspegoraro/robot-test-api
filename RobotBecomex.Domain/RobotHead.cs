using RobotBecomex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Domain
{
    public class RobotHead
    {
        public HeadRotationEnum HeadRotation { get; set; } = HeadRotationEnum.InRest;
        public HeadInclinationEnum HeadInclination { get; set; } = HeadInclinationEnum.InRest;
    }
}
