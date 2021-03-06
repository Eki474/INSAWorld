﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass()]
    public class GameTest
    {
        Game g;
        GameMap m;
        
        [TestInitialize()]
        public void Setup()
        {
            Player p1 = new Player("Michel", 0, 6);
            Player p2 = new Player("Jean", 1, 6);
            g = new Game(ref p1, ref p2);
            m = g.Map;
            g.Initialize(0);
        }

        /// <summary>
        /// test the Game constructor
        /// </summary>
        [TestMethod()]
        public void TestGame()
        {
            Assert.IsNotNull(g.Player1);
        }

        /// <summary>
        /// test if the map is created
        /// </summary>
        [TestMethod()]
        public void TestInitialize()
        {
            g.Initialize(0);
            Assert.IsNotNull(g.Map);
        }

        /// <summary>
        /// test if the game is stopped by the EndGame method when there is no turn available to play
        /// (limited by the map)
        /// </summary>
        [TestMethod()]
        public void TestEndGame()
        {
            g.Player1.UnitsList.Clear();
            Assert.IsTrue(g.EndGame());
        }

        /// <summary>
        /// test if when no end game conditions are true, the game don't stop
        /// </summary>
        [TestMethod()]
        public void TestEndGameFail()
        {
            Assert.IsFalse(g.EndGame());
        }
    }
}
