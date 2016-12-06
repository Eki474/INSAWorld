using INSAWORLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Player
    {
        private string name; //name of the player 
        private Race racePlay; //race choosen by the player 
        private int points; //points earned by the player 
        List<Unit> unitsList; //units of the player 
        private bool playing; //player currently playing
        private int tailleMap; //taille de la map

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the player</param>
        /// <param name="race">0 if Cyclops - 1 if Cerberus - 2 if Centaurs</param>
        /// <param name="tailleMap">6 Demo - 10 Small - 14 Standard</param>
        public Player(string n, int race, int tailleMap)
        {
            name = n;
            points = 0;
            this.tailleMap = tailleMap;
            racePlay = RaceFactory.Instance.createRace(race);
            UnitsList = UnitsFactory.Instance.createUnits(racePlay, this.tailleMap);
            playing = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int TailleMap
        {
            get { return tailleMap; }
            set { tailleMap = value; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Race RacePlay
        {
            get { return racePlay; }
            set { racePlay = value; }
        }

        public bool Playing
        {
            get { return playing; }
            set { playing = value; }
        }

        public List<Unit> UnitsList
        {
            get { return unitsList; }
            set{ unitsList = value; }
        }

        /// <summary>
        /// check if unitsList is empty
        /// </summary>
        /// <returns>true if the game is lost by the player false if not</returns>
        public bool Lost()
        {
            return unitsList.Count == 0;
        }

        /// <summary>
        /// End the turn of the player : playing = false for the current player (while the other is on true thanks to StartTurn)
        /// </summary>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the turn can be ended false if not</returns>
        public bool EndTurn(ref GameMap map)
        {
            foreach(Unit u in unitsList)
            {
                if(!(u.Played && racePlay.NoMoreMoves(u, ref map)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// begin the turn of a player : playing = true for the current player (while the other is on false thanks to EndTurn)
        /// </summary>
        /// <returns>true if the turn can be started false if not</returns>
        public void StartTurn()
        {
            playing = true;
        }

        /// <summary>
        /// method compute points earned by the player this turn (attribute points)
        /// </summary>
        /// <param name="map">reference to the map</param>
        public void ComputePoints(ref Game game)
        {
            points = 0;
            foreach(Unit u in unitsList)
            {
                points += racePlay.VictoryPoints(u, ref game);
            }
        }

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
        /// <param name="u">unit which attack</param>
        /// <param name="d">pair of unit/coord of the attacked unit</param>
        /// <param name="myGame">reference to the game to obtain the map</param>
        /// <returns>true if the attack has been done false if not</returns>
        public bool Attack(Unit u, Unit d, ref Game myGame)
        {
            bool success = false;
            //use attack of unit
            int lostLife = u.Attack(d.C, d, ref myGame);
            if(lostLife > 0) //defender lost points
            {
                if (d.LifePoints < lostLife)
                {
                    d.LifePoints = 0;
                    myGame.Cleaner();
                    u.Race.MoveOverride(u, d, ref myGame);
                }
                else { d.LifePoints -= lostLife; }
                success = true;
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if (u.LifePoints < lostLife)
                {
                    u.LifePoints = 0;
                    myGame.Cleaner();
                }
                else { u.LifePoints -= lostLife; }
                success = true;
            }
            return success;
        }
    }
}
