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

            while (!Game.EndGame)
            {
                ScreenController.PrintBoard(Game.Board);
                Game.PlayerMove();
                Console.Clear();
            }






        }
    }
}
