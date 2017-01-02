namespace AcademyEcosystem.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wolf : Animal, ICarnivore
    {
        private const int sizeOfWolf = 4;

        public Wolf(string name, Point location)
            : base(name, location, sizeOfWolf)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            int quantityOfEatenMeat = 0;
            if (animal != null)
            {
                if (this.Size >= animal.Size || 
                    animal.State == AnimalState.Sleeping)
                {
                    quantityOfEatenMeat = animal.GetMeatFromKillQuantity();
                }
            }
            return quantityOfEatenMeat;
        }
    }
}
