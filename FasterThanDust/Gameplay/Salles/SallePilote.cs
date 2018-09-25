namespace GameJam17.Gameplay.Salles
{
    public class SallePilote : Salle
    {

        private int esquive; //pourcentage d'esquive lors d'attaque
        
        public SallePilote(int taille) : base(taille)
        {
            esquive = 10;
        }

        public override void upgrade()
        {
            niveau += 1;
            esquive += 10;
        }
    }
}