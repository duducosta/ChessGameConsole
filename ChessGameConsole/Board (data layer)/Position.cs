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

        /// <summary>
        /// Methos create to facilitate the navigation on the board.
        /// Just change the coordinates of a position.
        /// Do not use to move pices around the board!
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        public void ChangeToPosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

    }
}
