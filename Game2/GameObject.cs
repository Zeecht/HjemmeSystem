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
    class GameObject : Component
    {
        #region fields;
        private List<Component> components = new List<Component>();
        private Transform transform;


        #endregion;

        public Transform Transform { get => transform; }

        public GameObject()
        {
            transform = new Transform(this, Vector2.One);

            AddComponent(transform);
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }
        public Component GetComponent(string component)
        {
            Component _return = null;
            foreach (Component com in components)
            {
                if (com.GetType().Name == component)
                {
                    _return = com;
                    break;
                }
            }

            return _return;
        }

        public void LoadContent(ContentManager content)
        {

            foreach (Component component in components)
            {
                if (component is Interfaces.ILoadable)
                {
                    (component as Interfaces.ILoadable).LoadContent(content);
                }
            }
            
        }
        public void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                if (component is Interfaces.IUpdateable)
                {
                    (component as Interfaces.IUpdateable).Update();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components)
            {
                if (component is Interfaces.IDrawable)
                {
                    (component as Interfaces.IDrawable).Draw(spriteBatch);
                }
            }
        }
        public void OnAnimationDone(string animationName)
        {
            foreach (Component component in components)
            {
                if (component is Interfaces.IAnimateable)
                {
                    (component as Interfaces.IAnimateable).OnAnimationDone(animationName);
                }
            }
        }
    }
}
