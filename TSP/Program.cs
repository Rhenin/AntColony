using System;

namespace TSP
{
    class Program
    {
        static void Main()
        {
            //init input
            
            Console.WriteLine("Number of Ants: ");
            var antCount = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("Size of graph: ");
            var graphSize = Convert.ToInt32(Console.ReadLine());


            
           
            var graph = Utility.GraphGenerate(graphSize);
            var anthill = Utility.AnthillGenerete(antCount, graphSize, graph);


           
            Console.ReadLine();

        }
    }
}

