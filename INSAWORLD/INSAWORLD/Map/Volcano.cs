using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Volcano : Tile
    {
        private static Volcano instance;

        public static Volcano Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Volcano();
                }
                return instance;
            }
        }

        /// <summary>
        /// return the string corresponding to the type
        /// </summary>
        /// <returns>volcano</returns>
        public string getType()
        {
            return "volcano";
        }
    }
}
