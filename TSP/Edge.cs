using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Edge number: {" + nameof(IdName) + "}")]
    public class Edge<T>
    {
        public Edge(T value)
        {
            IdName = value;
            Pheromone = 1;
        }
        public T IdName { get; set; }
        public double Pheromone { get; set; }
        public int Cost { get; set; }
        public GraphNode<T> FirstNode { get; set; }
        public GraphNode<T> SecondNode { get; set; }

    }
}
