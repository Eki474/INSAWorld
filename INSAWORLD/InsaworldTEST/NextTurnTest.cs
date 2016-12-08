using System;
using System.Linq;
using INSAWORLD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsaworldTEST
{
    [TestClass]
    public class NextTurnTest
    {
        private Game g;

        [TestInitialize()]
        public void Setup()
        {
            var rdn = new Random();
            Player p1 = new Player("batman", 0, 6);
            Player p2 = new Player("superman", 1, 6);
            g = new Game(ref p1, ref p2);
            g.Initialize(0);
        }

        [TestMethod]
        public void TestNextTurnCommand()
        {
            var rdn = new Random();
            var l1 = g.Player1.UnitsList;
            var l2 = g.Player2.UnitsList;
            if (g.Player1.Playing)
            {
                int nb = rdn.Next(0, l1.Count);
                Unit u = l1[nb];
                Coord c = u.C;
                g.Player1.Move(l1.First(), c, ref g);
                g.Player1.ComputePoints(ref g);
                new NextTurn(g).Execute();
            }
            else
            {
                int nb = rdn.Next(0, l2.Count);
                Unit u = l2[nb];
                Coord c = u.C;
                g.Player2.Move(l2.First(), c, ref g);
                g.Player2.ComputePoints(ref g);
                new NextTurn(g).Execute();
            }
            Assert.IsFalse(true);
        }
    }
}
