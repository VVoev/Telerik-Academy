using Cars.Contracts;
using System;
using System.Collections.Generic;
using Cars.Models;
using System.Linq;

namespace Cars.Data
{
    class CarsRepository : ICarsRepository
    {
        public CarsRepository()
            :this(new Database())
        {

        }

        public CarsRepository(IDatabase database)
        {
            this.Data = database;
        }

        protected IDatabase Data { get; set; }

        public int TotalCars
        {
            get
            {
                return this.Data.Cars.Count;
            }
        }

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null Cannot be Added");
            }
            this.Data.Cars.Add(car);
        }

        public ICollection<Car> All()
        {
            var all = this.Data.Cars.ToList();
            return all;
        }

        public Car GetById(int id)
        {
            var car = this.Data.Cars.FirstOrDefault(x => x.ID == id);
            if(car == null)
            {
                throw new ArgumentException("Car", "Car with such id doest not exist");
            }
            return car;
        }

        public void Remove(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null Car cannot be removed");
            }
            this.Data.Cars.Remove(car);
        }

        public ICollection<Car> Search(string condition)
        {
            if(string.IsNullOrEmpty(condition) || string.IsNullOrWhiteSpace(condition))
            {
                throw new ArgumentException("Please provide a proper condition");
            }
            return this.Data.Cars.Where(x => x.Make == condition || x.Model == condition).ToList();
        }

        public ICollection<Car> SortedByMake()
        {
            return this.Data.Cars.OrderBy(x => x.Make).ToList();
        }

        public ICollection<Car> SortedByYear()
        {
            return this.Data.Cars.OrderByDescending(x => x.Year).ToList();
        }
    }
}
