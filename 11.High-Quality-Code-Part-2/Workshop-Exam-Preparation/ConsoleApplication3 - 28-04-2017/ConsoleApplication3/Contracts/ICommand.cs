namespace StudentApplication
{

    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
