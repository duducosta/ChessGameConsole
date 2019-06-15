using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class King : Piece
    {
        //Constructor
        public King(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors

        
        public override string ToString()
        {
            return "@";
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
            if (Board.CheckBoardLimits(virtualPosition)&& EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //South

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //East

            virtualPosition.ChangeToPosition(Position.Line, Position.Column + 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //West
            virtualPosition.ChangeToPosition(Position.Line, Position.Column - 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //NW

            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column - 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //NE

            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //SE

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column + 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //SW

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column - 1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            return possibleMoves;
        }

    }
}
