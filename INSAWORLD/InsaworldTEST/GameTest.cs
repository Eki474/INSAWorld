using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass]
    public class GameTest
    {
        Game g;

        [TestInitialize()]
        public void Initialize()
        {
            Player p1 = new Player("Michel", 0);
            Player p2 = new Player("Jean", 1);
            g = new Game(p1, p2);
        }

        [TestMethod]
        public void TestGame()
        {
            Assert.IsNotNull(g.Player1);
        }

        [TestMethod]
        public void TestLaunch()
        {
            g.Initialize();
            g.Launch();
            Assert.IsTrue(g.Player1.Playing);
        }

        [TestMethod]
        public void TestInitialize()
        {
            g.Initialize();
            Assert.IsNotNull(g.Map);
        }

        [TestMethod]
        public void TestEndGame()
        {
            for(int i=0; i<5; i++)
            {
                g.Player1.EndTurn();
                g.Player2.EndTurn();
            }
            Assert.IsTrue(g.EndGame());
        }

        [TestMethod]
        public void TestEndGameFail()
        {
            Assert.IsFalse(g.EndGame());
        }
    }
}
