using System;
using System.Collections.Generic;
using ProjectManager.Framework.Data.Models.States;

namespace ProjectManager.Framework.Data.Models
{
    public interface IProject
    {
        DateTime EndingDate { get; set; }
        string Name { get; set; }
        DateTime StartingDate { get; set; }
        ProjectState State { get; set; }
        IList<ITask> Tasks { get; set; }
        IList<IUser> Users { get; set; }

        string ToString();
    }
}