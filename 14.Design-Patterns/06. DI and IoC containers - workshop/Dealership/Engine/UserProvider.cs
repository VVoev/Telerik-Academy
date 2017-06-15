using Dealership.Contracts;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Dealership.Engine
{
    public class UserProvider : IUserProvider
    {
        private readonly IList<IUser> users;

        public UserProvider()
        {
            this.users = new List<IUser>();
        }

        public IUser LoggedUser { get; set; }

        public IEnumerable<IUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public void AddUser(IUser user)
        {
            this.users.Add(user);
        }
    }

    public interface IGetUsers
    {
        IEnumerable<IUser> Users { get; }
    }

    public interface IAddUser
    {
        void AddUser(IUser user);
    }

    public interface IUserProvider : IGetUsers,IAddUser
    {
        IUser LoggedUser { get; set; }
    }
}
