using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new CofeeShop();
            var kafence = shop.ServeCofee(7, true, CofeeTypes.Black);
            var torta = shop.ServeCake(CakeType.Strawberry);
        }
    }



    interface ICofee
    {
        int Grams { get; set; }

        bool isSugar { get; set; }
    }

    class Cofee : ICofee
    {
        public int Grams { get; set; }

        public bool isSugar { get; set; }

        public CofeeTypes type { get; set; }

        private readonly ICofee cofee;

        public Cofee(int grams, bool anySugar, CofeeTypes cofeeType)
        {
            this.Grams = grams;
            this.isSugar = anySugar;
            this.type = cofeeType;
            this.cofee = cofee;
        }
    }

    class Cake
    {
        public CakeType Type { get; set; }

        public Cake(CakeType type)
        {
            this.Type = type;
        }
    }

    class CofeeShop : IShop
    {
        public CofeeShop()
        {
        }

        public Cake ServeCake(CakeType type)
        {
            return new Cake(type);
        }

        public Cofee ServeCofee(int grams, bool isSugar, CofeeTypes type)
        {
            return new Cofee(grams, isSugar, type);
        }
    }

    interface ICofeeShop
    {
        Cofee ServeCofee(int grams, bool isSugar, CofeeTypes type);
    }

    interface ICakeShop
    {
        Cake ServeCake(CakeType type);
    }

    interface IShop : ICakeShop,ICofeeShop
    {

    }

    enum CofeeTypes
    {
        Black,
        White,
        Capuchino,
        Makiato
    }
    enum CakeType
    {
        Cheese,
        Strawberry,
        Vanilla
    }
}
