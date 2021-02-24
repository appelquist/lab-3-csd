using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class Board : ICell
    {
        public string Coordinate { get; private set; }
        public string WinningPlayer { get; private set; }
        public List<ICell> Cells { get; private set; } = new List<ICell>();
        private List<string> WinningMoves = new List<string>();
        public List<string> Moves { get; private set; } = new List<string>();
        public int Depth { get; private set; }
        public string[] Coordinates { get; private set; } = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        public List<string[]> WinningPatterns { get; private set; } = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" },
                                                                                             new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" },
                                                                                             new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" },
                                                                                             new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
        public Board(string coordinate)
        {
            Coordinate = coordinate;
        }
        public Board()
        {
        }
        public void SetMoves(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Moves.Add(moves[i] + ".X");
                }
                else
                {
                    Moves.Add(moves[i] + ".O");
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
        public void AddCell(ICell cell)
        {
            Cells.Add(cell);
        }
        public List<ICell> GetCells()
        {
            return Cells;
        }
        public void SetWinningPlayer(string player)
        {
            WinningPlayer = player;
        }
        public void AddWinningMove(string move)
        {
            WinningMoves.Add(move);
        }
        public void SetWinningMoves(List<string> winningMoves)
        {
            int nw = 0; int nc = 0; int ne = 0; int cw = 0; int cc = 0; int ce = 0; int sw = 0; int sc = 0; int se = 0;
            foreach (string move in winningMoves)
            {
                switch (move)
                {
                    case "NW":
                        nw++;
                        if (nw == 3) { WinningMoves.Add(move); }
                        break;
                    case "NC":
                        nc++;
                        if (nc == 3) { WinningMoves.Add(move); }
                        break;
                    case "NE":
                        ne++;
                        if (ne == 3) { WinningMoves.Add(move); }
                        break;
                    case "CW":
                        cw++;
                        if (cw == 3) { WinningMoves.Add(move); }
                        break;
                    case "CC":
                        cc++;
                        if (cc == 3) { WinningMoves.Add(move); }
                        break;
                    case "CE":
                        ce++;
                        if (ce == 3) { WinningMoves.Add(move); }
                        break;
                    case "SW":
                        sw++;
                        if (sw == 3) { WinningMoves.Add(move); }
                        break;
                    case "SC":
                        sc++;
                        if (sc == 3) { WinningMoves.Add(move); }
                        break;
                    case "SE":
                        se++;
                        if (se == 3) { WinningMoves.Add(move); }
                        break;
                }
            }
        }

        public void PrintCellInfo()
        {  
            foreach (ICell cell in Cells)
            {
                Console.Write(Coordinate);
                cell.PrintCellInfo();
            }
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

        public void MakeMove(List<string> move)
        {
            return;
        }

        public List<string> GetMoves()
        {
            return Moves;
        }
    }
}
