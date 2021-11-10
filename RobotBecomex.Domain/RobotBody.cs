using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Domain
{
    public class RobotBody
    {
        public RobotArm RobotLeftArm { get; set; } = new RobotArm();
        public RobotArm RobotRightArm { get; set; } = new RobotArm();
    }
}
