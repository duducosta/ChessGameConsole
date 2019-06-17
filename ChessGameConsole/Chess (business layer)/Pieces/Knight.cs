using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Knight : Piece
    {
        //Constructor
        public Knight(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "K";
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

            //North-right

            virtualPosition.ChangeToPosition(Position.Line - 2, Position.Column+1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //North-left

            virtualPosition.ChangeToPosition(Position.Line-2, Position.Column-1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //East-up

            virtualPosition.ChangeToPosition(Position.Line-1, Position.Column + 2);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //East-down
            virtualPosition.ChangeToPosition(Position.Line+1, Position.Column +2);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //South-right

            virtualPosition.ChangeToPosition(Position.Line +2, Position.Column +1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //South-left

            virtualPosition.ChangeToPosition(Position.Line +2, Position.Column -1);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //West-down

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column -2);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //West-up

            virtualPosition.ChangeToPosition(Position.Line -1, Position.Column -2);
            if (Board.CheckBoardLimits(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }
            return possibleMoves;
        }
    }
}