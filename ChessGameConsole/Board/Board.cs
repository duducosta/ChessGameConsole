using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class BoardTable
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        //Constructors
        public BoardTable(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }
         //End of contructors

        public Piece GetPiece(int line, int column)
        {
            return pieces[line, column];
        }


    }
}
