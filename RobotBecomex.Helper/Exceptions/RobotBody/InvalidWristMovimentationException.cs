using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Helper.Exceptions
{
    public class InvalidWristMovimentationException : Exception
    {
        public InvalidWristMovimentationException() : base("Movimento de pulso inválido!")
        {
        }
    }
}
