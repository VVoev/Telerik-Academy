using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Abstract;
using Zoo.Contracts;

namespace Zoo.Models
{
    public class Zoo : IZoo
    {
        private ICollection<Animal> animalList;

        public ICollection<Animal> AnimalList
        {
            get
            {
                return this.animalList;
            }
            set
            {
                this.animalList = value;
            }
        }
        public int TotalAnimal
        {
            get { return this.animalList.Count; }
        }

        public void add(Animal animal)
        {
            this.animalList.Add(animal);
        }

        public ICollection<Animal> All()
        {
            return new List<Animal>(this.animalList);
        }



        public void Remove(Animal animal)
        {
            this.animalList.Remove(animal);
        }

        public ICollection<Animal> SortedByAge()
        {
            return this.animalList.OrderBy(x => x.Age).ToList();
        }

        public ICollection<Animal> SortedByName()
        {
            return this.animalList.OrderBy(x => x.Name).ToList();
        }

        public Zoo()
        {
            this.animalList = new List<Animal>();
        }
    }
}
