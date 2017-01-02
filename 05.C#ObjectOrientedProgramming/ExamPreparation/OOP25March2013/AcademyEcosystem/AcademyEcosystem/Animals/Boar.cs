namespace AcademyEcosystem.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Boar : Animal, IHerbivore, ICarnivore
    {
        private int biteSize;
        private const int boarSize = 4;

        public Boar(string name, Point location)
            : base(name, location, boarSize)
        {
            this.biteSize = 2;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            int quantityOfEatenMeat = 0;
            if (animal != null)
            {
                if (this.Size >= animal.Size)
                {
                    quantityOfEatenMeat = animal.GetMeatFromKillQuantity();
                }
            }
            return quantityOfEatenMeat;
        }
    }
}
