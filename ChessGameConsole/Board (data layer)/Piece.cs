using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMovement { get; protected set; }
        public BoardTable Board { get; protected set; }

        public Piece(Color color, BoardTable board)
        {
            Position = null;
            Color = color;
            Board = board;
            QtyMovement = 0;
        }

        public void IncreaseQtyMovement()
        {
            QtyMovement++;
        }

        ///// <summary>
        ///// Checks if a position is empty or has an enemy. 
        ///// Used as first test to list the possible moves for a piece.
        ///// </summary>
        ///// <param name="position">Position to be checked</param>
        ///// <returns></returns>
        //public bool EmptyOrEnemy(Position pos)
        //{
        //    Piece piece = Board.GetPiece(pos);
        //    return piece == null || piece.Color != Color;
        //}


        ///// <summary>
        ///// Checks if a position has an enemy. 
        ///// Used as first test to list the possible moves for a piece.
        ///// </summary>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //public bool HasEnemy(Position position)
        //{
        //    return Board.GetPiece(position).Color != Color;
        //}
        ///// <summary>
        ///// Checks if a position is empty. 
        ///// Used as first test to list the possible moves for a piece.
        ///// Is was possible to used other ways, 
        ///// but it was decided to create this method to normalize the code with same structure methods.
        ///// </summary>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //public bool IsEmpty(Position position)
        //{
        //    return Board.GetPiece(position) == null;
        //}

        public abstract bool[,] PossibleMoves();




    }
}
