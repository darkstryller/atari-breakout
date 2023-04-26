using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelManager
    {
        private int levelID = 1;
        private int totalbricks = 6;
        private Character brick;
        private Transform layout = new Transform(new Vector2(-50,-50),0,new Vector2(0,0));
        public Transform Layout => layout;
        public int TotalBricks => totalbricks;
      

        public void levelsetter(int ID)
        {
            levelID = ID;
            if(ID == 1)
            {
                for (int i = 0; i < totalbricks; i++)
                {
                    
                    if (i == 1)
                    {
                        layout = new Transform(new Vector2(150, 300), 0, new Vector2(1, 1));
                        level1(i);
                    }
                    if (i == 2)
                    {
                        layout = new Transform(new Vector2(250, 300), 0, new Vector2(1, 1));
                        level1(i);
                    }
                    if (i == 3)
                    {
                        layout = new Transform(new Vector2(350, 300), 0, new Vector2(1, 1));
                        level1(i);
                    }
                    if (i == 4)
                    {
                        layout = new Transform(new Vector2(450, 300), 0, new Vector2(1, 1));
                        level1(i);
                    }
                    if (i == 5)
                    {
                        layout = new Transform(new Vector2(550, 300), 0, new Vector2(1, 1));
                        level1(i);
                    }
                }
                
            }
        }
        public void level1(int _totalbricks)
        {
            
            
            if (_totalbricks == 1)
            {
                brick = new Character(layout.position, 2);

            }

            if (_totalbricks == 2)
            {
                brick = new Character(layout.position, 2);

            }

            if (_totalbricks == 3)
            {
                brick = new Character(layout.position, 2);

            }

            if (_totalbricks == 4)
            {
                brick = new Character(layout.position, 2);

            }

            if (_totalbricks == 5)
            {
                brick = new Character(layout.position, 2);

            }

            return;
        }
    }
}
