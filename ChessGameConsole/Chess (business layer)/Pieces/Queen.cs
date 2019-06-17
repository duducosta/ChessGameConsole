using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Queen : Piece
    {
        //Constructor
        public Queen(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "Q";
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

            //North
            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line - 1;
            }

            //South
            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Line = virtualPosition.Line + 1;
            }

            //West
            virtualPosition.ChangeToPosition(Position.Line, Position.Column - 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Column = virtualPosition.Column - 1;
            }

            //East
            virtualPosition.ChangeToPosition(Position.Line, Position.Column + 1);
            while (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {

                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
                virtualPosition.Column = virtualPosition.Column + 1;
            }

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