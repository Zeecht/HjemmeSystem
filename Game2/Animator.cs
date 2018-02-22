using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class Animator : Component, Interfaces.IUpdateable
    {
        private SpriteRenderer spriteRenderer;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Rectangle[] rectangles;
        private string animationName;
        private Dictionary<string, Animation> animations;








        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
        }

        //Udcommenter hele loadcontent
        public void LoadContent(ContentManager content)
        {
            int width = spriteRenderer.Sprite.Width / 4;
            rectangles = new Rectangle[4];
            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i] = new Rectangle(i * width, 0, width, spriteRenderer.Sprite.Height);
            }
        }

        public void Update()
        {
            timeElapsed += GameWorld.GetInstance.DeltaTime;
            currentIndex = (int)(timeElapsed * fps);
            if (currentIndex > rectangles.Length - 1)
            {
                GameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }

            spriteRenderer.GetRectangle1 = rectangles[currentIndex];
        }

        public void CreateAnimation(string name,Animation animation)
        {


        }

        public void PlayAnimation(string animationName)
        {
            if (this.animationName != animationName)
            {
                //sets the reactangles
                this.rectangles = animations[animationName].Rectangles;

                //resets the rectangles
                this.spriteRenderer.GetRectangle1 = rectangles[0];

                //sets the offset
                this.spriteRenderer.Offset = animations[animationName].Offset;

                //sets the animationname
                this.animationName = animationName;

                //sets the fps
                this.fps = animations[animationName].Fps;

                //resets the animation
                timeElapsed = 0;
                currentIndex = 0;
            }
        }

    }
}
