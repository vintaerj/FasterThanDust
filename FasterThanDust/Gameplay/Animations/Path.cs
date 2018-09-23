using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameJam17.Gameplay.Animations
{
    public class Path
    {
        public List<Vector2> Positions { get; set; }
        public bool IsPathing { get; set; }

        public Path(List<Vector2> listes)
        {
            Positions = listes;
            IsPathing = false;
        }
        
        
    }
}