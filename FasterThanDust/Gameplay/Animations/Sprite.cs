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

        public Vector2 Position { get; set; }

        public AnimationManager AnimationManager { get; set; }

        public Texture2D Texture { get; set; }
        
        protected float Speed { get; set; }

        public Tween Tween;

        public bool IsMoving { get; set; }
        
       
        
        public Path Path { get; set; }

     




        public Sprite(Texture2D texture)
        {
           
            Texture = texture;
            IsMoving = false;
            Tween = new Tween(0,Position,new Vector2(0,0),1);
            Path = new Path(new List<Vector2>());
          
           
            

        }
        

        public virtual void Load(ContentManager c)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.K))
            {
                launchPath();
                Console.WriteLine("K");
            }
               
            
          
          
           UpdatePath(gameTime);

        }
        
        public virtual void Draw(SpriteBatch sp)
        {
            sp.Draw(Texture,Position,new Rectangle(0,0,Texture.Width,Texture.Height),Color.Green);
        }

        public void Move(Vector2 dest)
        {
            
            
         
            if (Tween.IsRunning == false)
            {
                Tween.Reset();
                Tween.Position = Position;
                Vector2 dist = new Vector2(Math.Abs(Position.X - dest.X),Math.Abs(Position.Y - dest.Y));
                Tween.Distance = dist;
                Tween.IsRunning = true;
                IsMoving = true;

            }
           

        }

        public virtual void UpdatePath(GameTime gameTime)
        {
            Tween.Update(gameTime);
            if (IsMoving)
            {
                Position = Tween.Tweening;
            }
          
            
            
            
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

        public virtual void SetPath(List<Vector2> l)
        {
            Path.Positions = l;
        }

        public void launchPath()
        {
            foreach (var p in Path.Positions)
            {
                Console.WriteLine(p);
            }
            Path.IsPathing = true;
        }

       

       
        
        
        
        
    }
}