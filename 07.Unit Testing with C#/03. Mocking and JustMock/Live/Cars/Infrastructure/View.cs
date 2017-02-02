using System;
using Cars.Contracts;

namespace Cars.Infrastructure
{
    public class View : IView
    {
        public View(object model = null)
        {
            this.Model = model;
        }
        public object Model { get; private set; }
    }
}
