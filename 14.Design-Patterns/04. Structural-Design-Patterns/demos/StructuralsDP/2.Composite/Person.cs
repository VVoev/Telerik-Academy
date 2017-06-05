using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Composite
{
    class Person : PersonComponent
    {
        public Person(string name) : base(name)
        {
        }

        public override void Display(int deapth)
        {
            Console.WriteLine(new string('-',deapth));
        }
    }
}
