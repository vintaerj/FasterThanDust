using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam17.Gameplay
{
    public class HUD
    {

        public HUD()
        {
            
        }
        
        // a l'aide !!
        private void afficherEquipe(){
            Color data = new Color[300 * 150];
            Texture2D rectTexture = new Texture2D(GraphicsDevice, 300, 150);

            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.White;
            }

            rectTexture.SetData(data);
            var position = new Vector2(rectangle.Left, rectangle.Top);

            spriteBatch.Draw(rectTexture, new Vector2(), Color.White);
        }
    }
    
}