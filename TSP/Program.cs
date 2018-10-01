using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            
           
            
           /* foreach(var item in graph.Nodes)
            {
                int inverseTour;
                for(int i = 0; i<anthill.Ants.Count; i++)
                {

                }
                item.Pheromone = (1 - 0.5) * item.Pheromone + 
           
            }
            */

            Console.ReadLine();

        }
    }
}

