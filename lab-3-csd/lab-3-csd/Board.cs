using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    class Board : IBoard
    {
        public string Coordinate { get; private set; }
        public List<Cell> Cells = new List<Cell>() { new Cell("NW"), new Cell("NC"), new Cell("NE"), new Cell("CW"), new Cell("CC"), new Cell("CE"), new Cell("SW"), new Cell("SC"), new Cell("SE") };
        public string WinningPlayer { get; private set; }
        public Board()
        {
        }
        public void PrintCellInfo()
        {
            Console.WriteLine(Coordinate);
            Console.WriteLine(Coordinate);
        }

        public void MakeMoves(List<string> moves)
        {
            string coordinate = moves.First().Remove(2);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (Cell cell in Cells)
                {
                    cell.MakeMove(moves);
                }
            }        
        }

        //public void Clear()
        //{
        //    PlayerOccupying = "";
        //}

        //public string GetWinningPlayer()
        //{
        //    return PlayerOccupying;
        //}

        public string GetCoordinate()
        {
            return Coordinate;
        }

        public void SetWinningCells(List<string> moves)
        {
            return;
        }

        public void AddBoard(IBoard b)
        {
            throw new NotImplementedException();
        }

        public void SetCoordinate(string coordinate)
        {
            Coordinate = coordinate;
        }

        public List<IBoard> GetCells()
        {
            return new List<IBoard>() { this };
        }
    }
}
