using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Linq;

namespace InsaworldTEST
{
    [TestClass]
    public class ReplayCollectorTest
    {

        private Game g;

        [TestInitialize()]
        public void Setup()
        {
            Player p1 = new Player("batman", 0, 6);
            Player p2 = new Player("superman", 1, 6);
            g = new Game(ref p1, ref p2);
            g.Initialize(0);
        }

        /// <summary>
        /// test if a step id added to the collector list
        /// </summary>
        [TestMethod]
        public void TestAddStep()
        {
            new NextTurn(g).Execute();
            Assert.IsTrue(g.Rpz.Step.Count() > 0);
            Assert.IsNotNull(g.Rpz.Step.First());
        }

        /// <summary>
        /// test if the init state is stocked in initState variable
        /// </summary>
        [TestMethod]
        public void TestInitState()
        {
            Assert.IsNotNull(g.Rpz.InitState);
        }
    }
}
