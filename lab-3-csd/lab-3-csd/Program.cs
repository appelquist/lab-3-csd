using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3_csd
{
    class Program
    {
        static int Main(string[] args)
        {
            List<string[]> winningPatterns = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" }, new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" }, new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" }, new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
            int depth;
            Board game = new Board("root");
            string[] moves = args[0].Split(',');
            List<string> Moves = new List<string>();
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
            
            depth = Moves[0].Count(ch => (ch == '.')) + 1;

            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);

            BoardDirector.ConstructBoard(moves, depth);

            return 0;
        }
    }
}
