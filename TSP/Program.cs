using System;

namespace TSP
{
    class Program
    {
        static void Main()
        {
            //init input
            
            int graphSize;

            Console.WriteLine("Number of Ants: ");
            var antCount = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("Size of graph(Must be 3 or greater): ");
            
            do
            {
                graphSize = Convert.ToInt32(Console.ReadLine());
            } while (graphSize < 3);
            var graph = Utility.GraphGenerate(graphSize);                                                              
            var anthill = Utility.AnthillGenerete(antCount, graphSize, graph);
                     
           
         
            
            

            Console.ReadLine();

        }
    }
}

