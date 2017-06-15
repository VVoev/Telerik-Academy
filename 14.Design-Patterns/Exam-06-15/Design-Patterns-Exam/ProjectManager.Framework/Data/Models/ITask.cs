using ProjectManager.Framework.Data.Models.States;

namespace ProjectManager.Framework.Data.Models
{
    public interface ITask
    {
        string Name { get; set; }
        User Owner { get; set; }
        TaskState State { get; set; }

        string ToString();
    }
}