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
    class Transform : Component
    {
        Vector2 position;

        public Transform(GameObject gameObject, Vector2 position): base(gameObject)
        {
            this.position = position;

        }

        public Vector2 Position { get => position; set => position = value; }


        public void Translate(Vector2 translation)
        {
            position += translation;
        }

        
    }
}
