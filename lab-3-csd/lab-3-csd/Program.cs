using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    public class Program
    {
        static int Main(string[] args)
        {
            List<string> Moves = new List<string>();
            InputChecker Checker = new InputChecker();
            int Depth = 0;
            try
            {   
                if (args.Length < 1 || args.Length > 1)
                {
                    Console.WriteLine("Provide input in one string");
                    return 1;
                }
                string[] moves = args[0].Split(',');
                if (!Checker.ContainsOnlyValidCharacters(moves))
                {
                    Console.WriteLine("One or more moves contain moves in wrong format, only provide moves in dot syntax and uppercase");
                    return 1;
                }
                if (!Checker.AllMovesEqualLength(moves))
                {
                    Console.WriteLine("All moves are not of equal length, provide equal lengthy moves");
                    return 1;
                }
                if (!Checker.NoDuplicateMoves(moves))
                {
                    Console.WriteLine("Duplicate moves exist, provide moves with no duplicates");
                    return 1;
                }
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
                Depth = moves[0].Count(ch => (ch == '.'));
            }
            catch
            {
                Console.WriteLine("Wrong format of provided moves");
            }

            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);

            try
            {
                BoardDirector.ConstructBoard(Moves, Depth);
                IBoard game = BoardBuilder.GetBoard();
                BoardPrinter Printer = new BoardPrinter(game, Moves);
                Printer.PrintPlayerWins();
                Printer.PrintTopLevelWinningMoves();
                Printer.PrintAllWinningMoves();
            }
            catch
            {
                Console.WriteLine("Failed when building board, check input");
            }                                             
            return 0;
        }
    }
}
