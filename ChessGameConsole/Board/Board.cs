using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class BoardTable
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] piecesArrangement;

        //Constructors
        public BoardTable(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            piecesArrangement = new Piece[lines, columns];
        }
         //End of contructors

        public Piece GetPiece(int line, int column)
        {
            return piecesArrangement[line, column];
        }

        public void addressPiece(Piece piece, Position position)
        {
            piecesArrangement[position.Line, position.Column] = piece;
            piece.Position = position;
        }

    }
}
