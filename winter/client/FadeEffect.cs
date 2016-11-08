using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace client
{
    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;
        public FadeEffect(float fadeSpeed = 1, bool increase = false)
        {
            FadeSpeed = fadeSpeed;
            Increase = increase;
        }
        public override void LoadContent(ref Image image)
        {
            base.LoadContent(ref image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.image.IsActive)
            {
                System.Diagnostics.Debug.WriteLine("HERE");
                if (!Increase)
                    image.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                else
                    image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (image.Alpha < 0.0f)
                {
                    Increase = true;
                    image.Alpha = 0.0f;
                }
                else if (image.Alpha > 1.0f)
                {
                    Increase = false;
                    image.Alpha = 1.0f;
                }
            }
            else
                image.Alpha = 1.0f;
        }
    }
}
