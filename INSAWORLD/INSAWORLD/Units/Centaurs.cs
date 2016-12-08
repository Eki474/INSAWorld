﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace INSAWORLD
{
    public class Centaurs : Race
    {
        /// <summary>
        /// units' statistics of this race
        /// </summary>
        private int attack;
        private int defense;
        private int life;
        private int move;

        public Centaurs()
        {
            attack = 8;
            defense = 2;
            life = 10;
            move = 3;
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Move
        {
            get { return move; }
            set { move = value; }
        }

        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>depend on the implementation</returns>
        public int VictoryPoints(Unit u, ref Game myGame)
        {
            Coord c = u.C;
            Tile t = myGame.Map.CasesJoueur[c];
            switch (t.getType())
            {
                case "plain": return 3;
                case "desert": return 2;
                case "swamp": return 1;
                case "volcano": return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public bool ActionMove(Unit u, Coord c, ref Game myGame)
        {
            

            if ( !TryMove(u, c, ref myGame)) return false;
            List<Unit> opponentList;
            if (myGame.Player1.UnitsList.Contains(u))
            {
                opponentList = myGame.Player2.UnitsList;
            }
            else
            { 
                opponentList = myGame.Player1.UnitsList;
            }

            foreach(Unit unit in opponentList)
            {
                if (unit.C.Equals(c))
                {
                    return false;
                }
            }

            u.C = c;
            Tile t = myGame.Map.CasesJoueur[u.C];
            if (!t.getType().Equals("plain")) u.MovePoints--;
            else u.MovePoints -= 0.5;

            new MoveUnit(u, c).Execute();

            return true;


        }

        /// <summary>
        /// Essaye de se deplacer de une case
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public bool TryMove(Unit u, Coord c, ref Game myGame)
        {
            if (u.C.Equals(c) || (Math.Abs(u.C.X - c.X) + Math.Abs(u.C.Y - c.Y)) > 1 || u.MovePoints==0 || (u.MovePoints<=0.5 && !myGame.Map.CasesJoueur[c].getType().Equals("plain")))
            {
                return false;
            }

            return true;
        } 

        /// <summary>
        /// verifies if a unit can still move or if it has no move points remaining
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the unit can't move, false if if do</returns>
        public bool NoMoreMoves(Unit u, ref GameMap map)
        {
            return u.MovePoints == 0 || (u.MovePoints == 0.5 && !map.CasesJoueur[u.C].Equals(Plain.Instance));
        }
    }
}