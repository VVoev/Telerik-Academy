using System;

namespace _3.FactoryMethod.Product
{
    class Iphone7 : GSM
    {
        public Iphone7()
        {
            this.Name = "Apple Iphone 7 ";
        }
        public override void Start()
        {
            Console.WriteLine("Booting....");
            Console.WriteLine("Welcome to your Apple Iphone7");
        }
    }
}
