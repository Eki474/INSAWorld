using System;
using System.Collections.Generic;
using System.Linq;

namespace INSAWORLD
{
    public class MoveUnit : CommandMenu, ToCollect
    {
        private Unit unit; // unit to move
        private Coord dest; // destination to move to
        private Game game; // game

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">destination to move to</param>
        /// <param name="g">reference to the game</param>
        public MoveUnit(Unit u, Coord c, ref Game g)
        {
            unit = u;
            dest = c;
            game = g;
        }
    
        /// <summary>
        /// move a unit
        /// </summary>
        public void Execute()
        {
            unit.Race.ActionMove(unit, dest, ref game);
            game.Rpz.AddStep(this);
        }

        /// <summary>
        /// verify if the unit can move on the tile : enough move points, no enemy units on the way
        /// </summary>
        /// <returns>true if it can, false if not</returns>
        public bool CanExecute()
        {
            if (!unit.Race.TryMove(unit, dest, ref game)) return false;

            List<Unit> opponentList;
            if (game.Player1.UnitsList.Contains(unit))
            {
                opponentList = game.Player2.UnitsList;
            }
            else
            {
                opponentList = game.Player1.UnitsList;
            }

            foreach (Unit u in opponentList)
            {
                if (u.C.Equals(dest))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>move,unit.Id,dest</returns>
        override
        public string ToString()
        {
            return "move," + unit.Id + "," + dest;
        }
    }
}
