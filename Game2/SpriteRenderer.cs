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
    class SpriteRenderer : Component, Interfaces.IDrawable, Interfaces.ILoadable 
    {
        private Rectangle GetRectangle;
        private Texture2D sprite;
        private string spriteName;
        private float layerDepth;
        private GameObject gameObject;
        private Vector2 origin;
        Vector2 offset;


        public Texture2D Sprite { get => sprite; set => sprite = value; }
        public Rectangle GetRectangle1 { get => GetRectangle; set => GetRectangle = value; }
        public Vector2 Offset { get => offset; set => offset = value; }

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth): base (gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
            this.gameObject = gameObject;
        }

        public void Update()
        {

        }

        public void LoadContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>(spriteName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //mangler offset side 82 advanced animation
            spriteBatch.Draw(Sprite, gameObject.Transform.Position,null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }
    }
}
