using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Director
    {
        private Builder Builder;

        public Director(Builder builder)
        {
            Builder = builder;
        }

        public void ConstructBoard(List<string> moves, int depth)
        {
            Builder.SetCoordinate("root");
            Builder.GenerateEmptyBoard(depth);
            Builder.MakeMoves(moves);
            //Builder.SetWinners(Builder.GetBoard());
            //Builder.SetWinningCells(Builder.GetBoard(), Builder.GetBoard().Moves);
            //Builder.SetWinningMoves(Builder.GetBoard());
        }
    }
}
