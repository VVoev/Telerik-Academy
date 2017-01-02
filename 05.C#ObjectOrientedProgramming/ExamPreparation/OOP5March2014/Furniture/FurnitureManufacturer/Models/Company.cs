namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Company : ICompany
    {
        private const int registrationLength = 10;
        private const int nameMinLength = 5;
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                this.furnitures = value;
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
                if (String.IsNullOrEmpty(value) || value.Length < nameMinLength)
                {
                    throw new ArgumentException("Company name cannot be empty, null or with less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (value.Length != registrationLength || value.Any(x => Char.IsDigit(x) == false))
                {
                    throw new ArgumentOutOfRangeException("Invalid registration number.");
                }
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        private IEnumerable<IFurniture> OrderByPriceAndModel(IEnumerable<IFurniture> furnitures)
        {
            var orderedFurnitures = this.Furnitures.OrderBy(x => x.Price)
                                                   .ThenBy(x => x.Model);
            return orderedFurnitures;
        }

        public string Catalog()
        {
            // TO DO implement Category info.
            //this.Name,
            //this.RegistrationNumber,
            //this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            //this.Furnitures.Count != 1 ? "furnitures" : "furniture"
            var sb = new StringBuilder();
            var orderedFurnitures = OrderByPriceAndModel(this.Furnitures);
            sb.AppendLine(string.Format("{0} - {1} - {2} {3}", 
                this.Name, 
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            foreach (var furniture in orderedFurnitures)
            {
                sb.AppendLine(furniture.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            var wantedFurniture = this.Furnitures.FirstOrDefault(x => x.Model.ToLower().CompareTo(model.ToLower()) == 0);
            return wantedFurniture;
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}
