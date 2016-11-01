using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace client
{
    class SplashScreen : GameScreen
    {
        Texture2D splash;
        Texture2D splashBackground;
        private int divisor = 5; // DIVISOR MUST BE > 2!!!
        int xPos;
        int yPos;
        int width;
        int height;
        public override void LoadContent()
        {
            base.LoadContent();
            xPos = (int)(ScreenManager.Instance.Dimensions.X / divisor);
            width = (int)(ScreenManager.Instance.Dimensions.X - ScreenManager.Instance.Dimensions.X / divisor * 2);
            height = (int)((808f/1216f) * width);
            yPos = (int)((ScreenManager.Instance.Dimensions.Y - height) / 2);
            splash = content.Load<Texture2D>("splashLogo");
            splashBackground = content.Load<Texture2D>("splashBackground");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(splashBackground, new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y), Color.White);
            spriteBatch.Draw(splash, new Rectangle (xPos, yPos, width, height), Color.White);
        }
    }
}
