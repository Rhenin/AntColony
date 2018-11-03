using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Node number: {" + nameof(Value) + "}")]
    public class GraphNode
    {
        public GraphNode(int value)
        {
            Value = value;
            Neighbors = new ListOfEdges();
        }
        public int Value { get; set; }
        public bool Food { get; set; }
        public Anthill Anthill { get; set; }
        public ListOfEdges Neighbors { get; set; }
    }
}
