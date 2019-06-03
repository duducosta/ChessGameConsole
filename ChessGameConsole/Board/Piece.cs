using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMovement { get; protected set; }
        public BoardTable Board { get; protected set; }

        public Piece(Position position, Color color, int qtyMovement, BoardTable board)
        {
            Position = position;
            Color = color;
            Board = board;
        }
    }
}
