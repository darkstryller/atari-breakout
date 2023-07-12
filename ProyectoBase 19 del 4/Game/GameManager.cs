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

        static GameManager()
        {
            // Set initial values
            score = 0;
            win = 0;
            balls = 3;
            originalLevel = null;
        }

        public static void Initialize(level levelInstance)
        {
            originalLevel = levelInstance;
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
                Engine.Debug($"your won a total of {totalwins} times");
                ResetGame();
            }
        }

        private static void ResetGame()
        {
            // Reset score and ball count
            score = 0;
            balls = 3;

            // Reset the level with the same brick layout
            if (originalLevel != null)
            {
                originalLevel.levelsetter();
            }
        }
    }
}
