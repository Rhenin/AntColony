using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant
    {       
        private readonly int _antValueName;
        private readonly Anthill _hill;
        private readonly Random _random;
        private readonly ListOfEdges _visited;
        private bool _foundFood;
        private double _lengthOfRoad;
        private GraphNode _currentLocation;
        private List<double> _probabilities;   
        public Ant(Anthill hill, int antValueName)
        {
            _hill = hill;
            _currentLocation = hill.CurrentLocation;           
            _antValueName = antValueName;
            _visited = new ListOfEdges();
            _random = new Random(_antValueName);
        }
        public void ResetAnt()
        {
            _visited.Clear();
            _foundFood = false;
            _lengthOfRoad = 0;
            _currentLocation = _hill.CurrentLocation;
        }
        public void UpdatePheromone(Edge item)
        {
            if (_foundFood == false) return;

            if (_visited.Contains(item))
            {
                item.Pheromone += (1 / _lengthOfRoad);
            }
        }
        public void Wander()
        {   
            _probabilities = FindWay();
            do
            {
                ChooseWay();
                if (_currentLocation.Food)
                    _foundFood = true;

            } while (!_foundFood && _probabilities.Any(p => p > 0));
        }
        private void ChooseWay()
        {
            double probabilitySpace = 0;
            var rollTheBones = _random.NextDouble();
            for (var j = 0; j < _probabilities.Count; j++)
            {
                probabilitySpace += _probabilities[j];
                if (!(rollTheBones < probabilitySpace)) continue;
                ChangeLocation(j);
                break;
            }            
        }
        private void ChangeLocation(int iterator)
        {
            _visited.Add(_currentLocation.Neighbors[iterator]);
            _lengthOfRoad += _currentLocation.Neighbors[iterator].Cost;
            _currentLocation = _currentLocation == _currentLocation.Neighbors[iterator].FirstNode
                ? _currentLocation.Neighbors[iterator].SecondNode
                : _currentLocation.Neighbors[iterator].FirstNode;
            _probabilities = FindWay();
        }
        private List<double> FindWay()
        {
            var probability = new List<double>();

            const double beta = 2;
            double sumOfAll = 0;


            foreach (var itemEdge in _currentLocation.Neighbors)
            {
                if (_visited.Contains(itemEdge)) continue;
                sumOfAll += Convert.ToDouble(itemEdge.Pheromone) *
                            Math.Pow(1 / Convert.ToDouble(itemEdge.Cost), beta);
            }

            foreach (var itemEdge in _currentLocation.Neighbors)
            {
                if (_visited.Contains(itemEdge))
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
