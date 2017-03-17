using System;
using Contacts;

namespace Models
{
    public class Bowl : ITableware
    {
        public void Add(IIengidient ingredient)
        {
            Console.WriteLine($@"Adding {ingredient.GetType().Name} to the soup");
        }
    }
}
