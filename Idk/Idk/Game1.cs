using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;


using FarseerPhysics.DebugView;
using FarseerPhysics;


namespace Idk
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AnimatedSprite car1;
        AnimatedSprite car2;
        Texture2D background;
        World world;
        float timer;
        private SpriteBatch _batch;
        private SpriteFont _font;
        Texture2D foreground;

        //debug view objects
        DebugViewXNA _debugView;
        private Matrix _view;
        private const float MeterInPixels = 64f;




        //Physics parameters
        Vector2 car1StartingPos = new Vector2(960.0f, 540.0f);
        Vector2 car2StartingPos = new Vector2(200.0f, 200.0f);


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            world = new World(new Vector2(0, 0));

            world.Gravity = new Vector2(0f, 0f);
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

            //taxi = Content.Load<Texture2D>("Taxi");
            background = Content.Load<Texture2D>("Background");
            foreground = Content.Load<Texture2D>("Foreground");
            Texture2D carsSpriteSheet = Content.Load<Texture2D>("Motor_Mania");
            car1 = new AnimatedSprite(carsSpriteSheet, 3, 6, car1StartingPos,world);
            car2 = new AnimatedSprite(carsSpriteSheet, 3, 6, car2StartingPos, world);


            //DebugViewXNA view objects
            _font = Content.Load<SpriteFont>("font");
            _batch = new SpriteBatch(graphics.GraphicsDevice);
            _debugView = new DebugViewXNA(world);
            _debugView.AppendFlags(DebugViewFlags.DebugPanel);
            _debugView.DefaultShapeColor = Color.White;
            _debugView.SleepingShapeColor = Color.LightGray;
            _debugView.LoadContent(GraphicsDevice, Content);


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
            car1.Position = ConvertUnits.ToDisplayUnits(car1.player1.Position);
            car2.Position = ConvertUnits.ToDisplayUnits(car2.player1.Position);
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer>=1.0f)
            {
                if(Keyboard.GetState().IsKeyDown(Keys.Up))
                
                car1.handleInput(1,"Player2");
                if (Keyboard.GetState().IsKeyDown(Keys.Down))

                    car1.handleInput(2, "Player2");
                if (Keyboard.GetState().IsKeyDown(Keys.Left))

                    car1.handleInput(3, "Player2");
                if (Keyboard.GetState().IsKeyDown(Keys.Right))

                    car1.handleInput(4, "Player2");

                if (Keyboard.GetState().IsKeyDown(Keys.W))

                    car2.handleInput(1, "Player1");
                if (Keyboard.GetState().IsKeyDown(Keys.S))

                    car2.handleInput(2, "Player1");
                if (Keyboard.GetState().IsKeyDown(Keys.A))

                    car2.handleInput(3, "Player1");
                if (Keyboard.GetState().IsKeyDown(Keys.D))

                    car2.handleInput(4, "Player1");

            }


            // TODO: Add your update logic here
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }






        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //        car1.Draw(spriteBatch);


            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(foreground, new Rectangle(50, 50, graphics.PreferredBackBufferWidth-100, graphics.PreferredBackBufferHeight-100), Color.White);
            // spriteBatch.Draw(taxi, vec, new Rectangle(0, 0, taxi.Width, taxi.Height), Color.White,ConvertUnits.ToDisplayUnits(player1.Rotation),origin,1.0f,SpriteEffects.None,1);
            car1.Draw(spriteBatch);
           car2.Draw(spriteBatch);
            spriteBatch.End();

            //debug view draw

            Matrix projection = Matrix.CreateOrthographicOffCenter(0f, ConvertUnits.ToSimUnits(graphics.GraphicsDevice.Viewport.Width),
                                                              ConvertUnits.ToSimUnits(graphics.GraphicsDevice.Viewport.Height), 0f, 0f,
                                                              1f);
           Matrix view = Matrix.CreateTranslation(new Vector3((Vector2.Zero / MeterInPixels) - (new Vector2(graphics.GraphicsDevice.Viewport.Width / 2f,
                                                graphics.GraphicsDevice.Viewport.Height / 2f) / MeterInPixels), 0f)) * Matrix.CreateTranslation(new Vector3((new Vector2(graphics.GraphicsDevice.Viewport.Width / 2f,
                                                graphics.GraphicsDevice.Viewport.Height / 2f) / MeterInPixels), 0f));
            // draw the debug view
           // _debugView.RenderDebugData(ref projection);



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
