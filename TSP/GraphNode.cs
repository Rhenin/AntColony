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
            Neighbors = new ListOfNodes<T>();
        }

        //properties
        public T Value { get; set; }

        public int Food { get; set; }
    

        public bool HasAntHill = false;

        public Anthill<T> Anthill { get; set; }

        public ListOfNodes<T> Neighbors { get; set; }

        public List<int> Costs = new List<int>();
        public List<double> Pheromone = new List<double>();

    }
}
