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

        public void AddCell(ICell cell)
        {
            Cells.Add(cell);
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
