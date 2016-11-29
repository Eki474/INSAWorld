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

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Michel", 0, 6);
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
            Coord changed = new Coord(u.Value.X + 1, u.Value.Y + 1);
            p.RacePlay.ActionMove(u.Key, changed);
            Coord n = p.UnitsList.First().Value;
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
            Coord changed = new Coord(u.Value.X + 10, u.Value.Y + 10);
            p.RacePlay.ActionMove(u.Key, changed);
        }

        /// <summary>
        /// test if at the beginning of the game players have points
        /// test if when a player have no more units, he has no point and lost
        /// </summary>
        [TestMethod()]
        public void TestVictoryPoints()
        {
            Assert.IsTrue(p.UnitsList != null & p.RacePlay.VictoryPoints() > 0);
            p.UnitsList.Clear();
            Assert.IsTrue(p.RacePlay.VictoryPoints() == 0);
        }
    }
}
