using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Board : ICell
    {
        public string Coordinate { get; private set; }
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
            for (int i = 0; i < 9; i++)
            {
                Board b = new Board(coordinates[i]);
                this.AddCell(b);
                b.GenerateEmptyBoard(depth - 1);
            }
        }

        public void SetMoves(string[] moves)
        {

        }


        public void PrintCellInfo()
        {  
            foreach (ICell cell in Cells)
            {
                Console.Write(Coordinate);
                cell.PrintCellInfo();
            }
        }
    }
}
