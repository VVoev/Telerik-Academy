namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common.Enums;
    using Common;
    public abstract class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private int wheels;
        private VehicleType type;
        private decimal price;
        private IList<IComment> comments = new List<IComment>();

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                this.comments = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                Validator.ValidateNull(value, "Make can not be null");
                Validator.ValidateIntRange(value.Length,
                                           Constants.MinMakeLength,
                                           Constants.MaxMakeLength,
                                           string.Format(Constants.StringMustBeBetweenMinAndMax,
                                                         "Make",
                                                         Constants.MinMakeLength,
                                                         Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validator.ValidateNull(value, "Model can not be null");
                Validator.ValidateIntRange(value.Length,
                                           Constants.MinModelLength,
                                           Constants.MaxModelLength,
                                           string.Format(Constants.StringMustBeBetweenMinAndMax,
                                                         "Model",
                                                         Constants.MinModelLength,
                                                         Constants.MaxModelLength));
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.ValidateDecimalRange(value,
                                               Constants.MinPrice,
                                               Constants.MaxPrice,
                                               string.Format(Constants.NumberMustBeBetweenMinAndMax,
                                                              "Price",
                                                              Constants.MinPrice,
                                                              Constants.MaxPrice));
                this.price = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }

        public int Wheels
        {
            // TODO
            get
            {
                return this.wheels;
            }
            protected set
            {
                this.wheels = value;
            }
        }
        protected string PrintComments()
        {
            var result = new StringBuilder();
            if (this.comments.Count == 0)
            {
                result.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                result.AppendLine("    --COMMENTS--");
                foreach (var comment in this.comments)
                {
                    result.AppendLine(comment.ToString());
                }
                result.AppendLine("    --COMMENTS--");
            }
            return result.ToString().TrimEnd();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}:", this.GetType().Name));
            sb.AppendLine(string.Format("  Make: {0}", this.Make));
            sb.AppendLine(string.Format("  Model: {0}", this.Model));
            return sb.ToString().TrimEnd();
        }
    }
}
