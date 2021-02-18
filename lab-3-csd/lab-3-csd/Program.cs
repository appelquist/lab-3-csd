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
            Board game = new Board("");
            string[] moves = args[0].Split(',');
            depth = moves[0].Count(ch => (ch == '.')) + 1;

            game.GenerateEmptyBoard(depth);
            game.PrintCellInfo();

            //string ChangePlayer(string player)
            //{
            //    if (player == "O")
            //    {
            //        return "X";
            //    }
            //    else
            //    {
            //        return "O";
            //    }
            //}
            return 0;
        }
    }
}
