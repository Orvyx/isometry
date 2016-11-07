using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;//comment out for no xml
using System;

namespace client
{
    public class GameScreen
    {
        protected ContentManager content;
        public Vector2 Dimensions;

        [XmlIgnore] //comment out for no xml
        public Type Type;//comment out for no xml
        public GameScreen()
        {
           Type = this.GetType();//comment out for no xml
        }
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
