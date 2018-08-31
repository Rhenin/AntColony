using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant<T>
    {
        
        private int _antValueName;
        private Anthill<T> _hill;

        public Ant(Anthill<T> hill, int antValueName)
        {
            _hill = hill;
            _antValueName = antValueName;
        }
        public ListOfNodes<T> Visited { get; set; }
    }
}
