using Microsoft.Xna.Framework.Graphics;

namespace GameJam17.Gameplay.Animations
{
    public class Animation
    {
        
        public int CurrentFrame { get; set; }  
        
        public int FrameCount { get; private set; }
        
        public int FrameHeight
        {
            get { return Texture.Height / FrameCount; }
        }
        
        public float FrameSpeed { get; set; }
        
        public int FrameWidth
        {
            get { return Texture.Width / (FrameCount -1); }
        }
        
        public bool IsLooping { get; set; }
        
        public Texture2D Texture { get; private set; }

        public OrientationSprite Orientation;

        public int Curseur;

        public Animation(Texture2D texture, int frameCount,OrientationSprite orientation,int curseur)
        {
            Texture = texture;

            FrameCount = frameCount;

            CurrentFrame = 0;

            Orientation = orientation;

            Curseur = curseur;

            IsLooping = true;

            FrameSpeed = 0.2f;


        }
        
        
        
    }
}