using System.Collections.ObjectModel;
using System.Linq;

namespace TSP
{
    public class ListOfEdges : Collection<Edge>
    {
            public Edge FindByValue(int value)
            {
                return Items.FirstOrDefault(edge => edge.IdName.Equals(value));
            }       
    }
}
