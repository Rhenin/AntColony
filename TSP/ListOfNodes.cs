using System.Collections.ObjectModel;
using System.Linq;

namespace TSP
{
    //Collection for nodes
    public class ListOfNodes<T> : Collection<GraphNode<T>>
    { 
        public GraphNode<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
