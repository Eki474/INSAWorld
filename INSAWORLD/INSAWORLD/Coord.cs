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
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Y 
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        //constructor
       public  Coord(int cx, int cy) 
        {
            x = cx;
            y = cy;
        }
        //destructor
        public ~Coord() 
        {

        }
    }
}
