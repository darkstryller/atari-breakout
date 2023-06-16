using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ball : Character
    {
        private Transform transform;

        private Vector2 launch = new Vector2(1, -1);

        public Random rng = new Random();


        public Ball(Vector2 initialPos) : base(initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            Tag = "ball";
        }
        
        public void ballMovement()
        {
           
            AddMove(launch);
            if (transform.position.x < 0 || transform.position.x > 700)
            {
                launch.x = launch.x * -1;
            }

            if (transform.position.y < 50)
            {
                launch.y = launch.y * -1;
            }


        }

    }
}

