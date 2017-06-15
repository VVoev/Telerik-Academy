using ProjectManager.Framework.Data.Models;

public interface IProjectFactory
{
    IProject GetProject(string name, string startingDate, string endingDate, string state);
}