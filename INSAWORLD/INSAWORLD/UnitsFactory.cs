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

        public IDictionary<Unit, Coord> createUnits(Race r)
        {
            throw new System.NotImplementedException();
        }
    }
}
