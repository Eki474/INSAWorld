using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ICollection<Unit> createUnits()
        {
            throw new System.NotImplementedException();
        }
    }
}
