using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Linq;

namespace InsaworldTEST
{
    [TestClass()]
    public class CentaursTest
    {

        Player p;
        Game g;

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Michel", 2, 6);
            Player temp = new Player("Jean", 0, 6);
            g = new Game(ref p, ref temp);
            g.Initialize(0);
        }

        /// <summary>
        /// test Centaurs constructor
        /// </summary>
        [TestMethod()]
        public void TestCentaurs()
        {
            Assert.IsInstanceOfType(p.RacePlay, typeof(Centaurs));
            Assert.IsNotNull(p.RacePlay.Life);
        }

        /// <summary>
        /// test if a wrong race is choose, an exception is risen
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(BadRaceException))]
        public void TestCentaursFail()
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
            Coord changed = new Coord(u.C.X + 1, u.C.Y);
            p.RacePlay.ActionMove(u, changed, ref g);
            Coord n = u.C;
            Assert.AreEqual(changed, n);
        }

        /// <summary>
        /// test if when the unit is asked to move too far, it rise an exception
        /// </summary>
        [TestMethod()]
        public void TestActionMoveFail()
        {
            var u = p.UnitsList.First();
            Coord changed = new Coord(u.C.X + 10, u.C.Y + 10);
            Assert.IsFalse(p.Move(u, changed, ref g));
        }

        /// <summary>
        /// test if at the beginning of the game players have points
        /// test if when a player have no more units, he has no point and lost
        /// </summary>
        [TestMethod()]
        public void TestVictoryPoints()
        {
            Unit v = p.UnitsList.First();
            if (g.Map.CasesJoueur[v.C].getType().Equals("volcano")) Assert.AreEqual(p.RacePlay.VictoryPoints(v, ref g), 0);
            else Assert.AreNotEqual(p.RacePlay.VictoryPoints(v, ref g), 0);


        }

        /// <summary>
        /// test if the unit can move with this method
        /// </summary>
        [TestMethod()]
        public void TestTryMove()
        {
            Unit u = p.UnitsList.First();
            Coord temp = new Coord(u.C.X + 1, u.C.Y);
            Assert.IsTrue(p.RacePlay.TryMove(u, temp, ref g));

            u.MovePoints = 0;
            Assert.IsFalse(p.RacePlay.TryMove(u, temp, ref g));
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

        [TestMethod()]
        public void TestSuggestMove()
        {
            Unit u = p.UnitsList.First();
            Assert.IsNotNull(BuilderMap.Instance.suggestMove(ref g, u));
        }
    }
}
