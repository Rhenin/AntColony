namespace TSP
{
    public class Graph<T>
    {
        //graph init
        public Graph() : this(null) { }

        public Graph(ListOfNodes<T> nodeSet)
        {
            Nodes = nodeSet ?? new ListOfNodes<T>();
        }


        public void AddNode(T value)
        {
            Nodes.Add(new GraphNode<T>(value));
        }


        //Connecting nodes to each other
        public void AddEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Pheromone.Add(1.0);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Pheromone.Add(1.0);
            to.Costs.Add(cost);
        }

        //search for node with set value
        public bool Contains(T value)
        {
            return Nodes.FindByValue(value) != null;

        }

        //removing node from graph
        public bool Remove(T value)
        {
            GraphNode<T> toRemove =  Nodes.FindByValue(value);
            if (toRemove == null)
                return false;

            Nodes.Remove(toRemove);

            foreach (var node in Nodes)
            {
                var gNode = node;
                var index = gNode.Neighbors.IndexOf(toRemove);
                if (index == -1) continue;
                gNode.Neighbors.RemoveAt(index);
                gNode.Pheromone.RemoveAt(index);
                gNode.Costs.RemoveAt(index);
            }

            return true;
        }

        //graph properties 
        public ListOfNodes<T> Nodes { get; }

        public int Count => Nodes.Count;
    }
}
