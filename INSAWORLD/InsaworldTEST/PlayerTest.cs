using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass()]
    public class PlayerTest
    {

        Player p;
        Player l;

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Bob", 0, 6);
            l = new Player("Jean", 1, 6);
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
        /// test if when a player finish his turn, he is not playing anymore
        /// </summary>
        [TestMethod()]
        public void TestEndTurn()
        {
            p.EndTurn();
            Assert.IsFalse(p.Playing);
        }

        /// <summary>
        /// test if when a player has less points than the other, he lost
        /// </summary>
        [TestMethod()]
        public void TestLost()
        {
            p.ComputePoints();
            l.ComputePoints();
            bool temp = p.Points < l.Points;
            Assert.AreEqual(p.Lost(), temp);
        }

        /// <summary>
        /// test if the computePoints methods update well the points attribute
        /// </summary>
        [TestMethod()]
        public void TestComputePoints()
        {
            int temp = p.Points;
            p.ComputePoints();
            Assert.IsTrue(temp <= p.Points);
        }
    }
}
