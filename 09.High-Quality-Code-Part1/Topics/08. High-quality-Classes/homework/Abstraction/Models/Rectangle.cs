using System;
using Abstraction.Abstract;
using Abstraction.Validations;

namespace Abstraction
{
   public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                Validator.ValidateIfPositive(value, "width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Validator.ValidateIfPositive(value, "height");
                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = (2 * this.Height) + (2 * this.Width);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
