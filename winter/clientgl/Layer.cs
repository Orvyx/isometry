using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Xml.Serialization;

namespace client
{
    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<String> Row;
            public TileMap()
            {
                Row = new List<String>();
            }
        }
        private Image Image = new Image();
        [XmlElement("TileMap")]
        public TileMap Tile;
        public string Path
        {
            get
            {
                return Image.Path;
            }
            set
            {
                Image.Path = value;
            }
        }
        List<Tile> tiles;
        

        public Layer()
        {
            tiles = new List<Tile>();
        }
        public void LoadContent(Vector2 tileDimensions)
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;
            foreach(string row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimensions.X;
                position.Y += tileDimensions.Y;
                foreach(string s in split)
                {
                    if(s != String.Empty)
                    {
                        position.X += tileDimensions.X;
                        tiles.Add(new Tile());

                        string str = s.Replace("[", String.Empty);
                        int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                        tiles[tiles.Count - 1].LoadContent(position, new Rectangle(value1 * (int)tileDimensions.X, value2 * (int)tileDimensions.Y, (int)tileDimensions.X, (int)tileDimensions.Y));

                    }
                }
            }

        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }
    }
}
