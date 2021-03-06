using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework.Graphics;

namespace AlgoStar.Boost
{
    public class Graph
    {
        
        public List<Noeud> ListNoeuds { get; set; }

        public Graph()
        {
            ListNoeuds = new List<Noeud>();
   
        }

        public Noeud getNoeud(Vector2 pos)
        {

            foreach (Noeud noeud in ListNoeuds)
            {
                if (noeud.Position.Y == pos.Y && noeud.Position.X == pos.X)
                {
                    return noeud;
                }
            }

            return null;

        }

        public Noeud getNoeud(int indice)
        {
            foreach (Noeud noeud in ListNoeuds)
            {
                if (noeud.Indice == indice)
                {
                    return noeud;
                }
            }

            return null;
        }


        private static Graph InitTab(int[,] tab)
        {
            Graph g = new Graph();
            int indice = 1;
            for (int line = 0; line < tab.GetLength(0) ; line++)
            {
                for (int column = 0; column< tab.GetLength(1); column++)
                {
                    // Creation du noeud
                    Noeud noeud = new Noeud(new Vector2(column,line));
                    noeud.Obstacle = tab[line, column];

                    if (tab[line, column] == 0)
                    {
                        g.ListNoeuds.Add(noeud);
                        noeud.Indice = indice;
                        indice++;
                    }
                        
           
                }
            }


          
         

            return g;
        }

        public static  Graph  InitTab(string[,] tab)
        {
            Graph graph = new Graph();
            int indice = 1;
            for (int line = 0; line < tab.GetLength(0) ; line++)
            {
                for (int column = 0; column< tab.GetLength(1); column++)
                {
                        
                    if (tab[line, column].Length > 1)
                    {
                        Noeud n = new Noeud(new Vector2(column, line));
                        n.Indice = indice++;
                        n.Obstacle = 0;
                        graph.ListNoeuds.Add(n);
                        
                    }
                       
                    
           
                }
            }

            return graph;
        }

        public static  Graph TabToGraph(string[,] tab)
        {
            
            Graph graph = InitTab(tab);
        
            for (int line = 0; line < tab.GetLength(0) ; line++)
            {
                for (int column = 0; column< tab.GetLength(1); column++)
                {
                    char[] id = convertId(tab[line, column]);
                    Noeud noeudCourant = graph.getNoeud(new Vector2(column,line));
                    
                    
                 
                  
                    if (id.Length > 1 && noeudCourant != null ) // je vérifie que l'id est bien composé et non un seul 0 .
                    {
                        
                       
                
                        if (id[0] == '0' || id[0] == '2'  )// haut
                        {
                            Noeud noeudTeste = graph.getNoeud(new Vector2( column,line - 1));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }
                        if (id[1] == '0' || id[1] == '2') // droite
                        {
                            Noeud noeudTeste = graph.getNoeud(new Vector2(column+1,line));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }
                        if (id[2] == '0' || id[2] == '2') // bas
                        {
                          
                            Noeud noeudTeste = graph.getNoeud(new Vector2(column,line+1));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }
                        
                        if (id[3] == '0' || id[3] == '2') // Gauche
                        {
                            Noeud noeudTeste = graph.getNoeud(new Vector2(column-1,line));
                           
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }
                        
                    }
                   
                   
                   
                    
           
                }
            }

            return graph;
        }

        public static char[] convertId(string s)
        {
            
   
            char[] id = s.ToCharArray(0,s.Length);
            
            if (s.Length == 4 || s.Length == 1)
                return id;
            else
                return new char[0];
            
          

        }


        public static Graph TabToGraph(int[,] tab)
        {
            Graph g = InitTab(tab);
            
            Noeud noeudTeste = null;
          
      
            for (int line = 0; line < tab.GetLength(0) ; line++)
            {
                for (int column = 0; column< tab.GetLength(1); column++)
                {

                    Noeud noeudCourant  = g.getNoeud(new Vector2(column,line));
                    if (noeudCourant != null)
                    {
                        if (line > 0) // we check up
                        {
                            
                            noeudTeste = g.getNoeud(new Vector2(column,line-1));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }

                        if (line < tab.GetLength(0)-1) // we check down
                        {
                           
                            noeudTeste = g.getNoeud(new Vector2(column,line + 1));
                           
                         
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        
                        }

                        if (column > 0) // we check left
                        {
                      
                            noeudTeste = g.getNoeud(new Vector2(column-1,line));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }

                        if (column < tab.GetLength(1) - 1) // we check right
                        {
                            
                            noeudTeste = g.getNoeud(new Vector2(column+1,line));
                            if(noeudTeste != null)
                                noeudCourant.ListNoeudAdjacents.Add(noeudTeste);
                        }


                    }
                  
    

                }
            }


            return g;
        }


        public List<Noeud> bestFirstSearch(Noeud pNoeudInitiale)
        {

            Noeud noeudInitiale = pNoeudInitiale;
            Noeud noeudCourant = null;
            List<Noeud> solutions = new List<Noeud>();
            List<Noeud> listeMarque = new List<Noeud>();
            listeMarque.Add(pNoeudInitiale);
            
            
            
            
            while (listeMarque.Count != 0)
            {
                noeudCourant = listeMarque[0];
                listeMarque.Remove(noeudCourant);
                solutions.Add(noeudCourant);
               
                foreach (Noeud n in noeudCourant.ListNoeudAdjacents)
                {
                    if (!solutions.Contains(n) && !listeMarque.Contains(n)) // pas étudié
                    {
                        
                        listeMarque.Add(n); // marquage
                    }
                    
                }
               
            }

            return solutions;
            

        }

        public List<Noeud> algoAStar(Noeud noeudDepart,Noeud noeudDestination)
        {

            List<Noeud> listeOuverte = new List<Noeud>();
            List<Noeud> listeFerme = new List<Noeud>();
            Noeud noeudCourant = noeudDepart;
            listeOuverte.Add(noeudDepart);

            while (listeOuverte.Count != 0 ) // tant que la liste n'est pas vide et que le noeud de depart n'est pas égale au noeud de destination
            {
               
                noeudCourant = Maths.bestNoeud(listeOuverte); // recherche du meilleur noeud
                
                listeFerme.Add(noeudCourant); // ajout du meilleur noeud dans la liste ferme
                listeOuverte.Remove(noeudCourant);  // suppresion du meilleur noeud dans la liste ouverte
                if (noeudCourant.Equals(noeudDestination))
                {
                    return listeFerme;
                }

                foreach (var noeudVoisin in noeudCourant.ListNoeudAdjacents)
                {
                  
                    
                    if (!listeFerme.Contains(noeudVoisin))
                    {
                        noeudVoisin.CoutG = Maths.distance(noeudDepart.Position, noeudVoisin.Position);
                        noeudVoisin.CoutH = Maths.distance(noeudVoisin.Position, noeudDestination.Position);
                        noeudVoisin.CoutF = noeudVoisin.CoutG + noeudVoisin.CoutH;
                        if (listeOuverte.Contains(noeudVoisin))
                        {
                            int idx = listeOuverte.IndexOf(noeudVoisin);
                            if (noeudVoisin.CoutF < listeOuverte[idx].CoutF)
                            {
                                listeOuverte[idx].Parent = noeudCourant;
                                listeOuverte[idx].CoutF = noeudVoisin.CoutF;
                            
                            }
                        }
                        else
                        {
                            noeudVoisin.Parent = noeudCourant;
                            listeOuverte.Add(noeudVoisin);
                        }
                        
                        
                    }
                  

                }


            }
                





            return listeFerme;
        }


        public List<Noeud> rechercherChemin(Noeud noeudDepart,Noeud noeudFinal)
        {
            
            List<Noeud> list = algoAStar(noeudDepart,noeudFinal);
            List<Noeud> res = new List<Noeud>();
            
            foreach (var n in list)
            {
                if (n.Indice == noeudFinal.Indice)
                {
                    Noeud noeud = n;
                   
                    while (noeud.Parent != null)
                    {
                        res.Add(noeud);
                        noeud = noeud.Parent;
                       
                    }
                    
                    res.Add(noeud);
                    
                   
                 
                }
              
               
            }

            res.Reverse();
            return res;
        }

        public List<Vector2> RetrievePath(Noeud noeudDepart,Noeud noeudFinal,int originX,int originY)
        {
            List<Vector2> listeVector = new List<Vector2>();
            List<Noeud> listeNoeuds = rechercherChemin(noeudDepart, noeudFinal);
            foreach (var n in listeNoeuds)
            {
                Vector2 v = n.Position;
                v.X = originX + v.X * 32;
                v.Y = originY + v.Y * 32;
                listeVector.Add(v);
                
            }

            return listeVector;
        }
        
        

    }
}