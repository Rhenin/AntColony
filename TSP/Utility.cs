using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSP
{
    static class Utility
    {
        private const double VanishRate = 0.5;

        public static Graph<int> GraphGenerate(int graphSize)
        {

            var graph = new Graph<int>();

            for (int j = 0; j < graphSize * graphSize; j++)
            {               
                    graph.AddNode(j+1);              
            }

            int edgeCount = graphSize * graphSize + (graphSize - 1) * (graphSize - 1) - 1;

            for (int i = 0; i < edgeCount; i++)
            {
                graph.AddEdge(i+1);
            }

            ConnectNodes(graph, graphSize);

            return graph;
        }

        public static void ConnectNodes(Graph<int> graph, int graphSize)
        {
            int edgeName = 1;

            for (int j = 0, nodeIndex = 0; j < graphSize; j++, nodeIndex++)
            {
                for (int i = 0; i < graphSize - 1; i++)
                {
                    if (nodeIndex < graphSize * graphSize - graphSize)
                    {
                        graph.InitEdge(graph.Nodes[nodeIndex], graph.Nodes[nodeIndex + graphSize], edgeName++);
                    }

                    graph.InitEdge(graph.Nodes[nodeIndex++], graph.Nodes[nodeIndex], edgeName++);
                }

                if (nodeIndex < graphSize * graphSize - graphSize)
                {
                    graph.InitEdge(graph.Nodes[nodeIndex], graph.Nodes[nodeIndex + graphSize], edgeName++);
                }
            }
        }

        public static Anthill<int> AnthillGenerete(int antCount, int graphSize, Graph<int> graph)
        {
            //var rng = new Random();
            //int anthillOnNode = rng.Next(1, graphSize);


            var node = graph.Nodes.FindByValue(1);
            var antHill = new Anthill<int>(antCount, node);
            graph.Anthill = antHill;
            node.Anthill = antHill;
            node.HasAntHill = true;
          
            return antHill;
        }

        public static void GlobalUpdateRule(Graph<int> graph)
        {
            foreach (var item in graph.Edges)
            {
                item.Pheromone = (1 - VanishRate) * item.Pheromone;
                foreach (var ant in graph.Anthill.Ants)
                {
                    if (ant.Visited.Contains(item))
                    {
                        item.Pheromone += (1 / ant.LengthOfRoad);
                    }
                }
            }
        }

        private static void SaveAsCsv(List<string> doZapisu)
        {
            Console.WriteLine("Name a file to which you want save the data: ");
            var fileName = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            var dataFilePath = Directory.GetCurrentDirectory() + "/" + fileName + ".csv";

            foreach (var arrayElement in doZapisu)
            {
                var newLine = $"{arrayElement},{Environment.NewLine}";
                stringBuilder.Append(newLine);
                File.WriteAllText(dataFilePath, stringBuilder.ToString());
            }

        }

        private static void SaveAsTxt(List<string> doZapisu)
        {
            Console.WriteLine("Name a file to which you want save the data: ");
            var fileName = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            var dataFilePath = Directory.GetCurrentDirectory() + "/" + fileName + ".txt";

            foreach (var element in doZapisu)
            {
                stringBuilder.AppendLine(element);
            }

            File.WriteAllText(dataFilePath, stringBuilder.ToString());
        }
    }
}
