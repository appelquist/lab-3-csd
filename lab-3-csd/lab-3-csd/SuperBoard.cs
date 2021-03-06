using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class SuperBoard : IBoard
    {
        public string Coordinate { get; private set; }
        public string WinningPlayer { get; private set; }
        public List<IBoard> Boards { get; private set; } = new List<IBoard>();
        private List<string> WinningCells = new List<string>();
        private List<string> WinningMoves = new List<string>();

        public SuperBoard(string coordinate)
        {
            Coordinate = coordinate;
        }
        public SuperBoard()
        {
        }
        public void MakeMove(string move)
        {
            string coordinate = move.Remove(2, move.Length - 2);
            move = move.Remove(0, 3);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (IBoard board in Boards)
                {
                    board.MakeMove(move);
                }
            } 
        }
        public void SetCoordinate(string coordinate)
        {
            Coordinate = coordinate;
        }
        public void AddCell(IBoard cell)
        {
            Boards.Add(cell);
        }
        public List<IBoard> GetCells()
        {
            return Boards;
        }
        public List<string> GetWinningCells()
        {
            return WinningCells;
        }
        public void SetWinningPlayer(string player)
        {
            WinningPlayer = player;
        }
        public void AddWinningCell(string cell)
        {
            WinningCells.Add(cell);
        }
        public void SetWinningCells(List<string> winningMoves)
        {
            int nw = 0; int nc = 0; int ne = 0; int cw = 0; int cc = 0; int ce = 0; int sw = 0; int sc = 0; int se = 0;
            foreach (string move in winningMoves)
            {
                switch (move)
                {
                    case "NW":
                        nw++;
                        if (nw == 3) { WinningCells.Add(move); }
                        break;
                    case "NC":
                        nc++;
                        if (nc == 3) { WinningCells.Add(move); }
                        break;
                    case "NE":
                        ne++;
                        if (ne == 3) { WinningCells.Add(move); }
                        break;
                    case "CW":
                        cw++;
                        if (cw == 3) { WinningCells.Add(move); }
                        break;
                    case "CC":
                        cc++;
                        if (cc == 3) { WinningCells.Add(move); }
                        break;
                    case "CE":
                        ce++;
                        if (ce == 3) { WinningCells.Add(move); }
                        break;
                    case "SW":
                        sw++;
                        if (sw == 3) { WinningCells.Add(move); }
                        break;
                    case "SC":
                        sc++;
                        if (sc == 3) { WinningCells.Add(move); }
                        break;
                    case "SE":
                        se++;
                        if (se == 3) { WinningCells.Add(move); }
                        break;
                }               
            }
        }
        //public void PrintResult(List<string> winningMoves)
        //{
        //    List<string> result = new List<string>();
        //    for (int i = 0; i < winningMoves.Count; i++)
        //    {
        //        foreach (IBoard board in Boards)
        //        {
        //            if (winningMoves[i].Length == 2)
        //            {
        //                if (board.GetCoordinate() == winningMoves[i])
        //                {
        //                    for (int j = 0; j < board.GetWinningCells().Count; j++)
        //                    {
        //                        result.Add(winningMoves[i] + "." + board.GetWinningCells()[j]);
        //                    }
        //                    board.PrintResult(result);
        //                }
        //            }
        //            else if (board.GetCoordinate() == winningMoves[i].Remove(2, winningMoves[i].Length - 2))
        //            {
        //                {
        //                    for (int j = 0; j < board.GetWinningCells().Count; j++)
        //                    {
        //                        result.Add(winningMoves[i] + "." + board.GetWinningCells()[j]);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    return;
        //}
        public List<string> PrintResult(List<string> winningMoves)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < WinningCells.Count; i++)
            {
                foreach (IBoard board in Boards)
                {
                    if (board.GetCoordinate() == WinningCells[i])
                    {
                        {
                            for (int j = 0; j < board.GetWinningCells().Count; j++)
                            {
                                //Problem
                                result.Add(WinningCells[i] + "." + board.GetWinningCells()[j]);                        
                            }                          
                        }
                        result = board.PrintResult(result);
                    }
                    
                }
            }
            return result;
        }
        public void Clear()
        {
            WinningPlayer = "";
        }
        public string GetWinningPlayer()
        {
            return WinningPlayer;
        }

        public string GetCoordinate()
        {
            return Coordinate;
        }

        public void AddBoard(IBoard b)
        {
            Boards.Add(b);
        }

        public void SetWinners(List<string[]> winningPatterns)
        {           
            foreach (IBoard board in Boards)
            {
                board.SetWinners(winningPatterns);
            }
            List<string> xWins = new List<string>();
            List<string> oWins = new List<string>();
            foreach (IBoard b in Boards)
            {
                if (b.GetWinningPlayer() == "X")
                {
                    xWins.Add(b.GetCoordinate());
                }
                else if (b.GetWinningPlayer() == "O")
                {
                    oWins.Add(b.GetCoordinate());
                }
            }

            //Check any winning pattern exists in xWins or oWins, if so set player to winner.
            foreach (string[] pattern in winningPatterns)
            {
                if (xWins.Contains(pattern[0].ToString()) && xWins.Contains(pattern[1].ToString()) && xWins.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("X");
                }
                else if (oWins.Contains(pattern[0].ToString()) && oWins.Contains(pattern[1].ToString()) && oWins.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("O");
                }
            }
        }
    }
}
