using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    public class NullBoard : IBoard

    {
        public void AddBoard(IBoard b)
        {
        }

        public void AddIfWinningMove(string move, string nextMove, List<string> winningMoves)
        {
        }

        public void AddWinningCell(string coordinate)
        {
        }

        public List<IBoard> GetAllBoards(List<IBoard> allBoards)
        {
            return new List<IBoard>();
        }

        public List<string> GetAllWinningCells(List<string> winningMoves)
        {
            return new List<string>();
        }

        public List<IBoard> GetCells()
        {
            return new List<IBoard>();
        }

        public string GetCoordinate()
        {
            return "";
        }

        public int GetLayer()
        {
            return 0;
        }

        public List<string> GetWinningCells()
        {
            return new List<string>();
        }

        public string GetWinningPlayer()
        {
            return "";
        }

        public void MakeMove(string move)
        {
        }

        public void SetCoordinate(string coordinate)
        {
        }

        public void SetLayer(int layer)
        {
        }

        public void SetLayers(int layer)
        {
        }

        public void SetWinners(List<string[]> winningPatterns)
        {
        }

        public void SetWinningCells(List<string> winningMoves)
        {
        }

        public void SetWinningPlayer(string player)
        {
        }
    }
}
