using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : gameObject
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

        private float leftBoundary;
        private float rightBoundary;
        public string Tag;
        public float Speed = 250;
        Animation idle;
        public Player(Vector2 initial_pos)
        {
            
            transform = new Transform(initial_pos,new Vector2(0, 0), new Vector2(1, 1));
            Tag = "player";
            idle = CreateAnimation("", "player", 4, 2);
            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
            renderManager.Instance.addObject(this);
            leftBoundary = RealWidth / 2;
            rightBoundary = 800 - (RealWidth / 2);


        }


        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        public void limits()
        {
            if (transform.position.x <= leftBoundary)
            {
                transform.position.x = leftBoundary;
            }
            else if (transform.position.x >= rightBoundary)
            {
                transform.position.x = rightBoundary;
            }
        }

        public void ResetPosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

    }
}
