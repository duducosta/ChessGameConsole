using System;
using System.Collections.Generic;
using System.Text;


namespace Board
{
    class BoardTable
    {
        public int Lines { get; private set; }
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

        public Piece GetPiece(Position position)
        {
            return piecesArrangement[position.Line, position.Column];
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
            if (!CheckEmptyAddress(position))
            {
                Piece aux = GetPiece(position);
                GetPiece(position).Position = null;
                piecesArrangement[position.Line, position.Column] = null;
                return aux;
            }
            else
            {
                return null;
            }
        }

        /// <summary> 
        /// The test is performed outside the "ValidadePosition" method because 
        /// there may be other tests for other games, so later on we can implement a inheritance class
        /// for checkers or any other board game and crete specifics tests for each kind of game - E.Costa
        ///</summary>
        public bool CheckBoardLimits(Position position)
        {
            if (position.Line > Lines || position.Column > Columns || position.Line < 0 || position.Column < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ValidadePosition(Position position)
        {
            if (!CheckBoardLimits(position))
            {
                throw new BoardExceptions("Invalid position!");
            }

        }

        public bool CheckEmptyAddress(Position position)
        {
            ValidadePosition(position);
            if (GetPiece(position) == null)
            {
                return true; //Empty address
            }
            else
            {
                return false;
            }
        }

    }
}
