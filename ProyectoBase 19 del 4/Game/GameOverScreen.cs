using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOverScreen : gameObject
    {
        public Transform Transform
        {
            get
            {
                return transform;
            }

            set
            {
                Transform = value;
            }
        }
        private Animation idle;
        
        public GameOverScreen(Vector2 inital_pos)
        {
            transform = new Transform(inital_pos, new Vector2(0, 0), new Vector2(1, 1));
            idle = CreateAnimation("", "gameover", 4, 2);
            currentAnimation = idle;
            currentAnimation.Reset();
            
        }
      

    }
}
