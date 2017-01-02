namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const int modelMinLength = 3;
        private string model;
        private decimal height;
        private decimal price;
        private MaterialType material;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }
        public virtual decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.00 m.");
                }
                this.height = value;
            }
        }

        public MaterialType Material
        {
            get
            {
                return this.material;
            }
            protected set
            {
                if (value.Equals(this.material))
                {

                }
                this.material = value;
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
                if (String.IsNullOrEmpty(value) || value.Length < modelMinLength)
                {
                    throw new ArgumentException("Model cannot be empty, null or with less than 3 symbols.");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to $0.00.");
                }
                this.price = value;
            }
        }
    }
}
