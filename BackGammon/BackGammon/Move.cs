using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon
{
    class Move
    {
        private int _destination;
        private int _startPosition;

        public Move(int start, int end)
        {
            _startPosition = start;
            _destination = end;
        }

        public int Start
        {
            get { return _startPosition; }
        }

        public int End
        {
            get { return _destination; }
        }
    }
}
