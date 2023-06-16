using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Brick : Character
    {

        private float life = 100f;
        private Transform transform;
        public Brick(Vector2 initialPos) : base(initialPos)
        {

        }

        public void DamageLife(int damage)
        {
           
            
                life -= damage;
            
           
        }

        public void death()
        {
            
            if(life <= 0)
            {
                
            }
            
        }

    }
}
