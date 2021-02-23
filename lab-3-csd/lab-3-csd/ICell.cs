using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface ICell
    {
        void MakeMove(string[] move);
        void SetWinningMoves(List<string> moves);
        void Clear();
        void PrintCellInfo();
        string GetWinningPlayer();
        string GetCoordinate();
    }
}
