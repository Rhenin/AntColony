using System;

namespace TSP
{
    class Program
    {
        private static void Main()
        {        
            int graphSize;
            Console.WriteLine("Number of Ants: ");
            var antCount = Convert.ToInt32(Console.ReadLine());          
            Console.WriteLine("Size of graph(Must be 3 or greater): ");           
            do
            {
                graphSize = Convert.ToInt32(Console.ReadLine());
            } while (graphSize < 3);
            var graph = new Graph(graphSize);
            var anthill = graph.AnthillGenerate(antCount);           

            for (var i = 0; i < 10; i++)
            {
                foreach (var ant in anthill.Ants)
                {
                    ant.Wander();
                }                    
                graph.GlobalUpdateRule();
                foreach (var ant in anthill.Ants)
                {
                    ant.ResetAnt();
                }
            }
            Console.ReadLine();
        }
    }
}

