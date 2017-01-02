namespace AcademyEcosystem.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lion : Animal, ICarnivore
    {
        private const int sizeOfLion = 6;

        public Lion(string name, Point location)
            : base(name, location, sizeOfLion)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            int quantityOfEatenMeat = 0;
            if (animal != null)
            {
                if (this.Size * 2 >= animal.Size)
                {
                    quantityOfEatenMeat = animal.GetMeatFromKillQuantity();
                    this.Size++;
                }
            }
            return quantityOfEatenMeat;
        }
    }
}
