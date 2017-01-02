namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;
    using Common.Enums;

    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;
        private const VehicleType typeTruck = VehicleType.Truck;
        private const int wheelsTruck = 8;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
            this.Type = typeTruck;
            this.Wheels = wheelsTruck;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                //Weight capacity must be between 1 and 100!
                Validator.ValidateIntRange(value,
                                           Constants.MinCapacity,
                                           Constants.MaxCapacity,
                                           string.Format(Constants.NumberMustBeBetweenMinAndMax,
                                           "Weight capacity",
                                           Constants.MinCapacity,
                                           Constants.MaxCapacity));
                this.weightCapacity = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var commentsTruck = PrintComments();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            sb.AppendLine(string.Format("  Price: ${0}", this.Price));
            sb.AppendLine(string.Format("  Weight Capacity: {0}t", this.WeightCapacity));
            sb.AppendLine(commentsTruck);
            return sb.ToString().TrimEnd();
        }
    }
}
