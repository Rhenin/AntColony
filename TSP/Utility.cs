using System;

namespace TSP
{
    static class Utility
    {
        public static Graph<int> GraphGenerate(int graphSize)
        {
            var rng = new Random();
            //node creation
            int nodeCount = 1;
            var graph = new Graph<int>();

            for (int j = 0; j < graphSize; j++)
            {
                for (int i = 0; i < graphSize; i++)
                {
                    graph.AddNode(nodeCount++);
                }
            }

            //node connection
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

            return graph;
        }

        public static Anthill<int> AnthillGenerete(int antCount, int graphSize, Graph<int> graph)
        {
            //var rng = new Random();
            //int anthillOnNode = rng.Next(1, graphSize);
            var antHill = new Anthill<int>(antCount);

            var node = graph.Nodes.FindByValue(3);
            node.Anthill = antHill;
            node.HasAntHill = true;

            return antHill;
        }
    }
}
