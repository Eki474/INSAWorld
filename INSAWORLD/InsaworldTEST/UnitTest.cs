using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Collections.Generic;
using System;
using System.Linq;

namespace InsaworldTEST
{
    [TestClass()]
    public class UnitTest
    {

        Unit u;
        Unit n;
        Unit i;
        Race race;
        Race r;
        Player p1;
        Player p2;
        Game g;

        [TestInitialize()]
        public void Setup()
        {
            race = RaceFactory.Instance.createRace(0);
            r = RaceFactory.Instance.createRace(1);
            u = UnitsFactory.Instance.createUnit(race);
            n = UnitsFactory.Instance.createUnit(race);
            i = UnitsFactory.Instance.createUnit(r);
            p1 = new Player("Jean", 2, 6);
            p2 = new Player("Paul", 1, 6);
            g = new Game(p1, p2);
        }

        /// <summary>
        /// constructor for a single unit test
        /// </summary>
        [TestMethod()]
        public void testUnit()
        {
            Assert.AreEqual(u.LifePoints, race.Life);
        }

        /// <summary>
        /// constructor for a list of units
        /// </summary>
        [TestMethod()]
        public void testUnitList()
        {
            Assert.IsNotNull(p1.UnitsList);
        }

        /// <summary>
        /// test of attack on another unit, life points is well diminished
        /// </summary>
        [TestMethod()]
        public void testAttack()
        {
            Unit u1 = p1.UnitsList.Keys.First();
            p1.UnitsList[u1] = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            p2.UnitsList[u2.Key] = new Coord(0, 1);
            bool b = p1.Attack(u1, u2, ref g);
            Assert.IsTrue(b && (u1.LifePoints < u1.Race.Life || u2.Key.LifePoints < u2.Key.Race.Life));
        } 

        /// <summary>
        /// test of attack on another unit, when the units are too far from each other
        /// </summary>
        [TestMethod()]
        public void testAttackFail()
        {
            Unit u1 = p1.UnitsList.Keys.First();
            p1.UnitsList[u1] = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            p2.UnitsList[u2.Key] = new Coord(5, 5);
            bool b = p1.Attack(u1, u2, ref g);
            Assert.IsFalse(b && (u1.LifePoints == u1.Race.Life || u2.Key.LifePoints == u2.Key.Race.Life));
        }

        /// <summary>
        /// test if the unit goes back to its initial state after reset
        /// </summary>
        [TestMethod()]
        public void testReset()
        {
            u.MovePoints = 0;
            u.Reset();
            Assert.IsTrue(u.LifePoints != 0);
        }

        /// <summary>
        /// test if unit is marked as played when it can do anything else
        /// </summary>
        [TestMethod()]
        public void testPlayed()
        {
            //Attack
            Unit u1 = p1.UnitsList.Keys.First();
            p1.UnitsList[u1] = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            p2.UnitsList[u2.Key] = new Coord(0, 1);
            bool b = p1.Attack(u1, u2, ref g);

            Assert.IsTrue(u1.Played);
        }
    }
}
