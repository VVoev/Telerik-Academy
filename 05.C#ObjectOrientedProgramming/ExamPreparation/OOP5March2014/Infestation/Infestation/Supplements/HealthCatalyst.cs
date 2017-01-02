using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public class HealthCatalyst : Catalyst
    {
        private const int healthEffect = 3;

        public HealthCatalyst()
            : base(HealthCatalyst.healthEffect,0,0)
        {

        }
    }
}
