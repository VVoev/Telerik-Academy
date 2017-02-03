using System.Collections.Generic;
using Cars.Contracts;
using Cars.Models;

namespace Cars.Tests.Mocks
{
    public abstract class CarsRepositoryMock : ICarsRepositoryMock
    {
        protected CarsRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public ICarsRepository CarsData { get; protected set; }

        protected ICollection<Car> FakeCarCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeCarCollection = new List<Car>
            {
                new Car {ID=1,Make="Audi",Model="A8",Year=2010 },
                new Car {ID=2,Make="Opel",Model="Astra",Year=2013 },
                new Car {ID=3,Make="BMW",Model="550i",Year=2011 },
                new Car {ID=4,Make="Volkswagen",Model="Golf GTi",Year=2002 },
            };
        }

        protected abstract void ArrangeCarsRepositoryMock();
    }
}
