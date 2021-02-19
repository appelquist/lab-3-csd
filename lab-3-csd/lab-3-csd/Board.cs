using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class Board : ICell
    {
        public string Coordinate { get; private set; }
        public string playerOccupying { get; private set; }
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
            if (depth == 2)
            {
                for (int i = 0; i < coordinates.Length; i++)
                {
                    Cell c = new Cell(coordinates[i]);
                    this.AddCell(c);
                }
                return;
            }
            for (int i = 0; i < coordinates.Length; i++)
            {
                Board b = new Board(coordinates[i]);
                this.Clear();
                this.AddCell(b);
                b.GenerateEmptyBoard(depth - 1);
            }
        }
        //public void MakeMove(string[] moves)
        //{
        //    if (moves.Length == 0)
        //    {
        //        return;
        //    }
        //    string[] move = moves[0].Split('.');
        //    string player = move[move.Length - 1];
        //    string coordinate = move[move.Length - 2];
        //    foreach (ICell cell in Cells)
        //    {
        //        moves = moves.Skip(1).ToArray();
        //        MakeMove(moves);
        //    }
        //    if (Coordinate == coordinate)
        //    {
        //        playerOccupying = player;
        //    }
            
        //}

        public void MakeMove(string[] moves)
        {
            if (moves.Length == 0)
            {
                return;
            }

            string[] firstMove = moves[0].Split('.');
            string player = firstMove[firstMove.Length - 1];
            string coordinate = firstMove[0];
            if (firstMove.Length == 2)
            {
                foreach (ICell cell in Cells)
                {
                    cell.MakeMove(firstMove);
                }
                return;
            }


            if (coordinate == Coordinate || Coordinate == "")
            {
                firstMove = firstMove.Skip(1).ToArray();
                string firstMoveString = String.Join(".", firstMove);
                string[] firstMoveArr = new string[] { firstMoveString };
                foreach (ICell cell in Cells)
                {
                    cell.MakeMove(firstMoveArr);
                }
            }
            moves = moves.Skip(1).ToArray();
            MakeMove(moves);
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
            playerOccupying = "";
        }
    }
}
