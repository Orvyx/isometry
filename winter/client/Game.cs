using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
namespace client
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsFixedTimeStep = true; //TURNS OFF CAPPED FRAMES
            this.graphics.SynchronizeWithVerticalRetrace = false; //VSYNC

            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;

            this.Window.Title = "winter";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ScreenManager.Instance.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            ScreenManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}