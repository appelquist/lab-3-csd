﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3_csd
{
    public class SuperBoard : IBoard
    {
        public string Coordinate { get; private set; }
        public string WinningPlayer { get; private set; }
        public int Layer { get; private set; }
        public List<IBoard> Boards { get; private set; } = new List<IBoard>();
        private List<string> WinningCells = new List<string>();
        private List<string> WinningMoves = new List<string>();

        public SuperBoard(string coordinate)
        {
            Coordinate = coordinate;
        }
        public SuperBoard()
        {
        }
        public void MakeMove(string move)
        {
            string coordinate = move.Remove(2, move.Length - 2);
            move = move.Remove(0, 3);
            if (coordinate == this.Coordinate || "root" == this.Coordinate)
            {
                foreach (IBoard board in Boards)
                {
                    board.MakeMove(move);
                }
            } 
        }
        public void SetCoordinate(string coordinate)
        {
            Coordinate = coordinate;
        }
        public void AddCell(IBoard cell)
        {
            Boards.Add(cell);
        }
        public List<IBoard> GetCells()
        {
            return Boards;
        }
        public List<string> GetWinningCells()
        {
            return WinningCells;
        }
        public void SetWinningPlayer(string player)
        {
            WinningPlayer = player;
        }
        public void AddWinningCell(string cell)
        {
            WinningCells.Add(cell);
        }
        public void SetWinningCells(List<string> winningMoves)
        {
            int nw = 0; int nc = 0; int ne = 0; int cw = 0; int cc = 0; int ce = 0; int sw = 0; int sc = 0; int se = 0;
            foreach (string move in winningMoves)
            {
                switch (move)
                {
                    case "NW":
                        nw++;
                        if (nw == 3) { WinningCells.Add(move); }
                        break;
                    case "NC":
                        nc++;
                        if (nc == 3) { WinningCells.Add(move); }
                        break;
                    case "NE":
                        ne++;
                        if (ne == 3) { WinningCells.Add(move); }
                        break;
                    case "CW":
                        cw++;
                        if (cw == 3) { WinningCells.Add(move); }
                        break;
                    case "CC":
                        cc++;
                        if (cc == 3) { WinningCells.Add(move); }
                        break;
                    case "CE":
                        ce++;
                        if (ce == 3) { WinningCells.Add(move); }
                        break;
                    case "SW":
                        sw++;
                        if (sw == 3) { WinningCells.Add(move); }
                        break;
                    case "SC":
                        sc++;
                        if (sc == 3) { WinningCells.Add(move); }
                        break;
                    case "SE":
                        se++;
                        if (se == 3) { WinningCells.Add(move); }
                        break;
                }               
            }
        }
        public List<string> GetAllWinningCells(List<string> moves)
        {
            List<string> winningPlayerMoves = new List<string>();
            List<string> winningMoves = new List<string>();
            foreach (string move in moves)
            {
                if (move.Substring(move.Length-1) == WinningPlayer)
                {
                    winningPlayerMoves.Add(move);
                }
            }
            foreach (string move in winningPlayerMoves)
            {
                foreach (IBoard board in Boards)
                {
                    if (board.GetWinningPlayer() == move.Substring(move.Length - 1) && board.GetCoordinate() == move.Substring(0, 2))
                    {
                        string next = move.Substring(3);
                        board.AddIfWinningMove(move, next, winningMoves);
                    }                      
                }
            }
            return winningMoves;
        }
        public void AddIfWinningMove(string move, string nextMove, List<string> moves)
        {
            foreach (IBoard board in Boards)
            {
                if (board.GetWinningPlayer() == move.Substring(move.Length - 1) && board.GetCoordinate() == nextMove.Substring(0, 2))
                {
                    string next = nextMove.Substring(3);
                    board.AddIfWinningMove(move, next, moves);
                }
            }
        }
        public void Clear()
        {
            WinningPlayer = "";
        }
        public string GetWinningPlayer()
        {
            return WinningPlayer;
        }

        public string GetCoordinate()
        {
            return Coordinate;
        }

        public void AddBoard(IBoard b)
        {
            Boards.Add(b);
        }
        public void SetWinners(List<string[]> winningPatterns)
        {           
            foreach (IBoard board in Boards)
            {
                board.SetWinners(winningPatterns);
            }
            List<string> xWins = new List<string>();
            List<string> oWins = new List<string>();
            foreach (IBoard b in Boards)
            {
                if (b.GetWinningPlayer() == "X")
                {
                    xWins.Add(b.GetCoordinate());
                }
                else if (b.GetWinningPlayer() == "O")
                {
                    oWins.Add(b.GetCoordinate());
                }
            }

            //Check any winning pattern exists in xWins or oWins, if so set player to winner.
            foreach (string[] pattern in winningPatterns)
            {
                if (xWins.Contains(pattern[0].ToString()) && xWins.Contains(pattern[1].ToString()) && xWins.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("X");
                }
                else if (oWins.Contains(pattern[0].ToString()) && oWins.Contains(pattern[1].ToString()) && oWins.Contains(pattern[2].ToString()))
                {
                    SetWinningPlayer("O");
                }
            }
        }
        public List<IBoard> GetAllBoards(List<IBoard> allBoards)
        {
            foreach (IBoard board in Boards)
            {
                allBoards.Add(board);
                board.GetAllBoards(allBoards);
            }
            return allBoards;
        }
        public void SetLayers(int layer)
        {
            SetLayer(layer);
            foreach (IBoard board in Boards)
            {
                board.SetLayers(layer - 1);
            }
        }

        public void SetLayer(int layer)
        {
            Layer = layer;
        }

        public int GetLayer()
        {
            return Layer;
        }
    }
}
