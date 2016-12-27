using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace INSAWORLD
{
    public enum TileType
    {
        Plain = 0,
        Swamp = 1,
        Volcano = 2,
        Desert = 3
    }

    //singleton and builder for GameMap
    public class BuilderMap : IDisposable
    {
        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algos_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algos_suggestMove(IntPtr algos, int[] tableTile, string[] retour, bool race, double moveP);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algos_new();

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algos_delete(IntPtr algo);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algos_placeUnits(IntPtr algo, int[] retour, int taille);
        

        private static BuilderMap instance;
        private bool disposed = false;
        private IntPtr nativeAlgo;

        /// <summary>
        /// build the map using c++ dll
        /// </summary>
        private BuilderMap()
        {
            nativeAlgo = Algos_new();
        }

        ~BuilderMap()
        {
            Dispose(false);
            Algos_delete(nativeAlgo);
        }

        public static BuilderMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuilderMap();
                }
                return instance;
            }
        }

        /// <summary>
        /// create the object GameMap using c++ dll
        /// </summary>
        /// <param name="type">0 demo - 1 small - 2 standard</param>
        /// <returns>created GameMap empty</returns>
        public GameMap BuildMap(int type)
        {
            switch (type)
            {
                case 0: return new Demo();
                case 1: return new Small();
                case 2: return new Standard();
                default:
                    throw new BadMapException("Bad Map Initialization");
            }
        }

        /// <summary>
        /// give type of the map in exchange of size
        /// </summary>
        /// <param name="i">size of the map</param>
        /// <returns>type int of the map</returns>
        public int getType(int i)
        {
            switch (i)
            {
                case 6: return 0;
                case 10: return 1;
                case 14: return 2;
                default: throw new BadMapException("Bad Map Type");
            }
        }

        /// <summary>
        /// give the size of the map in exchange of type
        /// </summary>
        /// <param name="type">type int of the map</param>
        /// <returns>size of the map</returns>
        public int getSize(int type)
        {
            switch (type)
            {
                case 0: return 6;
                case 1: return 10;
                case 2: return 14;
                default: throw new BadMapException("Bad Map Type");
            }
        }

        /// <summary>
        /// fill the Tile of the GameMap using c++ dll
        /// </summary>
        /// <param name="map">GameMap to be fill</param>
        public void FillMap(ref GameMap map)
        {
            int taille = map.Taille;
            var tiles = new TileType[taille * taille];
            Algos_fillMap(nativeAlgo, tiles, taille * taille);
            for (int i = 0; i < tiles.Length; i++)
            {
                map.CasesJoueur.Add(new Coord(i / taille, i % taille), convertType((int)tiles[i]));
            }
        }

        /// <summary>
        /// convert a TileType into a real Tile
        /// </summary>
        /// <param name="type">0 Plain - 1 Swamp - 2 Volcano - 3 Desert</param>
        /// <returns>Tile created</returns>
        private Tile convertType(int type)
        {
            switch (type)
            {
                case 0: return Plain.Instance;
                case 1: return Swamp.Instance;
                case 2: return Volcano.Instance;
                case 3: return Desert.Instance;
                default:
                    throw new BadTypeException("Bad Tile Type");
            }
        }

        /// <summary>
        /// give coordinates to players units
        /// </summary>
        /// <param name="p1">player 1</param>
        /// <param name="p2">player 2</param>
        /// <param name="taille">size of the map</param>
        public void setJoueurs(ref Player p1, ref Player p2, int taille)
        {
            int[] coord = new int[2];
            IntPtr tmp = Algos_placeUnits(nativeAlgo, coord, taille-1);
            //int[] coord2 = new int[2];
            //Marshal.Copy(tmp, coord2, 0, 2);
            //ReleaseMemory(tmp);
            Coord coordonnee = new Coord(coord[0], coord[1]);
            foreach (Unit u in p1.UnitsList)
            {
                u.C = coordonnee;
            }
            coordonnee = new Coord(taille-1 - coord[0], taille-1 - coord[1]);
            foreach (Unit u in p2.UnitsList)
            {
                u.C = coordonnee;
            }
        }
        public List<string> suggestMove(ref Game game, Unit u)
        {
            int[,] tableTile = new int[7, 7];
            int cXInit = u.C.X - 3;
            int cYInit = u.C.Y - 3;
            int cY = cYInit;
            Player o;
            if (game.Player1.UnitsList.Contains(u))
            {
                o = game.Player2;
            }
            else
            {
                o = game.Player1;
            }
            int taille = game.Map.Taille;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (cXInit < 0 || cY < 0 || cXInit > taille - 1 || cY > taille - 1)
                    {
                        tableTile[i, j] = -1;
                    }
                    else
                    {
                        bool b = false;
                        Coord coord = new Coord(cXInit, cYInit);
                        foreach (Unit unit in o.UnitsList)
                        {
                            if (unit.C.Equals(coord))
                            {
                                tableTile[i, j] = 2;
                                b = true;
                                break;
                            }
                        }
                        if (!b)
                        {
                            if (game.Map.CasesJoueur[coord].getType().Equals("plain"))
                            {
                                tableTile[i, j] = 1;
                            }
                            else
                            {
                                tableTile[i, j] = 0;

                            }
                        }
                    }
                    cY++;
                }
                cXInit++; cY = cYInit;
            }
            int[] table = new int[49];
            for (int i = 0; i < 49; i++)
            {
                table[i] = tableTile[i / 7, i % 7];
            }
            string[] retour = new string[3];
            Algos_suggestMove(nativeAlgo, table, retour, u.Race.Type.Equals("Centaurs"), u.MovePoints);
            List<string> result = new List<string>();
            result.Add(retour[0]);
            result.Add(retour[1]);
            result.Add(retour[2]);
            return result;

        }

        public double getMaxTurn(int taille)
        {
            switch (taille)
            {
                case 6: return 5;
                case 10: return 20;
                case 14: return 30;
                default: throw new BadMapException("Bad Map type given");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algos_delete(nativeAlgo);
            }
            disposed = true;
        }
    }
}