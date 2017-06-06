using System;
using System.Collections.Generic;

namespace _5.Decorator
{
    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    public class Borrowable : Decorator
    {
        private readonly List<string> borowers = new List<string>();


        public Borrowable(LibraryItem item) : base(item)
        {

        }

        public void BorrowItem(string name)
        {
            this.borowers.Add(name);
            this.Item.CopiesCount--;
        }

        public void ReturnItem(string name)
        {
            this.borowers.Remove(name);
            this.Item.CopiesCount++;
        }

        public override void Display()
        {
            base.Display();
            foreach (var borower in this.borowers)
            {
                Console.WriteLine($@"Borower: {borower}");
            }
        }
    }
}