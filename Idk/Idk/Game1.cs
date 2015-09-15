using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;


using FarseerPhysics.DebugView;
using FarseerPhysics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using FarseerPhysics.Dynamics.Contacts;
using System;
using System.Collections.Generic;
using FarseerPhysics.Common;
using FarseerPhysics.Collision;

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
        Texture2D pencilTex;
        World world;
        float timer;
        private SpriteBatch _batch;
        private SpriteFont _font;
        Texture2D foreground;
        Texture2D boxTex;
        BoxPlatform boxPlatform;
        Texture2D collisionSpark;
        Vector2 collisionPoint;
        ScrollingBackground myBackground;
        PencilWall[] pencilWallTop;
        PencilWall[] pencilWallBot;
        PencilWall[] pencilWallLeft;
        PencilWall[] pencilWallRight;
        bool drawSpark = false;

        //music stuff
        protected Song song;
        protected SoundEffect[] effect;
        //debug view objects
        DebugViewXNA _debugView;

        //Startscreen
        private List<ScreenInterface> ScreenList = new List<ScreenInterface>();
        private bool isActive;
        Texture2D firstbackground;
        SpriteFont font;





        //Physics parameters
        Vector2 car1StartingPos = new Vector2(1700.0f, 200.0f);
        Vector2 car2StartingPos = new Vector2(300.0f, 200.0f);
        private Texture2D pencilTexSide;
        private bool GameMusicPlaying=false;

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

            //Steup StartScreen
            Song MenuSong;
            MenuSong = Content.Load<Song>("Sounds/Menu_Song_mixdown");
            font = Content.Load<SpriteFont>("Sprites/font");


            isActive = false;
            ScreenList.Add(new FirstScreen(MenuSong,font));
            ScreenList[0].setActive(true);
            firstbackground = Content.Load<Texture2D>("Sprites/Start_Screen_Background");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Sprites/Lava_Scrolling_Bkrnd_2048");
            foreground = Content.Load<Texture2D>("Sprites/Foreground");
            boxTex = Content.Load<Texture2D>("Sprites/ToyBox");
            Texture2D carsSpriteSheet = Content.Load<Texture2D>("Sprites/Cars_test");
            myBackground = new ScrollingBackground();
            myBackground.Load(GraphicsDevice, background);


            //pENCIL wALLS TOP
            pencilTex = Content.Load<Texture2D>("Sprites/Bottom_pencil");
            pencilTexSide = Content.Load<Texture2D>("Sprites/Side_Pencil");
            pencilWallTop = new PencilWall[5];
            pencilWallTop[0] = new PencilWall(pencilTex, new Vector2(125, 100), world, "up");
            pencilWallTop[1] = new PencilWall(pencilTex, new Vector2(455, 100), world, "up");
            pencilWallTop[2] = new PencilWall(pencilTex, new Vector2(785, 100), world, "up");
            pencilWallTop[3] = new PencilWall(pencilTex, new Vector2(1125, 100), world, "up");
            pencilWallTop[4] = new PencilWall(pencilTex, new Vector2(1445, 100), world, "up");


            //PencilWalls Bot
            pencilWallBot = new PencilWall[5];

            pencilWallBot[0] = new PencilWall(pencilTex, new Vector2(125, 950), world, "down");
            pencilWallBot[1] = new PencilWall(pencilTex, new Vector2(455, 950), world, "down");
            pencilWallBot[2] = new PencilWall(pencilTex, new Vector2(785, 950), world, "down");
            pencilWallBot[3] = new PencilWall(pencilTex, new Vector2(1125, 950), world, "down");
            pencilWallBot[4] = new PencilWall(pencilTex, new Vector2(1445, 950), world, "down");

            //PencilWalls Left
            pencilWallLeft = new PencilWall[3];
            pencilWallLeft[0] = new PencilWall(pencilTexSide, new Vector2(100, 130), world, "left");
            pencilWallLeft[1] = new PencilWall(pencilTexSide, new Vector2(100, 410), world, "left");
            pencilWallLeft[2] = new PencilWall(pencilTexSide, new Vector2(100, 690), world, "left");

            pencilWallRight = new PencilWall[3];
            pencilWallRight[0] = new PencilWall(pencilTexSide, new Vector2(1775, 130), world, "right");
            pencilWallRight[1] = new PencilWall(pencilTexSide, new Vector2(1775, 410), world, "right");
            pencilWallRight[2] = new PencilWall(pencilTexSide, new Vector2(1775, 690), world, "right");

            //collision spark
            collisionSpark = Content.Load<Texture2D>("Sprites/SINGLE_Spark_Sprite_Sheet");

            //Background music
            effect = new SoundEffect[3];
            effect[0] = Content.Load<SoundEffect>("Sounds/Car_Crash001");
            effect[1] = Content.Load<SoundEffect>("Sounds/Car_Crash002");
            effect[2] = Content.Load<SoundEffect>("Sounds/Car_Crash003");




            car1 = new AnimatedSprite(carsSpriteSheet, 3, 6, car1StartingPos, world);
            car2 = new AnimatedSprite(carsSpriteSheet, 3, 6, car2StartingPos, world);
            boxPlatform = new BoxPlatform(boxTex, new Vector2(650, 350), world);

            car1.player1.OnCollision += MyOnCollision;
            car2.player1.OnCollision += MyOnCollision;
            //DebugViewXNA view objects
            _font = Content.Load<SpriteFont>("Sprites/font");
            _batch = new SpriteBatch(graphics.GraphicsDevice);
            _debugView = new DebugViewXNA(world);
            _debugView.AppendFlags(DebugViewFlags.DebugPanel);
            _debugView.DefaultShapeColor = Color.White;
            _debugView.SleepingShapeColor = Color.LightGray;
            _debugView.LoadContent(GraphicsDevice, Content);


            // TODO: use this.Content to load your game content here

        }
        private bool MyOnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
          FixedArray2<ManifoldPoint> fa2 = contact.Manifold.Points;
            collisionPoint = ConvertUnits.ToDisplayUnits(fa2[0].LocalPoint);
            drawSpark = true;

            Random randomSound = new Random();
            effect[randomSound.Next(3)].Play();
            return true;
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

            if (ScreenList[0].getActive() == true)
            {
                ScreenList[0].Update(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    ScreenList[0].setActive(false);
                    isActive = true;
                    if(!GameMusicPlaying)
                    playGameMusic();
                }
            }
            car1.Position = ConvertUnits.ToDisplayUnits(car1.player1.Position);
            car2.Position = ConvertUnits.ToDisplayUnits(car2.player1.Position);
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            myBackground.Update(0.1f);
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
         RemoveFallenObjects();
            // TODO: Add your update logic here
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        private void RemoveFallenObjects()
        {
            //check if cars are on the table
            Vector2 car1Pos= car1.player1.Position;
            Vector2 car2Pos = car1.player1.Position;
        }

        private bool isBodyOnTable(Vector2 position)
        {
            if(position.X<100.0f || position.X>1550.0f)

                return false;
          /*  if(position.Y < 130.0f || position.Y > 800.0f)
                return false;*/
            return true;

        }

        private void playGameMusic()
        {
            if (isActive)
            {
                GameMusicPlaying = true;
                song = Content.Load<Song>("Sounds/In_Game");
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true;
            }
        }






        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (ScreenList[0].getActive() == true)
                ScreenList[0].Draw(gameTime, graphics, firstbackground, spriteBatch);

            else
            {
                spriteBatch.Begin();


                myBackground.Draw(spriteBatch);
                //spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.Draw(foreground, new Rectangle(50, 50, graphics.PreferredBackBufferWidth - 100, graphics.PreferredBackBufferHeight - 100), Color.White);
                // spriteBatch.Draw(taxi, vec, new Rectangle(0, 0, taxi.Width, taxi.Height), Color.White,ConvertUnits.ToDisplayUnits(player1.Rotation),origin,1.0f,SpriteEffects.None,1);
                car1.Draw(spriteBatch);
                car2.Draw(spriteBatch);
              //  boxPlatform.Draw(spriteBatch);
                pencilWallTop[0].Draw(spriteBatch);
                pencilWallTop[1].Draw(spriteBatch);
                pencilWallTop[2].Draw(spriteBatch);
                pencilWallTop[3].Draw(spriteBatch);
                pencilWallTop[4].Draw(spriteBatch);



                pencilWallBot[0].Draw(spriteBatch);
                pencilWallBot[1].Draw(spriteBatch);
                pencilWallBot[2].Draw(spriteBatch);
                pencilWallBot[3].Draw(spriteBatch);
                pencilWallBot[4].Draw(spriteBatch);



                //pencil wall left

                pencilWallLeft[0].Draw(spriteBatch);
                pencilWallLeft[1].Draw(spriteBatch);
                pencilWallLeft[2].Draw(spriteBatch);



                //pencil wall right
                pencilWallRight[0].Draw(spriteBatch);
                pencilWallRight[1].Draw(spriteBatch);
                pencilWallRight[2].Draw(spriteBatch);

                //draw collisionspark if drawSpark
                if (drawSpark)
                {
                    drawSpark = false;
                    spriteBatch.Draw(collisionSpark, new Rectangle((int)collisionPoint.X, (int)collisionPoint.Y, collisionSpark.Width,collisionSpark.Height), Color.White);

                }

                spriteBatch.End();

                //debug view draw

                Matrix projection = Matrix.CreateOrthographicOffCenter(0f, ConvertUnits.ToSimUnits(graphics.GraphicsDevice.Viewport.Width),
                                                                  ConvertUnits.ToSimUnits(graphics.GraphicsDevice.Viewport.Height), 0f, 0f,
                                                                  1f);
                //Matrix view = Matrix.CreateTranslation(new Vector3((Vector2.Zero / MeterInPixels) - (new Vector2(graphics.GraphicsDevice.Viewport.Width / 2f,
                                           //          graphics.GraphicsDevice.Viewport.Height / 2f) / MeterInPixels), 0f)) * Matrix.CreateTranslation(new Vector3((new Vector2(graphics.GraphicsDevice.Viewport.Width / 2f,
                                             //        graphics.GraphicsDevice.Viewport.Height / 2f) / MeterInPixels), 0f));
                // draw the debug view
                 _debugView.RenderDebugData(ref projection);



                // TODO: Add your drawing code here

                base.Draw(gameTime);
            }
        }
    }
}
