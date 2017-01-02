using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DragonArmy
{

    public class DragonArmy
    {
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
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> dragons = new List<string>();
            var dragonArmy = new SortedDictionary<string, int[]>();
            double currentDamage = 0;
            double currentHealth = 0;
            double currentArmor = 0;
            for (int i = 0; i < n; i++)
            {
                string[] inputline = Console.ReadLine().Split(' ').ToArray();

                string currentDragonName = inputline[0];
                string currentDragonType = inputline[1];
                if (inputline[2] != "null")
                {
                    currentDamage = double.Parse(inputline[2]);
                }
                else
                {
                    currentDamage = 45;
                }
                if (inputline[3] != "null")
                {
                    currentHealth = double.Parse(inputline[3]);
                }
                else
                {
                    currentHealth = 250;
                }
                if (inputline[4] != "null")
                {
                    currentArmor = double.Parse(inputline[4]);
                }
                else
                {
                    currentArmor = 10;
                }

                Dragon currentDragon = new Dragon(currentDragonName, currentDragonType, currentDamage, currentHealth, currentArmor);

                if (!dragons.Contains(currentDragon.DragonName))
                {
                    dragons.Add(currentDragon.DragonName);
                }
                string dragonNameAndType = currentDragon.DragonName + " " + currentDragon.DragonType;

                if (dragonArmy.ContainsKey(dragonNameAndType))
                {
                    dragonArmy[dragonNameAndType][0] = (int)currentDragon.Damage;
                    dragonArmy[dragonNameAndType][1] = (int)currentDragon.Health;
                    dragonArmy[dragonNameAndType][2] = (int)currentDragon.Armor;
                }
                else
                {
                    dragonArmy.Add(dragonNameAndType, new int[4]);
                    dragonArmy[dragonNameAndType][0] = (int)currentDragon.Damage;
                    dragonArmy[dragonNameAndType][1] = (int)currentDragon.Health;
                    dragonArmy[dragonNameAndType][2] = (int)currentDragon.Armor;
                    dragonArmy[dragonNameAndType][3]++;

                }
            }

            foreach (var item in dragons)
            {
                var output = new StringBuilder();
                int count = 0;
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;
                foreach (var dragon in dragonArmy)
                {
                    string[] split = dragon.Key.Split(' ').ToArray();
                    if (split[0] == item)
                    {
                        avgDamage += dragon.Value[0];
                        avgHealth += dragon.Value[1];
                        avgArmor += dragon.Value[2];
                        count++;
                        output.AppendLine("-" + split[1] + " -> damage: " + dragon.Value[0]
                            + ", health: " + dragon.Value[1] + ", armor: " + dragon.Value[2]);
                    }
                }
                avgDamage /= count;
                avgHealth /= count;
                avgArmor /= count;

                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})"
                                  , item
                                  , avgDamage
                                  , avgHealth
                                  , avgArmor);
                Console.WriteLine(string.Join(Environment.NewLine, output.ToString().Substring(0, output.Length - 1)));
            }
        }
    }
}
