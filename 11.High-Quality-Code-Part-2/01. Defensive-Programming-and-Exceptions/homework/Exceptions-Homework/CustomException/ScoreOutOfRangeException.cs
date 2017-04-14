using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_Homework.CustomException
{
    class ScoreOutOfRangeException : Exception
    {
        public ScoreOutOfRangeException(string message) : base(message)
        {
        }
    }
}
