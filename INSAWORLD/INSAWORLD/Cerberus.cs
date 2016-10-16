using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cerberus : Race
    {
        //contains units of the race (so player) and their coordinates on the map
        private Dictionary<Coord, Unit> units;

        public Cerberus()
        {
            //add base units of the race
        }

        public ~Cerberus()
        {
            //delete units;
            units.Clear(); //vide la liste
            //à compléter le delete fonctionne pas 
        }

        public Dictionary<Coord, Unit> Units
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //method : compute points earned by the race, this turn
        public void VictoryPoints()
        {
            throw new NotImplementedException();
        }
    }
}
