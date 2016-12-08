using System;
using System.Collections.Generic;
using System.Linq;

namespace INSAWORLD
{
    public class MoveUnit : CommandMenu, ToCollect
    {
        private Unit unit;
        private Coord dest;
        private Game game;

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
            ReplayCollector.Instance.AddStep(this);
        }

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

            foreach (Unit unit in opponentList)
            {
                if (unit.C.Equals(dest))
                {
                    return false;
                }
            }
            return true;
        }

        override
        public string ToString()
        {
            return "move," + unit.Id + "," + dest;
        }
    }
}
