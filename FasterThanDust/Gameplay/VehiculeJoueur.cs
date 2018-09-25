using System.Collections.Generic;
using GameJam17.Personnage;

namespace GameJam17.Gameplay
{
    public class VehiculeJoueur
    {

        private Grid map;
        private string nom;
        private List<Membre> equipe;
        private int pv;

        VehiculeJoueur()
        {
            equipe = new List<Membre>();
        }

        public List<Membre> getEquipe()
        {
            return equipe;
        }

    }
}