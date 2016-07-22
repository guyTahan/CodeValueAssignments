using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon
{


    public class Player
    {
        private Color _color;
        private int _startPillar, _targetPillar;
        private int _id;
        private int[] _homeBoardRange;
        private int _movementDirection; // 1 if moving towards pillar 24, -1 if moving towards pillar 1


        public int MovementDirection
        {
            get { return _movementDirection; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public int ID
        {
            get { return _id; }

        }
        public int StartPillar
        {
            get { return _startPillar; }
        }

        public int TargetPillar
        {
            get { return _targetPillar; }
        }

        public int HomeBoardStartIndex
        {
            get { return _homeBoardRange[0]; }
        }

        public int HomeBoardEndIndex
        {
            get { return _homeBoardRange[1]; }
        }
    }
}
