using Microsoft.Xna.Framework;
using System;
using System.Text;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;


namespace Idk
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AnimatedSprite car1,car2;
        float timer;
        string direction = "down";
        World world;

        //Physics parameters

        const float MaxSteerAngle = (float)Math.PI / 3;
        const float SteerSpeed = 1.5f;
        const float Horsepower = 40f;
        Vector2 carStartingPos = new Vector2(, 10);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            world = new World(new Vector2(0,0));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
           
           Texture2D cartex = Content.Load<Texture2D>("car");
            car1 = new AnimatedSprite(cartex, 4, 3,new Vector2(400,200));
            car2 = new AnimatedSprite(cartex, 4, 3, new Vector2(200, 300));

            //background
            //const string bgImagePath = "";
            //backgroundTexture = Content.Load<Texture2D>(bgImagePath);

            // TODO: use this.Content to load your game content here
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
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer>=1.0f)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (!direction.Equals("down"))
                    {
                        direction = "down";
                        
                    }
                    car1.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (!direction.Equals("up"))
                    {
                        direction = "up";

                    }
                    car1.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (!direction.Equals("left"))
                    {
                        direction = "left";

                    }
                    car1.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (!direction.Equals("right"))
                    {
                        direction = "right";

                    }
                    car1.Update(direction);

                }


                //player 2
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (!direction.Equals("down"))
                    {
                        direction = "down";

                    }
                    car2.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (!direction.Equals("up"))
                    {
                        direction = "up";

                    }
                    car2.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    if (!direction.Equals("left"))
                    {
                        direction = "left";

                    }
                    car2.Update(direction);

                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (!direction.Equals("right"))
                    {
                        direction = "right";

                    }
                    car2.Update(direction);

                }



            }

            // TODO: Add your update logic here

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
                       car1.Draw(spriteBatch);
            car2.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
