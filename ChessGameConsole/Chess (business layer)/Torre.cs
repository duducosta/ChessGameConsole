using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Torre : Piece
    {
        //Constructor
        public Torre(Color color, BoardTable board) : base(color, board)
        {

        }

        //End of contructors


        public override string ToString()
        {
            return "T";
        }


    }
}
