using System;
using Board;
using Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame Game = new ChessGame();

                while (!Game.EndGame)
                {
                    Console.Clear();
                    ScreenController.PrintBoard(Game.Board);
                    Console.WriteLine();
                    Console.Write("Which position you which to move FROM: ");
                    Position origin = ScreenController.ReadChessNotation().TranslateChessToZeroBased();
                    bool[,] possibleMoves = Game.Board.GetPiece(origin).PossibleMoves();
                    Console.Clear();
                    ScreenController.PrintBoard(Game.Board, possibleMoves);
                    Console.WriteLine();
                    Console.Write("Which position you which to move TO: ");
                    Position destiny = ScreenController.ReadChessNotation().TranslateChessToZeroBased();
                    Game.ChessMove(origin, destiny);
                }
            }
            catch (BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
