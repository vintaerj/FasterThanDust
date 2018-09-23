using System;
using System.Collections.Generic;
using GameJam17.Gameplay.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam17.Personnage
{
    public class Membre : Sprite
    {

        private Dictionary<string, int> competences;
        private string nom;
        private int vie;

        public Membre(Texture2D texture,string nom) : base(texture)
        {
            this.nom = nom;
            vie = 100;
            competences = new Dictionary<string, int>();
        }

        public int getVie()
        {
            return vie;
        }

        public void setVie(int v)
        {
            vie = v;
        }
    }
}