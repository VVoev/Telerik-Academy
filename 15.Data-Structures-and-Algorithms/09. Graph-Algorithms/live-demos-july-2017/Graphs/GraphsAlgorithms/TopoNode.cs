using System.Collections.Generic;

namespace GraphsAlgorithms
{
    partial class Program
    {
        class TopoNode
        {
            public LinkedList<int> Children { get; set; }
            public int ParentsCount { get; set; }
        }
    }
}
