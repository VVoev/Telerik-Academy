using System;
using Zoo.Abstract;
using Zoo.Contracts;
using Zoo.Enumerations;

namespace Zoo.Models
{
    public class Dog : Animal, IDog
    {
        public DogBreed Breed { get; protected set; }

        public bool CanByte { get;  set; }

        public bool IsitPuppy { get; protected set; }

        public Dog(string name,int age,DogBreed breed)
            :base(name, age)
        {

        }
        public override string Hello()
        {
            return $"{this.Name} say bay"; 
        }
    }
}
