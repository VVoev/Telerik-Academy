using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var waiter = new Waiter();
            waiter.TakeOrder();
            var product = waiter.PassOrderToShop(shop);
            Console.WriteLine(product.Type + " " + product.IsSugar);


        }       
    }

    public class Waiter
    {
        private string type;
        private bool isSugar;
        public Waiter()
        {
        }

        public void TakeOrder()
        {
            Console.WriteLine("Please enter What KindOfCofee Do you want");
            type = Console.ReadLine();
            Console.WriteLine("Please enter do you want sugar");
            isSugar = bool.Parse(Console.ReadLine());
        }

        public Cofee PassOrderToShop(Shop shop)
        {
            var product = shop.MakeCofee(CofeeType.CAPUCHINO,isSugar);
            return product;
        }
    }

    public interface ICofeeFactory
    {
        Cofee MakeCofee(CofeeType type, bool isSugar);
    }

    public enum CofeeType
    {
        COFEE,
        CAPUCHINO,
        AMERICANO
    }

    public class Shop : ICofeeFactory
    {
        private Cofee order;
        public Cofee MakeCofee(CofeeType type, bool isSugar)
        {
            return new Cofee(type, isSugar);
        }

        internal void Serve()
        {
            throw new NotImplementedException();
        }

        public Shop()
        {

        }
    }

    public class Cofee
    {
        public CofeeType Type { get; set; }

        public bool IsSugar { get; set; }

        public Cofee(CofeeType type,bool isSugar)
        {
            this.Type = type;
            this.IsSugar = isSugar;
        }
    }
}
