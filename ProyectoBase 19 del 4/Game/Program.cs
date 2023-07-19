using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;

namespace Game
{
    public class Program
    {
        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        
        
        
        static Player player;
        static Ball ball;
        static GameOverScreen gameoverscreen;
        
        
        static level start;

        


        static void Main(string[] args)
        {
            Engine.Initialize();
            
            
            player = new Player(new Vector2(400, 550));
            ball = new Ball(new Vector2(400, 350));
            start = new level();
            gameoverscreen = new GameOverScreen(new Vector2(400, 300));
            gameoverscreen.renderer = false;
            GameManager.Initialize(start, player, gameoverscreen, ball);
            
            SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
            //myplayer.PlayLooping();

            while (true)
            {
                calcDeltatime();
                
                Update();
                if (Engine.GetKey(Keys.SPACE) && GameManager.Loser)
                {
                    gameoverscreen.renderer = false; 
                    GameManager.ResetGame();
                }

                Draw();
            }
        }
      

        static void Update()
        {
            if (GameManager.Loser == true)
            {
                foreach (var item in renderManager.Instance.getObjects())
                {

                    item.renderer = false;

                }

                return;
            }

            if (Engine.GetKey(Keys.A))
            {
                player.AddMove(new Vector2(-player.Speed * deltaTime, 0));
                player.limits();
            }
            if (Engine.GetKey(Keys.D))
            {
                player.AddMove(new Vector2(player.Speed * deltaTime, 0));
                player.limits();
            }

           

            if (ball.IsBoxColliding(player))
            {

                ball.collisiontrue("player", player.Transform);
                
            }
            ball.ballMovement();

            

            var l_bricks = LayoutManager.Instance.GetBricks();

            
            
            foreach(var brick in l_bricks)
            {
                if (brick.IsBoxColliding(ball))
                {
                    
                    ball.collisiontrue("Brick", brick.Transform);
                    brick.collisiontrue();
                }

                

                brick.Update();
            }

           

        }

        static void Draw()
        {
            Engine.Clear();
            
                
            
            foreach (var item in renderManager.Instance.getObjects())
            {
                if(item.renderer == true)
                {
                    item.Draw();
                }

                
            }
            //ship.Render();
            if(gameoverscreen != null)
            {
                if (gameoverscreen.renderer == true)
                {
                    gameoverscreen.Draw();
                }
            }
           
            

            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }


       

       
    }
}