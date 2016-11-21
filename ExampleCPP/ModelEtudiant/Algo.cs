using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelEtudiant
{
    public enum TileType
    {
        Plain = 0,
        Moutain = 1,
        Forest = 2,
        Water = 3
    }

    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;
     
        public Map CreateMap(int nbTiles)
        {
            var tiles = new TileType[nbTiles];
            Algo_fillMap(nativeAlgo, tiles, nbTiles);
            return new Map(tiles);
        }

        public Algo()
        {
            nativeAlgo = Algo_new();
        }

        ~Algo()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
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
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }


        [DllImport("libCPP.dll", CallingConvention= CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
