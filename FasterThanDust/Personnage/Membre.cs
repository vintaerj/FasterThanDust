using System;
using System.Collections.Generic;

namespace GameJam17.Personnage
{
    public class Membre
    {

        private Dictionary<string, int> competences;
        private string nom;
        private int vie;

        public Membre(string nom)
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