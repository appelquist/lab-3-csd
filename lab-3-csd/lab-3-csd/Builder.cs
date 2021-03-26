using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    public class Builder : IBoardBuilder
    {
        private IBoard Board;
        private string[] Coordinates = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        
        public Builder()
        {
            Reset();
        }

        public void Reset()
        {
            Board = new SuperBoard();
        }
        public void SetCoordinate(string coordinate)
        {
            Board.SetCoordinate(coordinate);
        }
        public void GenerateEmptyBoard(int depth)
        {
            //Base case 1 - Create single board
            if (depth == 0)
            {
                this.Board = new Board();
                return;
            }
            //Base case 2 - if one layer above bottom, fill out bottom layer with leafs(Board)
            if (depth == 1)
            {
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    Board b = new Board();
                    b.SetCoordinate(Coordinates[i]);
                    this.Board.AddBoard(b);
                }
                return;
            }
            //Else - Create a Builder, set coordinate, add that Builders Board to this Boards Cells and genererate boards for those boards
            for (int i = 0; i < Coordinates.Length; i++)
            {
                Builder b = new Builder();
                b.SetCoordinate(Coordinates[i]);
                this.Board.AddBoard(b.Board);
                b.GenerateEmptyBoard(depth - 1);
            }
        }

        public void SetLayers(int depth)
        {
            if (depth == 0)
            {
                Board.SetLayer(1);
            }
            else
            {
                Board.SetLayer(depth + 1);
                foreach (IBoard board in Board.GetCells())
                {
                    board.SetLayers(depth);
                }
            }        
        }

        public void MakeMoves(List<string> moves)
        {
            //Base case - if all moves have been gone through, return
            if (moves.Count == 0)
            {
                return;
            }
            string move = moves.First();
            foreach (IBoard b in this.Board.GetCells())
            {
                 b.MakeMove(move);
            }

            //Remove firstMove from moves and continue
            List<string> tail = moves.ToList();
            tail.RemoveAt(0);
            MakeMoves(tail);
        }

        public void SetWinners(List<string[]> winningPatterns)
        {   
            //Set winners for root cells
            foreach (IBoard board in Board.GetCells())
            {
                board.SetWinners(winningPatterns);
            }
            //Set winner for root 
            List<string> xWins = new List<string>();
            List<string> oWins = new List<string>();
            foreach (IBoard b in Board.GetCells())
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
                    Board.SetWinningPlayer("X");
                }
                else if (oWins.Contains(pattern[0].ToString()) && oWins.Contains(pattern[1].ToString()) && oWins.Contains(pattern[2].ToString()))
                {
                    Board.SetWinningPlayer("O");
                }
            }
        }
        //TODO: This function does not work if the first board is of depth 1.
        public void SetWinningCells(IBoard board, List<string> moves)
        {
            if (moves.Count == 0)
            {
                return;
            }
            //If the length of a move is 4 (NW.X) set the winning cells of that board.
            if (moves.ElementAt(0).Length == 4)
            {
                //for(int i = 0; i < moves.Count; i++)
                //{
                //    moves[i] = moves[i].Remove(2);
                //}
                board.SetWinningCells(moves);
                return;
            }
            //If the board was won by X, save all X moves, if O won, save all O moves.
            List<string> winningMoves = new List<string>();
            if (board.GetWinningPlayer() == "X")
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    string player = moves[i].Remove(0, moves[i].Length - 1);
                    if (player == "X")
                    {
                        winningMoves.Add(moves[i].Split(".")[0]);
                    }
                }
            }
            if (board.GetWinningPlayer() == "O")
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    string player = moves[i].Remove(0, moves[i].Length - 1);
                    if (player == "O")
                    {
                        winningMoves.Add(moves[i].Split(".")[0]);
                    }
                }
            }

            //Set this boards WinningMoves in order based on winningMoves.
            board.SetWinningCells(winningMoves);

            //For each board in this boards Cells remove the outermost part of all moves and call SetWinningMoves with that board and those moves
            foreach (IBoard b in board.GetCells())
            {
                List<string> nextMoves = new List<string>();
                for (int i = 0; i < moves.Count; i++)
                {
                    string moveCoordinate = moves.ElementAt(i).Remove(2);
                    if (b.GetCoordinate() == moveCoordinate)
                    {
                        string nextMove = moves[i].Remove(0, 3);
                        nextMoves.Add(nextMove);
                    }
                }
                SetWinningCells(b, nextMoves);
            }
        }
        public IBoard GetBoard()
        {
            return Board;
        }
    }
}
