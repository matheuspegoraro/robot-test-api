using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Domain
{
    public class Robot
    {
        public RobotHead RobotHead { get; set; } = new RobotHead();
        public RobotBody RobotBody { get; set; } = new RobotBody();
    }
}
