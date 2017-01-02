using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, LocationType type, ItemType gatheredItemItem, ItemType requiredItemType)
            : base(name, type)
        {
            this.GatheredType = gatheredItemItem;
            this.RequiredItem = requiredItemType;
        }
        public virtual ItemType GatheredType { get; protected set; }

        public virtual ItemType RequiredItem { get; protected set; }

        public abstract Item ProduceItem(string name);
    }
}
