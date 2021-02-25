using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class Builder : IBuilder
    {
        private Board Board;
        public Builder()
        {
            Reset();
        }

        public void Reset()
        {
            Board = new Board();
        }
        public void SetMoves(string[] moves)
        {
            Board.SetMoves(moves);
        }
        public void SetDepth(int depth)
        {
            Board.SetDepth(depth);
        }
        public void SetWinningPlayer(string player)
        {
            Board.SetWinningPlayer(player);
        }
        public void SetCoordinate(string coordinate)
        {
            Board.SetCoordinate(coordinate);
        }
        public void GenerateEmptyBoard(int depth)
        {
            //Base case - if one layer above bottom, fill out bottom layer with leafs(Cell)
            if (depth == 1)
            {
                for (int i = 0; i < Board.Coordinates.Length; i++)
                {
                    Cell c = new Cell(Board.Coordinates[i]);
                    Board.AddCell(c);
                }
                return;
            }
            //Else - Create a Builder, set coordinate, add that Builders Boar to this Boards Cells and genererate boards for those boards
            for (int i = 0; i < Board.Coordinates.Length; i++)
            {
                Builder b = new Builder();
                b.SetCoordinate(Board.Coordinates[i]);
                Board.AddCell(b.Board);
                b.GenerateEmptyBoard(depth - 1);
            }
        }

        public void MakeMoves(ICell cell, List<string> moves)
        {
            //Base case - if all moves have been gone through, return
            if (moves.Count == 0)
            {
                return;
            }          
            List<string> firstMove = new List<string>() { moves.First() };
            string coordinate = firstMove.First().Remove(2);

            //Special case - Fill out each cell under root with the moves.
            if (cell.GetCoordinate() == "root")
            {
                if (cell.GetCells().First().GetType().Equals(typeof(Cell)))
                {
                    foreach (ICell c in cell.GetCells())
                    {
                        c.MakeMove(moves);
                    }
                }
                foreach (ICell c in cell.GetCells())
                {
                    MakeMoves(c, moves);
                }
            }

            //If not root, check if this cell hase the same coordinate as the move, if so: call MakeMove on all its cells with the list of moves;
            if (cell.GetCoordinate() == coordinate)
            {
                if (cell.GetCells().First().GetType().Equals(typeof(Cell)))
                {
                    foreach (ICell c in cell.GetCells())
                    {
                        c.MakeMove(moves);
                    }
                    return;
                }
                foreach (ICell c in cell.GetCells())
                {
                    MakeMoves(c, moves);
                }
            }
            //Remove firstMove from moves and continue
            List<string> tail = moves.ToList();
            tail.RemoveAt(0);
            MakeMoves(cell, tail);
        }

        public void SetWinners(Board b)
        {
            //Base case - if the first cell is of Type Cell calculate that boards winner and return
            if (b.Cells.First().GetType().Equals(typeof(Cell)))
            {
                //Get the X and O player moves
                List<string> xMoves = new List<string>();
                List<string> oMoves = new List<string>();
                foreach (Cell cell in b.Cells)
                {
                    if (cell.PlayerOccupying == "X")
                    {
                        xMoves.Add(cell.Coordinate);
                    }
                    else if (cell.Coordinate == "O")
                    {
                        oMoves.Add(cell.Coordinate);
                    }
                }

                //Check if the moves  for bothe players contain any of the winning patterns
                foreach (string[] pattern in b.WinningPatterns)
                {
                    if (xMoves.Contains(pattern[0].ToString()) && xMoves.Contains(pattern[1].ToString()) && xMoves.Contains(pattern[2].ToString()))
                    {
                        b.SetWinningPlayer("X");
                        return;
                    }
                    else if (oMoves.Contains(pattern[0].ToString()) && oMoves.Contains(pattern[1].ToString()) && oMoves.Contains(pattern[2].ToString()))
                    {
                        b.SetWinningPlayer("O");
                        return;
                    }
                }
                return;
            }

            //Set winner of each board and of its children
            foreach (Board board in Board.Cells)
            {
                SetWinnerSelf(board);
                //Recursive step
                SetWinners(board);
            }

            //Special case, set winner of the root board aka the winner of the game.
            if (Board.Coordinate == "root")
            {
                SetWinnerSelf(Board);
            }
        }
        private void SetWinnerSelf(Board board)
        {
            //Save all winning moves for both players
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

            //Check any winning pattern exists in xWins or oWins, if so set player to winner.
            foreach (string[] pattern in board.WinningPatterns)
            {
                if (xWins.Contains(pattern[0].ToString()) && xWins.Contains(pattern[1].ToString()) && xWins.Contains(pattern[2].ToString()))
                {
                    board.SetWinningPlayer("X");
                }
                else if (oWins.Contains(pattern[0].ToString()) && oWins.Contains(pattern[1].ToString()) && oWins.Contains(pattern[2].ToString()))
                {
                    board.SetWinningPlayer("O");
                }
            }
        }

        //TODO: This function does not work if the first board is of depth 1.
        public void SetWinningCells(Board board, List<string> moves)
        {
            if (moves.Count == 0)
            {
                return;
            }
            //If the length of a move is 4 (NW.X), add the moves (NW) to the boards WinningMoves
            if (moves.ElementAt(0).Length == 4)
            {
                foreach (string move in moves)
                {
                    board.AddWinningCell(move.Remove(2, 2));
                }
                return;
            }
            //If the board was won by X, save all X moves, if O won, save all O moves.
            List<string> winningMoves = new List<string>();
            if (board.WinningPlayer == "X")
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        winningMoves.Add(board.Moves[i].Split(".")[0]);
                    }
                }
            }
            if (board.WinningPlayer == "O")
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        winningMoves.Add(moves[i].Split(".")[0]);
                    }
                }
            }

            //Set this boards WinningMoves in order based on winningMoves.
            board.SetWinningCells(winningMoves);

            //For each board in this boards Cells remove the outermost part of all moves and call SetWinningMoves with that board and those moves
            foreach (Board b in board.Cells)
            {
                List<string> nextMoves = new List<string>();
                for (int i = 0; i < moves.Count; i++)
                {
                    string moveCoordinate = moves.ElementAt(i).Remove(2, Board.Moves.ElementAt(i).Length - 2);
                    if (b.GetCoordinate() == moveCoordinate)
                    {
                        string nextMove = moves[i].Remove(0, 3);
                        nextMoves.Add(nextMove);
                    }
                }
                SetWinningCells(b,nextMoves);
            }
        }
        public void SetWinningMoves(Board board)
        {
            if (board.GetCells().First().GetType().Equals(typeof(Cell)))
            {
                foreach (string cell in board.GetWinningCells())
                {
                    board.AddWinningMove(board.Coordinate + "." + cell);
                }
                return;
            }
            foreach (string cell in board.GetWinningCells())
            {
                board.AddWinningMove(board.Coordinate + "." + cell);
            }
            foreach (Board b in board.Cells)
            {
                SetWinningMoves(b);
            }
        }
        public Board GetBoard()
        {
            return Board;
        }
    }
}
