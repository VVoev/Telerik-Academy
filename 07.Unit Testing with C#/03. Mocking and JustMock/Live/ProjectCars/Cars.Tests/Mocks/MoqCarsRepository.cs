using Cars.Contracts;
using Cars.Models;
using Moq;
using System;
using System.Linq;

namespace Cars.Tests.Mocks
{
    public class MoqCarsRepository : CarsRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(x => x.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.LastOrDefault(x => x.ID == x.ID));
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
