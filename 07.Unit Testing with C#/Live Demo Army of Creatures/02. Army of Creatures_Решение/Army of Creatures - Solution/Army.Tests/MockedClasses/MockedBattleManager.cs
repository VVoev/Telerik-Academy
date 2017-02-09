using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;

namespace Army.Tests.MockedClasses
{
    public class MockedBattleManager : BattleManager
    {
        public MockedBattleManager(ICreaturesFactory creaturesFactory,ILogger logger)
            :base(creaturesFactory,logger)
        {

        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            //var creature = new Angel();
            //return new CreaturesInBattle(creature, 1);

            return null;
        }
    }
}
