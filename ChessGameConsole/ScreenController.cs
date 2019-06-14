using System;
using System.Collections.Generic;
using System.Text;
using Board;
using Chess;

namespace ChessGameConsole
{
    class ScreenController
    {
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
            char column = chessNotation[0];
            int line = int.Parse(chessNotation[1] + "");
            return new ChessPosition(column, line);
        }

    }
}
