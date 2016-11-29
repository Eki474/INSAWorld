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
        IDictionary<Unit, Coord> unitsList; //units of the player 
        private bool playing; //player currently playing
        private int tailleMap;

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

        public IDictionary<Unit, Coord> UnitsList
        {
            get { return unitsList; }
            set{ unitsList = value; }
        }

        // method : return true if the game is lost by the player
        // false if not
        public bool Lost()
        {            
            throw new System.NotImplementedException();
        }
        // method : end the turn of the player
        public bool EndTurn()
        {
            throw new System.NotImplementedException();
        }
        // method : begin the turn of the player
        public bool StartTurn()
        {
            throw new System.NotImplementedException();
        }
        // method compute points earned by the player this turn and add the result to global count
        public void ComputePoints()
        {
            throw new System.NotImplementedException();
        }

        //call unit attack method and remove life points
        public bool Attack(Unit u, KeyValuePair<Unit, Coord> d)
        {
            bool success = false;
            //use attack of unit
            int lostLife = u.Attack(d.Value, d.Key);
            if(lostLife > 0) //defender lost points
            {
                if(d.Key.LifePoints < lostLife)
                {
                    d.Key.LifePoints = 0;
                }
                else
                {
                    d.Key.LifePoints -= lostLife;
                }
                success = true;
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if(u.LifePoints < lostLife)
                {
                    u.LifePoints = 0;
                }else
                {
                    u.LifePoints -= lostLife;
                }
                success = true;
            }
            //call game cleaner method
            return success;
        }
    }
}
