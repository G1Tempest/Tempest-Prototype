using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Media;

namespace Idk
{
    
    class EndScreen : ScreenInterface 
    {
        SpriteFont Font;
     public   EndScreen()
        {
            //MediaPlayer.Play(MenuSong);
            //MediaPlayer.IsRepeating = true;
            //Font = font;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics,Texture2D firstbackground,SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            
            spriteBatch.Draw(firstbackground, new Rectangle(450 , 00 , firstbackground.Width,firstbackground.Height), Color.White);
            spriteBatch.End(); 
            //graphics.PreferredBackBufferWidth / 4 + 240, graphics.PreferredBackBufferHeight / 4, graphics.PreferredBackBufferHeight / 2, graphics.PreferredBackBufferHeight / 2
            //spriteBatch.DrawString(Font, "Player1:W,A,S,D to Move", new Vector2(75, 100), Color.Black);
            //spriteBatch.DrawString(Font, "Player2:Arrow Keys to Move", new Vector2(1100, 100), Color.Black);
            //spriteBatch.DrawString(Font, "Press Enter To Start", new Vector2(800, 540), Color.Black);
            //spriteBatch.End();
            //spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
