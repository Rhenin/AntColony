using System.Collections.Generic;

namespace TSP
{

    public class GraphNode<T> : Node<T>
    {
        //fields
        private List<int> _costs;

        
        //ctors of graphNode
        public GraphNode()
        {
        }
        public GraphNode(T value) : base(value)
        {
        }
        public GraphNode(T value, ListOfNodes<T> neighbors): base(value, neighbors)   
        {
        }

        //properties
        public int Food { get; set; }
        public int Pheromone { get; set; } = 1;

        public bool HasAntHill = false;

        public Anthill<T> Anthill { get; set; } 

        public new ListOfNodes<T> Neighbors => base.Neighbors ?? (base.Neighbors = new ListOfNodes<T>());

        public List<int> Costs => _costs ?? (_costs = new List<int>());
       
    }
}
