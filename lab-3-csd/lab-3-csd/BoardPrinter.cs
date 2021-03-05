using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class BoardPrinter
    {
        private List<string> result = new List<string>();
        public BoardPrinter()
        {
        }
        public void PrintBoard(IBoard board)
        {
            List<string> winningCells = board.GetWinningCells();
            for (int i = 0; i < winningCells.Count; i++)
            {
                foreach (IBoard b in board.GetCells())
                {
                    if (b.GetCoordinate() == winningCells[i])
                    {
                        for (int j = 0; j < b.GetWinningCells().Count; j++)
                        {
                            result.Add(winningCells[i] + "." + b.GetWinningCells()[j]);
                        }
                        PrintBoard(b);
                    }
                }
            }
            return;
        }
    }
}
