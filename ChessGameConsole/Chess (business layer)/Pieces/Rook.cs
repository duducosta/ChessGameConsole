using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Rook : Piece
    {
        //Constructor
        public Rook(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "T";
        }


    }
}
