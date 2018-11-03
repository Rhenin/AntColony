using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Edge number: {" + nameof(IdName) + "}")]
    public class Edge
    {
        public Edge(int value)
        {
            IdName = value;
            Pheromone = 1;
        }
        public int IdName { get; set; }
        public double Pheromone { get; set; }
        public int Cost { get; set; }
        public GraphNode FirstNode { get; set; }
        public GraphNode SecondNode { get; set; }

    }
}
