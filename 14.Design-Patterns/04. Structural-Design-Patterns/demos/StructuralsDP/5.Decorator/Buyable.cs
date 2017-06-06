using System;

namespace _5.Decorator
{
    public class Buyable : Borrowable
    {
        private int price;

        public Buyable(LibraryItem item,int price) : base(item)
        {
            this.price = price;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($@"Price + {this.price}");
        }
    }
}
