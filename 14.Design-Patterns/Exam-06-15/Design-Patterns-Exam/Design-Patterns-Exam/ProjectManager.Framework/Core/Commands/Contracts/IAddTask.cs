public interface IAddTask
{
    void AddTask(int projectId, int ownerId, string taskName, string taskState);
}