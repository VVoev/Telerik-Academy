using Cars.Contracts;
using System.Collections.Generic;
using Cars.Models;

namespace Cars.Data
{
    public class Database : IDatabase
    {
        public IList<Car> Cars { get; set; }
    }
}
