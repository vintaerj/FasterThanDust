using System;
using Microsoft.Xna.Framework;

namespace GameJam17.Gameplay.Animations
{
    public class Tween
    {

      
        public Vector2 Position { get; set;}

        public float Time { get; set; }

        public float Duration { get; set; }

        public Vector2 Distance { get; set; }

        public Vector2 Tweening;

        public bool IsRunning { get; set; }




        public Tween(float time,Vector2 position,Vector2 distance, float duration)
        {
            Time = time;
            Position = position;
            Distance = distance;
            Duration = duration;
            Tweening = position;
            IsRunning = false;



        }

        public virtual void Update(GameTime gameTime)
        {

            if(IsRunning){

                if (Time < Duration)
                {
                    Time += (float) gameTime.ElapsedGameTime.TotalSeconds;
                    Tweening.X = EaseInSin(Time, Position.X, Distance.X, Duration);
                    Tweening.Y = EaseInSin(Time, Position.Y, Distance.Y, Duration);

                }
                else
                {
                    IsRunning = false;
                }
                
            }
               


        }

        public void Reset()
        {
            Time = 0;
            IsRunning = true;
        }

      

        public static float EaseInSin(float time,float value,float distance,float duration)
        {
            
            return -distance * (float)Math.Cos(time / duration * (Math.PI / 2)) + distance + value;
        }
        
      




    }
}