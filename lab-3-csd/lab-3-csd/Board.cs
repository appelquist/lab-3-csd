using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class Board : IBoard
    {
        public string Coordinate { get; private set; }
        public List<Cell> Cells = new List<Cell>() { new Cell("NW"), new Cell("NC"), new Cell("NE"), new Cell("CW"), new Cell("CC"), new Cell("CE"), new Cell("SW"), new Cell("SC"), new Cell("SE") };
        public List<string> WinningCells { get; private set; } = new List<string>();
        public string WinningPlayer { get; private set; }
        public Board()
        {
        }
        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
            Console.WriteLine(Coordinate);
        }

        public void MakeMoves(List<string> moves)
        {
            string coordinate = moves.First().Remove(2);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (Cell cell in Cells)
                {
                    cell.MakeMove(moves);
                }
            }
        }

        //public void Clear()
        //{
        //    PlayerOccupying = "";
        //}

        //public string GetWinningPlayer()
        //{
        //    return PlayerOccupying;
        //}

        public string GetCoordinate()
        {
            return Coordinate;
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

        public void AddBoard(IBoard b)
        {
            throw new NotImplementedException();
        }

        public void SetCoordinate(string coordinate)
        {
            Coordinate = coordinate;
        }

        public List<IBoard> GetCells()
        {
            return new List<IBoard>() { this };
        }

        public string GetWinningPlayer()
        {
            return WinningPlayer;
        }

        public void SetWinningPlayer(string player)
        {
            WinningPlayer = player;
        }

        public void SetWinners(List<string[]> winningPatterns)
        {
            // Get the X and O player moves
            List<string> xMoves = new List<string>();
            List<string> oMoves = new List<string>();
            foreach (Cell cell in Cells)
            {
                if (cell.PlayerOccupying == "X")
                {
                    xMoves.Add(cell.Coordinate);
                }
                else if (cell.PlayerOccupying == "O")
                {
                    oMoves.Add(cell.Coordinate);
                }
            }

            //Check if the moves  for both players contain any of the winning patterns
            foreach (string[] pattern in winningPatterns)
            {
                if (xMoves.Contains(pattern[0].ToString()) && xMoves.Contains(pattern[1].ToString()) && xMoves.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("X");
                    return;
                }
                else if (oMoves.Contains(pattern[0].ToString()) && oMoves.Contains(pattern[1].ToString()) && oMoves.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("O");
                    return;
                }
            }
            return;
        }

        public void AddWinningCell(string coordinate)
        {
            WinningCells.Add(coordinate);
        }

        public void PrintResult()
        {
            throw new NotImplementedException();
        }
    }
}
