using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TGr_Carrying
{
    class Program
    {
        static void Main(string[] args)
        {
            var rooms = new List<Room>();
            var bagCappacity = int.Parse(Console.ReadLine());
            var b = Console.ReadLine();
            var roomsCapacity = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var room in roomsCapacity)
            {
                rooms.Add(new Room(room));
            }

            var robbedRooms = 0;
            for (int i = 0; i < roomsCapacity.Length; i++)
            {
                if (bagCappacity >= roomsCapacity[i])
                {
                    robbedRooms++;
                    bagCappacity -= roomsCapacity[i];
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(robbedRooms);
        }
    }

    class Room
    {
        public int Treasure { get; set; }

        public Room(int treasure)
        {
            this.Treasure = treasure;
        }
    }
}
