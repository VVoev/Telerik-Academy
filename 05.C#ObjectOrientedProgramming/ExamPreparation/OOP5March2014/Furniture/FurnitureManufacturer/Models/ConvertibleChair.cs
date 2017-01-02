namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private StateType state = StateType.Normal;
        private decimal height;
        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {

        }
        public override decimal Height
        {
            get
            {
                if (!IsConverted)
                {
                    return this.height;
                }
                else
                {
                    return 0.10m;
                }
            }

            protected set
            {
                this.height = value;
            }
        }
        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }
        private StateType State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
            if (IsConverted)
            {
                this.State = StateType.Converted;
            }
            else
            {
                this.State = StateType.Normal;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));
            return sb.ToString().TrimEnd();
        }
    }
}
