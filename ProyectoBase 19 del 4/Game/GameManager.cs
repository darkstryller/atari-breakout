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
        private static int win;
        private static int totalwins;
        private static int balls;
        private static level originalLevel;
        private static Player player;
        private static GameOverScreen gameOver;
        private static Ball ball;
        public static bool Loser;

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
            ResetGame();
            win = originalLevel.totalbricks; // Set the number of bricks required to win
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
                
                ShowGameOverScreen(totalwins);
                Loser = true;
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
        }

    }
}
