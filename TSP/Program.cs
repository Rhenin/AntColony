using System;
using System.Linq;
using System.Security.Cryptography;

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

            graph.Nodes.FindByValue(30).Food = true;
            graph.Nodes.FindByValue(36).Food = true;

            var random = new Random();
            var foundWay = false;
            double probabilitySpace = 0;
            
            for (var i = 0; i < 10; i++)
            {
                foreach (var ant in anthill.Ants)
                {
                    ant.Probabilities = ant.ChooseWay();

                    do
                    {
                        var rollTheBones = random.NextDouble();
                        for (var j = 0; j < ant.Probabilities.Count; j++)
                        {
                            if (foundWay) break;
                            probabilitySpace += ant.Probabilities[j];
                            if (!(rollTheBones <= probabilitySpace)) continue;
                            foundWay = true;
                            ant.Visited.Add(ant.CurrentLocation.Neighbors[j]);
                            ant.LengthOfRoad += ant.CurrentLocation.Neighbors[j].Cost;
                            ant.CurrentLocation = ant.CurrentLocation == ant.CurrentLocation.Neighbors[j].FirstNode
                                ? ant.CurrentLocation.Neighbors[j].SecondNode
                                : ant.CurrentLocation.Neighbors[j].FirstNode;
                            ant.Probabilities = ant.ChooseWay();
                            if (ant.CurrentLocation.Food)
                                ant.FoundFood = true;

                        }

                        foundWay = false;
                        probabilitySpace = 0;

                    } while(ant.FoundFood == false && ant.Probabilities.Any(p => p > 0));
                    ant.CurrentLocation = anthill.CurrentLocation;


                }
             
            Utility.GlobalUpdateRule(graph);
            }
            
            
            

            Console.ReadLine();

        }
    }
}

