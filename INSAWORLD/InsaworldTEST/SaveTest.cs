using System;
using System.Linq;
using INSAWORLD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsaworldTEST
{
    [TestClass]
    public class SaveTest
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
        public void TestSaveCommand()
        {
            var cmd = new SaveCommand(ref g, "holo");
            if (cmd.CanExecute()) cmd.Execute();
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void TestLoadCommand()
        {
            var cmd = new LoadCommand("holo");
            if (cmd.CanExecute()) cmd.Execute();
            Assert.IsFalse(true);
        }
    }
}
