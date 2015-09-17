using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Media;

namespace Idk
{

    class SecondScreen : ScreenInterface
    {
        SpriteFont Font;
        int box1OriginX = 118,
            box1OriginY = 223,
            spriteHeight = 281,
            spriteWidth = 281,
            boxHeight = 317,
            boxWidth = 318,
            box2OriginX = 1482,
            box2OriginY = 223;




        public SecondScreen(Song MenuSong, SpriteFont font)
        {
            MediaPlayer.Play(MenuSong);
            MediaPlayer.IsRepeating = true;
            Font = font;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics, Texture2D firstbackground, SpriteBatch spriteBatch,Texture2D CarP1, Texture2D CarP2,int selectP1, int selectP2)
        {

            int carOri1X = 0;
            int carOri1Y = 0;
            int carOri2X = 0;
            int carOri2Y = 0;
            int barrierWidth = 4; 
            spriteBatch.Begin();

            spriteBatch.Draw(firstbackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            switch (selectP1)
            {
                case 0:
                    carOri1X = 0;
                    carOri1Y = 0;
                    break;
                case 1:
                    carOri1X = spriteWidth;
                    carOri1Y = 0;
                    break;
                case 2:
                    carOri1X = 0;
                    carOri1Y = spriteHeight + barrierWidth;
                    break;
                case 3:
                    carOri1X = spriteWidth + barrierWidth;
                    carOri1Y = spriteHeight + barrierWidth;
                    break;
                case 4:
                    carOri1X = 0;
                    carOri1Y = 2 * spriteHeight + barrierWidth;
                    break;
                case 5:
                    carOri1X = spriteWidth + barrierWidth;
                    carOri1Y = 2 * spriteHeight + barrierWidth;
                    break;
            }
            spriteBatch.Draw(CarP1, new Rectangle(box1OriginX, box1OriginY, boxWidth, boxHeight),new Rectangle(carOri1X, carOri1Y, spriteWidth,spriteHeight), Color.White);

            switch (selectP2)
            {
                case 0:
                    carOri2X = 0;
                    carOri2Y = 0;
                    break;
                case 1:
                    carOri2X = spriteWidth;
                    carOri2Y = 0;
                    break;
                case 2:
                    carOri2X = 0;
                    carOri2Y = spriteHeight + barrierWidth;
                    break;
                case 3:
                    carOri2X = spriteWidth + barrierWidth;
                    carOri2Y = spriteHeight + barrierWidth;
                    break;
                case 4:
                    carOri2X = 0;
                    carOri2Y = 2 * spriteHeight + barrierWidth;
                    break;
                case 5:
                    carOri2X = spriteWidth + barrierWidth;
                    carOri2Y = 2 * spriteHeight + barrierWidth;
                    break;
            }
            spriteBatch.Draw(CarP2, new Rectangle(box2OriginX, box2OriginY, boxWidth, boxHeight), new Rectangle(carOri2X, carOri2Y, spriteWidth, spriteHeight), Color.White);
            //spriteBatch.DrawString(Font, "Player1:W,A,S,D to Move", new Vector2(75, 100), Color.Black);
            //spriteBatch.DrawString(Font, "Player2:Arrow Keys to Move", new Vector2(1100, 100), Color.Black);
            //spriteBatch.DrawString(Font, "Press Enter To Start", new Vector2(800, 540), Color.Black);
            spriteBatch.End();
            //spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
