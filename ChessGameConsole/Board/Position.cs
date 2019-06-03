using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        //Constructors
        public Position (int line, int column)
        {
            Line = line;
            Column = column;
        }

        //End of constructors


        //Overrides
        public override string ToString()
        {
            return "(" + Line + "," + Column + ")";
        }
        //End of overrides

    }
}
