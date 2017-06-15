using ProjectManager.Framework.Data.Models;

public interface ITaskFactory
{
    ITask GetTask(IUser owner, string name, string state);
}