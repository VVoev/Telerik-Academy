using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using Telerik.JustMock;
using Zoo.Abstract;
using Zoo.Contracts;
using Zoo.Models;
using Zoo.Tests.Mocks;

namespace Zoo.Tests
{
    [TestClass]
    public class ZooTest
    {

        private readonly IZoo data;

        private ZooTest(TelerikMockZoo mockdata)
        {
            this.data = mockdata.ZooData;
        }
        public ZooTest()
            :this(new TelerikMockZoo())
        {

        }
        [TestMethod]
        [TestCategory("Zoo")]
        public void ZooSuccesfullyCreated()
        {
            var zoo = new Models.Zoo();
        }

        [TestMethod]
        [TestCategory("Zoo")]
        public void AnimalCountIncrease_WhenAddingNewAnimal()
        {
            var zoo = new Models.Zoo();
            var cat = new Cat("Djingal", 1);
            zoo.add(cat);
            Assert.AreEqual(1, zoo.TotalAnimal);
        }

        [TestMethod]
        [TestCategory("Zoo")]
        public void AnimalCountIncrease_WhenAddingNewAnimal1()
        {
            var cat = new Cat("Mol", 1);
            this.data.add(cat);
            Assert.AreEqual(this.data.TotalAnimal,6);
        }

        [TestMethod]
        [TestCategory("Zoo")]
       public void RemoveWillBeInitiatedOnlyOnce()
        {
            var dog = Mock.Create<Dog>();
            var dog1 = Mock.Create<Dog>();

            this.data.add(dog);
            this.data.add(dog1);
            this.data.Remove(dog);

            //TODO finish later



        }







    }
}
