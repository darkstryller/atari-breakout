using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Brick : gameObject
    {
        private int life = 100;
        public bool isAlive = true;
       
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

        
        Animation idle;

        public Brick(Vector2 initial_pos)
        {
            Transform = new Transform(initial_pos, 0, new Vector2(1, 1));
            idle = CreateAnimation("Idle", "", 4, 2);
            Tag = "Brick";
            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
            LayoutManager.Instance.AddBrick(this);
        }

        internal void collisiontrue()
        {
            
            if(Coll_Flag == true)
            {
                DamageLife(50);
            }
           
            Coll_Flag = false;
            if(life <= 0)
            {
                Kill();
            }

        }

        public void DamageLife(int damage)
        {
            life -= damage;
        }

        public void Kill()
        {
            if(life <= 0)
            {
                Engine.Debug("mori");
                transform.position = new Vector2(-20, -20);
                isAlive = false;
                GameManager.addPoint();
            }
        }
    }
}
