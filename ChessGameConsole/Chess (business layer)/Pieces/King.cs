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
            return "K";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];
            Position virtualPosition = new Position(Position.Line, Position.Column);

            //North

            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 0);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //South

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column + 0);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //East

            virtualPosition.ChangeToPosition(Position.Line +0, Position.Column + 1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //West
            virtualPosition.ChangeToPosition(Position.Line + 0, Position.Column - 1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //NW

            virtualPosition.ChangeToPosition(Position.Line -1, Position.Column -1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //NE

            virtualPosition.ChangeToPosition(Position.Line -1, Position.Column + 1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //SE

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column + 1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            //SW

            virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column - 1);
            if (EmptyOrEnemy(virtualPosition) && Board.ValidadePosition(virtualPosition))
            {
                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
            }

            return possibleMoves;
        }

    }
}
