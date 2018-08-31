using System.Diagnostics;

namespace TSP
{
    //node scaffolding
    [DebuggerDisplay("Node number: {" + nameof(Value) + "}")]
    public class Node<T>
    {
        public Node()
        {
        }

        public Node(T data)
        {
            Value = data;
            Neighbors = null;
        }
        public Node(T data, ListOfNodes<T> neighbors)
        {
            Value = data;
            Neighbors = neighbors;
        }

       

        public T Value { get; set; }

        protected ListOfNodes<T> Neighbors { get; set; }
    }
}
