using System;
using GameJam17.Gameplay;
using GameJam17.Gameplay.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FasterThanDust
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Grid grid;
        private AnimationManager animationManager;
        private Animation animation;
        private Texture2D texture;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 552;
            graphics.ApplyChanges();
            string[,] tab = new string[,]
            {
                {"1011","1010","1101","0"   ,"1101"},
                {"1001","1020","0000","1000","0100"},
                {"0011","0010","0010","0010","0110"}

            };
            grid = new Grid(tab);
            
          
            

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
          
          
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("Ressources/Salles/murSprite");
            animation = new Animation(texture,4);
            animationManager = new AnimationManager(animation);
            animationManager.Play(animation);
          
            grid.Load(GraphicsDevice,this.Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            grid.Update(gameTime);
            animationManager.Update(gameTime);
      

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            grid.Draw(spriteBatch,GraphicsDevice);
            animationManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}