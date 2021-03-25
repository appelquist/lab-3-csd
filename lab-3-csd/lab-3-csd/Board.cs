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
        public int Layer { get; private set; }
        public List<string> WinningCells { get; private set; } = new List<string>();
        public string WinningPlayer { get; private set; }
        private List<string[]> WinningPatterns = new List<string[]>() { new string[] { "NW", "NC", "NE" }, new string[] { "CW", "CC", "CE" },
                                                                                             new string[] { "SW", "SC", "SE" }, new string[] { "NW", "CW", "SW" },
                                                                                             new string[] { "NC", "CC", "SC" }, new string[] { "NE", "CE", "SE" },
                                                                                             new string[] { "NW", "CC", "SE" }, new string[] { "SW", "CC", "NE" } };
        public Board()
        {
        }
        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
            Console.WriteLine(Coordinate);
        }

        public void MakeMove(string move)
        {
            string coordinate = move.Remove(2, move.Length - 2);
            move = move.Remove(0, 3);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (Cell cell in Cells)
                {
                    cell.MakeMove(move);
                }
            }
        }
        public string GetCoordinate()
        {
            return Coordinate;
        }

        public void SetWinningCells(List<string> winningMoves)
        {
            foreach (string move in winningMoves)
            {
                string m = move.Remove(2);
                switch (m)
                {
                    case "NW":
                        WinningCells.Add(m);
                        break;
                    case "NC":
                        WinningCells.Add(m);
                        break;
                    case "NE":
                        WinningCells.Add(m);
                        break;
                    case "CW":
                        WinningCells.Add(m);
                        break;
                    case "CC":
                        WinningCells.Add(m);
                        break;
                    case "CE":
                        WinningCells.Add(m);
                        break;
                    case "SW":
                        WinningCells.Add(m);
                        break;
                    case "SC":
                        WinningCells.Add(m);
                        break;
                    case "SE":
                        WinningCells.Add(m);
                        break;
                }
            }
            if (WinningCells.Count > 3)
            {
                for (int i = 0; i < WinningCells.Count; i++)
                {
                    for (int j = i + 1; j < WinningCells.Count; j++)
                    {
                        for (int k = j + 1; k < WinningCells.Count; k++)
                        {
                            List<string> threeMoves = new List<string>() { WinningCells[i], WinningCells[j], WinningCells[k] };
                            foreach (string[] pattern in WinningPatterns)
                            {
                                if (threeMoves.Contains(pattern[0].ToString()) && threeMoves.Contains(pattern[1].ToString()) && threeMoves.Contains(pattern[2].ToString()))
                                {
                                    WinningCells = threeMoves;
                                    return;
                                }
                            }
                        }                       
                    }
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

        public List<string> GetAllWinningCells(List<string> moves)
        {
            List<string> winningPlayerMoves = new List<string>();
            List<string> winningMoves = new List<string>();
            foreach (string move in moves)
            {
                if (move.Substring(move.Length - 1) == WinningPlayer)
                {
                    winningPlayerMoves.Add(move);
                }
            }
            foreach (string move in winningPlayerMoves)
            {
                foreach (Cell cell in Cells)
                {
                    if (cell.PlayerOccupying == move.Substring(move.Length - 1) && cell.Coordinate == move.Substring(0, 2))
                    {
                        winningMoves.Add(move.Substring(0, 2));
                    }
                }
            }
            return winningMoves;
        }

        public List<string> GetWinningCells()
        {
            return WinningCells;
        }

        public void AddIfWinningMove(string move, string nextMove, List<string> moves)
        {
            if (WinningCells.Contains(nextMove.Substring(0, 2)) && WinningPlayer == move.Substring(move.Length - 1))
            {
                moves.Add(move);
            }
        }
        public string GetPlayerWins(string player, string layerWins)
        {
            return "";
        }
        public List<IBoard> GetAllBoards(List<IBoard> allBoards)
        {
            return allBoards;
        }
        public void SetLayers(int layer)
        {
            Layer = layer;
        }

        public void SetLayer(int layer)
        {
            Layer = layer;
        }

        public int GetLayer()
        {
            return Layer;
        }
    }
}
