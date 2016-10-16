using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //singleton and builder for GameMap

    //problem : on ne peut pas choisir le type de map 
    public class BuilderMap
    {
        private static BuilderMap instance;

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
    
        //method : create the object GameMap
        public GameMap BuildMap()
        {
            throw new System.NotImplementedException();
        }

        //method : fill the Tile of the GameMep
        public bool FillMap()
        {
            throw new System.NotImplementedException();
        }
    }
}
