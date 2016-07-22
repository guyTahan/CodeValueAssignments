using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackGammon
{
    public class Move
    {
        public enum moveType {PrisonBreak, BearingOff, Normal };
        private int _destination;
        private int _startPosition;
        private moveType _type;
        private int _cubeUsed;




        public Move(int start, int end, int cube , moveType type)
        {
            _startPosition = start;
            _destination = end;
            _type = type;
            _cubeUsed = cube;
        }


        public int Start
        {
            get { return _startPosition; }
        }

        public int End
        {
            get { return _destination; }
        }

        public moveType Type
        {
            get { return _type; }
        }

        public int CubeUsed
        {
            get { return _cubeUsed; }
        }
    }
}
