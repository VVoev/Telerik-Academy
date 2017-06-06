using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Decorator
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    public abstract class Decorator : LibraryItem
    {
        protected LibraryItem Item { get; set; }

        protected Decorator(LibraryItem item)
        {
            this.Item = item;
        }

        public override void Display()
        {
            this.Item.Display();
        }
    }
}
