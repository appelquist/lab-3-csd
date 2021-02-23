using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    class Cell : ICell
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

        public void MakeMove(string[] move)
        {
            string player = move[1];
            string coordinate = move[0];
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

        public void SetWinningMoves(List<string> moves)
        {
            return;
        }
    }
}
