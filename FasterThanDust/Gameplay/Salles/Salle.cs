using System.Collections.Generic;
using GameJam17.Personnage;

namespace GameJam17.Gameplay.Salles
{
    public abstract class Salle
    {
        private int taille;
        protected List<Membre> lesMembres;
        

        public Salle(int taille)
        {
            this.taille = taille;
            lesMembres = new List<Membre>();
        }

        abstract public void upgrade();

        public void addMembre(Membre m)
        {
            lesMembres.Add(m);
        }

        public void removeMembre(Membre m)
        {
            lesMembres.Remove(m);
        }

        public bool isActif()
        {
            return lesMembres.Count > 0;
        }
    }
}