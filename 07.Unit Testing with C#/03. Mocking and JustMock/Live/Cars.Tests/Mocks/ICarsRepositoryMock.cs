using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Tests.Mocks
{
    public interface ICarsRepositoryMock
    {
        ICarsRepository CarsData { get; }
    }
}
