using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace client
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
       // public XmlManager<GameScreen> xmlManager;//comment out for no xml
        GameScreen currentScreen, newScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;
        public Image Fade;
        public bool IsTransitioning { get; private set; }
        public bool Quit = false;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                    instance.Fade = new Image();
                    instance.Fade.Path = "Fade";
                    instance.Fade.Scale = new Vector2(Instance.Dimensions.X, Instance.Dimensions.Y);
                }
                return instance;
            }
        }
        public void ChangeScreen(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("client." + screenName));
            Fade.LoadContent();
            Fade.IsActive = true;
            //.Effects = "FadeEffect";
            Fade.FadeEffect.Increase = true;
            Fade.Alpha = 0.01f;
            IsTransitioning = true;
        }
        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Fade.Update(gameTime);
                if(Fade.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    currentScreen.LoadContent();
                }
                else if(Fade.Alpha == 0.0f)
                {
                    Fade.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }
        public ScreenManager()
        {
            Dimensions = new Vector2(1200, 675);
            currentScreen = new SplashScreen(); ///SETS THE STARTING SCREEN. SplashScreen IS DEFAULT. CHANGE TO OTHERS FOR TESTING.

        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
            if (Quit)
            {
                currentScreen.UnloadContent();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
                Fade.Draw(spriteBatch);
        }
    }
}
