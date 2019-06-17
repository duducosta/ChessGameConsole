using System;
using System.Collections.Generic;
using System.Text;
using Board;
using Chess;

namespace ChessGameConsole
{
    class ScreenController
    {
        public static void PrintGame(ChessGame game)
        {
            Console.Clear();
            ScreenController.PrintBoard(game.Board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine("Turn: " + game.Turn);
            if (!game.EndGame)
            {
                Console.WriteLine("Current player: " + game.CurrentPlayer);

                if (game.PlayerInCheck)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(">>>>>> " + game.CurrentPlayer + " Is in CHECK!!!   <<<<<<");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(game.EnemyIs(game.CurrentPlayer) + " Player is on check mate");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER!!!");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("CAPTURED PIECES: ");
            Console.Write("White: ");
            PrintPieceSet(game.CapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintPieceSet(game.CapturedPiecesByColor(Color.Black));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintPieceSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(BoardTable board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + ") ");
                for (int j = 0; j < board.Lines; j++)
                {
                    PrintPieceOnBoard(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   ^ ^ ^ ^ ^ ^ ^ ^");
            Console.WriteLine("   a b c d e f g h");
        }

        public static void PrintBoard(BoardTable board, bool[,] possibleMoves)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + ") ");
                for (int j = 0; j < board.Lines; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    PrintPieceOnBoard(board.GetPiece(i, j));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   ^ ^ ^ ^ ^ ^ ^ ^");
            Console.WriteLine("   a b c d e f g h");
        }


        public static void PrintPieceOnBoard(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-" + " ");
            }
            else
            {
                if (piece.Color == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write(piece.ToString() + " ");
                Console.ResetColor();
            }

        }

        public static ChessPosition ReadChessNotation()
        {
            string chessNotation = Console.ReadLine();
            if (ChessNotationCheck(chessNotation))
            {
                char column = chessNotation[0];
                int line = int.Parse(chessNotation[1] + "");
                return new ChessPosition(column, line);
            }
            else
            {
                throw new BoardExceptions("Invalid coordinate");
            }
        }

        public static bool ChessNotationCheck(string notation)
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
            string letter = notation.Substring(0, 1);
            int number;
            bool letterCheck;
            bool numberCheck;
            if (int.TryParse(notation.Substring(1, 1), out number))
            {

            }
            else
            {
                number = 99;
            }
            letterCheck = (Array.Exists(letters, l => l.Equals(letter)));
            numberCheck = (Array.Exists(numbers, l => l.Equals(number)));
            return (letterCheck && numberCheck);
        }


        public static bool CheckPlayerChoice(string playerChoice)
        {
            string[] choices = { "queen", "bishop", "knight", "rook", "QUEEN", "BISHOP", "KNIGHT", "ROOK", "Queen", "Bishop", "Knight", "Rook" };
            return (Array.Exists(choices, l => l.Equals(playerChoice)));
        }
    }
}
