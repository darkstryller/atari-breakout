using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ball : gameObject
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

        protected string Tag;
        private Vector2 speed = new Vector2(1,1);

        
       

        private Random rng = new Random();
        private float isNegative;
        private float angleX;
        private float angleY;
        
        
        Animation idle;
        public Ball(Vector2 initial_pos)
        {
            transform = new Transform(initial_pos, new Vector2(0, 0), new Vector2(1, 1));
            Tag = "ball";
            idle = CreateAnimation("", "ball", 4, 2);
            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
            renderManager.Instance.addObject(this);
            
        }
       
      
        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        private Vector2 newDirection(float random_x, float random_y, float is_negative, string Tag, Transform obj_transform)
        {

            random_x = rng.Next(1, 3);
            random_y = rng.Next(0, 4);
            
            if (Tag == "player")
            {
                is_negative = rng.Next(0, 2);
                if (is_negative >= 1)
                {
                    random_x = random_x * -1;
                }

                random_y = random_y * -1;



                speed = new Vector2(random_x, random_y);
            }

            //if(Tag == "Brick")
            else
            {
                random_x = rng.Next(1, 3);
                random_y = rng.Next(1, 4);


                speed = new Vector2(-random_x, -random_y);

                obj_transform.position.x += speed.x;
                obj_transform.position.y += speed.y;
            }


            return speed;
        }
        internal void collisiontrue(string Tag, Transform transform)
        {

            

                newDirection(angleX, angleY, isNegative, Tag, transform);
           
             
        }
        public void ballMovement()
        {
            AddMove(speed);
            if(transform.position.x <= 0 + RealWidth / 2 || transform.position.x >= 780 + RealWidth / 2)
            {
                speed.x = -speed.x;
            }
            if(transform.position.y <= 0 + RealHeight/2)
            {
                speed.y = -speed.y;
            }
            if(transform.position.y >= 700)
            {
                transform.position = new Vector2(400, 500);
                speed = new Vector2(1, -1);
                GameManager.loser();
            }
        }
        public void ResetPosition(Vector2 pos, Vector2 restSpeed)
        {
            transform.position = pos;
            speed = restSpeed;
        }
    }
}
