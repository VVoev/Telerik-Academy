namespace AcademyEcosystem.Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Grass : Plant
    {
        private const int sizeOfGrass = 2; 

        public Grass(Point location) : base(location, sizeOfGrass)
        {

        }

        public override void Update(int time)
        {
            if (time > 0 && this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}
