using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class levelMaker
    {
        
        private static int totalbricks = 7;
       
        private static Brick brick;
        private static Transform spawn;
        private static Vector2 offset = new Vector2(50, 100);
       

        public static void levelsetter()
        {
            GameManager.win = totalbricks + 1;
            
            for (int i = 0; i < totalbricks; i++)
            {
                spawn = new Transform(offset, new Vector2(0,0), new Vector2(1, 1));
                brick = new Brick(spawn.position);
                offset.x += 100;
                
            }

        }


    }
}
