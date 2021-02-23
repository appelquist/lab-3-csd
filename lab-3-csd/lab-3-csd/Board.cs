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
        private List<string> WinningMoves = new List<string>();
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
        //public void MakeMove(List<string> moves)
        //{
        //    //Base case - if all moves have been gone through, return
        //    if (moves.Count == 0)
        //    {
        //        return;
        //    }

        //    List<string> firstMove = new List<string>() { moves.First() };
        //    string coordinate = firstMove.First().Remove(2);

        //    //Special case - Fill out each cell under root with the moves.
        //    if (Coordinate == "root")
        //    {
        //        foreach (ICell cell in Cells)
        //        {
        //            cell.MakeMove(moves);
        //        }
        //    }

        //    //If not root, check if this cell hase the same coordinate as the move, if so: remove the first coordinate of the move
        //    //(NW.CC.X -> CC.X), and for each children of this cell, try to place that move.
        //    if (coordinate == Coordinate)
        //    {
        //        firstMove[0] = firstMove.First().Remove(0, 3);
        //        foreach (ICell cell in Cells)
        //        {
        //            cell.MakeMove(firstMove);
        //        }
        //    }
        //    //Remove firstMove from moves and continue
        //    moves.RemoveAt(0);
        //    MakeMove(moves);
        //}
        public void MakeMove(List<string> moves)
        {
            //Base case - if all moves have been gone through, return
            if (moves.Count == 0)
            {
                return;
            }

            List<string> firstMove = new List<string>() { moves.First() };
            string coordinate = firstMove.First().Remove(2);

            //Special case - Fill out each cell under root with the moves.
            if (Coordinate == "root")
            {
                foreach (ICell cell in Cells)
                {
                    cell.MakeMove(moves);
                }
            }

            //If not root, check if this cell hase the same coordinate as the move, if so: call MakeMove on all its cells with the list of moves;
            if (Coordinate == coordinate)
            {
                foreach (ICell cell in Cells)
                {               
                    cell.MakeMove(moves);
                }
            }
            //Remove firstMove from moves and continue
            List<string> tail = moves.ToList();
            tail.RemoveAt(0);
            MakeMove(tail);
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

        public void SetWinningMoves(List<string> moves)
        {
            if (moves.Count == 0)
            {
                return;
            }
            if (moves.ElementAt(0).Length == 4)
            {
                foreach (string move in moves)
                {
                    WinningMoves.Add(move.Remove(2, 2));
                }
                return;
            }
            List<string> winningMoves = new List<string>();
            if (WinningPlayer == "X")
            {
                for(int i = 0; i < moves.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        winningMoves.Add(moves[i].Split(".")[0]);
                    }
                }
            }
            if (WinningPlayer == "O")
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        winningMoves.Add(moves[i].Split(".")[0]);
                    }
                }
            }

            SetWinningMovesSelf(winningMoves);

            foreach (ICell board in Cells)
            {
                List<string> nextMoves = new List<string>();
                for (int i = 0; i < moves.Count; i++)
                {
                    string moveCoordinate = moves.ElementAt(i).Remove(2, moves.ElementAt(i).Length - 2);
                    if (board.GetCoordinate() == moveCoordinate)
                    {
                        string nextMove = moves[i].Remove(0, 3);
                        nextMoves.Add(nextMove);
                    }
                    
                }
                board.SetWinningMoves(nextMoves);
            }
        }

        private void SetWinningMovesSelf(List<string> winningMoves)
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
    }
}
