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
        float timer;
        string direction = "down";
        World world;

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
        float steeringAngle;

        private Body leftWheel;
        private Body rightWheel;
        private Body leftRearWheel;
        private Body rightRearWheel;
        private Body body;
        private RevoluteJoint leftJoint;
        private RevoluteJoint rightJoint;

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

            taxi = Content.Load<Texture2D>("Taxi");
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
            body.LinearDamping = 1;




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
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (!direction.Equals("down"))
                {
                    direction = "down";
                    
                    body.ApplyForce(new Vector2(0,0.1f), body.WorldCenter);
                   // engineSpeed = Horsepower;
                }
                //car1.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (!direction.Equals("up"))
                {
                    body.ApplyForce(new Vector2(0,-0.1f),body.WorldCenter);
                    Console.WriteLine(body.Position);

                    //engineSpeed = -Horsepower;

                }
               // car1.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (!direction.Equals("left"))
                {
                    body.ApplyForce(new Vector2(0, 1), body.WorldCenter);
                    direction = "left";
                    steeringAngle = -MaxSteerAngle;

                }
             //   car1.Update(direction);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (!direction.Equals("right"))
                {
                    steeringAngle = MaxSteerAngle;
                    direction = "right";

                }
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
           

            spriteBatch.Draw(taxi, new Rectangle(x, y, taxi.Width, taxi.Height),Color.White);
            //car2.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
