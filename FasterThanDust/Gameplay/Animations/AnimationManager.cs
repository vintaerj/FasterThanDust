using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam17.Gameplay.Animations
{
    public class AnimationManager
    {

        private Animation _animation;

        public int BeginFrame ;

        private bool play = false;

        private float _timer;
        
        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation,Vector2 pos)
        {
            _animation = animation;
            Position = pos;
            BeginFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int x = 0;
            int y = 0;
            int curseur = _animation.Curseur;
            if (_animation.Orientation.Equals(OrientationSprite.Horizontale))
            {
                x = _animation.CurrentFrame * _animation.FrameWidth;
                y = curseur * _animation.FrameHeight;
            }else if (_animation.Orientation.Equals(OrientationSprite.Verticale))
            {
                x = curseur * _animation.FrameWidth ;
                y =  _animation.CurrentFrame * _animation.FrameHeight;
            }
                
            
          

            spriteBatch.Draw(_animation.Texture,
                Position,
                new Rectangle(x,
                    y,
                    _animation.FrameWidth ,
                    _animation.FrameHeight



                ),
                Color.White);






        }

        public void Play(Animation animation)
        {
            play = true;
            if (_animation == animation)
            {
                return;
            }

            _animation = animation;

            _animation.CurrentFrame = BeginFrame;

            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0;
            _animation.CurrentFrame = BeginFrame;
        }

        public void Update(GameTime gameTime)
        {

            if (play)
            {
                _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

                if (_timer > _animation.FrameSpeed)
                {
                    _timer = 0f;

                    _animation.CurrentFrame++;

                    if (_animation.CurrentFrame >= _animation.FrameCount)
                    {
                        if (!_animation.IsLooping)
                        {
                            play = false;
                        }
                        _animation.CurrentFrame = BeginFrame;
                    }

                } 
            }
          
            
            
            
        }


    }
}