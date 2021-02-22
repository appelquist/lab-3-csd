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
        private List<ICell> Cells = new List<ICell>();
        public Board(string coordinate)
        {
            Coordinate = coordinate;
        }
        public Board()
        {
        }
        public void setCoordinate(string coordinate)
        {
            Coordinate = coordinate;
        }
        public void AddCell(ICell cell)
        {
            Cells.Add(cell);
        }
        public void GenerateEmptyBoard(int depth)
        {
            string[] coordinates = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
            //Base case - if one layer above bottom, fill out bottom layer with leafs(Cell)
            if (depth == 2)
            {
                for (int i = 0; i < coordinates.Length; i++)
                {
                    Cell c = new Cell(coordinates[i]);
                    this.AddCell(c);
                }
                return;
            }
            //Else - Create boards and Genererate boards for those boards
            for (int i = 0; i < coordinates.Length; i++)
            {
                Board b = new Board(coordinates[i]);
                this.Clear();
                this.AddCell(b);
                b.GenerateEmptyBoard(depth - 1);
            }
        }
        public void MakeMove(string[] moves)
        {
            //Base case - if all moves have been gone through, return
            if (moves.Length == 0)
            {
                return;
            }

            string[] firstMove = moves[0].Split('.');
            string coordinate = firstMove[0];
            
            //Special case - Fill out each cell under root with the moves.
            if (Coordinate == "root")
            {
                foreach (ICell cell in Cells)
                {
                    cell.MakeMove(moves);
                }
            }

            //If not root, check if this cell hase the same coordinate as the move, if so: remove the first coordinate of the move
            //(NW.CC.X -> CC.X), and for each children of this cell, try to place that move.
            if (coordinate == Coordinate)
            {
                firstMove = firstMove.Skip(1).ToArray();
                foreach (ICell cell in Cells)
                {
                    cell.MakeMove(firstMove);
                }
            }
            //Remove firstMove from moves and continue
            moves = moves.Skip(1).ToArray();
            MakeMove(moves);
        }

        public void SetWinners(Board board, List<string[]> winningPatterns)
        {
            //Base case - if the first cell is of Type Cell calculate that boards winner and return
            if (board.Cells.First().GetType().Equals(typeof(Cell)))
            {
                //Get the X and O player moves
                List<string> xMoves = new List<string>();
                List<string> oMoves = new List<string>();
                foreach (Cell cell in board.Cells)
                {
                    if (cell.PlayerOccupying == "X")
                    {
                        xMoves.Add(cell.Coordinate);
                    }
                    else if(cell.Coordinate == "O")
                    {
                        oMoves.Add(cell.Coordinate);
                    }
                }

                //Check if the moves  for bothe players contain any of the winning patterns
                foreach (string[] pattern in winningPatterns)
                {
                    if (xMoves.Contains(pattern[0].ToString()) && xMoves.Contains(pattern[1].ToString()) && xMoves.Contains(pattern[2].ToString()))
                    {
                        board.WinningPlayer = "X";
                        return;
                    }
                    else if (oMoves.Contains(pattern[0].ToString()) && oMoves.Contains(pattern[1].ToString()) && oMoves.Contains(pattern[2].ToString()))
                    {
                        board.WinningPlayer = "O";
                        return;
                    }
                }
                return;
            }      

            //Set winner of each board and of its children
            foreach (Board b in board.Cells)
            {
                SetWinnerSelf(b, winningPatterns);
                //Recursive step
                SetWinners(b, winningPatterns);
            }

            //Special case, set winner of the root board aka the winner of the game.
            if (board.Coordinate == "root")
            {
                SetWinnerSelf(board, winningPatterns);
            }
        }

        private void SetWinnerSelf(Board board, List<string[]> winningPatterns)
        {
            List<string> xWins = new List<string>();
            List<string> oWins = new List<string>();
            foreach (ICell bd in board.Cells)
            {
                if (bd.GetWinningPlayer() == "X")
                {
                    xWins.Add(bd.GetCoordinate());
                }
                else if (bd.GetWinningPlayer() == "O")
                {
                    oWins.Add(bd.GetCoordinate());
                }
            }

            foreach (string[] pattern in winningPatterns)
            {
                if (xWins.Contains(pattern[0].ToString()) && xWins.Contains(pattern[1].ToString()) && xWins.Contains(pattern[2].ToString()))
                {
                    board.WinningPlayer = "X";
                }
                else if (oWins.Contains(pattern[0].ToString()) && oWins.Contains(pattern[1].ToString()) && oWins.Contains(pattern[2].ToString()))
                {
                    board.WinningPlayer = "O";
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
    }
}
