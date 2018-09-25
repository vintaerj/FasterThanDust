using System.Collections.Generic;
using GameJam17.Personnage;

namespace GameJam17.Gameplay.Salles
{
    public abstract class Salle
    {
        protected int niveau;
        protected int taille;
        protected List<Membre> lesMembres;
        

        public Salle(int taille)
        {
            this.taille = taille;
            lesMembres = new List<Membre>();
        }

        public abstract void upgrade();

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