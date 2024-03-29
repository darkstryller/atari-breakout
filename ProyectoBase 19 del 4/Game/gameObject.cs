﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class gameObject : IRenderer
    {
        protected Transform transform;

        public bool Coll_Flag = false;
        public bool M_renderer = true;
        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public bool renderer
        {
            get
            {
                return M_renderer;
            }
            set
            {
                M_renderer = value;
            }
        }

        public Animation currentAnimation = null;



        internal Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);

            return animation;
        }

       

        public void Update()
        {
            currentAnimation.Update();
        }

        public void Draw()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }

        public bool IsBoxColliding(gameObject p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_objB.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_objB.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                Coll_Flag = true;

                return true;
            }
            return false;
        }


    }
}
