namespace MobileDeviceCharacteristics
{
    using System;
    public class Display
    {
        // Fields in class Display.
        private double displaySize;
        private int displayNumberOfColors;

        // Properties in class Display.
        public double DisplaySize
        {
            get { return this.displaySize; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Screen can't be negative");
                }
                else if (value < 2.5)
                {
                    throw new ArgumentException("According to the latest Compatibility Definition Document screen must be at least 2.5 inches");
                }
                else
                {
                    this.displaySize = value;
                }
            }
        }

        public int DisplayColorNumbers
        {
            get { return displayNumberOfColors; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Colors can't be less than 0.");
                }
                else
                {
                    this.displayNumberOfColors = value;
                }
            }
        }

        // Constructor in class Display.
        public Display(double displaySize, int displayNumberOfColors)
        {
            this.DisplaySize = displaySize;
            this.DisplayColorNumbers = displayNumberOfColors;
        }
    }
}
