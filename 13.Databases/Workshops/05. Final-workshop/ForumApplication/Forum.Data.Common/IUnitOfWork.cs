using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    // IDisposable gives us syntactic sugar with the using keyword
    public interface IUnitOfWork : IDisposable
    {
        void Commit(); 
    }
}
