using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBecomex.Helper.Exceptions
{
    public class InvalidElbowMovimentationException : Exception
    {
        public InvalidElbowMovimentationException() : base("Movimento de cotovelo inválido!")
        {
        }
    }
}
