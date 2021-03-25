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
        
        string testInput = "NW.CC,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,CW.CC,SE.CC,CW.NW,CC.CC,CW.SE,CC.NW,CC.SE,CE.NW,SW.CC,CE.SE,SW.NW,SE.SE,SW.SE";
        [TestMethod]
        public void HasCorrectWinner()
        {
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

            string ExpectedWinner = "X";
            Assert.AreEqual(ExpectedWinner, game.GetWinningPlayer());
        }
    }
}
