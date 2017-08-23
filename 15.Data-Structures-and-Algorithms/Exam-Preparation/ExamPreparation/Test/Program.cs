using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var konan = new Player(20,"Konan",Weapon.Sword);
            var archer = new Player(22,"Robin Hood",Weapon.Bow);

            konan.AttackOther(archer);
            konan.AttackOther(archer);
            konan.AttackOther(archer);
            konan.AttackOther(archer);
            konan.AttackOther(archer);
            archer.AttackOther(konan);

            

        }
    }

    class Player
    {
        private int healthPonts = 100;
        private HashSet<Player> enemys;

        public string Name;

        public int HealthPoints
        {
            get
            {
                if (this.HealthPoints <= 0)
                {
                    var killer = enemys.OrderBy((x => x.Name)).ToArray()[0];
                    Console.WriteLine($"{this.Name} is dead by {killer.Name} equiped with {killer.Weapon}");
                }
                return this.healthPonts;
            }
            private set
            { 
                this.healthPonts = value;
            }
        }

        public Weapon Weapon { get; set; }

        public int Damage { get; set; }

        public Player(int damage,string name,Weapon weapon)
        {
            this.Damage = damage;
            this.Name = name;
            this.Weapon = weapon;
            this.enemys = new HashSet<Player>();
        }

        public void AttackOther(Player otherPlayer)
        {
            this.enemys.Add(otherPlayer);
            this.healthPonts -= otherPlayer.Damage;
            otherPlayer.healthPonts -= this.Damage;
        }

    }

    enum Weapon
    {
        Sword,
        Bow
    }
}
