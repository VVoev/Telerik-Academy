using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketQueue
{
    public class Program
    {
        public static void Main()
        {
            var supermarket = new Supermarket();

            var result = new StringBuilder();
 
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ');

                string commandName = line[0];
                if (commandName == "End")
                {
                    break;
                }

                if (commandName == "Append")
                {
                    result.AppendLine(supermarket.Append(line[1]));
                }
                else if (commandName == "Insert")
                {
                    result.AppendLine(supermarket.Insert(int.Parse(line[1]), line[2]));
                }
                else if (commandName == "Find")
                {
                    result.AppendLine(supermarket.Find(line[1]).ToString());
                }
                else if (commandName == "Serve")
                {
                    result.AppendLine(supermarket.Serve(int.Parse(line[1])));
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class Supermarket
    {
        public int startIndex;

        public Supermarket()
        {
            this.Waiting = new Dictionary<string, int>();
            this.Queue = new List<string>();
            this.startIndex = 0;
        }

        public Dictionary<string, int> Waiting { get; set; }

        public List<string> Queue { get; set; }

        public int Find(string name)
        {
            if (this.Waiting.ContainsKey(name))
            {
                return this.Waiting[name];
            }

            return 0;
        }

        public string Insert(int position, string name)
        {
            if (position < 0 || this.startIndex + position > this.Queue.Count)
            {
                return "Error";
            }

            position += this.startIndex;

            this.Queue.Insert(position, name);
            if (this.Waiting.ContainsKey(name))
            {
                this.Waiting[name]++;
            }
            else
            {
                this.Waiting[name] = 1;
            }

            return "OK";
        }

        public string Append(string name)
        {
            this.Queue.Add(name);
            if (this.Waiting.ContainsKey(name))
            {
                this.Waiting[name]++;
            }
            else
            {
                this.Waiting[name] = 1;
            }

            return "OK";
        }

        public string Serve(int count)
        {
            if (this.startIndex + count > this.Queue.Count)
            {
                return "Error";
            }

            var builder = new StringBuilder();
            for (int i = startIndex; i < count + startIndex; i++)
            {
                if (this.Waiting.ContainsKey(this.Queue[i]) && this.Waiting[this.Queue[i]] > 0)
                {
                    this.Waiting[this.Queue[i]]--;
                }

                builder.Append(this.Queue[i] + " ");
            }

            this.startIndex += count;
            return builder.ToString().Trim();
        }
    }
}
