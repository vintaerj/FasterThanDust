﻿using System;
using System.Collections.Generic;
using System.Linq;
using AlgoStar.Boost;

namespace FasterThanDust
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            
 
            
            using (var game = new Game1())
                game.Run();
        }
    }
}