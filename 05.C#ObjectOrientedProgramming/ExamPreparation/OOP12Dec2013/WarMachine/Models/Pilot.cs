namespace WarMachine.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Pilot : IPilot
    {
        // Fields.
        private string name;
        private ICollection<IMachine> machines;

        // Constructor.
        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }
        
        // Properties.
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
        public ICollection<IMachine> Machines
        {
            get
            {
                return this.machines;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.machines = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);

            this.machines = new List<IMachine>(this.machines.OrderBy(x => x.HealthPoints)
                                                            .ThenBy(x => x.Name))
                                                            .ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            // To do count for machines.
            sb.Append(string.Format("{0} - ", this.Name));
            if (this.Machines.Count > 1)
            {
                sb.AppendLine(string.Format("{0} machines",this.machines.Count));
            }
            else if (this.Machines.Count == 1)
            {
                sb.AppendLine(string.Format("{0} machine",this.machines.Count));
            }
            else
            {
                sb.AppendLine("no machines");

            }
            foreach (var machine in this.Machines)
            {
                if (machine.Pilot != null)
                {
                    sb.AppendLine(machine.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
