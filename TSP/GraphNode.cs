using System.Collections.Generic;
using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Node number: {" + nameof(Value) + "}")]
    public class GraphNode<T>
    {
        //ctors of graphNode

        public GraphNode(T value)
        {
            Value = value;
            Neighbors = new ListOfEdges<T>();
        }

        //properties
        public T Value { get; set; }

        public bool Food { get; set; }
    

        public bool HasAntHill = false;

        public Anthill<T> Anthill { get; set; }

        public ListOfEdges<T> Neighbors { get; set; }

        

    }
}
