using System;
using System.Collections.Generic;
using System.Text;
using Board;
using ChessGameConsole;

namespace Chess
{
    class ChessGame
    {
        public BoardTable Board { get; set; }
        public int Turn { get; set; }
        public Color CurrentPlayer { get; set; }
        public bool EndGame { get; set; }

        public ChessGame()
        {
            Board = new BoardTable(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            StartPieces();
        }
                                                                                                    
        //public void PlayerMove()
        //{
            //Console.WriteLine();
            //Console.Write("Which position you which to move FROM: ");
            //string aux = Console.ReadLine();
            //ChessPosition chessOrigin = 
            //    new ChessPosition(char.Parse(aux.Substring(0, 1)), int.Parse(aux.Substring(1, 1)));
            //Console.Clear();
            //ScreenController.PrintBoard(Board);
            // ScreenController.PrintBoard(Board, Board.GetPiece(chessOrigin.TranslateChessToZeroBased()).PossibleMoves());

        //    Console.Write("Which position you which to move TO: ");
        //    aux = Console.ReadLine();
        //    ChessPosition chessDestiny =
        //        new ChessPosition(char.Parse(aux.Substring(0, 1)), int.Parse(aux.Substring(1, 1)));

        //    ChessMove(chessOrigin.TranslateChessToZeroBased(), chessDestiny.TranslateChessToZeroBased());
        //}

        public void ChessMove(Position origin, Position destiny)
        {
            Piece movedPiece = Board.RemovePiece(origin); //tratar erro quando apontar uma casa vazia
            movedPiece.IncreaseQtyMovement();
            Piece takenPiece = Board.RemovePiece(destiny);
            Board.AddressPiece(movedPiece, destiny);
            Turn++;
        }

        public void StartPieces()
        {
            Board.AddressPiece(new Rook(Color.Black, Board), new ChessPosition('e',5).TranslateChessToZeroBased());  //Posição correta é a8, somente para teste deixar nessa posição
            //Board.AddressPiece(new Rook(Color.Black, Board), new ChessPosition('h',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Knight(Color.Black, Board), new ChessPosition('b',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Knight(Color.Black, Board), new ChessPosition('g',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Bishop(Color.Black, Board), new ChessPosition('c',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Bishop(Color.Black, Board), new ChessPosition('f',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Queen(Color.Black, Board), new ChessPosition('d',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new King(Color.Black, Board), new ChessPosition('e',8).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('a',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('b',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('c',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('d',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('e',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('f',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('g',7).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.Black, Board), new ChessPosition('h',7).TranslateChessToZeroBased());

            //Board.AddressPiece(new Rook(Color.White, Board), new ChessPosition('a', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Rook(Color.White, Board), new ChessPosition('h', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Knight(Color.White, Board), new ChessPosition('b', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Knight(Color.White, Board), new ChessPosition('g', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Bishop(Color.White, Board), new ChessPosition('c', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Bishop(Color.White, Board), new ChessPosition('f', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Queen(Color.White, Board), new ChessPosition('d', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new King(Color.White, Board), new ChessPosition('e', 1).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('a', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('b', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('c', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('d', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('e', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('f', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('g', 2).TranslateChessToZeroBased());
            //Board.AddressPiece(new Pawn(Color.White, Board), new ChessPosition('h', 2).TranslateChessToZeroBased());


        }



    }
}
