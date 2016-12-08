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

        /// <summary>
        /// test if when a player end his turn the playing attributes exchange values (true - false)
        /// test if number of turn are well decremented in the GameMap object
        /// </summary>
        [TestMethod]
        public void TestNextTurnCommand()
        {
            bool b1 = g.Player1.Playing;
            bool b2 = g.Player2.Playing;
            double turn = g.Map.NbTurn;

            if (g.Player1.Playing)
            {
                new NextTurn(g).Execute();
            }
            else
            {
                new NextTurn(g).Execute();
            }
            Assert.IsTrue(g.Map.NbTurn < turn);
            Assert.IsFalse(g.Player1.Playing && b1);
            Assert.IsFalse(g.Player2.Playing && b2);
        }
    }
}
