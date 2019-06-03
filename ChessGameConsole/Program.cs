using System;
using Board;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardTable newBoard = new BoardTable(8,8);
            ScreenController.PrintBoard(newBoard);

        }
    }
}
