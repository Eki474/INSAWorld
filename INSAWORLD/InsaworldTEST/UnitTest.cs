using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
namespace InsaworldTEST
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void testUnit()
        {
            Race race = RaceFactory.Instance.createRace(0);
            Unit unit1 = UnitsFactory.Instance.createUnit(race);
            Assert.AreEqual(unit1.LifePoints, race.Life);
        }

        [TestMethod]
        public void testAttack()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void testAttackFail()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void testReset()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void testPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
