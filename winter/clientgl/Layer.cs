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

        [XmlElement("SolidTiles")]
        public string SolidTiles;

        CollisionState state;

        public string Sheet
        {
            get
            {
                return Image.Path;
            }
            set
            {
                Image.Path = "TileSheet/"+ value;
            }
        }
        List<Tile> tiles;
        

        public Layer()
        {
            tiles = new List<Tile>();
            SolidTiles = String.Empty;
        }
        public void LoadContent(Vector2 tileDimensions)
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;
            position.X = -tileDimensions.X / 2;
            position.Y += tileDimensions.Y / 2;
            Vector2 startingRowPosition = position;
            foreach(string row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = startingRowPosition.X;
                position.Y = startingRowPosition.Y;
                foreach(string s in split)
                {
                    if(s != String.Empty)
                    {
                        position.X += tileDimensions.X / 2;
                        position.Y += tileDimensions.Y / 4;
                        if (!s.Contains("x"))
                        {
                            state = CollisionState.PASSIVE;
                            tiles.Add(new Tile());

                            string str = s.Replace("[", String.Empty);
                            int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                            int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                            if(SolidTiles.Contains("[" + value1.ToString() + ":" + value2.ToString() + "]"))
                            {
                                state = CollisionState.SOLID;
                            }

                            tiles[tiles.Count - 1].LoadContent(position, new Rectangle(value1 * (int)tileDimensions.X, value2 * (int)tileDimensions.Y, (int)tileDimensions.X, (int)tileDimensions.Y), state);
                        }
                    }
                }
                startingRowPosition.X = startingRowPosition.X - (tileDimensions.X / 2);
                startingRowPosition.Y = startingRowPosition.Y + (tileDimensions.Y / 4);
            }

        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }
        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Tile tile in tiles)
                tile.Update(gameTime, ref player);
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
