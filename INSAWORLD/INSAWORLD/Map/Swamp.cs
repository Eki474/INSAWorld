using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Swamp : Tile
    {
        private static Swamp instance;

        public static Swamp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Swamp();
                }
                return instance;
            }
        }

        /// <summary>
        /// return the string corresponding to the type
        /// </summary>
        /// <returns>swamp</returns>
        public string getType()
        {
            return "swamp";
        }
    }
}
