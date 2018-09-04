using System;
using System.Collections.Generic;

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

            foreach (var ant in anthill.Ants)
            {
                ant.Visited.Add(ant.CurrentLocation);
                List<double> probabilities = ant.ChooseWay(ant.Visited, ant.CurrentLocation.Neighbors);
            }

           
            Console.ReadLine();

        }
    }
}

