﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TSP
{
    [DebuggerDisplay("Ant number: {" + nameof(_antValueName) + "}")]
    public class Ant<T>
    {
        
        private int _antValueName;
        private Anthill<T> _hill;
        public GraphNode<T> CurrentLocation { get; set; } 

        public Ant(Anthill<T> hill, int antValueName, GraphNode<T> currentLocation)
        {
            CurrentLocation = currentLocation;
            _hill = hill;
            _antValueName = antValueName;
        }
        public ListOfNodes<T> Visited = new ListOfNodes<T>();

        public List<double> ChooseWay(ListOfNodes<T> visited, ListOfNodes<T> neighboors)
        {
            List<double> probability = new List<double>();
            

            const double beta = 0.5;
            double sumOfAll = 0;

            
            for(var i = 0; i < neighboors.Count; i++)
            { 
                if (!visited.Contains(neighboors[i]))               
                    sumOfAll += Convert.ToDouble(neighboors[i].Pheromone) *  
                                Math.Pow(1/Convert.ToDouble(CurrentLocation.Costs[i]), beta);                
            }

            for (var i = 0; i < neighboors.Count; i++)
            {
                if (visited.Contains(neighboors[i])) continue;

                var singleProb = (Convert.ToDouble(neighboors[i].Pheromone) *
                                  Math.Pow(1 / Convert.ToDouble(CurrentLocation.Costs[i]), beta)) / sumOfAll;
                probability.Add(singleProb);

            }

            return probability;
        }
    }
}
