using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    public interface IBoardBuilder
    {
        void Reset();
        void SetCoordinate(string coordinate);
        void GenerateEmptyBoard(int depth);
        void MakeMoves(List<string> moves);
        void SetWinners(List<string[]> winningPatterns);
    }
}
