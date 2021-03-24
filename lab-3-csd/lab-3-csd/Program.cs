using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    class Program
    {
        static int Main(string[] args)
        {
            List<string> Moves = new List<string>();
            string[] moves = args[0].Split(',');
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Moves.Add(moves[i] + ".X");
                }
                else
                {
                    Moves.Add(moves[i] + ".O");
                }
            }

            int depth = moves[0].Count(ch => (ch == '.'));

            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);

            BoardDirector.ConstructBoard(Moves, depth);
            IBoard game = BoardBuilder.GetBoard();

            BoardPrinter Printer = new BoardPrinter(game, Moves);
            Printer.PrintTopLevelWinningMoves();
            Printer.PrintAllWinningMoves();
            Printer.PrintPlayerWins();
            
            return 0;
        }
    }
}
