
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using AlgoStar.Boost;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = System.Numerics.Vector2;

namespace GameJam17.Gameplay
{
    public class Grid
    {
        public Graph graph;
        public string[,] grid;
        private Texture2D murGauche;
        private Texture2D murHaut;
        private Texture2D murDroite;
        private Texture2D murBas;
        private Texture2D sol;
        private Texture2D backgroundSol;
        
        private int TileWidth = 32;
        private int TileHeight = 32;
        private int OriginX = 100;
        private int OriginY = 100;
        private bool isDrawChemin = false;
        

        public Grid(string[,] grid)
        {
            this.grid = grid;
            graph = Graph.TabToGraph(grid);
        }

      

        // Chargement des images.
        public void Load(GraphicsDevice g,ContentManager c)
        {
          
            murGauche = c.Load<Texture2D>("Ressources/Salles/murGauche");
            murHaut = c.Load<Texture2D>("Ressources/Salles/murHaut");
            murDroite = c.Load<Texture2D>("Ressources/Salles/murDroite");
            murBas = c.Load<Texture2D>("Ressources/Salles/murBas");
            sol = c.Load<Texture2D>("Ressources/Salles/sol");
            //backgroundSol = c.Load<Texture2D>("Ressources/Backgrounds/terre_desolee");


        }

        // Mise à jour .
        public void Update(GameTime gameTime)
        {
            
            MouseState ms = Mouse.GetState();
            if (ms.RightButton == ButtonState.Pressed)
            {
                Console.WriteLine("pressed");
                changeCase(ms.X,ms.Y,0);
            }else if (ms.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("pressed");
                changeCase(ms.X,ms.Y,1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                isDrawChemin = true;
            }

        }

        // dessine le sol .
        private void DrawGrid(SpriteBatch sp)
        {

            // dessiner le background sol;
            //sp.Draw(backgroundSol,new Rectangle(0,0,1024,768),Color.White);
          
            for (int line = 0; line < grid.GetLength(0) ; line++)
            {
                for (int column = 0; column< grid.GetLength(1); column++)
                {
                    char[] id = Graph.convertId(grid[line, column]);
                 
          
                    if (id.Length > 1 ) // je vérifie que l'id est bien composé et non un seul 0 .
                    {
                        
                        sp.Draw(sol,new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight,32,32),Color.White);
                
                        if (id[0] == '1' || id[0] == '2'  )// haut
                        {
                            sp.Draw(murHaut,new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight-3,TileWidth,TileHeight),Color.White);
                        }
                        if (id[1] == '1' || id[1] == '2') // droite
                        {
                            sp.Draw(murDroite,new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight,TileWidth,TileHeight),Color.White);
                        }
                        if (id[2] == '1' || id[2] == '2') // bas
                        {
                            sp.Draw(murBas,new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight+3,TileWidth,TileHeight),Color.White);
                        }
                        
                        if (id[3] == '1' || id[3] == '2') // Gauche
                        {
                            sp.Draw(murGauche,new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight,TileWidth,TileHeight),Color.White);
                        }
                        
                        
                    }
                   
                   
                   
                    
           
                }
            }
           
                
               


            
        }
        
      

        // Dessine .
        public void Draw(SpriteBatch sp)
        {

            DrawGrid(sp);
            if (isDrawChemin)
            {
                Console.WriteLine("Ready");
                DrawChemin(sp,new Vector2(0,0),new Vector2(2,1));
            }
           
  
        }

        // Desinne le chemin d'un point A à B
        private void DrawChemin(SpriteBatch sp,System.Numerics.Vector2 depart, System.Numerics.Vector2 fin)
        {
            graph = Graph.TabToGraph(grid);
            Noeud d = graph.getNoeud(depart);
            Noeud f = graph.getNoeud(fin);
            List<Noeud> chemins = graph.rechercherChemin(d, f);
            
            
            
            foreach (var n in chemins)
            {
                Rectangle rect =new Rectangle(OriginX+(int)n.Position.X*TileWidth,OriginY+(int)n.Position.Y*TileHeight,TileWidth,TileHeight);
                sp.Draw(sol,rect,Color.Green);
                
            }

        }

        // Change une case .
        public void changeCase(double positionX,double positionY,int valeur)
        {
            int line = (int)Math.Floor((positionY- OriginY) / TileHeight );
            int column = (int)Math.Floor((positionX-OriginX) / TileWidth );
            Console.WriteLine(line+"  "+column);
           
            
            
            if (line >= 0 && column >= 0 && line < grid.GetLength(0) && column < grid.GetLength(1))
            {
                //grid[line, column] = valeur;
            }
            
        }

        // recupere Id.
        public int GetId(Vector2 v)
        {
            float positionX = v.X - OriginX;
            float positionY = v.Y - OriginY;
            int line = (int)Math.Floor(positionY / TileHeight);
            int column = (int)Math.Floor(positionX / TileWidth);

            Noeud n = graph.getNoeud(new Vector2(column, line));
            if (n != null)
            {
                return n.Indice;
            }
            else
            {
                return -1;
            }
         
        }
        
    }
}