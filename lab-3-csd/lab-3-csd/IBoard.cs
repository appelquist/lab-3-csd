using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface IBoard
    {
        void AddBoard(IBoard b);
        void SetCoordinate(string coordinate);
        string GetCoordinate();
        void MakeMoves(List<string> moves);
        List<IBoard> GetCells();
        string GetWinningPlayer();
        void SetWinningPlayer(string player);
        void SetWinners(List<string[]> winningPatterns);
        void AddWinningCell(string coordinate);
        void SetWinningCells(List<string> winningMoves);
        void PrintResult();
    }
}
