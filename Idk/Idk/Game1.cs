using Microsoft.Xna.Framework;
using System;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.SamplesFramework;
using FarseerPhysics.Factories;


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
        Texture2D taxi;
        Texture2D background;
        float timer;
        string direction = "down";
        World world;
        Rectangle taxiRect;
        Vector2 directionVec;
        Fixture bodyFixture;

        //Physics parameters

        const float MaxSteerAngle = (float)Math.PI / 3;
        const float SteerSpeed = 1.5f;
        const float Horsepower = 40f;
        Vector2 carStartingPos = new Vector2(400, 200);

        Vector2 leftRearWheelPosition = new Vector2(-1.5f, 1.9f);
        Vector2 rightRearWheelPosition = new Vector2(1.5f, 1.9f);
        Vector2 leftFrontWheelPosition = new Vector2(-1.5f, -1.9f);
        Vector2 rightFrontWheelPosition = new Vector2(1.5f, -1.9f);
        float engineSpeed;
        float steeringAngle=0;

        private Body leftWheel;
        private Body rightWheel;
        private Body leftRearWheel;
        private Body rightRearWheel;
        private Body body;
        private RevoluteJoint leftJoint;
        private RevoluteJoint rightJoint;
        private float rotation;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            world = new World(new Vector2(0,0));
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
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

            taxi = Content.Load<Texture2D>("Taxi");
            background = Content.Load<Texture2D>("Background_TEMP");

            // car1 = new AnimatedSprite(taxi, 1, 1,new Vector2(300,200));
            //car2 = new AnimatedSprite(cartex, 4, 3, new Vector2(400, 300));
            //uint[] texData=new uint[cartex.Width*cartex.Height]

            //background
            //const string bgImagePath = "";
            //backgroundTexture = Content.Load<Texture2D>(bgImagePath);

            // TODO: use this.Content to load your game content here

            //car physics

            world.Gravity = new Vector2(0f, 0f);

            /*
            body = new Body(world);

            body.BodyType = BodyType.Dynamic;
    
            body.LinearDamping = 1;
            body.AngularDamping = 1;
            body.Position = ConvertUnits.ToSimUnits(carStartingPos);
            */
            body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(taxi.Width), ConvertUnits.ToSimUnits(taxi.Height), 0.1f);

            body.BodyType= BodyType.Dynamic;
            body.Position = ConvertUnits.ToSimUnits(new Vector2(GraphicsDevice.Viewport.Width/2.0f, GraphicsDevice.Viewport.Height / 2.0f));
            body.LinearDamping = 5;
            body.Friction = 5;
            bodyFixture = FixtureFactory.AttachRectangle(ConvertUnits.ToSimUnits(taxi.Width), ConvertUnits.ToSimUnits(taxi.Height), 0.0f, body.Position, body);

            taxiRect = new Rectangle((int)body.Position.X,(int)body.Position.Y,taxi.Width,taxi.Height);
            directionVec = body.GetWorldVector(new Vector2(0, 1));



            /* leftWheel = BodyFactory.CreateRectangle(world, 1f, 1f, 0f);

             leftWheel.BodyType = BodyType.Dynamic;
             leftWheel.Position = ConvertUnits.ToSimUnits(body.Position)+ new Vector2(-31,23);


             rightWheel = BodyFactory.CreateRectangle(world, 1f, 1f, 0f);

             rightWheel.BodyType = BodyType.Dynamic;
             rightWheel.Position = ConvertUnits.ToSimUnits(body.Position) + new Vector2(31, 23); */


            /*     leftWheel = new Body(world);
                 leftWheel.BodyType = BodyType.Dynamic;
                 leftWheel.Position = ConvertUnits.ToSimUnits(carStartingPos + leftFrontWheelPosition);

                 rightWheel = new Body(world);
                 rightWheel.BodyType = BodyType.Dynamic;
                 rightWheel.Position = ConvertUnits.ToSimUnits(carStartingPos + rightFrontWheelPosition);

                 leftRearWheel = new Body(world);
                 leftRearWheel.BodyType = BodyType.Dynamic;
                 leftRearWheel.Position = ConvertUnits.ToSimUnits(carStartingPos + leftRearWheelPosition);

                 rightRearWheel = new Body(world);
                 rightRearWheel.BodyType = BodyType.Dynamic;
                 rightRearWheel.Position = ConvertUnits.ToSimUnits(carStartingPos + rightRearWheelPosition);


                 //defining shapes

                 PolygonShape box = new PolygonShape(PolygonTools.CreateRectangle(1.5f,2.5f),0f);
                 body.CreateFixture(box);

                 PolygonShape leftWheelShape = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.5f), 0f);
                 body.CreateFixture(leftWheelShape);
                 PolygonShape rightWheelShape = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.5f), 0f);
                 body.CreateFixture(rightWheelShape);
                 PolygonShape leftRareWheelShape = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.5f), 0f);
                 body.CreateFixture(leftRareWheelShape);
                 PolygonShape rightRearWheelShape = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.5f), 0f);
                 body.CreateFixture(rightRearWheelShape);


                 leftJoint = new RevoluteJoint(body, leftWheel, body.GetLocalPoint(leftWheel.Position), Vector2.Zero);
                 leftJoint.MotorEnabled = true;
                 leftJoint.MaxMotorTorque = 100;
                 world.AddJoint(leftJoint);


                 rightJoint = new RevoluteJoint(body, rightWheel, body.GetLocalPoint(rightWheel.Position), Vector2.Zero);
                 rightJoint.MotorEnabled = true;
                 rightJoint.MaxMotorTorque = 100;
                 world.AddJoint(rightJoint);

                 PrismaticJoint leftRearJoint = new PrismaticJoint(body, leftRearWheel, leftRearWheelPosition, Vector2.Zero, new Vector2(1, 0));
                 leftRearJoint.LimitEnabled = true;
                 leftRearJoint.LowerLimit = leftRearJoint.UpperLimit = 0;
                 world.AddJoint(leftRearJoint);
                 PrismaticJoint rightRearJoint = new PrismaticJoint(body, rightRearWheel, rightRearWheelPosition, Vector2.Zero, new Vector2(1, 0));
                 rightRearJoint.LimitEnabled = true;
                 rightRearJoint.LowerLimit = rightRearJoint.UpperLimit = 0;
                 world.AddJoint(rightRearJoint); */


        }
     /*   private void killOrthogonalVelocity(Body body)
        {
            Vector2 localPoint = new Vector2(0, 0);
            Vector2 velocity = body.GetLinearVelocityFromLocalPoint(localPoint);
            Transform tmp;
            this.body.GetTransform(out tmp);
            Vector2 sidewaysAxis = tmp.R.Col2;
            sidewaysAxis = Vector2.Multiply(sidewaysAxis, Vector2.Dot(velocity, sidewaysAxis));
            body.LinearVelocity = sidewaysAxis;

        }*/


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
                handleInput();



            }


         /*   killOrthogonalVelocity(leftWheel);
            killOrthogonalVelocity(rightWheel);
            killOrthogonalVelocity(leftRearWheel);
            killOrthogonalVelocity(rightRearWheel);*/

            //driving
           /* Transform tmp;
            leftWheel.GetTransform(out tmp);
            Vector2 lDirection = tmp.R.Col2 * engineSpeed;
            Transform tmp2;
            leftWheel.GetTransform(out tmp2);
            Vector2 rDirection = tmp2.R.Col2 * engineSpeed;

            leftWheel.ApplyForce(lDirection);
            rightRearWheel.ApplyForce(rDirection);


            //steering
            float mspeed = steeringAngle - leftJoint.JointAngle;
            leftJoint.MotorSpeed = mspeed * SteerSpeed;
            mspeed = steeringAngle - rightJoint.JointAngle;
            rightJoint.MotorSpeed = mspeed * SteerSpeed; */

            // TODO: Add your update logic here
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        private void handleInput()

        {
            Transform tmp;
            body.GetTransform(out tmp);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                //float x = (float)Math.Cos((double)tmp.Angle);
                //float y = (float)Math.Sin((double)tmp.Angle);
                // body.ApplyForce(new Vector2(0, 0.1f), body.WorldCenter);
                /* float x = (float)(taxi.Height * Math.Cos(MathHelper.ToRadians(steeringAngle)));
                 float y = (float)(taxi.Height * Math.Sin(MathHelper.ToRadians(steeringAngle)));
                 Vector2 temp = new Vector2(x, y);
                 temp.Normalize();
                 body.ApplyForce(AngleToVector(body.Rotation),body.WorldCenter); */

                body.ApplyForce(AngleToVector(ConvertUnits.ToDisplayUnits(body.Rotation),"down"), body.WorldCenter);
                /*   if (!direction.Equals("down"))
                   {
                      // direction = "down";


                      // engineSpeed = Horsepower;
                   }
                   //car1.Update(direction);
                   */

                /*   if (direction.Equals("left"))
                       body.ApplyLinearImpulse(new Vector2((taxiRect.Left / 2.0f) * 0.001f, (taxiRect.Top / 2.0f) * 0.001f));
                   if (direction.Equals("right"))
                       body.ApplyLinearImpulse(new Vector2((-taxiRect.Right / 2.0f) * 0.001f, (taxiRect.Right / 2.0f) * 0.001f)); */

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {

                //float x = (float)(taxi.Height * Math.Cos(MathHelper.ToRadians(steeringAngle)));
                //(float)Math.Cos((double)ConvertUnits.ToDisplayUnits(steeringAngle));
                //float y = (float)(taxi.Height * Math.Sin(MathHelper.ToRadians(steeringAngle)));
                //(float)Math.Sin((double)ConvertUnits.ToDisplayUnits(steeringAngle));
                /*  if(direction.Equals("left"))
                  body.ApplyLinearImpulse(new Vector2((-taxiRect.Left/2.0f)*0.001f,(-taxiRect.Top/2.0f)*0.001f));
                  if (direction.Equals("right"))
                      body.ApplyLinearImpulse(new Vector2((taxiRect.Right / 2.0f) * 0.0001f, (-taxiRect.Right / 2.0f) * 0.0001f));
                      */





                //body.ApplyForce(new Vector2(0,-0.2f),body.WorldCenter);
                //body.ApplyLinearImpulse(body.GetWorldVector(new Vector2(0,1)));
                //leftWheel.ApplyForce(new Vector2(0, -10f));
                // rightWheel.ApplyForce(new Vector2(0, -10f));

                //Console.WriteLine(body.Position);

                //engineSpeed = -Horsepower;

                // car1.Update(direction);
                body.ApplyForce(AngleToVector(ConvertUnits.ToDisplayUnits(body.Rotation),"up"), body.WorldCenter);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                body.Rotation -= 0.00025f;
               // steeringAngle -= 0.1f;
                direction = "left";
               

            }
             //   car1.Update(direction);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                // body.ApplyForce(new Vector2(1f, 0), body.WorldCenter);
                body.Rotation += 0.00025f;
                //steeringAngle += 0.1f;
                rotation -= 9f;

                direction = "right";


                //  car1.Update(direction);

            }


            //player 2
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (!direction.Equals("down"))
                {
                    direction = "down";

                }
               // car2.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!direction.Equals("up"))
                {
                    direction = "up";

                }
              //  car2.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (!direction.Equals("left"))
                {
                    direction = "left";

                }
//car2.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (!direction.Equals("right"))
                {
                    direction = "right";

                }
               // car2.Update(direction);

            }
        }

        private Vector2 AngleToVector(float rotation,string dir)
        {   if (dir.Equals("up"))
            {
                Vector2 normalVec = new Vector2((float)Math.Sin(rotation), -(float)Math.Cos(rotation));
                return normalVec;
            }
            else
            {
                Vector2 normalVec = new Vector2(-(float)Math.Sin(rotation), +(float)Math.Cos(rotation));
                return normalVec;
            }

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //        car1.Draw(spriteBatch);
            Vector2 vec = ConvertUnits.ToDisplayUnits(body.Position);
            int x = (int)vec.X;
            int y = (int)vec.Y;
            Vector2 origin = new Vector2(taxi.Width / 2, taxi.Height / 2);


            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(taxi, vec, new Rectangle(0, 0, taxi.Width, taxi.Height), Color.White,ConvertUnits.ToDisplayUnits(body.Rotation),origin,1.0f,SpriteEffects.None,1);
            //car2.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
