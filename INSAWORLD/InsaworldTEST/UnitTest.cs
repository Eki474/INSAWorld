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

            Coord c1 = new Coord(0, 0);
            Coord c2 = new Coord(0, 0);
            Coord c3 = new Coord(1, 1);
            race = RaceFactory.Instance.createRace(0);
            r = RaceFactory.Instance.createRace(1);
            u = UnitsFactory.Instance.createUnit(ref race, ref c1);
            n = UnitsFactory.Instance.createUnit(ref race, ref c2);
            i = UnitsFactory.Instance.createUnit(ref r, ref c3);
            p1 = new Player("Jean", 2, 6);
            p2 = new Player("Paul", 1, 6);
            g = new Game(ref p1, ref p2);
        }

        /// <summary>
        /// constructor for a single unit test
        /// </summary>
        [TestMethod()]
        public void TestUnit()
        {
            Assert.AreEqual(u.LifePoints, race.Life);
        }

        /// <summary>
        /// constructor for a list of units
        /// </summary>
        [TestMethod()]
        public void TestUnitList()
        {
            Assert.IsNotNull(p1.UnitsList);
        }

        /// <summary>
        /// test of attack on another unit, life points is well diminished
        /// </summary>
        [TestMethod()]
        public void TestAttack()
        {
            Unit u1 = p1.UnitsList.First();
            u1.C = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            u2.C = new Coord(0, 1);
            bool b = p1.Attack(u1, u2, ref g);
            Assert.IsTrue(b && (u1.LifePoints < u1.Race.Life || u2.LifePoints < u2.Race.Life));
        } 

        /// <summary>
        /// test of attack on another unit, when the units are too far from each other
        /// </summary>
        [TestMethod()]
        public void TestAttackFail()
        {
            Unit u1 = p1.UnitsList.First();
            u1.C = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            u2.C = new Coord(5, 5);
            bool b = p1.Attack(u1, u2, ref g);
            Assert.IsFalse(b && (u1.LifePoints == u1.Race.Life || u2.LifePoints == u2.Race.Life));
        }

        /// <summary>
        /// test if the unit goes back to its initial state after reset
        /// </summary>
        [TestMethod()]
        public void TestReset()
        {
            u.MovePoints = 0;
            u.Reset();
            Assert.IsTrue(u.LifePoints != 0);
        }

        /// <summary>
        /// test if unit is marked as played when it can do anything else
        /// </summary>
        [TestMethod()]
        public void TestPlayed()
        {
            //Attack
            Unit u1 = p1.UnitsList.First();
            u1.C = new Coord(0, 0);
            var u2 = p2.UnitsList.First();
            u2.C = new Coord(0, 1);
            bool b = p1.Attack(u1, u2, ref g);

            Assert.IsTrue(u1.Played);
        }
    }
}
