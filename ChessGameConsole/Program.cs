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
                    try
                    {
                        ScreenController.PrintGame(Game);
                        Console.Write("Which position you which to move FROM: ");
                        Position origin = ScreenController.ReadChessNotation().TranslateChessToZeroBased();
                        Game.ValidadeOrigin(origin);
                        bool[,] possibleMoves = Game.Board.GetPiece(origin).PossibleMoves();
                        Console.Clear();
                        ScreenController.PrintBoard(Game.Board, possibleMoves);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + Game.Turn);
                        Console.WriteLine("Current player: " + Game.CurrentPlayer);
                        Console.WriteLine();
                        Console.Write("Which position you which to move TO: ");
                        Position destiny = ScreenController.ReadChessNotation().TranslateChessToZeroBased();
                        Game.ValidateDestiny(origin, destiny);
                        Game.MakeMove(origin, destiny);
                    }
                    catch (BoardExceptions e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                ScreenController.PrintGame(Game);

            }
            catch (BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
