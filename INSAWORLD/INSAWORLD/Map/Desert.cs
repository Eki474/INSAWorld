using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Desert : Tile
    {

        private static Desert instance;

        public static Desert Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Desert();
                }
                return instance;
            }
        }
    }
}
