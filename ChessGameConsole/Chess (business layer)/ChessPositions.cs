using System;
using System.Collections.Generic;
using System.Text;
using Chess;
using Board;

namespace Chess
{
    /// <summary>
    /// Class for translation of zero based address in C# array to chess based position (1A, 2B, etc)
    /// </summary>
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public override string ToString()
        {
            return Column + Line.ToString();
        }

        public Position TranslateChessToZeroBased()
        {
            return new Position(8 - Line, Column - 'a');
        }


    }
}
