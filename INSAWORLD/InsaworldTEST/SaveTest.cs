using System;
using System.Linq;
using INSAWORLD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        /// <summary>
        /// test if a file is created for the save and if it is not empty
        /// </summary>
        [TestMethod]
        public void TestSaveCommand()
        {
            var cmd = new SaveCommand(ref g, "holo");
            if (cmd.CanExecute()) cmd.Execute();

            Assert.IsTrue(File.Exists(@Environment.CurrentDirectory + @"\Save\holo.txt"));

            StreamReader file = new StreamReader(@Environment.CurrentDirectory + @"\Save\holo.txt");
            string text = file.ToString();
            Assert.IsNotNull(text);
        }

        /// <summary>
        /// test if the state of the game retrieve is the same as the one saved
        /// </summary>
        [TestMethod]
        public void TestLoadCommand()
        {
            var cmd1 = new SaveCommand(ref g, "holo");
            if (cmd1.CanExecute()) cmd1.Execute();
            var cmd2 = new LoadCommand("holo");
            if (cmd2.CanExecute()) cmd2.Execute();

            Assert.IsTrue(g.Equals(cmd2.Game));
        }
    }
}
