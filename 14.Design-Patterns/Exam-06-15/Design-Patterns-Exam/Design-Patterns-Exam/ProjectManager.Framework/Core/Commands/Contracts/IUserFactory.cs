using ProjectManager.Framework.Data.Models;

public interface IUserFactory
{
    IUser CreateUser(string username, string email);
}