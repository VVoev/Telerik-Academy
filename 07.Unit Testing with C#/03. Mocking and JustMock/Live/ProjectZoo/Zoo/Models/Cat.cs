using System;
using Zoo.Abstract;
using Zoo.Contracts;

namespace Zoo.Models
{
    public class Cat : Animal, ICat
    {
        public int NumberOfLegs { get; }

        public string SkinColour { get; }

        public Cat(string name,int age)
            :base(name, age)
        {
            
        }
    }
}
