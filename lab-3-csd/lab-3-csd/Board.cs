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
            if (depth == 1)
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

        //public Board GenerateEmptyBoard(int depth, Board board)
        //{
        //    string[] coordinates = new string[] { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        //    if (depth == 1)
        //    {
        //        for (int i = 0; i < coordinates.Length; i++)
        //        {
        //            Cell c = new Cell(coordinates[i]);
        //            this.AddCell(c);
        //        }
        //        return board;
        //    }
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Board b = new Board(coordinates[i]);
        //        board.AddCell(b);
        //        GenerateEmptyBoard(depth - 1, b);
        //    }
        //    return board;
        //}

        public void MakeMove(string[] moves)
        {
            if (moves.Length == 0)
            {
                return;
            }
            string[] move = moves[0].Split('.');
            string player = move[move.Length - 1];
            string coordinate = move[move.Length - 2];
            foreach (ICell cell in Cells)
            {
                moves = moves.Skip(1).ToArray();
                MakeMove(moves);
            }
            if (Coordinate == coordinate)
            {
                playerOccupying = player;
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
            playerOccupying = "";
        }
    }
}
