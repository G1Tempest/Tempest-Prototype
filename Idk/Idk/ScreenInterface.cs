using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;


using FarseerPhysics.DebugView;
using FarseerPhysics;

namespace Idk
{    
    class ScreenInterface 
    {
        private bool isActive;
        protected SpriteBatch spriteBatch;

        
        public void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }
        public virtual void Update(GameTime gameTime)
        {            

        }
        public virtual void Draw(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, GraphicsDeviceManager graphics, Texture2D firstbackground,SpriteBatch spriteBatch)
        {

        }
        public bool  getActive( )
        {            
            return isActive;
        }

        public void setActive( bool i_screenstate)
        {
            isActive = i_screenstate;
        }    

    }
}
