using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Director
    {
        private List<string[]> WinningPatterns = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" },
                                                                                             new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" },
                                                                                             new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" },
                                                                                             new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
        private Builder Builder;

        public Director(Builder builder)
        {
            Builder = builder;
        }

        public void ConstructBoard(List<string> moves, int depth)
        {
            Builder.SetCoordinate("root");
            Builder.GenerateEmptyBoard(depth);
            Builder.SetLayers(depth);
            Builder.MakeMoves(moves);
            Builder.SetWinners(WinningPatterns);
            Builder.SetWinningCells(Builder.GetBoard(), moves);
        }
    }
}
