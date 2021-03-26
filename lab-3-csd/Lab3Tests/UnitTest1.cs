using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using lab_3_csd;
using System.Linq;

namespace Lab3Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetsCorrectOutput1Layers()
        {
            string testInput = "NW,NE,CW,CC,SW";
            List<string> Moves = new List<string>();
            InputChecker Checker = new InputChecker();
            int Depth = 0;
            string[] moves = testInput.Split(',');
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Moves.Add(moves[i] + ".X");
                }
                else
                {
                    Moves.Add(moves[i] + ".O");
                }
            }
            Depth = moves[0].Count(ch => (ch == '.'));


            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);


            BoardDirector.ConstructBoard(Moves, Depth);
            IBoard game = BoardBuilder.GetBoard();

            BoardPrinter Printer = new BoardPrinter(game, Moves);

            string ExpectePlayerWins = "1, 0";
            string ExpecteTopLevelMoves = "NW, CW, SW";
            string ExpecteAllWinningMoves = "NW, CW, SW";
            Assert.AreEqual(ExpectePlayerWins, Printer.GetPlayerWins());
            Assert.AreEqual(ExpecteTopLevelMoves, Printer.GetTopLevelWinningMoves());
            Assert.AreEqual(ExpecteAllWinningMoves, Printer.GetAllWinningMoves());
        }

        [TestMethod]
        public void GetsCorrectOutput2Layers()
        {
            string testInput = "NW.CC,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,CW.CC,SE.CC,CW.NW,CC.CC,CW.SE,CC.NW,CC.SE,CE.NW,SW.CC,CE.SE,SW.NW,SE.SE,SW.SE";
            List<string> Moves = new List<string>();
            InputChecker Checker = new InputChecker();
            int Depth = 0;
            string[] moves = testInput.Split(',');
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Moves.Add(moves[i] + ".X");
                }
                else
                {
                    Moves.Add(moves[i] + ".O");
                }
            }
            Depth = moves[0].Count(ch => (ch == '.'));


            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);


            BoardDirector.ConstructBoard(Moves, Depth);
            IBoard game = BoardBuilder.GetBoard();

            BoardPrinter Printer = new BoardPrinter(game, Moves);

            string ExpectePlayerWins = "1.3, 0.1";
            string ExpecteTopLevelMoves = "NW, CW, SW";
            string ExpecteAllWinningMoves = "NW.CC, NW.NW, NW.SE, CW.CC, CW.NW, CW.SE, SW.CC, SW.NW, SW.SE";
            Assert.AreEqual(ExpectePlayerWins, Printer.GetPlayerWins());
            Assert.AreEqual(ExpecteTopLevelMoves, Printer.GetTopLevelWinningMoves());
            Assert.AreEqual(ExpecteAllWinningMoves, Printer.GetAllWinningMoves());
        }

        [TestMethod]
        public void GetsCorrectOutput3Layers()
        {
            string testInput = "NW.NW.CC,NW.NC.CC,NW.NW.NW,NW.NE.CC,NW.NW.SE,NW.CE.CC,NW.CW.CC,NW.SE.CC,NW.CW.NW," +
                               "NW.CC.CC,NW.CW.SE,NW.CC.NW,NW.CC.SE,NW.CE.NW,NW.SW.CC,NW.CE.SE,NW.SW.NW,NW.SE.SE," +
                               "NW.SW.SE,CW.NC.CC,CW.NW.CC,CW.NE.CC,CW.NW.NW,CW.CC.NW,CW.NW.SE,CW.CC.CC,CW.SW.CC," +
                               "CW.CE.NW,CW.SW.NW,CW.CE.SE,CW.SW.SE,CW.CE.CC,CW.CW.SE,CW.SE.CC,CW.CW.CC,CW.SW.NE," +
                               "CW.CW.NW,CW.NE.SE,SW.NW.CC,SW.NC.CC,SW.NW.NW,SW.NE.CC,SW.NW.SE,SW.CE.CC,SW.CW.CC," +
                               "SW.SE.CC,SW.CW.NW,SW.CC.CC,SW.CW.SE,SW.CC.NW,SW.CC.SE,SW.CE.NW,SW.SW.CC,SW.CE.SE," +
                               "SW.SW.NW,SW.SE.SE,SW.SW.SE";
            List<string> Moves = new List<string>();
            InputChecker Checker = new InputChecker();
            int Depth = 0;
            string[] moves = testInput.Split(',');
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Moves.Add(moves[i] + ".X");
                }
                else
                {
                    Moves.Add(moves[i] + ".O");
                }
            }
            Depth = moves[0].Count(ch => (ch == '.'));


            Builder BoardBuilder = new Builder();
            Director BoardDirector = new Director(BoardBuilder);


            BoardDirector.ConstructBoard(Moves, Depth);
            IBoard game = BoardBuilder.GetBoard();

            BoardPrinter Printer = new BoardPrinter(game, Moves);

            string ExpectePlayerWins = "1.3.9, 0.0.3";
            string ExpecteTopLevelMoves = "NW, CW, SW";
            string ExpecteAllWinningMoves = "NW.NW.CC, NW.NW.NW, NW.NW.SE, NW.CW.CC, NW.CW.NW, NW.CW.SE, NW.SW.CC, NW.SW.NW, NW.SW.SE, CW.NW.CC, CW.NW.NW, CW.NW.SE," +
                                            " CW.SW.CC, CW.SW.NW, CW.SW.SE, CW.CW.SE, CW.CW.CC, CW.CW.NW, SW.NW.CC, SW.NW.NW, SW.NW.SE, SW.CW.CC, SW.CW.NW, SW.CW.SE, SW.SW.CC, SW.SW.NW, SW.SW.SE";
            Assert.AreEqual(ExpectePlayerWins, Printer.GetPlayerWins());
            Assert.AreEqual(ExpecteTopLevelMoves, Printer.GetTopLevelWinningMoves());
            Assert.AreEqual(ExpecteAllWinningMoves, Printer.GetAllWinningMoves());
        }
    }
}