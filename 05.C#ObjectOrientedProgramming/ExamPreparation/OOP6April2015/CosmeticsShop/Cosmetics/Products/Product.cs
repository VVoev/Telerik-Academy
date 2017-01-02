namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private GenderType gender;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);
                Validator.CheckIfStringLengthIsValid(value, 10, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                Validator.CheckIfNull(value, GlobalErrorMessages.ObjectCannotBeNull);
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);
                Validator.CheckIfStringLengthIsValid(value, 10, 3, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));
                this.name = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value;
            }
        }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            sb.AppendLine(string.Format("  * Price: ${0}", this.Price));
            sb.AppendLine(string.Format("  * For gender: {0}", this.Gender));
            //sb.AppendLine(string.Format(" * Quantity: ${0}", this.));
            //sb.AppendLine(string.Format(" * Usage: ${0}", this.Price));
            //    * Quantity: { product quantity} ml(when applicable)
            //    * Usage: EveryDay / Medical(when applicable)
            return sb.ToString().TrimEnd();
        }
    }
}
