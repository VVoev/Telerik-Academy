using Cars.Contracts;
using Cars.Data;
using Cars.Infrastructure;
using Cars.Models;
using System;
using System.Collections.Generic;

namespace Cars.Controllers
{
    public class CarControllers
    {
        private readonly ICarsRepository carsData;

        public CarControllers()
            :this(new CarsRepository())
        {

        }

        public CarControllers(ICarsRepository data)
        {
            this.carsData = data; 
        }

        public IView Index()
        {
            var cars = this.carsData.All();
            return new View(cars);
        }

        public IView Add(Car car)
        {
            if(car == null)
            {
                throw new ArgumentException("Car cannot be null"); 
            }
            if(string.IsNullOrEmpty(car.Make)|| string.IsNullOrEmpty(car.Model))
            {
                throw new ArgumentException("make and model are mandatory fields");
            }
            this.carsData.Add(car);
            return this.Details(car.ID);
        }
        public IView Details(int id)
        {
            var car = this.carsData.GetById(id);
            if(car== null)
            {
                throw new ArgumentException("Car", "Car cannot be null");
            }
            return new View(car);
        }

        public IView Search (string parameters)
        {
            var result = this.carsData.Search(parameters);
            return new View(result);
        }

        public IView Sort(string parameters)
        {
            ICollection<Car> results = null;

            switch (parameters)
            {
                case "make":results = this.carsData.SortedByMake();break;
                case "year":results = this.carsData.SortedByYear();break;
                default:throw new ArgumentException("Invalid sorting parameters");
            }
            return new View(results);
        }
    }
}
