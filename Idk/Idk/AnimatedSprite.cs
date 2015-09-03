using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Idk
{
    public class AnimatedSprite
    {
        Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int LocationX;
        private int LocationY;

        public AnimatedSprite(Texture2D texture,int rows,int cols,Vector2 Location)
        {
            Texture = texture;
            Rows = rows;
            Columns = cols;
            currentFrame = 9;
            totalFrames = Rows * Columns;
            LocationX =(int) Location.X;
            LocationY = (int)Location.Y;

        }
        public void Update(string direction)
        {
            if (direction.Equals("down"))
            {   
                LocationY += 5;
            }
            if (direction.Equals("up"))
            {
                LocationY -= 5;
            }
            if (direction.Equals("left"))
            {
                LocationX -= 5;
            }
            if (direction.Equals("right"))
            {
                LocationX += 5;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(LocationX, LocationY, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
