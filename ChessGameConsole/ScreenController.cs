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
                for (int j = 0; j < board.Lines; j++)
                {
                    if (board.GetPiece(i, j) != null)
                    {
                        Console.Write(board.GetPiece(i, j).ToString() + " ");  //fazer identificação da peça
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
