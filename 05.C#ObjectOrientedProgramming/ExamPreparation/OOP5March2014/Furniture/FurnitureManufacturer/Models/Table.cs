namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width) 
            :base(model,materialType,price,height)
        {
            this.Length = length;
            this.Width = width;
            // TO DO maybe setter for area.
        }
        public decimal Area
        {
            get
            {
                return this.length * this.width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }
        public override string ToString()
        {
            //Type: { 0}, Model: { 1}, Material: { 2}, Price: { 3}, Height: { 4}, Length: { 5}, Width: { 6}, Area: { 7}
            //", this.GetType().Name, this.Model, this.Material, this.Price, this.Height,  this.Length, this.Width, this.Area
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area));
            return sb.ToString().TrimEnd();
        }
    }
}
