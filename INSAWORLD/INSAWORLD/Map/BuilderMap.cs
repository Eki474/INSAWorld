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
        extern static void Algos_suggestMove(IntPtr algos, int[,] tableTile, string[] retour, bool race, double moveP);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algos_new();

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algos_delete(IntPtr algo);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algos_placeUnits(IntPtr algo, int [] retour, int taille);

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
            Algos_placeUnits(nativeAlgo, coord, taille);
            Coord coordonnee = new Coord(coord[0], coord[1]);
            foreach (Unit u in p1.UnitsList)
            {
                u.C = coordonnee;
            }
            coordonnee = new Coord(taille - coord[0], taille - coord[1]);
            foreach (Unit u in p2.UnitsList)
            {
                u.C = coordonnee;
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