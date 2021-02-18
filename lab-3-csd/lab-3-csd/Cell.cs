using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Cell : ICell
    {
        public string Coordinate { get; private set; }
        public string playerOccupying { get; private set; }

        public Cell(string coordinate)
        {
            Coordinate = coordinate;
        }

        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
            Console.WriteLine(playerOccupying);
        }

        public void MakeMove(string[] move)
        {
            string player = move[move.Length - 1];
            string coordinate = move[move.Length - 2];
            playerOccupying = player;
            if (Coordinate == coordinate)
            {
                playerOccupying = player;
            }
        }

        public void Clear()
        {
            playerOccupying = "";
        }
    }
}
