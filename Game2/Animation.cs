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
    class Animation : Animator
    {
        float fps;
        Vector2 offset;
        Rectangle[] rectangles;

        public Animation(int frames,int yPos,int xStratFrame,int width,int height,float fps,Vector2 offset)
        {
            Rectangles = new Rectangle[frames];
            this.fps = fps;
            this.offset = offset;

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStratFrame) * width, yPos, width, height);
            }
        }

        public float Fps { get => fps; set => fps = value; }
        public Vector2 Offset { get => offset; set => offset = value; }
        public Rectangle[] Rectangles { get => rectangles; set => rectangles = value; }


        
    }
}
