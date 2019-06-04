using System;
using Board;
using Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessGame Game = new ChessGame();
            Game.StartPieces();
            ScreenController.PrintBoard(Game.Board);





        }
    }
}
