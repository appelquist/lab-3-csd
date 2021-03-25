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
        void MakeMove(string move);
        List<IBoard> GetCells();
        string GetWinningPlayer();
        void SetWinningPlayer(string player);
        void SetWinners(List<string[]> winningPatterns);
        void AddWinningCell(string coordinate);
        void SetWinningCells(List<string> winningMoves);
        List<string> GetWinningCells();
        List<string> GetAllWinningCells(List<string> winningMoves);
        void AddIfWinningMove(string move, string nextMove, List<string> winningMoves);
        List<IBoard> GetAllBoards(List<IBoard> allBoards);
        public void SetLayers(int layer);
        public void SetLayer(int layer);
        public int GetLayer();
    }
}
