using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"..\..\cars.txt");


            //var cars = JsonConvert.DeserializeObject<Car>(text);
            var cars = JArray.Parse(text);
            foreach (var car in cars)
            {
                var currentCar = JsonConvert.DeserializeObject<Car>(car.ToString());
                Console.WriteLine(currentCar);
            }
            
        }
    }
}
