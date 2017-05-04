using ProjectManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Common;

namespace ProjectManager.Tests.Mocks
{
    public class EngineMock : Engine
    {
        public EngineMock(FileLogger logger, CmdCPU processor) : base(logger, processor)
        {
        }
    }
}
