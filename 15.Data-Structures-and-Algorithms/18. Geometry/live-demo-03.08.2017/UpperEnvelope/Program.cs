using System;
using System.Collections.Generic;
using System.Linq;

namespace UpperEnvelope
{
    class Program
    {
        static void Main()
        {
            var rnd = new Random(42);
            var lines = Enumerable.Range(0, 100000)
                .Select(x => Line.GenLine(rnd))
                .ToArray();

            lines = new Line[]
                {
                    new Line(-1,0),
                    new Line(0,7),
                    new Line(1,0),
                    new Line(0.3,-5)
                };

            Array.Sort(lines, Line.AngleComparer);

            var envelope = new List<int>();
            envelope.Add(0);

            for (int i = 1; i < lines.Length; ++i)
            {
                while (envelope.Count > 1)
                {
                    var prev = lines[envelope[envelope.Count - 2]]
                        .IntersectionWith(
                                lines[envelope[envelope.Count - 1]]);
                    var curr = lines[envelope[envelope.Count - 1]]
                        .IntersectionWith(lines[i]);

                    if (prev < curr)
                    {
                        break;
                    }

                    envelope.RemoveAt(envelope.Count - 1);
                }

                envelope.Add(i);
            }

            Console.WriteLine(string.Join(" ", envelope));

            foreach (var i in envelope)
            {
                Console.WriteLine($"{lines[i].A} {lines[i].B}");
            }
        }
    }
}
