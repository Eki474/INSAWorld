using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //this class permtis to save coordinates of each cases of the map
    public struct Coord 
    {
        private int x; //vertical coordinate of the map
        private int y; //horizontal coordinate of the map
        
        public int X 
        {
            get { return x; }
            set { x = value; }
        }

        public int Y 
        {
            get { return y; }
            set { y = value; }
        }
       
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cx">horizontal coord</param>
        /// <param name="cy">vertical coord</param>
       public  Coord(int cx, int cy) 
        {
            x = cx;
            y = cy;
        }

        /// <summary>
        /// Equals override to compare coordinates and not references
        /// </summary>
        /// <param name="c">coord to compare to</param>
        /// <returns>true if same coord, false if not</returns>
        public bool Equals(Coord c)
        {
            if (c.X == x && c.Y == y) return true;
            return false;
        }

        /// <summary>
        /// == override to compare coordinates and not references
        /// </summary>
        /// <param name="c">coord to compare</param>
        /// <param name="d">coord to compare</param>
        /// <returns>true if same coord, false if not</returns>
        public static bool operator ==(Coord c, Coord d){
            return c.Equals(d);
        }
        public static bool operator !=(Coord c, Coord d)
        {
            return !c.Equals(d);
        }
    }
}
