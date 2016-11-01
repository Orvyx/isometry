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
        Texture2D texture;
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
            height = (808 / 1216) * width;
            yPos = (int)((ScreenManager.Instance.Dimensions.Y - height) / 2);
            texture = content.Load<Texture2D>("splashLogo");
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
            spriteBatch.Draw(texture, 
                new Rectangle ((int)(ScreenManager.Instance.Dimensions.X/ divisor), 
                    (int)(ScreenManager.Instance.Dimensions.Y / divisor), 
                    (int)(ScreenManager.Instance.Dimensions.X-ScreenManager.Instance.Dimensions.X / divisor * 2), 
                    (int)(ScreenManager.Instance.Dimensions.Y-ScreenManager.Instance.Dimensions.Y / divisor * 2)), 
                Color.White);
        }
    }
}
