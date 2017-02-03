using System;
using System.Linq;
using Telerik.JustMock;
using Zoo.Abstract;
using Zoo.Contracts;

namespace Zoo.Tests.Mocks
{
    public class TelerikMockZoo : ZooMock
    {
        protected override void ArrangeZooMock()
        {
            this.ZooData = Mock.Create<IZoo>();
            Mock.Arrange(() => this.ZooData.add(Arg.IsAny<Animal>())).DoNothing();
            Mock.Arrange(() => this.ZooData.All()).Returns(this.fakeZoo);
            Mock.Arrange(() => this.ZooData.SortedByName()).Returns(this.fakeZoo.OrderBy(x => x.Name.Length > x.Name.Length).ToList());
            Mock.Arrange(() => this.ZooData.SortedByAge()).Returns(this.fakeZoo.OrderBy(x => x.Age > x.Age).ToList());
            Mock.Arrange(() => this.ZooData.Remove(Arg.IsAny<Animal>())).OccursOnce();
            Mock.Arrange(() => this.ZooData.TotalAnimal).Returns(this.fakeZoo.Count);
        }
    }
}
