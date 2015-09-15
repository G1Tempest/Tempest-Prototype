using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idk
{
    class PencilWall
    {
        Texture2D Tex { get; set; }
        public Body Pencil;
        public World world;
        Vector2 PhyPosition;
        Vector2 Loc;
        string PencilWallPos;

        public PencilWall(Texture2D texture, Vector2 Location, World GameWorld,string pos)
        {
               Tex = texture;
            world = GameWorld;
            PhyPosition = ConvertUnits.ToSimUnits(new Vector2(Location.X + (Tex.Width / 2.0f), Location.Y + (Tex.Height / 2.0f)));
            Loc = Location;

            Pencil = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(Tex.Width-10), ConvertUnits.ToSimUnits(Tex.Height-10), 1.0f, PhyPosition);
            Pencil.BodyType = BodyType.Dynamic;
            Pencil.LinearDamping = 10;
            Pencil.AngularDamping = 150;
            Pencil.Friction = 5;
            Pencil.Restitution = -2;
            Pencil.Mass = 10;
            Pencil.FixedRotation = true;
            PencilWallPos = pos;




        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Tex, destinationRectangle, sourceRectangle, Color.White);
            Vector2 boxPos = new Vector2(ConvertUnits.ToDisplayUnits(Pencil.Position.X) - Tex.Width / 2, ConvertUnits.ToDisplayUnits(Pencil.Position.Y) - Tex.Height / 2);

            float x = boxPos.X;

            float y = boxPos.Y;

            if (PencilWallPos == "up")
            {
                if (y + 30 > Loc.Y)
                {
                    spriteBatch.Draw(Tex, boxPos, Color.White);
                    //spriteBatch.Draw(Tex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);
                }
                else
                {
                    Pencil.Dispose();
                }
            }

            if (PencilWallPos == "down")
            {
                if (y - 30 < Loc.Y)
                {
                    spriteBatch.Draw(Tex, boxPos, Color.White);
                }
                else
                {
                    Pencil.Dispose();
                }
            }

            if (PencilWallPos == "left")
            {
                if (x + 30 > Loc.X)
                {
                    spriteBatch.Draw(Tex, boxPos, Color.White);
                }
                else
                {
                    Pencil.Dispose();
                }
            }

            if (PencilWallPos == "right")

            {
                if (x - 30 < Loc.X)
                {
                    spriteBatch.Draw(Tex, boxPos, Color.White);
                }
                else
                {
                    Pencil.Dispose();
                }
            }

            // spriteBatch.Draw(Tex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);

        }//end of draw
    }//end of class
}//end of namespace

