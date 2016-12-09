using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NextTurn : CommandMenu, ToCollect
    {
        private Game game; //game
        private bool nbTurn; //true if game win by a player false if not

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="g">game</param>
        public NextTurn(Game g)
        {
            game=g;
        }

        /// <summary>
        /// end the player turn and go to the next turn
        /// verify if the game is finished
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
            game.Rpz.AddStep(this);
        }

        public void ExecuteReplay()
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
        }

        /// <summary>
        /// do nothing, don't use
        /// </summary>
        /// <returns>true</returns>
        public bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>next</returns>
        override
        public string ToString()
        {
            return "next";
        }
    }
}
