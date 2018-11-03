using System;

namespace TSP
{
    public class Graph
    {
        private readonly int _graphSize;
        private readonly Random _random = new Random();
        private readonly ListOfNodes _nodes;
        private readonly ListOfEdges _edges;
        public Anthill Anthill { get; set; }
        public Graph(int size)
        {
            _nodes = new ListOfNodes();
            _edges = new ListOfEdges();
            _graphSize = size;
            GraphGenerate();
            _nodes.FindByValue(30).Food = true;
            _nodes.FindByValue(36).Food = true;
        }
        private void AddNode(int value)
        {
            _nodes.Add(new GraphNode(value));
        }
        private void AddEdge(int value)
        {
            _edges.Add(new Edge(value));
        }
        private void InitEdge(GraphNode from, GraphNode to, int value)
        {
            var currentEdge = _edges.FindByValue(value);
            from.Neighbors.Add(currentEdge);
            to.Neighbors.Add(currentEdge);
            currentEdge.FirstNode = from;
            currentEdge.SecondNode = to;
            currentEdge.Cost = _random.Next(1, 10);
        }
        private void GraphGenerate()
        {         
            for (int j = 0; j < _graphSize * _graphSize; j++)
            {
                AddNode(j + 1);
            }
            int edgeCount = _graphSize * _graphSize + (_graphSize - 1) * (_graphSize - 1) - 1;
            for (int i = 0; i < edgeCount; i++)
            {
                AddEdge(i + 1);
            }
            ConnectNodes();
        }
        private void ConnectNodes()
        {
            int edgeName = 1;
            for (int j = 0, nodeIndex = 0; j < _graphSize; j++, nodeIndex++)
            {
                for (int i = 0; i < _graphSize - 1; i++)
                {
                    if (nodeIndex < _graphSize * _graphSize - _graphSize)
                    {
                        InitEdge(_nodes[nodeIndex], _nodes[nodeIndex + _graphSize], edgeName++);
                    }

                    InitEdge(_nodes[nodeIndex++], _nodes[nodeIndex], edgeName++);
                }
                if (nodeIndex < _graphSize * _graphSize - _graphSize)
                {
                    InitEdge(_nodes[nodeIndex], _nodes[nodeIndex + _graphSize], edgeName++);
                }
            }
        }
        public void GlobalUpdateRule()
        {
            const double vanishRate = 0.5;
            foreach (var item in _edges)
            {
                item.Pheromone = (1 - vanishRate) * item.Pheromone;
                foreach (var ant in Anthill.Ants)
                {
                    ant.UpdatePheromone(item);
                }
            }
        }
        public Anthill AnthillGenerate(int antCount)
        {
            //int anthillOnNode = rng.Next(1, graphSize);
            Anthill = new Anthill(antCount, _nodes.FindByValue(6));
            return Anthill;
        }
    }
}
