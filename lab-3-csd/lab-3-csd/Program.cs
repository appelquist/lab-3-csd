﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    class Program
    {
        static int Main(string[] args)
        {
            //string[,] winningPatterns = new string[,] { { "NW", "NC", "NE" }, { "CW", "CC", "CE" }, { "SW","SC","SE" }, { "NW", "CW", "SW" }, { "NC", "CC", "SC" }, { "NE", "CE", "SE" }, { "NW", "CC", "SE" }, { "SW", "CC", "NE" } };
            List<string[]> winningPatterns = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" }, new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" }, new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" }, new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
            int depth;
            Board game = new Board("root");
            string[] moves = args[0].Split(',');
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    moves[i] = moves[i] + ".X";
                }
                else
                {
                    moves[i] = moves[i] + ".O";
                }

            }
            
            depth = moves[0].Count(ch => (ch == '.')) + 1;

            game.GenerateEmptyBoard(depth);
            game.MakeMove(moves);
            game.SetWinners(game, winningPatterns);
            game.PrintCellInfo();
            return 0;
        }
    }
}
