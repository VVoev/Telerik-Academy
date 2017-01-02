namespace Cosmetics.Products
{
    using System.Text;

    using Contracts;
    using Common;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private UsageType usageType;
        private decimal price;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint quantity, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = quantity;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                Validator.CheckIfNull(value, GlobalErrorMessages.ObjectCannotBeNull);
                this.milliliters = value;
            }
        }

        public override decimal Price
        {
            get
            {
                return this.price * this.milliliters;
            }

            protected set
            {
                this.price = value;
            }
        }
        public UsageType Usage
        {
            get
            {
                return this.usageType;
            }
            private set
            {
                Validator.CheckIfNull(value, GlobalErrorMessages.ObjectCannotBeNull);
                this.usageType = value;
            }
        }
        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            sb.AppendLine(string.Format("  * Usage: {0}", this.Usage));
            return sb.ToString().TrimEnd();
        }
    }
}
