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
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            map = mapLoader.Load("Content/TestMap.xml");
            map.LoadContent();
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            Player.UnloadContent();
            map.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Player.Update(gameTime);
            map.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            map.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }
    }
}
