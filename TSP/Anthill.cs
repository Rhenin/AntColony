using System.Collections.Generic;

namespace TSP
{
    public class Anthill
    {
        public List<Ant> Ants = new List<Ant>();
        public GraphNode CurrentLocation { get; set; }  
        public Anthill(int antCount, GraphNode currentLocation)
        {
            CurrentLocation = currentLocation;
            CreateAnts(antCount);
            CurrentLocation.Anthill = this;
        }
        public void CreateAnts(int antCount)
        {
            for (int i = 0; i < antCount; i++)
            {
                Ants.Add(new Ant(this, i+1));
            }
        }        
    }
}

