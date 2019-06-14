using System;
using System.Collections.Generic;
using System.Text;


namespace Board
{
    class BoardTable
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] piecesArrangement;

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

        public Piece GetPiece(Position pos)
        {
            return piecesArrangement[pos.Line, pos.Column];
        }

        public bool CheckEmptyAddress(Position pos) //Equivalente ao existepeca()
        {
            ValidadePosition(pos);
            return GetPiece(pos) == null;
        }

        public void AddressPiece(Piece piece, Position position)
        {
            if (!CheckEmptyAddress(position))
            {
                throw new BoardExceptions("This position is ocupied by another piece!");
            }
            piecesArrangement[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }
            Piece auxPiece = GetPiece(position);
            auxPiece.Position = null;
            piecesArrangement[position.Line, position.Column] = null;
            return auxPiece;
        }

        public bool CheckBoardLimits(Position position)
        {
            if (position.Line >= Lines || position.Column >= Columns || position.Line < 0 || position.Column < 0)
            {
                return false;
            }
            return true;

        }

        public void ValidadePosition(Position pos)
        {
            if (!CheckBoardLimits(pos))
            {
                throw new BoardExceptions("Invalid position!");
            }
            
        }



   







    }
}
