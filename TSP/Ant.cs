using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant<T>
    {
        
        private int _antValueName;
        private Anthill<T> _hill;
        public ListOfNodes<T> Visited;

        public int LengthOfRoad { get; set; }
        public GraphNode<T> CurrentLocation { get; set; }
        public List<double> Probabilities { get; set; }
        

        public Ant(Anthill<T> hill, int antValueName, GraphNode<T> currentLocation)
        {
            CurrentLocation = currentLocation;
            _hill = hill;
            _antValueName = antValueName;
            Visited = new ListOfNodes<T> {CurrentLocation};
            Probabilities = ChooseWay(Visited, CurrentLocation.Neighbors);
        }
        

        public List<double> ChooseWay(ListOfNodes<T> visited, ListOfNodes<T> neighboors)
        {
            var probability = new List<double>();

            const double beta = 2;
            double sumOfAll = 0;


            for(var i = 0; i < neighboors.Count; i++)
            { 
                if (visited.Contains(neighboors[i])) continue;           

                sumOfAll += Convert.ToDouble(CurrentLocation.Pheromone[i]) * 
                            Math.Pow(1/Convert.ToDouble(CurrentLocation.Costs[i]), beta);                
            }

            for (var i = 0; i < neighboors.Count; i++)
            {
                if (visited.Contains(neighboors[i])) continue;

                var singleProb = (Convert.ToDouble(CurrentLocation.Pheromone[i]) * 
                                  Math.Pow(1 / Convert.ToDouble(CurrentLocation.Costs[i]), beta)) / sumOfAll;

                probability.Add(singleProb);

            }

            return probability;
        }

       
        public void ChangeLocation(List<double> probabilities)
        {
          
        }
    }
}
