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

        public PencilWall(Texture2D texture, Vector2 Location, World GameWorld)
        {
            Tex = texture;
            world = GameWorld;
            PhyPosition = ConvertUnits.ToSimUnits(new Vector2(Location.X + (Tex.Width / 2.0f), Location.Y + (Tex.Height / 2.0f)));
            Loc = Location;

            Pencil = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(Tex.Width-10), ConvertUnits.ToSimUnits(Tex.Height-10), 10.0f, PhyPosition);
            //BoxBody.BodyType = BodyType.Static;




        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Tex, destinationRectangle, sourceRectangle, Color.White);
            Vector2 boxPos = new Vector2(ConvertUnits.ToDisplayUnits(Pencil.Position.X) - Tex.Width / 2, ConvertUnits.ToDisplayUnits(Pencil.Position.Y) - Tex.Height / 2);

            spriteBatch.Draw(Tex, Loc, Color.White);

            // spriteBatch.Draw(Tex, Position, sourceRectangle, Color.White, player1.Rotation, origin, 1.0f, SpriteEffects.None, 1);

        }
    }
}
