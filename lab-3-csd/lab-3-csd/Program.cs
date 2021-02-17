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

            for (int i = 0; i < depth; i++)
            {
                string[] coordinates = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
                for (int j = 0; j < 9; j++)
                {
                    Board board = new Board(coordinates[j]);
                    for (int k = 0; k < 9; k++)
                    {
                        board.AddCell(new Cell(coordinates[k]));
                    }
                    game.AddCell(board);
                }
            }
            game.PrintCellInfo();


            string ChangePlayer(string player)
            {
                if (player == "O")
                {
                    return "X";
                }
                else
                {
                    return "O";
                }
            }
            return 0;
        }
    }
}
