using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager : gameObject
    {
        private Transform Transform => transform;

        static private int score;

        static public int win;

        static int balls = 3;
        
        static public void addPoint()
        {
           score = score + 1;
            if(score >= win)
            {
                Engine.Debug("you win");
            }
        }

        static public void loser()
        {
            balls -= 1;
            if(balls <= 0)
            {
                Engine.Debug("you lose");
            }
        }
    }
}
