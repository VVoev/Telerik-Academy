using ProjectManager.Framework.Data.Models;

public interface IAddUser
{
    void AddUser(int projectId, IUser user);
}