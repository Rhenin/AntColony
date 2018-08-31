using System.Collections.Generic;

namespace TSP
{
    public class Anthill<T>
    {
        public List<Ant<T>> Ants = new List<Ant<T>>();

     
        public Anthill(int antCount)
        {
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

