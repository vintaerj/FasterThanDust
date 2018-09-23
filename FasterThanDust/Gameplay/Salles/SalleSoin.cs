using System.Threading;

namespace GameJam17.Gameplay.Salles
{
    public class SalleSoin : Salle
    {
        private int regenPerSecond;
        
        public SalleSoin(int taille) : base(taille)
        {
            regenPerSecond = 5;
        }


        public int getRegenPerSecond()
        {
            return regenPerSecond;
        }


        public override void upgrade()
        {
            regenPerSecond += 5;
        }

        public void regenMember()
        {
            Thread threadRegen = new Thread(new ThreadStart(threadRegenMembre));
            threadRegen.Start();
        }

        private void threadRegenMembre()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                foreach (var m in lesMembres)
                {
                    m.setVie(m.getVie() + regenPerSecond);
                }
                Thread.Sleep(1000);
                if(!isActif()) return;
            }
        }
    }
}