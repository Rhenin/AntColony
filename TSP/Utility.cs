using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSP
{
    static class Utility
    {
        public static Graph<int> GraphGenerate(int graphSize)
        {         

            int nodeCount = 1;
            var graph = new Graph<int>();

            for (int j = 0; j < graphSize; j++)
            {
                for (int i = 0; i < graphSize; i++)
                {
                    graph.AddNode(nodeCount++);
                }
            }
            ConnectNodes(graph, graphSize);

            return graph;
        }

        public static void ConnectNodes(Graph<int> graph, int graphSize)
        {
            var rng = new Random();
            int z = 0;
            for (int j = 0; j < graphSize; j++, z++)
            {
                for (int i = 0; i < graphSize - 1; i++)
                {
                    if (z < graphSize * graphSize - graphSize)
                    {
                        graph.AddEdge(graph.Nodes[z], graph.Nodes[z + graphSize], rng.Next(1, graphSize));
                    }
                    graph.AddEdge(graph.Nodes[z++], graph.Nodes[z], rng.Next(1, graphSize));
                }

                if (z < graphSize * graphSize - graphSize)
                {
                    graph.AddEdge(graph.Nodes[z], graph.Nodes[z + graphSize], rng.Next(1, graphSize));
                }
            }
        }

        public static Anthill<int> AnthillGenerete(int antCount, int graphSize, Graph<int> graph)
        {
            //var rng = new Random();
            //int anthillOnNode = rng.Next(1, graphSize);
            

            var node = graph.Nodes.FindByValue(5);           
            var antHill = new Anthill<int>(antCount, node);
            node.Anthill = antHill;
            node.HasAntHill = true;

            return antHill;
        }

        public static void SaveToFileCsvOrTxt(List<string> doZapisu)
        {
            Console.WriteLine("Name a file to which you want save the data: ");
            var fileName = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            string dataFilePath = Directory.GetCurrentDirectory() + "/" + fileName;
            if (fileName != null && fileName.Contains(".txt"))
            {
                foreach (var element in doZapisu)
                {
                    stringBuilder.AppendLine(element);
                }
                File.WriteAllText(dataFilePath, stringBuilder.ToString());

            }
            else
            {
                if (fileName != null && fileName.Contains(".csv"))
                {
                    foreach (var arrayElement in doZapisu)
                    {
                        var newLine = $"{arrayElement},{Environment.NewLine}";
                        stringBuilder.Append(newLine);
                        File.WriteAllText(dataFilePath, stringBuilder.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Wrong file format, only txt and csv are supported.");
                    Console.WriteLine("Try again");
                    SaveToFileCsvOrTxt(doZapisu);
                }
            }


        }
    }
}
