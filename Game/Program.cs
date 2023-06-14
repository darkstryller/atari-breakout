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
        
        static float _posY = 305;
        static float _posX = 305;
        static float _speed = 100;
        static int levelcounter = 1;
        static float _rot = 0;
     
        static Character player;
        
        static Ball ball;
        static Character ball2;
        static LevelManager level = new LevelManager { };
        static List<Bullet> bullets = new List<Bullet>();

        static Animation currentAnimation = null;
        static Animation idle;
        
       


        static void Main(string[] args)
        {

            Engine.Initialize();
            
            level.levelsetter(levelcounter);
            player = new Character(new Vector2(400,500));
           
            idle = CreateAnimation();
            currentAnimation = idle;
            ball = new Ball(new Vector2(400, 200));
            ball2 = new Character(new Vector2(200, 200));

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
            if (Engine.GetKey(Keys.D) && player.Transform.position.x < 800 - player.RealWidth / 2)
            {
                
               player.AddMove(new Vector2(player.Speed * 5 * deltaTime, 0));
            }

            if (Engine.GetKey(Keys.A) && player.Transform.position.x > (0 + player.RealWidth) / 2)
            {
                
                player.AddMove(new Vector2(-player.Speed * 5 * deltaTime,0));
            }

            ball.ballMovement();
            ball2.ballMovement();


            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }

            

            var l_characters = CharactersManager.Instance.GetCharacters();
            foreach (var character in l_characters)
            {
                for (int i = 0; i < l_characters.Count; i++)
                {
                    if(character != l_characters[i])
                        if (character.IsBoxColliding(l_characters[i]))
                        {
                            //Engine.Debug("ESTOY COLISIONANDO");
                        }
                        if (ball.IsBoxColliding(l_characters[i]))
                        {

                        }
                }

                character.Update();
            }

           
            
            //currentAnimation.Update();
            //ship.Update();
            //pp.Update();
        }

        static void Draw()
        {
            Engine.Clear();


            foreach (var character in CharactersManager.Instance.GetCharacters())
            {
                character.Draw();
            }
           
            //ship.Render();
            //pp.Render();
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Draw)
                {
                    bullets.RemoveAt(i);
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].DrawBullet();
            }

            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }


         void Shoot()
        {
            bullets.Add(new Bullet(_posX + 230, _posY + 60, _rot));
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