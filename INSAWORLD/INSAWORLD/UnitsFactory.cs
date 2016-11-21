using System;
using System.Collections.Generic;

namespace INSAWORLD
{
    public class UnitsFactory
    {
        public static UnitsFactory Instance { get; } = new UnitsFactory();

        private UnitsFactory() {}

        public Unit createUnit(Race r)
        {   
            return new Unit(r);
        }

        public IDictionary<Unit, Coord> createUnits(Race r, int taille)
        {
            var dico = new Dictionary<Unit, Coord>();
            System.Random rnd = new System.Random();
            var coord = new Coord(rnd.Next(0,taille), rnd.Next(0, taille));
            //TODO check if no unit on coord
            int nbUnit;
            switch (taille)
            {
                case 6: nbUnit = 4; break;
                case 10: nbUnit = 6; break;
                case 14: nbUnit = 8; break;
                default: throw new System.Exception("size not valid"); 
            }

            for(;nbUnit>=0;nbUnit--)
            {
                Unit u = createUnit(r);
                dico.Add(u, coord);
            }
   
            return dico;
         }
    }
}
