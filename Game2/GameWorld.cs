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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private List<GameObject> gameObjects;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static GameWorld instance = new GameWorld();
        float deltaTime;

        public static GameWorld GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }
        internal List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public float DeltaTime { get => deltaTime;}

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            gameObjects = new List<GameObject>();
            // TODO: Add your initialization logic here
            GameObject g = new GameObject();
            g.AddComponent(new SpriteRenderer(g, "HeroStrip", 1));
            g.AddComponent(new Player(g));
            g.AddComponent(new Animator(g));
            //go.AddComponent(new SpriteRenderer(go, "index", 1));
            GameObjects.Add(g);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (GameObject go in gameObjects)
            {
                go.LoadContent(Content);
            }

            //GameObjects.Add(go);
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject go in GameObjects)
            {
                go.Update(gameTime);
            }
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (GameObject go in GameObjects)
            {
                
                go.Draw(spriteBatch);
                
            }
            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
