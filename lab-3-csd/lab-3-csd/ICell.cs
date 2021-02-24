using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface ICell
    {
        void MakeMove(List<string> move);
        void SetWinningMoves(List<string> moves);
        List<ICell> GetCells();
        void Clear();
        void PrintCellInfo();
        string GetWinningPlayer();
        string GetCoordinate();
    }
}
