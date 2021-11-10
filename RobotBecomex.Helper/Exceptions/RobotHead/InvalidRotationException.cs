using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Helper.Exceptions
{
    public class InvalidRotationException : Exception
    {
        public InvalidRotationException() : base("Movimento de rotação inválida!")
        {
        }
    }
}
