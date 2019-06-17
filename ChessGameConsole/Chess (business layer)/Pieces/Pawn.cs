using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Pawn : Piece
    {
        private ChessGame Game;
        //Constructor
        public Pawn(Color color, BoardTable board, ChessGame game) : base(color, board)
        {
            Game = game;
        }

        //End of contructors


        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool IsEmpty(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];
            Position virtualPosition = new Position(0, 0);

            //Check white pieces - only move North
            if (Color == Color.White)
            {
                //Inital move allow 2 squares
                virtualPosition.ChangeToPosition(Position.Line - 2, Position.Column);
                if (Board.CheckBoardLimits(virtualPosition) && QtyMovement == 0 && IsEmpty(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Regular move allow 1 square
                virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column);
                if (Board.CheckBoardLimits(virtualPosition) && IsEmpty(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Diagonal capture - North-east
                virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column + 1);
                if (Board.CheckBoardLimits(virtualPosition) && HasEnemy(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Diagonal capture - North-west
                virtualPosition.ChangeToPosition(Position.Line - 1, Position.Column - 1);
                if (Board.CheckBoardLimits(virtualPosition) && HasEnemy(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }


                //Special move: En passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.CheckBoardLimits(left) && HasEnemy(left) && Board.GetPiece(left) == Game.VulnerableToEnPassant)
                    {
                        possibleMoves[Position.Line - 1, Position.Column - 1] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.CheckBoardLimits(right) && HasEnemy(right) && Board.GetPiece(right) == Game.VulnerableToEnPassant)
                    {
                        possibleMoves[Position.Line - 1, Position.Column + 1] = true;
                    }
                }


            }

            //Check black pieces - only move South
            if (Color == Color.Black)
            {
                //Inital move allow 2 squares
                virtualPosition.ChangeToPosition(Position.Line + 2, Position.Column);
                if (Board.CheckBoardLimits(virtualPosition) && QtyMovement == 0 && IsEmpty(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Regular move allow 1 square
                virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column);
                if (Board.CheckBoardLimits(virtualPosition) && IsEmpty(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Diagonal capture - South-east
                virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column + 1);
                if (Board.CheckBoardLimits(virtualPosition) && HasEnemy(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Diagonal capture - South-west
                virtualPosition.ChangeToPosition(Position.Line + 1, Position.Column - 1);
                if (Board.CheckBoardLimits(virtualPosition) && HasEnemy(virtualPosition))
                {
                    possibleMoves[virtualPosition.Line, virtualPosition.Column] = true;

                }

                //Special move: En passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.CheckBoardLimits(left) && HasEnemy(left) && Board.GetPiece(left) == Game.VulnerableToEnPassant)
                    {
                        possibleMoves[Position.Line + 1, Position.Column - 1] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.CheckBoardLimits(right) && HasEnemy(right) && Board.GetPiece(right) == Game.VulnerableToEnPassant)
                    {
                        possibleMoves[Position.Line + 1, Position.Column + 1] = true;
                    }
                }
            }





                return possibleMoves;
        }
    }
}