using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.SamplesFramework;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;

namespace Idk
{
    enum BlueCar{Front=0,Left=1,Right=2 };
    enum WhiteCar { Front = 3, Left = 4, Right = 5 };
  //  enum CopCar { Front = 6, Left = 7, Right = 8 };
    enum OrangeCar { Front = 9, Left = 10, Right = 11 };
    enum RedCar { Front = 12, Left = 13, Right = 14 };
    enum BlackCar { Front = 15, Left = 16, Right = 17 };
    public class AnimatedSprite
    {
        Texture2D Tex { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 Position;
       public  Body player1;
       public  World world;
      //  Fixture bodyFixture;

        public AnimatedSprite(Texture2D texture, int rows, int cols, Vector2 Location,World Realworld)
        {
            Tex = texture;
            Rows = rows;
            Columns = cols;
            currentFrame = (int)OrangeCar.Front;
            totalFrames = Rows * Columns;
            Position = Location;



            this.world = Realworld;



            int width = Tex.Width / Columns;
            int height = Tex.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            player1 = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits((float)sourceRectangle.Width), ConvertUnits.ToSimUnits((float) sourceRectangle.Height), 0.1f,ConvertUnits.ToSimUnits(Position));   // ConvertUnits.ToSimUnits((float)texture.Width / (float)cols), ConvertUnits.ToSimUnits((float)texture.Height / (float)rows)

            player1.BodyType = BodyType.Dynamic;
            player1.LinearDamping = 5;
            player1.AngularDamping = 150;
            player1.Friction = 5;
            player1.Restitution = 2;
            player1.Mass = 3;
            player1.LinearVelocity = Vector2.Zero;
            player1.OnCollision += MyOnCollision;
        }

        private bool MyOnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            
            return true;
        }

        public void handleInput(int input,String player)

        {
            if (player == "Player2")
            {
                switch (input)
                {
                    case 1:
                        currentFrame = (int)OrangeCar.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "up"), player1.WorldCenter);
                        break;
                    case 2:
                        currentFrame = (int)OrangeCar.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "down"), player1.WorldCenter);
                        break;
                    case 3:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation -= 0.050f;
                            currentFrame = (int)OrangeCar.Left;
                        }
                        break;
                    case 4:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation += 0.050f;
                            currentFrame = (int)OrangeCar.Right;
                        }
                        break;
                }
            }

            if (player == "Player1")
            {
                switch (input)
                {
                    case 1:
                        currentFrame = (int)RedCar.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "up"), player1.WorldCenter);
                        break;
                    case 2:
                        currentFrame = (int)RedCar.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "down"), player1.WorldCenter);
                        break;
                    case 3:
                        if (player1.LinearVelocity.Length()>0)
                        {
                            player1.Rotation -= 0.050f;
                            
                           
                        }
                        currentFrame = (int)RedCar.Left;
                        break;
                    case 4:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation += 0.050f;
                           
                        }
                        currentFrame = (int)RedCar.Right;
                        break;
                }
            }


        }
        private Vector2 AngleToVector(float rotation, string dir)
        {
            if (dir.Equals("up"))
            {
                Vector2 normalVec = new Vector2((float)Math.Sin(rotation)*75f, -(float)Math.Cos(rotation)*75f);
                return normalVec;
            }
            else
            {
                Vector2 normalVec = new Vector2(-(float)Math.Sin(rotation)*75f, (float)Math.Cos(rotation)*75f);
                return normalVec;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Tex.Width / Columns;
            int height = Tex.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
           // Vector2 vec = new Vector2(LocationX, LocationY);
                //ConvertUnits.ToDisplayUnits(player1.Position);
            Vector2 origin = new Vector2(width / 2, height / 2);

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            //spriteBatch.Draw(Tex, destinationRectangle, sourceRectangle, Color.White);

           // spriteBatch.Draw(Tex, ConvertUnits.ToDisplayUnits(player1.Position), Color.White);

            spriteBatch.Draw(Tex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);

        }
    }
}

