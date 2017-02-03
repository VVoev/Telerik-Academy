using System;
using Zoo.Abstract;
using Zoo.Contracts;

namespace Zoo.Models
{
    public class Frog : Animal, IFrog
    {
        public int Jumps { get; set; }

        public Frog(string name,int age)
            :base(name, age)
        {

        }
    }
}
