using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant<T>
    {
        
        private readonly int _antValueName;
        private readonly Anthill<T> _hill;
        private readonly Random _random;

        public ListOfEdges<T> Visited;

        public double LengthOfRoad { get; set; }
        public GraphNode<T> CurrentLocation { get; set; }
        public List<double> Probabilities { get; set; }
        public bool FoundFood { get; set; }
        public bool FoundWay { get; set; }


        public Ant(Anthill<T> hill, int antValueName)
        {
            _hill = hill;
            CurrentLocation = hill.CurrentLocation;
            
            _antValueName = antValueName;
            Visited = new ListOfEdges<T>();
            _random = new Random(_antValueName);
        }
        

        private List<double> FindWay()
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

        public bool Wander()
        {
            
            Probabilities = FindWay();
            do
            {
                ChooseWay();
            } while (CurrentLocation.Food == false && Probabilities.Any(p => p > 0));
            CurrentLocation = _hill.CurrentLocation;

            return FoundFood;
        }

        private void ChooseWay()
        {
            double probabilitySpace = 0;
            var rollTheBones = _random.NextDouble();
            for (var j = 0; j < Probabilities.Count; j++)
            {
                if (FoundWay) break;
                probabilitySpace += Probabilities[j];
                if (!(rollTheBones <= probabilitySpace)) continue;
                FoundWay = true;
                ChangeLocation(j);
            }
        }
        private void ChangeLocation(int iterator)
        {
            Visited.Add(CurrentLocation.Neighbors[iterator]);
            LengthOfRoad += CurrentLocation.Neighbors[iterator].Cost;
            CurrentLocation = CurrentLocation == CurrentLocation.Neighbors[iterator].FirstNode
                ? CurrentLocation.Neighbors[iterator].SecondNode
                : CurrentLocation.Neighbors[iterator].FirstNode;
            Probabilities = FindWay();
        }

    }
}
