using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameJam17.Gameplay.Animations
{
    public class Sprite
    {

        private Vector2 Position;

        public AnimationManager AnimationManager { get; set; }

        public Texture2D Texture { get; set; }
        
        public float Speed { get; set; }

        public Tween Tween;

        public bool IsMoving { get; set; }
        
       
        
        public Path Path { get; set; }

     




        public Sprite(Texture2D texture)
        {
            Texture = texture;
            IsMoving = false;
            Tween = new Tween(0,Position,new Vector2(0,0),2);
            Path = new Path(new List<Vector2>());
           
            

        }
        

        public virtual void Load(ContentManager c)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.K))
                launchPath();
            
            Console.WriteLine(Path.IsPathing);
          
           UpdatePath(gameTime);

        }
        
        public virtual void Draw(SpriteBatch sp)
        {
            sp.Draw(Texture,Position,new Rectangle(0,0,Texture.Width,Texture.Height),Color.White);
        }

        public void Move(Vector2 dest)
        {
            
            
         
            if (Tween.IsRunning == false)
            {
                Tween.Reset();
                Tween.Position = Position;
                Tween.Distance = dest;
                Tween.IsRunning = true;
                IsMoving = true;

            }
           

        }

        public void UpdatePath(GameTime gameTime)
        {
            Tween.Update(gameTime);
            Position = Tween.Tweening;
            
            
            
            if (Path != null && Path.IsPathing && Path.Positions.Count != 0)
            {

                if (!IsMoving) // if there is a moving.
                {
                    Move(Path.Positions[0]); // we move it.
                    Path.Positions.RemoveAt(0); // then we remove from the path.
                    
                }
                  
                
            }
            
            
            if (Tween.IsRunning == false)
            {
                IsMoving = false;
            }

            if (Path.Positions.Count == 0)
            {
                Path.IsPathing = false;
            }
     
         }

        public void SetPath(List<Vector2> l)
        {
            Path.Positions = l;
        }

        public void launchPath()
        {
            Path.IsPathing = true;
        }

       

       
        
        
        
        
    }
}