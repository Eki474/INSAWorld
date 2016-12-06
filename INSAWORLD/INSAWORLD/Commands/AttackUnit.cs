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

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
        /// <returns>true if the attack has been done false if not</returns>
        public Array Execute()
        {
            var retour = new Boolean[1];
            bool success = false;
            //use attack of unit
            int lostLife = u.Attack(d.C, d, ref game);
            if (lostLife > 0) //defender lost points
            {
                if (d.LifePoints < lostLife)
                {
                    d.LifePoints = 0;
                    game.Cleaner();
                    u.Race.MoveOverride(u, d, ref game);
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
                    game.Cleaner();
                }
                else { u.LifePoints -= lostLife; }
                success = true;
            }
            retour[0] = success;
            return retour;
        }

        /// <summary>
        /// Attack an other unit
        /// </summary>
        /// <param name="c">coord of the attacked unit</param>
        /// <param name="def">unit which defend the tile on coord</param>
        /// <param name="myGame">reference to game to use information from map</param>
        /// <returns>true if the fight is won false if not</returns>
        private int Attack(Coord c, Unit def, ref Game myGame)
        {
            bool success = false;
            int lifeP = 0;
            success = u.Race.ActionMove(u, c, ref myGame); //attention il faut se mettre sur la case à côté pas la case de l'unité qu'on attaque...
            if (success)
            {
                double attacker = 0.5;
                double defender = 0.5;
                int ratio = (u.Race.Attack * (u.LifePoints / u.Race.Life)) / (def.Race.Defense * (def.LifePoints / def.Race.Life));
                if (ratio < 1)
                {
                    attacker = ratio * (100 / (ratio + 1));
                    defender = 100 - attacker;
                }
                else
                {
                    ratio = def.Race.Defense / u.Race.Attack;
                    attacker += ratio;
                    defender = ratio * (100 / (ratio + 1));
                    attacker = 100 - defender;
                }
                Random prob = new Random();
                Random lostPoints = new Random();
                //if random between 0 and attacker --> the attacker wins
                //if random superior to attacker --> the defenser wins
                if (prob.Next(0, 100) < attacker)
                {
                    success = true;
                    //if attacker wins --> return a positive value of the defenser life points lost
                    lifeP = lostPoints.Next(1, u.Race.Attack);
                }
                else
                {
                    success = false;
                    //if attacker wins --> return a negative value of the defenser life points lost
                    lifeP = -lostPoints.Next(1, def.Race.Attack);
                }
                u.Played = true;
            }
            return lifeP;
        }
    }
}
