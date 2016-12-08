using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass]
    public class GameMapTest
    {

        GameMap map;

        [TestInitialize()]
        public void Setup()
        {
            map = BuilderMap.Instance.BuildMap(0);
        }

        [TestMethod]
        public void TestBuildMap()
        {
            Assert.IsNotNull(map);
        }

        [TestMethod]
        [ExpectedException(typeof(BadMapException))]
        public void TestBuildMapFail()
        {
            GameMap fail = BuilderMap.Instance.BuildMap(3);
        }

        [TestMethod]
        public void TestFillMap()
        {
            BuilderMap.Instance.FillMap(ref map);
            Assert.IsNotNull(map.CasesJoueur.First());
            Assert.IsNotNull(map.CasesJoueur.Keys.First());
        }

        [TestMethod]
        public void TestFillMapEkitable()
        {
            BuilderMap.Instance.FillMap(ref map);
            var cpt = new int[4];
            for(int i = 0; i < 4; i++) cpt[0] = 0;
            foreach(Tile t in map.CasesJoueur.Values)
            {
                switch (t.getType())
                {
                    case "plain": cpt[0] += 1; break;
                    case "volcano": cpt[1] += 1; break;
                    case "swamp": cpt[2] += 1; break;
                    case "desert": cpt[3] += 1; break;
                }
            }
            Assert.IsTrue(cpt[0] == cpt[1] && cpt[0] == cpt[2] && cpt[0] == cpt[3]);
        }

        [TestMethod]
        public void TestSetJoueurs()
        {
            var p1 = new Player("Jacques", 0, 6);
            var p2 = new Player("Zac", 1, 6);
            BuilderMap.Instance.setJoueurs(ref p1, ref p2, 6);
            Assert.IsNotNull(p1.UnitsList.First().C);
            Assert.IsNotNull(p2.UnitsList.First().C);
        }

        [TestMethod]
        public void TestTurnPlayed()
        {
            bool test = false;
            map.TurnPlayed();
            Assert.IsTrue(map.NbTurn < 6);
            for(int i = 0; i<12; i++)
            {
                test = map.TurnPlayed();
            }
            Assert.IsTrue(test);
        }
    }
}
