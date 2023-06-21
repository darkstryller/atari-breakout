using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        static int input_Multiplier = 100;
        static float _posY = 305;
        static float _posX = 305;
        static float _speed = 100;
        
        static float _rot = 0;

        static levelMaker levelMaker = new levelMaker{ };
        
        static Player Player;
        static Ball ball;
        static Brick brick;
        
       

        static Animation currentAnimation = null;
        static Animation idle;


        static void Main(string[] args)
        {
            Engine.Initialize();
            
            
            Player = new Player(new Vector2(400, 550));
            ball = new Ball(new Vector2(400, 350));
            idle = CreateAnimation();
            currentAnimation = idle;
            
            brick = new Brick(new Vector2(400, 200));
            
            
            SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
            //myplayer.PlayLooping();

            while (true)
            {
                calcDeltatime();

                Update();
                Draw();
            }
        }

        static void Update()
        {
            
            if (Engine.GetKey(Keys.A))
            {
                Player.AddMove(new Vector2(-Player.Speed * deltaTime, 0));
                Player.limits();
            }
            if (Engine.GetKey(Keys.D))
            {
                Player.AddMove(new Vector2(Player.Speed * deltaTime, 0));
                Player.limits();
            }

            if (ball.IsBoxColliding(Player))
            {

                ball.collisiontrue(Player.Tag, Player.Transform);
                
            }
            ball.ballMovement();

            

            var l_bricks = LayoutManager.Instance.GetBricks();

            levelMaker.levelsetter();
            
            foreach(var brick in l_bricks)
            {
                if (brick.IsBoxColliding(ball))
                {
                    Engine.Debug("hit");
                    ball.collisiontrue(brick.Tag, brick.Transform);
                    brick.collisiontrue();
                }

                

                brick.Update();
            }


        }

        static void Draw()
        {
            Engine.Clear();
            
            Player.Draw();
            ball.Draw();

            foreach (var brick in LayoutManager.Instance.GetBricks())
            {
                if (brick.isAlive == true)
                {
                    brick.Draw();
                }
                
            }
            //ship.Render();
          


            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }


       

        private static Animation CreateAnimation()
        {
            // Idle Animation
            List<Texture> idleFrames = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                idleFrames.Add(Engine.GetTexture($"{i}.png"));
            }

            Animation idleAnimation = new Animation("Idle", idleFrames, 2, true);

            return idleAnimation;
        }
    }
}