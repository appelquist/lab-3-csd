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

        public void MakeMove(List<string> moves)
        {
            string move = moves[0];
            string player = move.Remove(0, move.Length - 1);
            move = move.Remove(move.Length - 2,2);
            string coordinate = move.Remove(0, move.Length - 2);
            
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
