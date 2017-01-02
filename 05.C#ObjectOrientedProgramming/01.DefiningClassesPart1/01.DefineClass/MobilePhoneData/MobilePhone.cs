namespace MobileDeviceCharacteristics
{
    using System;
    using MobilePhoneData.Batteries;
    using MobilePhoneData.DisplayData;

    public class MobilePhone
    {
        private decimal price;
        private string owner;
        private string model;
        private string manufacturer;
        private Battery battery;
        private Display display;

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can't be less than 0!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value == string.Empty)
                {
                    this.owner = null;
                }
                else
                {
                    this.owner = value;
                }
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                this.manufacturer = value;
            }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

    }
}