namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int minLength = 2;
        private const int maxLength = 15;
        private string name;
        private ICollection<IProduct> cosmeticsList = new List<IProduct>();

        public Category(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, maxLength, minLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", minLength, maxLength));
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);
                this.name = value;
            }
        }
        public void AddCosmetics(IProduct cosmetics)
        {
            cosmeticsList.Add(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} category - {1} {2} in total", this.Name, cosmeticsList.Count,
                cosmeticsList.Count == 1 ? "product" : "products"));
            var orderedCosmeticsList = cosmeticsList.OrderBy(x => x.Brand)
                                                    .ThenByDescending(x => x.Price)
                                                    .ToList();
            foreach (var product in orderedCosmeticsList)
            {
                sb.AppendLine(product.Print());
            }
            return sb.ToString().TrimEnd();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (cosmeticsList.Contains(cosmetics))
            {
                cosmeticsList.Remove(cosmetics);
            }
            else
            {
                Console.WriteLine(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
        }
    }
}
