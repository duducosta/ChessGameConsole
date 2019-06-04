using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Queen : Piece
    {
        //Constructor
        public Queen(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "Q";
        }


    }
}