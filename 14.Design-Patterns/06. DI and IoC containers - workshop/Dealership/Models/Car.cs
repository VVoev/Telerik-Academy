namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;
    using Common.Enums;

    public class Car : Vehicle, ICar
    {
        private int carSeats;
        private const VehicleType typeCar = VehicleType.Car;
        private const int wheelsCar = 4;

        public Car(string make, string model,decimal price, int seats)
            : base(make, model, price)
        {
            this.Seats = seats;
            this.Type = typeCar;
            this.Wheels = wheelsCar;
        }

        public int Seats
        {
            get
            {
                return this.carSeats;
            }
            private set
            {
                Validator.ValidateIntRange(value,
                                           Constants.MinSeats,
                                           Constants.MaxSeats,
                                           string.Format(Constants.NumberMustBeBetweenMinAndMax,"Seats" ,Constants.MinSeats, Constants.MaxSeats));
                this.carSeats = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var commentsCar = PrintComments();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            sb.AppendLine(string.Format("  Price: ${0}", this.Price));
            sb.AppendLine(string.Format("  Seats: {0}", this.Seats));
            sb.AppendLine(commentsCar);
            return sb.ToString().TrimEnd();
        }
    }
}
