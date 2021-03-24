using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class BoardPrinter
    {
        private IBoard Board;
        private List<string> Moves;
        public BoardPrinter(IBoard board, List<string> moves)
        {
            Board = board;
            Moves = moves;
        }

        public void PrintTopLevelWinningMoves()
        {
            List<string> moves = Board.GetWinningCells();
            string result = "";
            for (int i = 0; i < moves.Count; i++)
            {
                if (i == moves.Count - 1)
                {
                    result = result + moves[i];
                }
                else
                {
                    result = result + moves[i] + ", ";
                }
            }
            Console.WriteLine(result);
        }
        public void PrintAllWinningMoves()
        {
            List<string> moves = Board.GetAllWinningCells(Moves);
            string result = "";
            for (int i = 0; i < moves.Count; i++)
            {
                if (i == moves.Count - 1)
                {
                    result = result + moves[i];
                }
                else
                {
                    result = result + moves[i] + ", ";
                }
            }
            Console.WriteLine(result);
        }

        public void PrintPlayerWins()
        {
            List<string> playerWins = new List<string>();
            string XWins = "";
            string OWins = "";
            if (Board.GetWinningPlayer() == "X")
            {
                XWins = "1";
                OWins = "0";
            }
            else if (Board.GetWinningPlayer() == "O")
            {
                XWins = "0";
                OWins = "1";
            }
            string layerWins = XWins;
            string result = Board.GetPlayerWins("X", XWins);
        }
    }
}
