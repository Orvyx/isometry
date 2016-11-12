using Microsoft.Xna.Framework;

namespace client
{
    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;
        public float MaxAlpha;
        public float MinAlpha;

        public FadeEffect(float fadeSpeed = 1, bool increase = false, float maxAlpha = 1.0f, float minAlpha = 0.0f)
        {
            FadeSpeed = fadeSpeed;
            Increase = increase;
            MaxAlpha = maxAlpha;
            MinAlpha = minAlpha;
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
                if (!Increase)
                    image.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                else
                    image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (image.Alpha < MinAlpha)
                {
                    Increase = true;
                    image.Alpha = MinAlpha;
                }
                else if (image.Alpha > MaxAlpha)
                {
                    Increase = false;
                    image.Alpha = MaxAlpha;
                }
            }
            else
                image.Alpha = MaxAlpha;
        }
    }
}
