using System;
using System.Collections.Generic;

namespace INSAWORLD
{
    public class UnitsFactory
    {
        public static UnitsFactory Instance { get; } = new UnitsFactory();

        private UnitsFactory() {}

        /// <summary>
        /// create a unit of asked race (r) and coordinates (c)
        /// </summary>
        /// <param name="c">unit coordinates</param>
        /// <param name="r">unit race</param>
        /// <returns>unit</returns>
        public Unit createUnit(ref Race r)
        {   
            return new Unit(ref r);
        }

        /// <summary>
        /// create a units list
        /// </summary>
        /// <param name="r">race of the units in the list</param>
        /// <param name="taille">size of the map (to know how many units have to be created)</param>
        /// <returns>units list</returns>
        public List<Unit> createUnits(Race r , int taille)
        {
            var dico = new List<Unit>();
            
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
                Unit u = createUnit(ref r);
                dico.Add(u);
            }
   
            return dico;
         }
    }
}
