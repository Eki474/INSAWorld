using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
namespace InsaworldTEST
{
    [TestClass]
    public class UnitTest
    {

        Unit u;
        Unit n;
        Unit i;
        Race race;

        [TestInitialize()]
        public void Initialize()
        {
            race = RaceFactory.Instance.createRace(0);
            Race r = RaceFactory.Instance.createRace(1);
            u = UnitsFactory.Instance.createUnit(race);
            n = UnitsFactory.Instance.createUnit(race);
            i = UnitsFactory.Instance.createUnit(r);
        }

        [TestMethod]
        public void testUnit()
        {
            Assert.AreEqual(u.LifePoints, race.Life);
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
            u.MovePoints = 0;
            u.Reset();
            Assert.IsTrue(u.LifePoints != 0);
        }

        [TestMethod]
        public void testPlayed()
        {
            u.Attack();
            Assert.IsTrue(u.Played);
        }
    }
}
