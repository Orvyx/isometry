using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace client
{
    public class GameplayScreen : GameScreen
    {
        Player Player = new Player();
        Map map;
        public override void LoadContent()
        {
            base.LoadContent();
            Player.LoadContent();
            map = content.Load<Map>("TestMap") as Map;

        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            Player.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Player.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }
    }
}
