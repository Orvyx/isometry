using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace client
{
    public class Player
    {
        public Image Image = new Image();
        public Vector2 Velocity = new Vector2(0,0);
        public float MoveSpeed = 1000.0f;
        public Vector2 prevPosition;

        public Player()
        {
            Velocity = Vector2.Zero;
        }
        public void LoadContent()
        {
            Image.Path = "Player_Example";
            Image.Effects = "SpriteSheetEffect";
            Image.Position = new Vector2(20, 20);
            Image.LoadContent();
        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            Image.IsActive = true;
            //if (Velocity.X == 0)
            //{
                if (InputManager.Instance.KeyDown(Keys.S) && InputManager.Instance.KeyDown(Keys.W))
                    Velocity.Y = 0;
                else if (InputManager.Instance.KeyDown(Keys.S))
                {
                    Velocity.Y = (MoveSpeed / 2) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 0;
                }
                else if (InputManager.Instance.KeyDown(Keys.W))
                {
                    Velocity.Y = -(MoveSpeed / 2) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 3;
                }
                else
                    Velocity.Y = 0;
            //}
            
            //if(Velocity.Y == 0)
            //{
                if (InputManager.Instance.KeyDown(Keys.A) && InputManager.Instance.KeyDown(Keys.D))
                    Velocity.X = 0;
                else if (InputManager.Instance.KeyDown(Keys.A))
                {
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                }
                else if (InputManager.Instance.KeyDown(Keys.D))
                {
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 2;
                }
                else
                    Velocity.X = 0;
            //}

            if (Velocity.X == 0 && Velocity.Y == 0)
                Image.IsActive = false;
            Image.Update(gameTime);
            prevPosition = Image.Position;
            Image.Position += Velocity;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
