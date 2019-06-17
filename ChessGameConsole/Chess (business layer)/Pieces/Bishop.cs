using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Bishop : Piece
    {
        //Constructor
        public Bishop(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "B";
        }

        private bool EmptyOrEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];
            Position virtualPosition = new Position(0, 0);

            //North-east
            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line - 1;
                virtualPosition.Column = virtualPosition.Column + 1;
            }

            //South-east
            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column + 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line + 1;
                virtualPosition.Column = virtualPosition.Column + 1;
            }

            //North-West
            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column - 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line - 1;
                virtualPosition.Column = virtualPosition.Column - 1;
            }

            //South-west
            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column - 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {

                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line + 1;
                virtualPosition.Column = virtualPosition.Column - 1;
            }
            return possibleMoves;
        }
    }
}
