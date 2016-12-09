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

        /// <summary>
        /// return the string corresponding to the type
        /// </summary>
        /// <returns>plain</returns>
        
        public string getType()
        {
            return "plain";
        }
        public bool Equals(Tile t)
        {
            return getType().Equals(t.getType());
        }


    }
}
