using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    public class BoardPrinter
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
                moves[i] = moves[i].Substring(0, moves[i].Length - 2);
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
            List<IBoard> allBoards = new List<IBoard>();
            List<int> layerWinsX = new List<int>();
            List<int> layerWinsO = new List<int>();
            for (int i = 0; i < Board.GetLayer(); i++)
            {
                layerWinsX.Add(0);
                layerWinsO.Add(0);
            }
            if (Board.GetWinningPlayer() == "X")
            {
                layerWinsX[0] = 1;
                layerWinsO[0] = 0;
            }
            else if (Board.GetWinningPlayer() == "O")
            {
                layerWinsX[0] = 0;
                layerWinsO[0] = 1;
            }
            allBoards = Board.GetAllBoards(allBoards);
            foreach (IBoard board in allBoards)
            {
                if (board.GetWinningPlayer() == "X")
                {
                    layerWinsX[Board.GetLayer() - board.GetLayer()] = layerWinsX[Board.GetLayer() - board.GetLayer()] + 1;
                }
                else if (board.GetWinningPlayer() == "O")
                {
                    layerWinsO[Board.GetLayer() - board.GetLayer()] = layerWinsO[Board.GetLayer() - board.GetLayer()] + 1;
                }
            }
            string resultX = layerWinsX[0].ToString();
            string resultO = layerWinsO[0].ToString();
            for (int i = 1; i < layerWinsX.Count; i++)
            {
                resultX = resultX + "." + layerWinsX[i].ToString();
                resultO = resultO + "." + layerWinsO[i].ToString();
            }
            string result = resultX + ", " + resultO;
            Console.WriteLine(result);
        }
    }
}
