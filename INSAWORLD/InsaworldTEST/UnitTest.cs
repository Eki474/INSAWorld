using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Collections.Generic;
using System;
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
            IEnumerator<Unit> uList1 = p1.UnitsList.Keys.GetEnumerator();
            Unit u1 = uList1.Current;
            p1.UnitsList.Add(u1, new Coord(0,0));
            IEnumerator<Unit> uList2 = p2.UnitsList.Keys.GetEnumerator();
            Unit u2 = uList2.Current;
            p2.UnitsList.Add(u2, new Coord(0, 1));
            Coord c2;
            p2.UnitsList.TryGetValue(u2, out c2);
            bool b = p1.Attack(u1, c2);
            Assert.IsTrue(b && (u2.LifePoints < r.Life || u1.LifePoints < race.Life));
        }

        /// <summary>
        /// test of attack on another unit, when the units are too far from each other
        /// </summary>
        [TestMethod()]
        public void testAttackFail()
        {
            IEnumerator<Unit> uList1 = p1.UnitsList.Keys.GetEnumerator();
            Unit u1 = uList1.Current;
            p1.UnitsList.Add(u1, new Coord(0, 0));
            IEnumerator<Unit> uList2 = p2.UnitsList.Keys.GetEnumerator();
            Unit u2 = uList2.Current;
            p2.UnitsList.Add(u2, new Coord(5, 5));
            Coord c2;
            p2.UnitsList.TryGetValue(u2, out c2);
            bool b = p1.Attack(u1, c2);

            Assert.IsFalse(b);
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
            IEnumerator<Unit> uList1 = p1.UnitsList.Keys.GetEnumerator();
            Unit u1 = uList1.Current;
            p1.UnitsList.Add(u1, new Coord(0, 0));
            IEnumerator<Unit> uList2 = p2.UnitsList.Keys.GetEnumerator();
            Unit u2 = uList2.Current;
            p2.UnitsList.Add(u2, new Coord(0, 1));
            Coord c2;
            p2.UnitsList.TryGetValue(u2, out c2);
            bool b = p1.Attack(u1, c2);

            //Move
            Coord cMove;
            p1.UnitsList.TryGetValue(u1, out cMove);
            Coord changed = new Coord(cMove.X, cMove.Y + 3);
            p1.RacePlay.ActionMove(u1, changed);

            Assert.IsTrue(u1.Played);
        }
    }
}
