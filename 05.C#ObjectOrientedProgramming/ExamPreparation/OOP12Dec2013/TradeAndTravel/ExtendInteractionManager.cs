using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendInteractionManager : InteractionManager
    {
        public ExtendInteractionManager()
        {

        }
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords[2],commandWords[3], actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string craftItemType, string craftItemName, Person actor)
        {
            if (craftItemType.Equals("armor"))
            {
                if (actor.ListInventory().Any(x => x.ItemType == ItemType.Iron))
                {
                    this.AddToPerson(actor, new Armor(craftItemName));
                }
                
            }
            else if (craftItemType.Equals("weapon"))
            {
                if (actor.ListInventory().Any(x => x.ItemType == ItemType.Iron) &&
                    actor.ListInventory().Any(x => x.ItemType == ItemType.Wood))
                {
                    this.AddToPerson(actor, new Weapon(craftItemName));
                }
            }
        }

        private void HandleGatherInteraction(string gatherItemName, Person actor)
        {
            var location = actor.Location;
            if (location is GatheringLocation)
            {
                var gatheringLocation = location as GatheringLocation;
                if (actor.ListInventory().Any(x => x.ItemType == gatheringLocation.RequiredItem))
                {
                    var producedItem = gatheringLocation.ProduceItem(gatherItemName);
                    actor.AddToInventory(producedItem);
                }
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    return location = new Mine(locationName);
                case "forest":
                    return location = new Forest(locationName);
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            
        }
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    return person = new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }
    }
}
