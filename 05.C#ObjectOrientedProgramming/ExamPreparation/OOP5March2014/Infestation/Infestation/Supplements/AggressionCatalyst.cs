namespace Infestation.Supplements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AggressionCatalyst : Catalyst
    {
        private const int aggressionEffect = 3;

        public AggressionCatalyst()
            : base(0, 0, AggressionCatalyst.aggressionEffect)
        {

        }
        
    }
}
