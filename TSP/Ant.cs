using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant<T>
    {
        
        private readonly int _antValueName;
        private readonly Anthill<T> _hill;
        public ListOfEdges<T> Visited;

        public double LengthOfRoad { get; set; }
        public GraphNode<T> CurrentLocation { get; set; }
        public List<double> Probabilities { get; set; }
        public bool FoundFood { get; set; } = false;
        

        public Ant(Anthill<T> hill, int antValueName, GraphNode<T> currentLocation)
        {
            CurrentLocation = currentLocation;
            _hill = hill;
            _antValueName = antValueName;
            Visited = new ListOfEdges<T>();
        }
        

        public List<double> ChooseWay()
        {
            var probability = new List<double>();

            const double beta = 2;
            double sumOfAll = 0;


            foreach (var itemEdge in CurrentLocation.Neighbors)
            {
                if (Visited.Contains(itemEdge)) continue;           
                sumOfAll += Convert.ToDouble(itemEdge.Pheromone) * 
                            Math.Pow(1/Convert.ToDouble(itemEdge.Cost), beta);
            }

            foreach (var itemEdge in CurrentLocation.Neighbors)
            {
                if (Visited.Contains(itemEdge))
                {
                    probability.Add(0);
                    continue;
                }
                var singleProb = (Convert.ToDouble(itemEdge.Pheromone) * 
                                  Math.Pow(1 / Convert.ToDouble(itemEdge.Cost), beta)) / sumOfAll;

                probability.Add(singleProb);
            }

            return probability;
        }

               
    }
}
