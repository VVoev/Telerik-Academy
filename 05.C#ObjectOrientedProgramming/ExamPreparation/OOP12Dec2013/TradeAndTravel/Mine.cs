namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Mine : GatheringLocation
    {
        public Mine(string name)
     : base(name, LocationType.Mine, ItemType.Wood, ItemType.Weapon)
        {

        }

        public override Item ProduceItem(string name)
        {
            return new Wood(name, null);
        }
    }
}
