using System.Collections.Generic;

namespace SchoolSystem
{
    interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
