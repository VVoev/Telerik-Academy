namespace AcademyRPG.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Giant : Character, IFighter, IGatherer
    {
        private const int giantHitPoints = 200;
        private int giantAttackPoints = 150;
        private int increasingAttackPoints = 100;
        private const int giantDefensePoints = 80;
        private const int neutralPlayer = 0;

        public Giant(string name, Point position) 
            : base(name, position, neutralPlayer)
        {
            this.HitPoints = giantHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return giantAttackPoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.giantAttackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return giantDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.giantAttackPoints += this.increasingAttackPoints;
                this.increasingAttackPoints = 0;
                return true;
            }
            return false;
        }
    }
}
