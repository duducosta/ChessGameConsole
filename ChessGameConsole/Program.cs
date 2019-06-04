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
            
            newBoard.AddressPiece(new Rei(Color.White, newBoard), new Position(0, 0));
            newBoard.AddressPiece(new Rei(Color.Black, newBoard), new Position(0, 1));


            ChessPositions test = new ChessPositions('a', 1);
            Console.WriteLine(test.TranslateChessToZeroBased());


            ScreenController.PrintBoard(newBoard);
        }
    }
}
