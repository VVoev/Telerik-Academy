using System;

namespace _3.FactoryMethod.Product
{
    class Galaxy : GSM
    {
        public Galaxy()
        {
            this.Name = "Galaxy";
        }

        public override void Start()
        {
            Console.WriteLine("Booting Galaxy");
            Console.WriteLine("Welcome to your Samsung Galaxy");
        }
    }
}
