using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Helper.Exceptions
{
    public class InvalidInclinationException : Exception
    {
        public InvalidInclinationException() : base("Movimento de inclinação inválida!")
        {
        }
    }
}
