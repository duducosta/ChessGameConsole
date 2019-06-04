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
            newBoard.AddressPiece(rei, new Position(0, 0));


            ChessPositions test = new ChessPositions('a', 1);
            Console.WriteLine(test.TranslateChessToZeroBased());


            ScreenController.PrintBoard(newBoard);
        }
    }
}
