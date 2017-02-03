using System.Collections.Generic;
using Zoo.Abstract;

namespace Zoo.Contracts
{
   public interface IZoo
    {
        int TotalAnimal { get; }

        void add(Animal animal);

        void Remove(Animal animal);

        ICollection<Animal> All();

        ICollection<Animal> SortedByName();

        ICollection<Animal> SortedByAge();
    }
}
