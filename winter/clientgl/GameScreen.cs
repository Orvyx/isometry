using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace client
{
    public class GameScreen
    {
        protected ContentManager content;
        public Vector2 Dimensions;

        //[XmlIgnore] //comment out for no xml
        //public Type Type;//comment out for no xml
        public GameScreen()
        {
           //Type = this.GetType();//comment out for no xml
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
            InputManager.Instance.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
