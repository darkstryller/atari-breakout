using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : gameObject
    {
        public Transform Transform
        {
            get
            {
                return transform;
            }
            set
            {
                transform = value;
            }
        }

        public string Tag;
        public float Speed = 250;
        Animation idle;
        public Player(Vector2 initial_pos)
        {
            transform = new Transform(initial_pos,new Vector2(0, 0), new Vector2(1, 1));
            Tag = "player";
            idle = CreateAnimation("Idle", "", 4, 2);
            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
            renderManager.Instance.addObject(this);
            
        }

        
        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        public void limits()
        {
            if (transform.position.x <= 0 + RealWidth/2 || transform.position.x >= 700 + RealWidth/2)
            {

                transform.position.x += RealWidth / 2;



            }

            
            
        }
    }
}
