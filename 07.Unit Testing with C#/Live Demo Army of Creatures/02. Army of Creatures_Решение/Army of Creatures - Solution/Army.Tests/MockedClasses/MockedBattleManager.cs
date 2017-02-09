using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Army.Tests.MockedClasses
{
    public class MockedBattleManager : BattleManager


    {
        public ICollection<ICreaturesInBattle> FirstArmyCreatures { get; set; }
        public ICollection<ICreaturesInBattle>  SecondArmyCreatures { get; set; }

        public MockedBattleManager(ICreaturesFactory creaturesFactory,ILogger logger)
            :base(creaturesFactory,logger)
        {
            this.FirstArmyCreatures = new List<ICreaturesInBattle>();
            this.SecondArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            return null;
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            if (creaturesInBattle == null)
            {
                throw new ArgumentNullException("creaturesInBattle");
            }

            if (creatureIdentifier.ArmyNumber == 1)
            {
                this.FirstArmyCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 2)
            {
                this.SecondArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", creatureIdentifier.ArmyNumber));
            }
            
        }
    }
}
