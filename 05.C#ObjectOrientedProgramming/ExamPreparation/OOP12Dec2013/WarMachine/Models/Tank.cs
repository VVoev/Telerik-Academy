namespace WarMachine.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Tank : Machine, ITank
    {
        private bool defenseMode = true;
        private double defaultHealthPoints = 100;
        private const double modifiedAttackPoints = 40;
        private const double modifiedDefensePoints = 30;


        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = defaultHealthPoints;
            this.DefenseMode = defenseMode;
            this.ToggleDefenseMode();
        }
        public bool DefenseMode { get { return this.defenseMode; } private set { this.defenseMode = value; } }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints += modifiedDefensePoints;
                this.AttackPoints -= modifiedAttackPoints;
            }
            else
            {
                this.DefensePoints -= modifiedDefensePoints;
                this.AttackPoints += modifiedAttackPoints;
            }
            this.DefenseMode = !this.DefenseMode;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (!this.DefenseMode)
            {
                sb.AppendLine(string.Format(" *Defense: ON"));
            }
            else
            {
                sb.AppendLine(string.Format(" *Defense: OFF"));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
