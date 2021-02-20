using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    class Program
    {
        static int Main(string[] args)
        {
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
            game.PrintCellInfo();
            return 0;
        }
    }
}
