namespace AcademyRPG.Models
{
    using System.Collections.Generic;

    public class Knight : Character, IFighter
    {
        private const int knightHitPoints = 100;
        private const int knightAttackPoints = 100;
        private const int knightDefensePoints = 100;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = knightHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return knightAttackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return knightDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
