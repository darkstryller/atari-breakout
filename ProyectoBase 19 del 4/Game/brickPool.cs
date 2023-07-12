using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class brickPool
    {
        private List<IBricksSpawnPositions> pool;

        public brickPool()
        {
            pool = new List<IBricksSpawnPositions>();
            
        }

        public IBricksSpawnPositions GetBrick(brickFactory.BrickSpawnPositions type, Vector2 position)
        {
            IBricksSpawnPositions brick = pool.FirstOrDefault(b => b.Type == type && !b.IsActive);

            if (brick == null)
            {
                brick = new Brick(position, GetBrickLife(type)); 
                pool.Add(brick);
            }
            else
            {
                brick.Reset(position); 
            }

            brick.IsActive = true;
            return brick;
        }

        public void ReleaseBrick(IBricksSpawnPositions brick)
        {
            brick.IsActive = false;
        }

        private int GetBrickLife(brickFactory.BrickSpawnPositions type)
        {
            
            switch (type)
            {
                case brickFactory.BrickSpawnPositions.glassBrick:
                    return 100;
                case brickFactory.BrickSpawnPositions.normalBrick:
                    return 200;
                case brickFactory.BrickSpawnPositions.toughBrick:
                    return 400;
                default:
                    return 0;
            }
        }
    }
}