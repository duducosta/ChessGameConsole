using System;
using System.Collections.Generic;
using System.Text;
using Board;
using ChessGameConsole;


namespace Chess
{
    class ChessGame
    {
        public BoardTable Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }
        public HashSet<Piece> GamePieces { get; set; }
        public HashSet<Piece> CapturedPieces { get; set; }
        public bool PlayerInCheck { get; private set; }
        public Piece VulnerableToEnPassant { get; private set; }


        public ChessGame()
        {
            Board = new BoardTable(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            GamePieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            StartPieces();
            PlayerInCheck = false;
            VulnerableToEnPassant = null;
        }

        public Piece ChessMove(Position origin, Position destiny)
        {
            Piece movedPiece = Board.RemovePiece(origin);
            movedPiece.IncreaseQtyMovement();
            Piece takenPiece = Board.RemovePiece(destiny);
            Board.AddressPiece(movedPiece, destiny);
            if (takenPiece != null)
            {
                CapturedPieces.Add(takenPiece);
            }

            //Special move: Castling
            ////Short Castling
            if (movedPiece is King && destiny.Column == origin.Column + 2)
            {
                Position rookOrigin = new Position(origin.Line, origin.Column + 3);
                Position rookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece movedRook = Board.RemovePiece(rookOrigin);
                movedRook.IncreaseQtyMovement();
                Board.AddressPiece(movedRook, rookDestiny);
            }
            ////Long Castling
            if (movedPiece is King && destiny.Column == origin.Column - 2)
            {
                Position rookOrigin = new Position(origin.Line, origin.Column - 4);
                Position rookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece movedRook = Board.RemovePiece(rookOrigin);
                movedRook.IncreaseQtyMovement();
                Board.AddressPiece(movedRook, rookDestiny);
            }

            //Special move: En passant
            if (movedPiece is Pawn)
            {
                if (origin.Column != destiny.Column)
                {
                    Position EnPassantCapture;
                    if (movedPiece.Color == Color.White)
                    {
                        EnPassantCapture = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        EnPassantCapture = new Position(destiny.Line - 1, destiny.Column);
                    }
                    takenPiece = Board.RemovePiece(EnPassantCapture);
                    CapturedPieces.Add(takenPiece);
                }
            }

            return takenPiece;
        }

        public void UndoChessMove(Position origin, Position destiny, Piece takenPiece)
        {
            Piece returnedPiece = Board.RemovePiece(destiny);
            returnedPiece.DecreaseQtyMovement();
            Board.AddressPiece(returnedPiece, origin);
            if (takenPiece != null)
            {
                Board.AddressPiece(takenPiece, destiny);
                CapturedPieces.Remove(takenPiece);
            }

            //Special move: Castling
            //Short Castling
            if (returnedPiece is King && destiny.Column == origin.Column + 2)
            {
                Position rookOrigin = new Position(origin.Line, origin.Column + 3);
                Position rookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece movedRook = Board.RemovePiece(rookDestiny);
                movedRook.DecreaseQtyMovement();
                Board.AddressPiece(movedRook, rookOrigin);
            }
            //Long Castling
            if (returnedPiece is King && destiny.Column == origin.Column - 2)
            {
                Position rookOrigin = new Position(origin.Line, origin.Column - 4);
                Position rookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece movedRook = Board.RemovePiece(rookDestiny);
                movedRook.DecreaseQtyMovement();
                Board.AddressPiece(movedRook, rookOrigin);
            }

            //Special move: En passant
            if (returnedPiece is Pawn)
            {
                if (origin.Column != destiny.Column && takenPiece == VulnerableToEnPassant)
                {
                    Piece EnPassantCapture = Board.RemovePiece(destiny);
                    Position EnPassantReturnPosition;
                    if (returnedPiece.Color == Color.White)
                    {
                        EnPassantReturnPosition = new Position(3, destiny.Column);
                    }
                    else
                    {
                        EnPassantReturnPosition = new Position(4, destiny.Column);
                    }
                    Board.AddressPiece(EnPassantCapture, EnPassantReturnPosition);
                }
            }


        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece takenPiece = ChessMove(origin, destiny);
            if (IsInCheck(CurrentPlayer))
            {
                UndoChessMove(origin, destiny, takenPiece);
                throw new BoardExceptions("You can not put your self in check");
            }
            if (IsInCheck(EnemyIs(CurrentPlayer)))
            {
                PlayerInCheck = true;
            }
            if (IsInCheckMate(EnemyIs(CurrentPlayer)))
            {
                EndGame = true;
            }
            else
            {
                Turn++;
                MudaJogador();
            }

            //Special move: en passant
            Piece movedPiece = Board.GetPiece(destiny);
            if (movedPiece is Pawn && (destiny.Line == origin.Line + 2 || destiny.Line == origin.Line - 2))
            {
                VulnerableToEnPassant = movedPiece;
            }
            else
            {
                VulnerableToEnPassant = null;
            }
        }

        public void MudaJogador()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPieces = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    capturedPieces.Add(piece);
                }
            }
            return capturedPieces;
        }

        public HashSet<Piece> InBoardPiecesByColor(Color color)
        {
            HashSet<Piece> inBoardPieces = new HashSet<Piece>();
            foreach (Piece piece in GamePieces)
            {
                if (piece.Color == color)
                {
                    inBoardPieces.Add(piece);
                }
            }
            inBoardPieces.ExceptWith(CapturedPiecesByColor(color));
            return inBoardPieces;
        }

        public Color EnemyIs(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            return Color.White;
        }

        private Piece FindKing(Color color)
        {
            foreach (Piece piece in InBoardPiecesByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece King = FindKing(color);
            foreach (Piece piece in InBoardPiecesByColor(EnemyIs(color)))
            {
                bool[,] aux = piece.PossibleMoves();
                if (aux[King.Position.Line, King.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in InBoardPiecesByColor(color))
            {
                bool[,] aux = piece.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (aux[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ChessMove(origin, destiny);
                            bool isIncheck = IsInCheck(color);
                            UndoChessMove(origin, destiny, capturedPiece);
                            if (!isIncheck)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }

        public void StartNewPiece(char column, int line, Piece piece)
        {
            Board.AddressPiece(piece, new ChessPosition(column, line).TranslateChessToZeroBased());
            GamePieces.Add(piece);
        }

        public void StartPieces()
        {
            StartNewPiece('a', 8, new Rook(Color.Black, Board));
            StartNewPiece('h', 8, new Rook(Color.Black, Board));
            //StartNewPiece('b', 8, new Knight(Color.Black, Board));
            //StartNewPiece('g', 8, new Knight(Color.Black, Board));
            //StartNewPiece('c', 8, new Bishop(Color.Black, Board));
            //StartNewPiece('f', 8, new Bishop(Color.Black, Board));
            //StartNewPiece('d', 8, new Queen(Color.Black, Board));
            StartNewPiece('e', 8, new King(Color.Black, Board, this));
            StartNewPiece('b', 4, new Pawn(Color.Black, Board, this)); //'b', 7,
            StartNewPiece('c', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('d', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('e', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('a', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('f', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('g', 7, new Pawn(Color.Black, Board, this));
            StartNewPiece('h', 7, new Pawn(Color.Black, Board, this));

            StartNewPiece('a', 1, new Rook(Color.White, Board));
            StartNewPiece('h', 1, new Rook(Color.White, Board));
            //StartNewPiece('b', 1, new Knight(Color.White, Board));
            //StartNewPiece('g', 1, new Knight(Color.White, Board));
            //StartNewPiece('c', 1, new Bishop(Color.White, Board));
            //StartNewPiece('f', 1, new Bishop(Color.White, Board));
            //StartNewPiece('d', 1, new Queen(Color.White, Board));
            StartNewPiece('e', 1, new King(Color.White, Board, this));
            StartNewPiece('b', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('c', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('d', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('e', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('a', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('f', 2, new Pawn(Color.White, Board, this));
            StartNewPiece('g', 5, new Pawn(Color.White, Board, this)); //'g', 2,
            StartNewPiece('h', 2, new Pawn(Color.White, Board, this));
        }



        public void ValidadeOrigin(Position position)
        {
            if (Board.GetPiece(position) == null)
            {
                throw new BoardExceptions("There is no piece on this position");
            }
            if (Board.GetPiece(position).Color != CurrentPlayer)
            {
                throw new BoardExceptions("The current move is to be done by the " + CurrentPlayer + " player");
            }
            if (!Board.GetPiece(position).HasPossibleMoves())
            {
                throw new BoardExceptions("This piece has no possible moves");
            }
        }

        public void ValidateDestiny(Position origin, Position destiny)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardExceptions("Invalid destiny position");
            }
        }
    }
}
