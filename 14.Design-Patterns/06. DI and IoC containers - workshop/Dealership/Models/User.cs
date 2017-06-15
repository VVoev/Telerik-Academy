namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common.Enums;
    using Common;

    public class User : IUser, ICommentable
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles = new List<IVehicle>();
        private IList<IComment> comments = new List<IComment>();

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length,
                                           Constants.MinNameLength,
                                           Constants.MaxNameLength,
                                           string.Format(Constants.StringMustBeBetweenMinAndMax,
                                           "Firstname",
                                           Constants.MinNameLength,
                                           Constants.MaxNameLength));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length,
                                           Constants.MinNameLength,
                                           Constants.MaxNameLength,
                                           string.Format(Constants.StringMustBeBetweenMinAndMax,
                                           "Lastname",
                                           Constants.MinNameLength,
                                           Constants.MaxNameLength));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Password"));
                Validator.ValidateIntRange(value.Length,
                                              Constants.MinPasswordLength,
                                              Constants.MaxPasswordLength,
                                              string.Format(Constants.StringMustBeBetweenMinAndMax,
                                              "Password",
                                              Constants.MinPasswordLength,
                                              Constants.MaxPasswordLength));
                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            private set
            {
                this.role = value;
            }
        }

        public string Username
        {
            get
            {
                return this.userName;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length,
                                              Constants.MinNameLength,
                                              Constants.MaxNameLength,
                                              string.Format(Constants.StringMustBeBetweenMinAndMax,
                                              "Username",
                                              Constants.MinNameLength,
                                              Constants.MaxNameLength));
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));

                this.userName = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
            private set
            {
                this.vehicles = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                this.comments = value;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(string.Format(Constants.AdminCannotAddVehicles));
            }
            else if (this.Role != Role.VIP && this.vehicles.Count >= Constants.MaxVehiclesToAdd)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }
            else
            {
                this.vehicles.Add(vehicle);
            }
        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("--USER {0}--", this.Username));
            if (this.vehicles.Count == 0)
            {
                sb.AppendLine("--NO VEHICLES--");
            }
            else
            {
                for (int i = 0; i < this.vehicles.Count; i++)
                {
                    sb.Append(i + 1 + ". ");
                    sb.AppendLine(this.vehicles[i].ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author == this.Username)
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
            else
            {
                throw new ArgumentException(string.Format(Constants.YouAreNotTheAuthor));
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Equals(vehicle))
                {
                    this.vehicles.RemoveAt(i);
                }
            }
        }
        public override string ToString()
        {
            var result = string.Format(Constants.UserToString, this.Username, this.FirstName, this.LastName);
            result += string.Format(", Role: {0}", this.Role);
            return result;
        }
    }
}
