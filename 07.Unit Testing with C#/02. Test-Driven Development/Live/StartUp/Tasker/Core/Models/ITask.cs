using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Core.Models
{
  public interface ITask
    {
        int ID { get; set; }

        string Description { get; }
    }
}
