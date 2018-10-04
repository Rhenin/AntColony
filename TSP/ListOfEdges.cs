using System.Collections.ObjectModel;
using System.Linq;

namespace TSP
{
    public class ListOfEdges<T> : Collection<Edge<T>>
    {
            public Edge<T> FindByValue(T value)
            {
                return Items.FirstOrDefault(edge => edge.IdName.Equals(value));
            }
        
    }
}
