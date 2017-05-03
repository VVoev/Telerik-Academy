using System.Collections.Generic;

namespace SchoolSystem
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
