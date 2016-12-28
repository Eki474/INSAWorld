using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace INSAWORLD
{
    public class LoadReplayCommand : CommandMenu
    {
        private string name; //name of the save - to find the file
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the save</param>
        public LoadReplayCommand(string n)
        {
            name = n;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Game Game
        {
            get { return game; }
            private set { game = value; }
        }

        /// <summary>
        /// load a file for a replay
        /// </summary>
        public void Execute()
        {
            string line;
            string[] linesplit;
            var block = new List<string>();

            // Read the file and display it line by line.
            StreamReader file =
               new StreamReader(@Environment.CurrentDirectory + @"\Replay\" + name + ".Game.txt");

            line = file.ReadLine();
            linesplit = line.Split(',');
            Player p1 = new Player(linesplit[1], linesplit[2], linesplit[3], linesplit[4], linesplit[9]);
            Player p2 = new Player(linesplit[5], linesplit[6], linesplit[7], linesplit[8], linesplit[9]);
            int tailleMap = int.Parse(linesplit[9]);
            GameMap map = BuilderMap.Instance.BuildMap(BuilderMap.Instance.getType(tailleMap));

            while ((line = file.ReadLine()) != null)
            {
                block.Add(line);
            }

            file.Close();

            StreamReader filemap =
               new StreamReader(@Environment.CurrentDirectory + @"\Replay\" + name + ".Map.txt");

            int ind = 0;
            while ((line = filemap.ReadLine()) != null)
            {
                linesplit = line.Split(',');
                for (int j = 0; j < linesplit.Length; j++)
                {
                    switch (linesplit[j])
                    {
                        case "plain": map.CasesJoueur.Add(new Coord(ind, j), Plain.Instance); break;
                        case "volcano": map.CasesJoueur.Add(new Coord(ind, j), Volcano.Instance); break;
                        case "swamp": map.CasesJoueur.Add(new Coord(ind, j), Swamp.Instance); break;
                        case "desert": map.CasesJoueur.Add(new Coord(ind, j), Desert.Instance); break;
                        default: throw new BadTypeException("Donnees corrompues. Bad Tile Exception");
                    }

                }
                ind++;
            }

            filemap.Close();

            game = new Game(ref p1, ref p2, ref map);
            ReplayCollector rc = new ReplayCollector();
            game.Rpz = rc;

            foreach(string s in block)
            {
                linesplit = s.Split(',');
                switch(linesplit[0])
                {
                    case "next":
                        rc.AddStep(new NextTurn(game));
                        break;
                    case "attack":
                        rc.AddStep(new AttackUnit(linesplit, ref game));
                        break;
                    case "move":
                        rc.AddStep(new MoveUnit(linesplit, ref game));
                        break;
                    default: throw new BadTypeException("Donnees corrompues. Bad index");
                }
            }

            //rc.Replay();

        }

        /// <summary>
        /// verify if the file exists
        /// </summary>
        /// <returns>return true if file exists, false if not</returns>
        public bool CanExecute()
        {
            if (File.Exists(@Environment.CurrentDirectory + @"\Replay\" + name + ".Game.txt") && File.Exists(@Environment.CurrentDirectory + @"\Replay\" + name + ".Map.txt"))
            {
                return true;
            }
            return false;
        }
    }
}
