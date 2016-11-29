﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass()]
    public class GameTest
    {
        Game g;
        
        [TestInitialize()]
        public void Setup()
        {
            Player p1 = new Player("Michel", 0, 6);
            Player p2 = new Player("Jean", 1, 6);
            g = new Game(p1, p2);
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
        /// test if Launch method, start the game by making play a player
        /// </summary>
        [TestMethod()]
        public void TestLaunch()
        {
            g.Initialize();
            g.Launch();
            Assert.IsTrue(g.Player1.Playing);
        }

        /// <summary>
        /// test if the map is created
        /// </summary>
        [TestMethod()]
        public void TestInitialize()
        {
            g.Initialize();
            Assert.IsNotNull(g.Map);
        }

        /// <summary>
        /// test if the game is stopped by the EndGame method when there is no turn available to play
        /// (limited by the map)
        /// </summary>
        [TestMethod()]
        public void TestEndGame()
        {
            for(int i=0; i<5; i++)
            {
                g.Player1.EndTurn();
                g.Player2.EndTurn();
            }
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