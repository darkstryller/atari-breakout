﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Brick : Character
    {

        private float life = 100f;
        public Brick(Vector2 initialPos) : base(initialPos)
        {

        }

        public void DamageLife(int damage)
        {
            /*
            if(objecttype == 2)
            {
                life -= damage;
            }
           */
        }

        public void death()
        {
            /*
            if(objecttype== 2 && life <= 0)
            {
                
            }
            */
        }

    }
}
