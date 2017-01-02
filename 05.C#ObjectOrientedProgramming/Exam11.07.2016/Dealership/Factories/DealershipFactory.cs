using Dealership.Contracts;
using System;
using Dealership.Models;
using Dealership.Common.Enums;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            return new Car(make, model, price, seats);
            // TODO: Implement this
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            return new Motorcycle(make, model, price, category);
            // TODO: Implement this
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            return new Truck(make, model, price, weightCapacity);
            // TODO: Implement this
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            return new User(username, firstName, lastName, password, GetRoleType(role));
            // TODO: Implement this
        }

        public IComment CreateComment(string content)
        {
            return new Comment(content);
            // TODO: Implement this
        }
        private Role GetRoleType(string role)
        {
            switch (role)
            {
                case "Admin":
                    return Role.Admin;
                case "VIP":
                    return Role.VIP;
                case "Normal":
                    return Role.Normal;
            }
            return 0;
        }
    }
}
