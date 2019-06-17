using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class King : Piece
    {

        private ChessGame Game;
        //Constructor
        public King(Color color, BoardTable board, ChessGame game) : base(color, board)
        {
            Game = game;
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

            //Special move: Castling
            if (QtyMovement ==0 && !Game.PlayerInCheck)
            {
                //Short Castling
                Position RookPosition = new Position(Position.Line, Position.Column + 3);
                if (CastlingCheck(RookPosition))
                {
                    Position pos1 = new Position(Position.Line, Position.Column + 1);
                    Position pos2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.GetPiece(pos1)==null && Board.GetPiece(pos2)==null)
                    {
                        possibleMoves[Position.Line, Position.Column + 2] = true;
                    }
                }

                //Long Castling
                RookPosition = new Position(Position.Line, Position.Column -4);
                if (CastlingCheck(RookPosition))
                {
                    Position pos1 = new Position(Position.Line, Position.Column - 1);
                    Position pos2 = new Position(Position.Line, Position.Column - 2);
                    Position pos3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null && Board.GetPiece(pos3) == null)
                    {
                        possibleMoves[Position.Line, Position.Column -2] = true;
                    }
                }
            }


            return possibleMoves;
        }


        private bool CastlingCheck(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.QtyMovement == 0;
                

                
        }
    }
}
