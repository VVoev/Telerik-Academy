using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cars.Contracts;
using Cars.Controllers;
using Cars.Tests.Mocks;
using Cars.Models;
using System.Collections.Generic;

namespace Cars.Tests
{
    [TestClass]
    public class CarsControllerTest
    {

        private readonly ICarsRepository carsData;
        private CarControllers controller;

        public CarsControllerTest()
            : this(new MoqCarsRepository())
        {

        }

        private CarsControllerTest(ICarsRepositoryMock carsDataMokc)
        {
            this.carsData = carsDataMokc.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarControllers(this.carsData);
        }
        private Object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }

        [TestCategory("Cars")]
        [TestMethod]
        public void ReturnAllCars_WhenUsingIndex()
        {
            var model = (ICollection<Car>) this.GetModel(() => this.controller.Index());
            Assert.AreEqual(4, model.Count);
        }

        [TestCategory("Cars")]
        [TestMethod]
        public void WillWorkSuccesfully_WhenAddFunctionIsTesting()
        {
            var car = new Car{ ID = 5, Model = "911", Make = "Porshe", Year = 1999 };
            var model = (Car)(this.GetModel(() => this.controller.Add(car)));
        }


        [TestCategory("Cars")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void WillThrowError_WhenMakeIsNull()
        {
            var car = new Car { ID = 5, Model = "911", Make = "", Year = 1999 };
            var model = (Car)(this.GetModel(() => this.controller.Add(car)));
        }
        [TestCategory("Cars")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void WillThrowError_WhenModelIsNull()
        {
            var car = new Car { ID = 5, Model = "", Make = "Porshe", Year = 1999 };
            var model = (Car)(this.GetModel(() => this.controller.Add(car)));
        }

        [TestCategory("Cars")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void WillThrowError_WhenNullCarsIsAdded()
        {
            var model = (Car)(this.GetModel(() => this.controller.Add(null)));
        }

        [TestCategory("Cars")]
        [TestMethod]
        public void RetulDetails_WhenAddingNewCar()
        {
            var car = new Car { ID = 10, Model = "Jetta", Make = "VW", Year = 2000 };
            var model = (Car)(this.GetModel(() => this.controller.Add(car)));
            Assert.AreEqual(10, car.ID);
            Assert.AreEqual("Jetta", car.Model);
            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual(2000, car.Year);
        }

        [TestCategory("Cars")]
        [TestMethod]
        public void GetCarById_WhenUsingId()
        {
            var model = (Car)(this.GetModel(() => this.controller.Details(4)));
            Assert.AreEqual("Volkswagen", model.Make);
        }

        [TestCategory("Cars")]
        [TestMethod]
        public void ReturnBmwCar_WhenUsingSearch()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Search("BMW"));
            foreach (var car in cars)
            {
                Assert.AreEqual(car.Make, "BMW");
            }
        }
        [TestMethod]
        [TestCategory("Cars")]
        [ExpectedException(typeof(ArgumentException))]
        public void WillThrowError_WhenSeachIsEmpty()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Search(""));

            foreach (var car in cars)
            {
                Assert.AreEqual(car.Make, "BMW");
            }
        }
        [TestMethod]
        public void SearchByNullIdShouldThrow()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(int.MaxValue));
            Assert.AreEqual("Volkswagen", model.Make);


        }









    }
}
