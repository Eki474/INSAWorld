using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class AttackUnit : CommandMenu, ToCollect
    {
        private string state;

        /// <param name="u">unit which attack</param>
        /// <param name="d">pair of unit/coord of the attacked unit</param>
        /// <param name="game">reference to the game to obtain the map</param>
        private Unit u;
        private Unit d;
        private int lostLifeSave;
        private Game game;

        public AttackUnit(ref Unit u, ref Unit d, ref Game g)
        {
            this.u = u;
            this.d = d;
            game = g;
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public bool CanExecute()
        {
            return u.Race.TryMove(u, d.C, ref game);
        }

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
        /// <returns>true if the attack has been done false if not</returns>
        public void Execute()
        {
            //use attack of unit
            int lostLife = u.Attack(d.C, d, ref game);
            lostLifeSave = lostLife;
            if (lostLife > 0) //defender lost points
            {
                if (d.LifePoints < lostLife)
                {
                    d.LifePoints = 0;
                    game.Cleaner();
                    u.Race.ActionMove(u, d.C, ref game);
                }
                else { d.LifePoints -= lostLife; }
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if (u.LifePoints < lostLife)
                {
                    u.LifePoints = 0;
                    game.Cleaner();
                }
                else { u.LifePoints -= lostLife; }
            }

            ReplayCollector.Instance.AddStep(this);
        }
    }
}
