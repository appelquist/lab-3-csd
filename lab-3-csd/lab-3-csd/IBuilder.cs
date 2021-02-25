using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface IBuilder
    {
        void Reset();
        void SetCoordinate(string coordinate);
        void SetMoves(string[] moves);
        void SetDepth(int Depth);
        void GenerateEmptyBoard(int depth);
        void MakeMoves(ICell cell, List<string> moves);
        void SetWinners(Board board);
        void SetWinningCells(Board board, List<string> moves);
    }
}
