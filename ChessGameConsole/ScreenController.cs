using System;
using System.Collections.Generic;
using System.Text;
using Board;

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
                    if (board.GetPiece(i, j) != null)
                    {
                        ChangeToPieceColor(board.GetPiece(i, j));
                        Console.Write(board.GetPiece(i, j).ToString() + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   ^ ^ ^ ^ ^ ^ ^ ^");
            Console.WriteLine("   a b c d e f g h");
        }

        public static void ChangeToPieceColor(Piece piece)
        {
            if (piece.Color == Color.Black)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }



    }
}
