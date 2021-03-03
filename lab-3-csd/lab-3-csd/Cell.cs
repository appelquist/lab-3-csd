using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Cell
    {
        public string Coordinate { get; private set; }
        public string PlayerOccupying { get; private set; }

        public Cell(string coordinate)
        {
            Coordinate = coordinate;
        }

        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
            Console.WriteLine(PlayerOccupying);
        }

        public void MakeMove(string move)
        {
            string player = move.Remove(0, 3);
            string coordinate = move.Remove(2, 2);

            if (Coordinate == coordinate)
            {
                PlayerOccupying = player;
                return;
            }
        }

        public void Clear()
        {
            PlayerOccupying = "";
        }

        public string GetWinningPlayer()
        {
            return PlayerOccupying;
        }

        public string GetCoordinate()
        {
            return Coordinate;
        }
    }
}
