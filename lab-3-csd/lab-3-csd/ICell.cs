using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3_csd
{
    interface ICell
    {
        void MakeMove(string[] move);
        void Clear();
        void PrintCellInfo();
    }
}
