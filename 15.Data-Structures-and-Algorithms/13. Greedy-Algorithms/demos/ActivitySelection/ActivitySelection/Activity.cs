using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelection
{
    public class Activity : IComparable<Activity>
    {
        public Activity(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public int From { get; private set; }

        public int To { get; private set; }

        public int CompareTo(Activity other)
        {
            return this.To.CompareTo(other.To);
        }

        public bool IsCompatible(Activity other)
        {
            bool areIntersecting = (this.From <= other.From && this.To >= other.From) ||
                             (this.From <= other.To && this.To >= other.To) ||
                             (this.From >= other.From && this.To <= other.To) ||
                             (this.From <= other.From && this.To >= other.To);

            return !areIntersecting;
        }

        public override string ToString()
        {
            return string.Format("From {0:####} to {1:####}", this.From, this.To);
        }
    }
}