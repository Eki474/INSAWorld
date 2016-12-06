using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Plain : Tile
    {
        private static Plain instance;

        public static Plain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Plain();
                }
                return instance;
            }
        }
    }
}
