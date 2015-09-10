using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Media;

namespace Idk
{
    
    class FirstScreen : ScreenInterface 
    {
        SpriteFont Font;
     public   FirstScreen(Song MenuSong,SpriteFont font)
        {
            MediaPlayer.Play(MenuSong);
            MediaPlayer.IsRepeating = true;
            Font = font;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics,Texture2D firstbackground,SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            
            spriteBatch.Draw(firstbackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(Font, "Player1:W,A,S,D to Move", new Vector2(75, 100), Color.Black);
            spriteBatch.DrawString(Font, "Player2:Arrow Keys to Move", new Vector2(1100, 100), Color.Black);
            spriteBatch.DrawString(Font, "Press Enter To Start", new Vector2(800, 540), Color.Black);
            spriteBatch.End();
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
