namespace _03.AnimalHierarchy
{
    using AbstractClass;
    using Animals;
    using Animals.CatTypes;
    using Animals.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class AnimalHierarchyTest
    {
        static void Main()
        {
            // Create dogs.
            var nemskaOvcharka = new Dog("Sharo", 14, SexEnumeration.Male);
            var rotweiller = new Dog("Patrick", 10, SexEnumeration.Male);
            var dakel = new Dog("Beatrice", 9, SexEnumeration.Female);
            var huskey = new Dog("John", 4, SexEnumeration.Male);
            var pincher = new Dog("Ema", 14, SexEnumeration.Female);
            var dogs = new List<Dog>() { nemskaOvcharka,rotweiller,dakel,huskey,pincher};

            // Create frogs.
            var frog1 = new Frog("Lizi", 2, SexEnumeration.Female);
            var frog2 = new Frog("Peggy", 2, SexEnumeration.Female);
            var frog3 = new Frog("Budd", 2, SexEnumeration.Male);
            var frog4 = new Frog("Kelly", 2, SexEnumeration.Female);
            var frog5 = new Frog("Al", 2, SexEnumeration.Male);
            var frogs = new List<Frog>() { frog1, frog2, frog3, frog4, frog5 };

            // Create tomcats.
            var tomcat1 = new Tomcat("Tom", 12);
            var tomcat2 = new Tomcat("Garfield", 11);
            var tomcat3 = new Tomcat("Budd", 5);
            var tomcat4 = new Tomcat("Bruno", 7);
            var tomcat5 = new Tomcat("Al", 9);
            var tomcats = new List<Tomcat>() { tomcat1, tomcat2, tomcat3, tomcat4, tomcat5 };

            // Create kittens.
            var kitten1 = new Kitten("Tom", 12);
            var kitten2 = new Kitten("Garfield", 11);
            var kitten3 = new Kitten("Budd", 5);
            var kitten4 = new Kitten("Bruno", 7);
            var kitten5 = new Kitten("Al", 9);
            var kittens = new List<Kitten>() { kitten1, kitten2, kitten3, kitten4, kitten5 };

            // Add all animals to list.
            // Calculate average year.
            // Print sound of each type of animal.
            var animals = new List<Animal>();
            animals.AddRange(dogs);
            animals.AddRange(frogs);
            animals.AddRange(tomcats);
            animals.AddRange(kittens);
            var animalsAvg = animals.Average(x => x.Age);
            Console.WriteLine(kitten1.ToString());
            Console.WriteLine(tomcat1.ToString());
            Console.WriteLine(nemskaOvcharka.ToString());
            Console.WriteLine(frog1.ToString());
            Console.WriteLine("Average year of all animals: " + animalsAvg + "years.");
        }
    }
}
