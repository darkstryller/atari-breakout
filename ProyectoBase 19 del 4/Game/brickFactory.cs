using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public static class brickFactory
    {
        public static Vector2 spawn;

        private static brickPool brickPool = new brickPool();

        public enum BrickSpawnPositions { glassBrick, normalBrick, toughBrick }
        
        public static void SetSpawn(Vector2 position)
        {
            spawn = position;
        }

        public static IBricksSpawnPositions CreateBrick(BrickSpawnPositions brick, Vector2 spawn)
        {
            return brickPool.GetBrick(brick, spawn);
        }
    }

    public class level
    {
        public int totalbricks = 8;
        private int instances;
        private Vector2 row1 = new Vector2(50, 100);
        private Vector2 row2 = new Vector2(50, 200);
        private Vector2 row3 = new Vector2(50, 300);
        private static Random rng = new Random();
        private brickPool brickPool = new brickPool();

        public void levelsetter()
        {
            instances = totalbricks;
            int glassBricks = rng.Next(1, totalbricks + 1);
            int normalBricks = rng.Next(1, totalbricks - glassBricks + 1);
            int toughBricks = totalbricks - glassBricks - normalBricks;

            firstRow(glassBricks);
            secondRow(normalBricks);
            thirdRow(toughBricks);

            ReleaseBricks();
        }

        private void firstRow(int thisrow)
        {
            Vector2 position = row1;

            for (int i = 0; i < thisrow; i++)
            {
                if (instances == 0)
                {
                    break;
                }
                IBricksSpawnPositions brick = brickPool.GetBrick(brickFactory.BrickSpawnPositions.glassBrick, position);
                position.x += 100;
                instances--;
            }

            return;
        }

        private void secondRow(int thisrow)
        {
            Vector2 position = row2;

            for (int i = 0; i < thisrow; i++)
            {
                if (instances == 0)
                {
                    break;
                }
                IBricksSpawnPositions brick = brickPool.GetBrick(brickFactory.BrickSpawnPositions.normalBrick, position);
                position.x += 100;
                instances--;
            }

            return;
        }

        private void thirdRow(int thisrow)
        {
            Vector2 position = row3;

            for (int i = 0; i < thisrow; i++)
            {
                if (instances == 0)
                {
                    break;
                }
                IBricksSpawnPositions brick = brickPool.GetBrick(brickFactory.BrickSpawnPositions.toughBrick, position);
                position.x += 100;
                instances--;
            }

            return;
        }

        private void ReleaseBricks()
        {
            Vector2 dummyPosition = new Vector2(0,0); // Dummy position

            while (instances > 0)
            {
                IBricksSpawnPositions brick = brickPool.GetBrick(brickFactory.BrickSpawnPositions.glassBrick, dummyPosition);
                instances--;
            }
        }

    }

}
