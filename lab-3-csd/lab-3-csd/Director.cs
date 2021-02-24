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

        public void ConstructBoard(string [] moves, int depth)
        {
            Builder.SetMoves(moves);
            Builder.SetCoordinate("root");
            Builder.GenerateEmptyBoard(depth);
            Builder.MakeMoves(Builder.Board, Builder.Board.Moves);
            Builder.SetWinners(Builder.Board);
            Builder.SetWinningMoves(Builder.Board, Builder.Board.Moves);
        }
    }
}
