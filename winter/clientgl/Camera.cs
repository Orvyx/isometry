using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace client
{
    class Camera
    {
        private static Camera instance;
        public Matrix Transform;
        public Vector2 Position;
        public float Rotation;
        private float zoom;
        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; if (zoom <= 0.0f) zoom = 0.1f; }
        }
        public Camera()
        {
            zoom = 1.0f;
            Rotation = 0.0f;
            Position = Vector2.Zero;
        }
        public void Move(Vector2 amount)
        {
            Position += amount;
        }
        public Matrix GetTransformation()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) 
                * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) 
                * Matrix.CreateTranslation(new Vector3(ScreenManager.Instance.Dimensions.X * 0.5f, ScreenManager.Instance.Dimensions.Y * 0.5f, 0));
            return Transform;
        }
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera();
                }
                return instance;
            }
        }
    }
}
