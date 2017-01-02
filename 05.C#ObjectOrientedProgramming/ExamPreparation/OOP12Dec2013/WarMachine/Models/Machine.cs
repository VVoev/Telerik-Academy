namespace WarMachine.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Machine : IMachine
    {
        // Fields.
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IPilot pilot;
        private IList<string> targets;

        //Constructor.
        public Machine()
        {
            this.Targets = new List<string>();
        }
        public Machine(string name, double attackPoints, double defensePoints) : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }

        // Properties.
        public double AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.attackPoints = value;
            }
        }

        public double DefensePoints { get; set; }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
            private set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            if (this.Pilot != null)
            {
                this.DefensePoints = 100;
                targets.Add(target);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            if (this.Targets.Count == 0)
            {
                sb.AppendLine(string.Format(" *Targets: None"));
            }
            else
            {
                sb.AppendLine(string.Format(" *Targets: {0}", string.Join(", ", this.Targets)));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
