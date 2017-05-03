using SchoolSystem.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    public interface IStudent
    {
        Grade Grades { get; set; }

        IList<IMark> Marks { get; set; }
    }
}
