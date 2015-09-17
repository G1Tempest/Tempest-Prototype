using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.SamplesFramework;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Audio;

namespace Idk
{
    class Car { public int Front=-1, Left=-1, Right=-1;
        public virtual void setValue() {
        } }
    class BlueCar:Car { /*public int override  Front = 0, Left = 1, Right = 2;*/
            public override void setValue() {
            Front = 0; Left = 1; Right = 2;
        } }
    class WhiteCar : Car { 

        public override void setValue()
        {
            Front = 3; Left = 4; Right = 5;
        }
    }

    class CopCar : Car { /*public int Front = 6, Left = 7, Right = 8; */
        public override void setValue()
        {
            Front = 6; Left = 7; Right = 8;
        }
    }
    class OrangeCar : Car { 

        public override void setValue()
        {
            Front = 9; Left = 10; Right = 11;
        }
    }
    class RedCar : Car { 

        public override void setValue()
        {
            Front = 12; Left = 13; Right = 14;
        }
    }
    class BlackCar : Car { 

        public override void setValue()
        {
            Front = 15; Left = 16; Right = 17;
        }
    }
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
        Texture2D explosionTex;
        int explosionRows;
        int explosionCols;
        int expCurrentFrame;
        int expTotalFrames;
        public int carSelected;
        Car car;
        //  Fixture bodyFixture;

        public AnimatedSprite(Texture2D texture, int rows, int cols, Texture2D explosionTexture,int expRows,int expCols, Vector2 Location,World Realworld,int carSel)
        {
            Tex = texture;
            Rows = rows;
            Columns = cols;
           
            totalFrames = Rows * Columns;
            Position = Location;
            explosionTex = explosionTexture;
            explosionRows = expRows;
            explosionCols = expCols;
            expTotalFrames = expRows * expCols;
            expCurrentFrame = 0;
            //setCar(carSelected);
            //currentFrame = (int)OrangeCar.Front;



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
            player1.Restitution = 3;
            player1.Mass = 3;
            player1.LinearVelocity = Vector2.Zero;
            
        }

        public void setCar(int carSel)
        {

            switch (carSel)
            {
                case 0:
                    BlueCar bc= new BlueCar();
                    car = (BlueCar)bc;
                    car.setValue();
                    break;
                case 1:
                    WhiteCar wc = new WhiteCar();
                    car = (WhiteCar)wc;
                    car.setValue();
                    break;
                case 2:
                    CopCar cc = new CopCar();
                    car = (CopCar)cc;
                    car.setValue();
                    break;
                case 3:
                    OrangeCar oc = new OrangeCar();
                    car = (OrangeCar)oc;
                    car.setValue();
                    break;
                case 4:
                    RedCar rc = new RedCar();
                    car = (RedCar)rc;
                    car.setValue();
                    break;
                case 5:
                    BlackCar blc = new BlackCar();
                    car = (BlackCar)blc;
                    car.setValue();
                    break;
            }
        }

        public void handleInput(int input,String player)

        {
            if (player == "Player2")
            {
                switch (input)
                {
                    case 1:
                        currentFrame = (int)car.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "up"), player1.WorldCenter);
                        break;
                    case 2:
                        currentFrame = (int)car.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "down"), player1.WorldCenter);
                        break;
                    case 3:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation -= 0.050f;
                            currentFrame = (int)car.Left;
                        }
                        break;
                    case 4:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation += 0.050f;
                            currentFrame = (int)car.Right;
                        }
                        break;
                }
            }

            if (player == "Player1")
            {
                switch (input)
                {
                    case 1:
                        currentFrame = (int)car.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "up"), player1.WorldCenter);
                        break;
                    case 2:
                        currentFrame = (int)car.Front;
                        player1.ApplyForce(AngleToVector(player1.Rotation, "down"), player1.WorldCenter);
                        break;
                    case 3:
                        if (player1.LinearVelocity.Length()>0)
                        {
                            player1.Rotation -= 0.050f;
                            
                           
                        }
                        currentFrame = (int)car.Left;
                        break;
                    case 4:
                        if (player1.LinearVelocity.Length() > 0)
                        {
                            player1.Rotation += 0.050f;
                           
                        }
                        currentFrame = (int)car.Right;
                        break;
                }
            }


        }
        private Vector2 AngleToVector(float rotation, string dir)
        {
            if (dir.Equals("up"))
            {
                Vector2 normalVec = new Vector2((float)Math.Sin(rotation)*70f, -(float)Math.Cos(rotation)*70f);
                return normalVec;
            }
            else
            {
                Vector2 normalVec = new Vector2(-(float)Math.Sin(rotation)*70f, (float)Math.Cos(rotation)*70f);
                return normalVec;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Tex.Width / Columns;
            int height = Tex.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            int expWidth = explosionTex.Width / explosionCols;
            int expHeight = explosionTex.Height / explosionRows;
            int expRow= (int)((float)expCurrentFrame / (float)explosionCols);
            int expcolumn = expCurrentFrame % explosionCols;
            if (isNotOnTable())
            {
                Vector2 origin = new Vector2(expWidth / 2, expHeight / 2);

                Rectangle sourceRectangle = new Rectangle(expWidth * expcolumn, expHeight * expRow, expWidth, expHeight);


                spriteBatch.Draw(explosionTex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);
                expCurrentFrame++;
                player1.BodyType = BodyType.Static;

            }
            else
            {

                Vector2 origin = new Vector2(width / 2, height / 2);

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);


                spriteBatch.Draw(Tex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);
            }

        }

        private bool isNotOnTable()
        {
            Vector2 bodyPos = ConvertUnits.ToDisplayUnits(player1.Position);
            if(bodyPos.X<80 || bodyPos.X > 1850)
            {
                return true;
            }
            if (bodyPos.Y < 80 || bodyPos.Y > 1000)
            {
                return true;
            }
            return false;
        }
    }
}

