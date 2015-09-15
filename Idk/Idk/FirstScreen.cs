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
            spriteBatch.End();
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
