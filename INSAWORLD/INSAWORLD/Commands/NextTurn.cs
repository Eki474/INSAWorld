using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NextTurn : CommandMenu, ToCollect
    {
        private Game game;
        private bool nbTurn;

        public NextTurn(Game g)
        {
            game=g;
        }

        /// <summary>
        /// end the player turn and go to the next turn
        /// </summary>
        public void Execute()
        {
            Player p;
            if (game.Player1.Playing)
            {
                p = game.Player1;
                game.Player2.StartTurn();
                game.Player1.Playing = false;
            }
            else
            {
                p = game.Player2;
                game.Player1.StartTurn();
                game.Player2.Playing = false;
            }
            foreach (Unit u in p.UnitsList) u.Reset();
            nbTurn = game.Map.TurnPlayed();
            ReplayCollector.Instance.AddStep(this);
        }

        public bool CanExecute()
        {
            return true;
        }

        override
        public string ToString()
        {
            return "next";
        }
    }
}
