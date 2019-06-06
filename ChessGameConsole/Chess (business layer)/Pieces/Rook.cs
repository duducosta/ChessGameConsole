using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Rook : Piece
    {
        //Constructor
        public Rook(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];
            Position virtualPosition = new Position(0, 0);

            //North
            virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 0);
            while (Board.ValidadePosition(virtualPosition) && EmptyOrEnemy(virtualPosition))
            {

                possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;
                virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 0);
                if (Board.GetPiece(virtualPosition) != null && Board.GetPiece(virtualPosition).Color != Color)
                {
                    break;
                }
            }




            return possibleMoves;
        }
    }
}
