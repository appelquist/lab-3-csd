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
        public List<string> Moves { get; private set; } = new List<string>();
        public int Depth { get; private set; }
        public string[] Coordinates { get; private set; } = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        public List<string[]> WinningPatterns { get; private set; } = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" },
                                                                                             new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" },
                                                                                             new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" },
                                                                                             new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
        public SuperBoard(string coordinate)
        {
            Coordinate = coordinate;
        }
        public SuperBoard()
        {
        }
        public void MakeMoves(List<string> moves)
        {
            string coordinate = moves.First().Remove(2);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (IBoard board in Boards)
                {
                    board.MakeMoves(moves);
                }
            } 
        }
        public void SetDepth(int depth)
        {
            Depth = depth;
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
        public void AddWinningMove(string move)
        {
            WinningMoves.Add(move);
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
        //public void PrintResult()
        //{
        //    string winningLargeCells = WinningCells[0] + ", " + WinningCells[1] + ", " + WinningCells[2];
        //    Console.WriteLine(winningLargeCells);
        //    List<string> winningMoves = WinningCells;
        //    if (Cells.First().GetType().Equals(typeof(Board)))
        //    {
        //        foreach (IBoard cell in Cells)
        //        {
        //            if (cell.GetWinningPlayer() == WinningPlayer)
        //            {
        //                winningMoves.Add(cell.GetCoordinate());
        //            }
        //        }
        //        return;
        //    }
        //    foreach (SuperBoard board in Cells)
        //    {

        //        if (board.GetWinningPlayer() == WinningPlayer)
        //        {
        //            winningMoves.Add(board.GetWinningMoves)
        //        }

        //    }

        //}

        //public void PrintCellInfo()
        //{  
        //    foreach (IBoard cell in Cells)
        //    {
        //        Console.Write(Coordinate);
        //        cell.PrintCellInfo();
        //    }
        //}
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

        public void MakeMove(List<string> move)
        {
            return;
        }

        public List<string> GetMoves()
        {
            return Moves;
        }

        public void AddBoard(IBoard b)
        {
            Boards.Add(b);
        }
    }
}
