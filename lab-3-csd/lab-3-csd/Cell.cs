using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Cell : ICell
    {
        public string Coordinate { get; private set; }

        public Cell(string coordinate)
        {
            Coordinate = coordinate;
        }

        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
        }
    }
}
