﻿using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.students[int.Parse(parameters[0])].ListMarks();
        }
    }
}
