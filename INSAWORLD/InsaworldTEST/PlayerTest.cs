using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass()]
    public class PlayerTest
    {

        Game g;
        GameMap m;
        Player p;
        Player l;

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Bob", 0, 6);
            l = new Player("Jean", 1, 6);
            g = new Game(ref p, ref l);
            m = g.Map;
            g.Initialize(0);
        }

        /// <summary>
        /// test of player constructor
        /// </summary>
        [TestMethod()]
        public void TestPlayer()
        {
            Assert.IsNotNull(p.RacePlay);
        }

        /// <summary>
        /// test if when a player start playing, his attribute say so too
        /// </summary>
        [TestMethod()]
        public void TestStartTurn()
        {
            p.StartTurn();
            Assert.IsTrue(p.Playing);
        }

        /// <summary>
        /// test if a player can still play
        /// </summary>
        [TestMethod()]
        public void TestEndTurnFail()
        {
            
            Assert.IsFalse(p.EndTurn(ref m));
        }

        /// <summary>
        /// test if a player can still play
        /// </summary>
        [TestMethod()]
        public void TestEndTurn()
        {
            Player p1 = g.Player1;
            Coord c = p1.UnitsList.First().C;
            Coord d = new Coord(c.X + 3, c.Y);
            Coord e = new Coord(c.X + 1, c.Y);

            Coord f = new Coord(c.X + 2, c.Y);
            foreach (Unit u in g.Player2.UnitsList)
            {
                u.C = d;
            }
            foreach(Unit u in p1.UnitsList)
            {
                p1.RacePlay.ActionMove(u, e, ref g);
                p1.RacePlay.ActionMove(u, f, ref g);
                p1.Attack(u, g.Player1.FindDefender(d, ref g), ref g);
                u.MovePoints = 0;
            }
            Assert.IsTrue(p1.EndTurn(ref m));
        }

        /// <summary>
        /// test if when a player has no units left, he loses
        /// </summary>
        [TestMethod()]
        public void TestLost()
        {
            p.UnitsList.Clear();
            Assert.IsTrue(p.Lost());
        }

        /// <summary>
        /// test if the computePoints methods update well the points attribute
        /// </summary>
        [TestMethod()]
        public void TestComputePoints()
        {
            int temp = p.Points;
            p.ComputePoints(ref g);
            Assert.IsTrue(temp <= p.Points);
        }

        /// <summary>
        /// test if the method return the higher def unit
        /// </summary>
        [TestMethod()]
        public void TestFindDefender()
        {
            Unit u = l.UnitsList.First();
            u.LifePoints -= 2;
            Unit res = p.FindDefender(u.C, ref g);
            Assert.IsNotNull(res);
            Assert.AreNotEqual(u, res);
        }
    }
}
