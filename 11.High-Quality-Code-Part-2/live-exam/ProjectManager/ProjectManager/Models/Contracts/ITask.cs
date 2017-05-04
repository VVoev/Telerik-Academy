namespace ProjectManager.Models.Contracts
{
    public interface ITask
    {
        string Name { get; set; }

        User Owner { get; set; }

        string State { get; set; }
    }
}
