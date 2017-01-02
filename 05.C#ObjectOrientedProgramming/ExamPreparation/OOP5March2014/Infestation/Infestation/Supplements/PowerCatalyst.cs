namespace Infestation.Supplements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PowerCatalyst : Catalyst
    {
        private const int powerEffect = 3;

        public PowerCatalyst()
            : base(0,PowerCatalyst.powerEffect,0)
        {

        }
    }
}
