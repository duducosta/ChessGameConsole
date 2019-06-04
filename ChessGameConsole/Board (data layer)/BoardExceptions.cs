using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class BoardExceptions:ApplicationException
    {
        public BoardExceptions(string message):base(message)
        {

        }
    }
}
