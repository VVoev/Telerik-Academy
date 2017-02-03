using Zoo.Models;
using System;

namespace Zoo.TestZoo
{
    public class TestZoo
    {
        public static void Go()
        {
            var cat = new Cat("Djingal", 1);
            var dog = new Dog("Penko", 2, Enumerations.DogBreed.Pudel);
            var frog = new Frog("Kermit", 8);

            var zoo = new Models.Zoo();
            zoo.add(cat);
            zoo.add(dog);
            zoo.add(frog);

            Console.WriteLine(zoo.AnimalList);
        }
    }
}
