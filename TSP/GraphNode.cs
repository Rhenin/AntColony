using System.Collections.Generic;
using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Node number: {" + nameof(Value) + "}")]
    public class GraphNode<T>
    {
        //fields
        
        private List<int> _costs;

        
        //ctors of graphNode
        public GraphNode()
        {
        }
        public GraphNode(T value)
        {
            Value = value;
            Neighbors = new ListOfNodes<T>();
        }
        public GraphNode(T value, ListOfNodes<T> neighbors) 
        {
            Value = value;
            Neighbors = neighbors;
        }

        //properties
        public T Value { get; set; }

        public int Food { get; set; }
        public int Pheromone { get; set; } = 1;

        public bool HasAntHill = false;

        public Anthill<T> Anthill { get; set; }

        public ListOfNodes<T> Neighbors { get; set; }

        public List<int> Costs => _costs ?? (_costs = new List<int>());
       
    }
}
