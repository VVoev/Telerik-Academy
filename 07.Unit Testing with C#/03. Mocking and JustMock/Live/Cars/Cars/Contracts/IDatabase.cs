using Cars.Models;
using System.Collections.Generic;

namespace Cars.Contracts
{
    public  interface IDatabase
    {
        IList<Car> Cars { get; set; }
    }
}
