namespace WarMachine.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Fighter : Machine, IFighter
    {
        // Field.
        private const double defaultHealthPoints = 200;
        private bool stealthMode = true;

        // Constructor.
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = defaultHealthPoints;
        }

        // Property.
        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            private set
            { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.StealthMode)
            {
                sb.AppendLine(string.Format(" *Stealth: ON"));
            }
            else
            {
                sb.AppendLine(string.Format(" *Stealth: OFF"));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
