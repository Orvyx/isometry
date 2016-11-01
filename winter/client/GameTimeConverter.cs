using Microsoft.Xna.Framework;

namespace client
{
    public class GameTimeConverter
    {
        GameTime gameTime;
        public GameTimeConverter(GameTime gt)
        {
            gameTime = gt;
        }
        public int Int(int i)
        {
            return i * (int)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public double Double(double d)
        {
            return d * gameTime.ElapsedGameTime.TotalSeconds;
        }
        public float Float(float f)
        {
            return f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
