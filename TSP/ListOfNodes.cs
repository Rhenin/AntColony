using System.Collections.ObjectModel;
using System.Linq;

namespace TSP
{
    //Collection for nodes
    public class ListOfNodes : Collection<GraphNode>
    { 
        public GraphNode FindByValue(int value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
