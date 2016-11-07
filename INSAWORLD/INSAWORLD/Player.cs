using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Player
    {
        private string name; //name of the player
        private int race; //race choosen by the player 
        /* 
         * -1 not set yet
         * 0 Centaurs
         * 1 Cerberus
         * 2 Cyclops
        */
        private int points; //points earned by the player

        public Player(string n)
        {
            name = n;
            race = -1;
            points = 0;
        }

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Points
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Race RacePlay
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IDictionary<Coord, Unit> UnitsList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        // method : return true if the game is lost by the player
        // false if not
        public void Lost()
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
    }
}
