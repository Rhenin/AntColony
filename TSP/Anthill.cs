using System.Collections.Generic;

namespace TSP
{
    public class Anthill<T>
    {

        public List<Ant<T>> Ants = new List<Ant<T>>();

        public GraphNode<T> CurrentLocation { get; set; }
     
        public Anthill(int antCount, GraphNode<T> currentLocation)
        {
            CurrentLocation = currentLocation;
            CreateAnts(antCount);
        }

        //creating ants
        public void CreateAnts(int antCount)
        {
            for (int i = 0; i < antCount; i++)
            {
                Ants.Add(new Ant<T>(this, i+1));
            }
        }

        
    }
}

