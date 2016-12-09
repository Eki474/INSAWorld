using System;

namespace INSAWORLD
{
    public class RaceFactory
    {
        private static RaceFactory instance;
        public static RaceFactory Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new RaceFactory();
                }
                return instance;
            }
        }

        private RaceFactory()  { }

        /// <summary>
        /// create a race 
        /// </summary>
        /// <param name="i">0 Cyclops - 1 Cerberus - 2 Centaurs</param>
        /// <returns></returns>
        public Race createRace(int i)
        {
            switch(i){
                case 0: return new Cyclops();
                case 1: return new Cerberus();
                case 2: return new Centaurs();
                default:
                    throw new BadRaceException("Bad Race Initialization");
            }
        }

        /// <summary>
        /// create a race from a string
        /// </summary>
        /// <param name="i">string designing a race</param>
        /// <returns></returns>
        public Race createRace(string i)
        {
            switch (i)
            {
                case "Cyclops": return new Cyclops();
                case "Cerberus": return new Cerberus();
                case "Centaurs": return new Centaurs();
                default:
                    throw new BadRaceException("Bad Race Initialization");
            }
        }

    }
}