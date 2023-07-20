using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class GameManager
    {
        private static int score;
        public static int win;
        private static int totalwins;
        private static int balls;
        private static brickPool pool;
        private static level originalLevel;
        private static Player player;
        private static GameOverScreen gameOver;
        private static Ball ball;
        public static bool Loser;

        private static List<IBricksSpawnPositions> activeBricks = new List<IBricksSpawnPositions>();

        static GameManager()
        {
            // Set initial values
            score = 0;
            win = 0;
            balls = 3;
            originalLevel = null;
            Loser = false;
        }

        public static void Initialize(level levelInstance, Player playerInstance, GameOverScreen gameOverScreenInstance, Ball ballinstance)
        {
            originalLevel = levelInstance;
            player = playerInstance;
            gameOver = gameOverScreenInstance;
            ball = ballinstance;
            pool = new brickPool();
            pool.ResetPool();
            ResetGame();
            win = levelInstance.totalbricks;
            totalwins = 0;

        }

        public static void addPoint()
        {
            score++;

            if (score >= win)
            {
                Engine.Debug("You win!");
                totalwins++;
                ResetGame();
            }
        }

        public static void loser()
        {
            balls--;

            if (balls <= 0)
            {
                Engine.Debug("You lose!");
                Loser = true;
                ShowGameOverScreen(totalwins);
                
                
                foreach (var brick in activeBricks)
                {
                    brickFactory.ReleaseBrick(brick);
                }
            }
        }

        private static void ShowGameOverScreen(int totalWins)
        {
            Engine.Debug($"Game Over! Total wins: {totalWins}");
            if(gameOver != null)
            {
                gameOver.renderer = true; 
            }
        }
        public static void AddActiveBrick(IBricksSpawnPositions brick)
        {
            activeBricks.Add(brick);
        }

        public static void RemoveActiveBrick(IBricksSpawnPositions brick)
        {
            activeBricks.Remove(brick);
        }
        public static void ResetGame()
        {
            
            score = 0;
            balls = 3;
            Loser = false;
            foreach (var item in renderManager.Instance.getObjects())
            {

                item.renderer = true;

            }
            if (originalLevel != null)
            {
                
                originalLevel.levelsetter();
            }

            if (player != null)
            {
                player.ResetPosition(new Vector2(400,550));
            }

            if(ball != null)
            {
                ball.ResetPosition(new Vector2(400, 350), new Vector2(1, 1));
            }
            Engine.Debug(win + "" + "bricks to win");
            pool.ResetPool();
        }

    }
}
