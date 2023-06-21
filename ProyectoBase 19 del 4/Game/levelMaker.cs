using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class levelMaker
    {
        private int totalbricks = 5;
       
        private Brick brick;
        private Transform spawn;
        private Vector2 offset = new Vector2(50, 300);
       

        public void levelsetter()
        {
            GameManager.win = totalbricks + 1;
            
            for (int i = 0; i < totalbricks; i++)
            {
                spawn = new Transform(offset, 0, new Vector2(1, 1));
                brick = new Brick(spawn.position);
                offset.x += 100;
            }

        }
    }
}
