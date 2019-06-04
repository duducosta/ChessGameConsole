using System;
using Board;
using Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardTable newBoard = new BoardTable(8, 8);
            Piece rei = new Rei(Color.White, newBoard);
            newBoard.addressPiece(rei, new Position(1, 1));


            ScreenController.PrintBoard(newBoard);
        }
    }
}
