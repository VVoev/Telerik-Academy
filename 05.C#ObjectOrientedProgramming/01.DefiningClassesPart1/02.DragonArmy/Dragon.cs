namespace _02.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dragon
    {
        private string dragonName;
        private string dragonType;
        private double? damage;
        private double? health;
        private double? armor;

        public string DragonName
        {
            get { return this.dragonName; }
            set { this.dragonName = value; }
        }

        public string DragonType
        {
            get { return this.dragonType; }
            set { this.dragonType = value; }

        }

        public double Damage
        {
            get { return (double)this.damage; }
            set
            {
                this.damage = value;
            }
        }

        public double Health
        {
            get { return (double)this.health; }
            set
            {
                this.health = value;
            }
        }

        public double Armor
        {
            get { return (double)this.armor; }

            set
            {
                this.armor = value;
            }
        }

        public Dragon(string dragonName, string dragonType, double damage, double health, double armor)
        {
            this.DragonName = dragonName;
            this.DragonType = dragonType;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }

}
