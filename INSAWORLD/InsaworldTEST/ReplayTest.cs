using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.IO;

namespace InsaworldTEST
{
    [TestClass]
    public class ReplayTest
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
            var l1 = g.Player1.UnitsList;
            var l2 = g.Player2.UnitsList;
            while (g.EndGame())
            {
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
            }
        }

        /// <summary>
        /// test if a file is created for the save and if it is not empty
        /// </summary>
        [TestMethod]
        public void TestSaveReplayCommand()
        {
            var cmd = new SaveReplayCommand("fancy");
            if (cmd.CanExecute()) cmd.Execute();

            Assert.IsTrue(File.Exists(@Environment.CurrentDirectory + @"\Replay\fancy.Game.txt"));
            Assert.IsTrue(File.Exists(@Environment.CurrentDirectory + @"\Replay\fancy.Map.txt"));

            StreamReader file1 = new StreamReader(@Environment.CurrentDirectory + @"\Replay\fancy.Game.txt");
            string text = file1.ToString();
            Assert.IsNotNull(text);

            StreamReader file2 = new StreamReader(@Environment.CurrentDirectory + @"\Replay\fancy.Map.txt");
            string map = file2.ToString();
            Assert.IsNotNull(map);
        }

        /// <summary>
        /// test if the states of the game retrieve are the same as those saved
        /// </summary>
        [TestMethod]
        public void TestLoadReplayCommand()
        {
            var cmd = new LoadReplayCommand("fancy");
            if (cmd.CanExecute()) cmd.Execute();

            Assert.AreSame(g, cmd.Game);
        }
    }
}
