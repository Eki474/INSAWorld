﻿using System;
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

        [TestMethod()]
        public void TestPlayer()
        {
            Assert.IsNotNull(p.RacePlay);
        }

        [TestMethod()]
        public void TestStartTurn()
        {
            p.StartTurn();
            Assert.IsTrue(p.Playing);
        }

        [TestMethod()]
        public void TestEndTurn()
        {
            p.EndTurn();
            Assert.IsFalse(p.Playing);
        }

        [TestMethod()]
        public void TestLost()
        {
            p.ComputePoints();
            l.ComputePoints();
            bool temp = p.Points < l.Points;
            Assert.AreEqual(p.Lost(), temp);
        }

        [TestMethod()]
        public void TestComputePoints()
        {
            int temp = p.Points;
            p.ComputePoints();
            Assert.IsTrue(temp <= p.Points);
        }
    }
}
