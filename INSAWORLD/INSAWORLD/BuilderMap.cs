using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //singleton and builder for GameMap
    public class BuilderMap
    {
        private static BuilderMap instance;

        /// <summary>
        /// build the map using c++ dll
        /// </summary>
        private BuilderMap()
        {

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
        /// <returns>created GameMap empty</returns>
        public GameMap BuildMap()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// fill the Tile of the GameMap using c++ dll
        /// </summary>
        /// <returns>created GameMap full</returns>
        public bool FillMap()
        {
            throw new System.NotImplementedException();
        }
    }
}
