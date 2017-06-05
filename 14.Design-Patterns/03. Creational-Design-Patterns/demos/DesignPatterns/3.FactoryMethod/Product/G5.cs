using System;

namespace _3.FactoryMethod.Product
{
    public class G5 : GSM
    {
        public G5()
        {
            this.Name = "G5";
        }

        public override void Start()
        {
            Console.WriteLine("Booting G5");
            Console.WriteLine("Welcome to your G5");
        }
    }
}
