namespace AcademyRPG.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class House : StaticObject
    {
        private const int houseHitPoints = 500;

        public House(Point position, int owner) : base(position, owner)
        {
            this.HitPoints = houseHitPoints;
        }
    }
}
