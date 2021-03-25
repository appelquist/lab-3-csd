using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab_3_csd
{
    class InputChecker
    {
        public InputChecker()
        {

        }

        public bool ContainsOnlyValidCharacters(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                string[] splits = moves[i].Split(".");
                for (int j = 0; j < splits.Length; j++)
                {
                    if (splits[j] != "NW" && splits[j] != "NC" && splits[j] != "NE" && splits[j] != "CW" && splits[j] != "CC" && splits[j] != "CE" && splits[j] != "SW" && splits[j] != "SC" && splits[j] != "SE")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool AllMovesEqualLength(string[] moves)
        {
            int length = moves[0].Length;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].Length != length)
                {
                    return false;
                }
            }
            return true;
        }
        public bool NoDuplicateMoves(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                for (int j = i + 1; j < moves.Length; j++)
                {
                    if (moves[i] == moves[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
