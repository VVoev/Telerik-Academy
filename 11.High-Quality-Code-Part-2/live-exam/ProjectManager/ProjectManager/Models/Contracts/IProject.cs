using ProjectManager.Models;
using System;
using System.Collections.Generic;

namespace ProjectManager.Models.Contracts
{
    public interface IProject
    {
        DateTime StartingDate { get; set; }

        DateTime EndingDate { get; set; }

        List<User> Users { get; set; }

        List<Task> Tasks { get; set; }

        string Name { get; set; }

        int Id { get; set; }

        string State { get; set; }
    }
}
