namespace AcademyRPG.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Ninja : Character, IFighter, IGatherer
    {
        private const int ninjaHitPoints = 1;
        private int ninjaAttackPoints;
        private int hitPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = ninjaHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.ninjaAttackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPoints = 0;
            int indexToAttack = -1;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (maxHitPoints < availableTargets[i].HitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        indexToAttack = i;
                    }
                }
            }

            return indexToAttack;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.ninjaAttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.ninjaAttackPoints += resource.Quantity * 2;
                return true;
            }
            return false;
        }
    }
}
