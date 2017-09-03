using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.Train
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = line[0];
            int m = line[1];

            var orderedBag = new OrderedBag<int>();

            var tickets = new Interval[n];
            for (int i = 0; i < n; i++)
            {
                var passengerInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                tickets[i] = new Interval(passengerInfo[0], passengerInfo[1]);
            }

            Array.Sort(tickets, (a, b) => a.Start.CompareTo(b.Start));

            var selectedTickets = new OrderedBag<int>();
            int result = 0;
            foreach (var ticket in tickets)
            {
                while (selectedTickets.Count > 0 && selectedTickets.GetFirst() <= ticket.Start)
                {
                    selectedTickets.RemoveFirst();
                    result++;
                }

                selectedTickets.Add(ticket.End);
                if (selectedTickets.Count > m)
                {
                    selectedTickets.RemoveLast();
                }
            }

            result += selectedTickets.Count;
            Console.WriteLine(result);
        }
    }

    public class Interval
    {
        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; set; }

        public int End { get; set; }
    }
}
