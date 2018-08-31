using System.Collections.ObjectModel;
using System.Linq;

namespace TSP
{
    //Collection for nodes
    public class ListOfNodes<T> : Collection<GraphNode<T>>
    {
        public ListOfNodes()
        {
        }

        public ListOfNodes(int initialSize)
        {
            for(var i = 0; i<initialSize; i++)
                Items.Add(default(GraphNode<T>));
        }

        public GraphNode<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
