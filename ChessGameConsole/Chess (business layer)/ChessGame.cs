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


        public ChessGame()
        {
            Board = new BoardTable(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            GamePieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            StartPieces();
        }

        public void ChessMove(Position origin, Position destiny)
        {
            Piece movedPiece = Board.RemovePiece(origin);
            movedPiece.IncreaseQtyMovement();
            Piece takenPiece = Board.RemovePiece(destiny);
            Board.AddressPiece(movedPiece, destiny);
            if (takenPiece != null)
            {
                CapturedPieces.Add(takenPiece);
            }
        }

        public void MakeMove(Position origin, Position destiny)
        {
            ChessMove(origin, destiny);
            Turn++;
            MudaJogador();
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
            StartNewPiece('e', 8, new King(Color.Black, Board));
            //StartNewPiece('a', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('b', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('c', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('d', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('e', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('f', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('g', 7, new Pawn(Color.Black, Board));
            //StartNewPiece('h', 7, new Pawn(Color.Black, Board));

            StartNewPiece('a', 1, new Rook(Color.White, Board));
            StartNewPiece('h', 1, new Rook(Color.White, Board));
            //StartNewPiece('b', 1, new Knight(Color.White, Board));
            //StartNewPiece('g', 1, new Knight(Color.White, Board));
            //StartNewPiece('c', 1, new Bishop(Color.White, Board));
            //StartNewPiece('f', 1, new Bishop(Color.White, Board));
            //StartNewPiece('d', 1, new Queen(Color.White, Board));
            StartNewPiece('e', 1, new King(Color.White, Board));
            //StartNewPiece('a', 2, new Pawn(Color.White, Board));
            //StartNewPiece('b', 2, new Pawn(Color.White, Board));
            //StartNewPiece('c', 2, new Pawn(Color.White, Board));
            //StartNewPiece('d', 2, new Pawn(Color.White, Board));
            //StartNewPiece('e', 2, new Pawn(Color.White, Board));
            //StartNewPiece('f', 2, new Pawn(Color.White, Board));
            //StartNewPiece('g', 2, new Pawn(Color.White, Board));
            //StartNewPiece('h', 2, new Pawn(Color.White, Board));
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
