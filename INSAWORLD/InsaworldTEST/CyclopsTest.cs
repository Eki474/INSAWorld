using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Linq;

namespace InsaworldTEST
{
    [TestClass()]
    public class CyclopsTest
    {
        Player p;
        Game g;

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Michel", 0, 6);
            Player temp = new Player("Jean", 1, 6);
            g = new Game(ref p, ref temp);
            p.UnitsList.First().C = new Coord(0, 0);
            //g.Initialize(0);
        }

        /// <summary>
        /// test Cyclops constructor
        /// </summary>
        [TestMethod()]
        public void TestCyclops()
        {
            Assert.IsInstanceOfType(p.RacePlay, typeof(Cyclops));
            Assert.IsNotNull(p.RacePlay.Life);
        }

        /// <summary>
        /// test if a wrong race is choose, an exception is risen
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(BadRaceException))]
        public void TestCyclopsFail()
        {
            Player trash = new Player("Batman", 5, 6);
        }

        /// <summary>
        /// test if a unit is moved by the ActionMove method
        /// </summary>
        [TestMethod()]
        public void TestActionMove()
        {
            var u = p.UnitsList.First();
            Coord changed = new Coord(u.C.X + 1, u.C.Y + 1);
            p.RacePlay.ActionMove(u, changed, ref g);
            Coord n = p.UnitsList.First().C;
            Assert.AreEqual(changed, n);
        }

        /// <summary>
        /// test if when the unit is asked to move too far, it rise an exception
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(OutOfBoundException))]
        public void TestActionMoveFail()
        {
            var u = p.UnitsList.First();
            Coord changed = new Coord(u.C.X + 10, u.C.Y + 10);
            p.RacePlay.ActionMove(u, changed, ref g);
        }

        /// <summary>
        /// test if at the beginning of the game players have points
        /// test if when a player have no more units, he has no point and lost
        /// </summary>
        [TestMethod()]
        public void TestVictoryPoints()
        {
            Unit v = p.UnitsList.First();
            Assert.IsTrue(p.UnitsList != null & p.RacePlay.VictoryPoints(v, ref g) > 0);
            p.UnitsList.Clear();
            Assert.IsTrue(p.RacePlay.VictoryPoints(v, ref g) == 0);
        }

        /// <summary>
        /// test if, with no more movePoints, the unit can still move with this method
        /// </summary>
        [TestMethod()]
        public void TestMoveOverride()
        {
            Unit u = p.UnitsList.First();
            u.MovePoints = 0;
            Coord temp = new Coord(u.C.X + 1, u.C.Y);
            Race r = RaceFactory.Instance.createRace(1);
            Unit d = UnitsFactory.Instance.createUnit(ref r);
            d.C= temp;
            p.RacePlay.MoveOverride(u, d, ref g);
            Assert.AreEqual(temp, u.C);
        }

        /// <summary>
        /// test if a unit with no life points can't move 
        /// </summary>
        [TestMethod()]
        public void TestNoMoreMoves()
        {
            Unit u = p.UnitsList.First();
            u.MovePoints = 0;
            GameMap m = g.Map;
            Assert.IsTrue(p.RacePlay.NoMoreMoves(u, ref m));
        }
    }
}
