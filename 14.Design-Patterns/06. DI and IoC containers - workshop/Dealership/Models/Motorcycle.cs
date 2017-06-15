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
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string categoryMotorcycle;
        private const VehicleType typeMotorcycle = VehicleType.Motorcycle;
        private const int wheelsMotorcycle = 2;

        public Motorcycle(string make, string model, decimal price, string category)
            : base (make,model,price)
        {
            this.Category = category;
            this.Type = typeMotorcycle;
            this.Wheels = wheelsMotorcycle;
        }

        public string Category
        {
            get
            {
                return this.categoryMotorcycle;
            }
            private set
            {
                Validator.ValidateNull(value, "Category can not be null");
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                                   "Category",
                                   Constants.MinCategoryLength, 
                                   Constants.MaxCategoryLength));
                this.categoryMotorcycle = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var commentsMotorcycle = PrintComments();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            sb.AppendLine(string.Format("  Price: ${0}", this.Price));
            sb.AppendLine(string.Format("  Category: {0}", this.Category));
            sb.AppendLine(commentsMotorcycle);
            return sb.ToString().TrimEnd();
        }
    }
}
