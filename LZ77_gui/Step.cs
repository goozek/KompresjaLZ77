using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77_gui
{
    class Step
    {
        int index;
        int matchCount;
        char symbol;

        public Step(int index, int matchCount, char symbol)
        {
            this.index = index;
            this.matchCount = matchCount;
            this.symbol = symbol;
        }
    }
}
