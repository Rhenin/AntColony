using System;

namespace TSP
{
    public class Graph<T>
    {
        //graph init
        public Graph() : this(null, null) { }

        public Graph(ListOfNodes<T> nodeSet, ListOfEdges<T> edgeSet)
        {
            Nodes = nodeSet ?? new ListOfNodes<T>();
            Edges = edgeSet ?? new ListOfEdges<T>();
        }


        public void AddNode(T value)
        {
            Nodes.Add(new GraphNode<T>(value));
        }

        public void AddEdge(T value)
        {
            Edges.Add(new Edge<T>(value));
        }


        //Connecting nodes to each other
        public void InitEdge(GraphNode<T> from, GraphNode<T> to, T value)
        {
            var rng = new Random();
            var currentEdge = Edges.FindByValue(value);

            from.Neighbors.Add(currentEdge);
            to.Neighbors.Add(currentEdge);

            currentEdge.FirstNode = from;
            currentEdge.SecondNode = to;
            currentEdge.Cost = rng.Next(1, 10);     
        }
   

        //graph properties 
        public ListOfNodes<T> Nodes { get; }
        public ListOfEdges<T> Edges { get; set; }
        public Anthill<T> Anthill { get; set; }
        public int Count => Nodes.Count;
    }
}
