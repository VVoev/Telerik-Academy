using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_Homework.CustomException
{
    public class NumberISNotPrime : Exception
    {
        public NumberISNotPrime(string message) : base(message)
        {
        }
    }
}
