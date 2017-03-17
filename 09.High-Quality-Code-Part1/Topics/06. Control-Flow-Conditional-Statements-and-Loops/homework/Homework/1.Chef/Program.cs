using Contacts;
using Models;

namespace ChefMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            IIengidient[] list = new IIengidient[] { new Carrot(), new Potato() };
            chef.Cook(list);
        }
    }
}
