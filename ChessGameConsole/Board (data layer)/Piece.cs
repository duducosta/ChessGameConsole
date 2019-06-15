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

        public abstract bool[,] PossibleMoves();

        public bool HasPossibleMoves()
        {
            bool[,] possibleMoves = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

    }
}
