using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface IBoardBuilder
    {
        void Reset();
        void SetCoordinate(string coordinate);
        //void SetDepth(int Depth);
        void GenerateEmptyBoard(int depth);
        void MakeMoves(List<string> moves);
        void SetWinners(List<string[]> winningPatterns);
        //void SetWinningCells(SuperBoard board, List<string> moves);
    }
}
