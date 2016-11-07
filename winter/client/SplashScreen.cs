using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace client
{
    public class SplashScreen : GameScreen
    {
        public Image Splash = new Image();
        public string Path;
        public override void LoadContent()
        {
            Splash.Path = "splashLogo";
            Splash.Scale = new Vector2(ScreenManager.Instance.Dimensions.X / 2000, ScreenManager.Instance.Dimensions.X / 2000);
            Splash.Position = new Vector2(ScreenManager.Instance.Dimensions.X / 2, ScreenManager.Instance.Dimensions.Y / 2);
            Splash.Effects = "FadeEffect";
            base.LoadContent();
            Splash.LoadContent();
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            Splash.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Splash.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Instance.GraphicsDevice.Clear(new Color(44,44,44));
            Splash.Draw(spriteBatch);
        }
    }
}
