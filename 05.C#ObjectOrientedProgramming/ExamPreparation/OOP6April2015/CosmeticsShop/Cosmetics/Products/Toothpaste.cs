namespace Cosmetics.Products
{
    using System.Text;

    using Contracts;
    using Common;

    public class Toothpaste : Product, IToothpaste
    {
        private const int minLength = 4;
        private const int maxLength = 12;
        private string ingredients;


        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) 
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);
                var arrayOfIngredients = value.Split(',');
                foreach (var ingredient in arrayOfIngredients)
                {
                    Validator.CheckIfStringLengthIsValid
                        (ingredient, maxLength, minLength,
                        string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", minLength, maxLength));
                }
                this.ingredients = value;
            }
        }
        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine(string.Format("  * Ingredients: {0}", string.Join(", ",this.Ingredients)));
            return sb.ToString().TrimEnd();
        }
    }
}
