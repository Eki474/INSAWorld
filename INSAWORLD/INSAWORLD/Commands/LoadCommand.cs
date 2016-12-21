using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace INSAWORLD
{
    public class LoadCommand : CommandMenu
    {
        private string name; //name of the save - to find the file
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the save</param>
        public LoadCommand(string n)
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
        /// load a saved game by reading a file from a save
        /// </summary>
        public void Execute()
        {
            string line;
            string[] linesplit;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@Environment.CurrentDirectory + @"\Save\" + name + ".txt");

            line = file.ReadLine();
            linesplit = line.Split(',');
            Player p1 = new Player(linesplit);

            line = file.ReadLine();
            linesplit = line.Split(',');
            Player p2 = new Player(linesplit);

            line = file.ReadLine();
            linesplit = line.Split(',');
            
            int tailleMap = int.Parse(linesplit[1]);
            GameMap map = BuilderMap.Instance.BuildMap(BuilderMap.Instance.getType(tailleMap));

            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                linesplit = line.Split(',');
                for (int j = 0; j < linesplit.Length; j++)
                {
                    switch (linesplit[j])
                    {
                        case "plain": map.CasesJoueur.Add(new Coord(i, j), Plain.Instance); break;
                        case "volcano": map.CasesJoueur.Add(new Coord(i, j), Volcano.Instance); break;
                        case "swamp": map.CasesJoueur.Add(new Coord(i, j), Swamp.Instance); break;
                        case "desert": map.CasesJoueur.Add(new Coord(i, j), Desert.Instance); break;
                        default: throw new BadTypeException("Donnees corrompues. Bad Tile Exception");
                    }
                    
                }
                i++;
            }

            file.Close();
            game=new Game(ref p1,ref p2,ref map);
        }

        /// <summary>
        /// verify if the file exists
        /// </summary>
        /// <returns>return true if file exists, false if not</returns>
        public bool CanExecute()
        {
            if (File.Exists(@Environment.CurrentDirectory + @"\Save\" + name + ".txt"))
            {
                return true;
            }
            return false;
        }
        
    }
}
