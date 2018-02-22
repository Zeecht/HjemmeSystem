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
    class Player : Component, Interfaces.IUpdateable, Interfaces.ILoadable
    {
        private float speed = 1000;
        public Animator animator;
        

        public Player(GameObject gameObject): base(gameObject)
        {
        }

        public void Update()
        {
            KeyboardState keystate = Keyboard.GetState();

            if (keystate.IsKeyDown(Keys.W))
            {
                GameObject.Transform.Translate(new Vector2(0, -1) * GameWorld.GetInstance.DeltaTime * speed);
            }
            if (keystate.IsKeyDown(Keys.S))
            {
                GameObject.Transform.Translate(new Vector2(0, 1) * GameWorld.GetInstance.DeltaTime * speed);
            }
            if (keystate.IsKeyDown(Keys.A))
            {
                GameObject.Transform.Translate(new Vector2(-1, 0) * GameWorld.GetInstance.DeltaTime * speed);
            }
            if (keystate.IsKeyDown(Keys.D))
            {
                GameObject.Transform.Translate(new Vector2(1, 0) * GameWorld.GetInstance.DeltaTime * speed);
            }
        }

        public void LoadContent(ContentManager content)
        {
            CreateAnimations();
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("IdleFront", new Animation(4, 0, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleBack", new Animation(4, 0, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(4, 0, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(4, 0, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkFront", new Animation(4, 150, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkBack", new Animation(4, 150, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkLeft", new Animation(4, 150, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(4, 150, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("AttackFront", new Animation(4, 300, 0, 145, 160, 8, new Vector2(-50, 0)));
            animator.CreateAnimation("AttackBack", new Animation(4, 465, 0, 170, 155, 8, new Vector2(-20, 0)));
            animator.CreateAnimation("AttackRight", new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero));
            animator.CreateAnimation("AttackLeft", new Animation(4, 770, 0, 150, 150, 8, new Vector2(-60, 0)));
            animator.CreateAnimation("DieFront", new Animation(3, 920, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieBack", new Animation(3, 920, 3, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));

        }


    }
}
