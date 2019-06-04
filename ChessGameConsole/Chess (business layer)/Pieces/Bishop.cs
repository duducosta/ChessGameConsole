using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Bishop : Piece
    {
        //Constructor
        public Bishop(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "B";
        }


    }
}
