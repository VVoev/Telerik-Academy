using System;
using System.Collections.Generic;

namespace _5.Builder
{
    /// <summary>
    /// The 'Product' class
    /// Represents the complex object under construction
    /// </summary>
    public class Vehichle
    {
        private readonly string vehickleType;
        private readonly Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehichle(string vehichleType)
        {
            this.vehickleType = vehichleType;
        }

        public string this[string key]
        {
            get
            {
                return this.parts[key];
            }
            set
            {
                this.parts[key] = value;
            }
        }

        public void Show()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Vehicle Type: {0}", this.vehickleType);
            Console.WriteLine(" Frame  : {0}", this["frame"]);
            Console.WriteLine(" Engine : {0}", this["engine"]);
            Console.WriteLine(" #Wheels: {0}", this["wheels"]);
            Console.WriteLine(" #Doors : {0}", this["doors"]);
        }
    }
}
