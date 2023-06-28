using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Brick : gameObject, Idamageable 
    {
        public int m_life = 100;
        
       
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

        private bool mydestroy = false;

        private onHit hitEvent = delegate { };
        private ondestroyer destroyerevent = delegate { };
        public bool o_isdestroyed 
        {
            get => mydestroy;
            set => mydestroy = value; 
            
        }
        public int life { get => m_life; }

        public string Tag;

        
        Animation idle;

        public event onHit onHit
        {
            add
            {
                hitEvent += value; 
            }
            remove
            {
                hitEvent -= value; 
            }
        }
        

        public event ondestroyer ondestroyer
        {
            add
            {
                destroyerevent += value;
            }
            remove
            {
                destroyerevent -= value;
            }
        }
        

        public Brick(Vector2 initial_pos)
        {
            Transform = new Transform(initial_pos, new Vector2(0, 0), new Vector2(1, 1));
            idle = CreateAnimation("Idle", "", 4, 2);
            Tag = "Brick";
            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
            LayoutManager.Instance.AddBrick(this);
            renderManager.Instance.addObject(this);
            
        }

        internal void collisiontrue()
        {
            DamageLife(50);
           
            if(m_life <= 0)
            {
                Kill();
                destroy();
            }

        }

        public void DamageLife(int damage)
        {
            m_life -= damage;
            hitEvent.Invoke(life);
        }

        private void Kill()
        {
            if(m_life <= 0)
            {
                Engine.Debug("mori");
                transform.position = new Vector2(-50, -50);
                M_renderer = false;
                GameManager.addPoint();
            }
        }

        public void destroy()
        {
            destroyerevent.Invoke(this);
            mydestroy = true;
            o_isdestroyed = mydestroy;
        }
    }
}