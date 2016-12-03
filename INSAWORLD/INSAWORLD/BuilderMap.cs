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
        private static BuilderMap instance;
        private bool disposed = false;
        private IntPtr nativeAlgo;

        /// <summary>
        /// build the map using c++ dll
        /// </summary>
        private BuilderMap()
        {
            nativeAlgo = Algo_new();
        }

        ~BuilderMap()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
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
        /// fill the Tile of the GameMap using c++ dll
        /// </summary>
        /// <returns>created GameMap full</returns>
        public bool FillMap(int taille)
        {
            throw new NotImplementedException();
        }

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static List<string> Algos_suggestMove(IntPtr algos, int[,] tableTile, bool race, int moveP);
        
        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("INSAWORLDCPP2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);

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
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }
    }
}
