using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    class Program
    {
        static int Main(string[] args)
        {
            string[] moves = args[0].Split(',');
            
            int depth = moves[0].Count(ch => (ch == '.')) + 1;

            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);

            BoardDirector.ConstructBoard(moves, depth);
            Board game = BoardBuilder.GetBoard();
            return 0;
        }
    }
}
