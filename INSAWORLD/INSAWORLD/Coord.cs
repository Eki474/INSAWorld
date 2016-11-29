using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{//this class permtis to save coordinates of each cases of tha map
    public class Coord 
    {
        private int x; //vertical coordinate of the map
        private int y; //horizontal coordinate of the map
        //getters and setters
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
        //constructor
       public  Coord(int cx, int cy) 
        {
            x = cx;
            y = cy;
        }
    }
}
