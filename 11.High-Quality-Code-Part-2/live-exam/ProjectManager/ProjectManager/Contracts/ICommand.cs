using System.Collections.Generic;

namespace ProjectManager.Contracts
{
    public interface ICommand
    {
        string Execute(List<string> parameters);
    }
}
