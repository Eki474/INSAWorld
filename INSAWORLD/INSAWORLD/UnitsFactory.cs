using System;
using System.Collections.Generic;

namespace INSAWORLD
{
    public class UnitsFactory
    {
        public static UnitsFactory Instance { get; } = new UnitsFactory();

        private UnitsFactory() {}

        /// <summary>
        /// crée une unité de la race demandéé (r)
        /// </summary>
        /// <param name="r">race de l'unité</param>
        /// <returns>retourne l'unité créée</returns>
        public Unit createUnit(Race r)
        {   
            return new Unit(r);
        }

        /// <summary>
        /// crée une liste d'unité
        /// </summary>
        /// <param name="r">race des unités de la liste</param>
        /// <param name="taille">taille de la map qui détermine le nombre d'unités créées</param>
        /// <returns>la liste créée</returns>
        public IDictionary<Unit, Coord> createUnits(Race r, int taille)
        {
            var dico = new Dictionary<Unit, Coord>();
            //TODO units placement must be handled by C++ librairy
            Random rnd = new Random();
            var coord = new Coord(rnd.Next(0,taille), rnd.Next(0, taille));
            //TODO check if no unit on coord
            int nbUnit;
            switch (taille)
            {
                case 6: nbUnit = 4; break;
                case 10: nbUnit = 6; break;
                case 14: nbUnit = 8; break;
                default: throw new Exception("size not valid"); 
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
