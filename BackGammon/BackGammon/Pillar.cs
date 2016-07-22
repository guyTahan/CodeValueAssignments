using System;


namespace BackGammon
{
    public class Pillar
    {
        private Color _dominator;
        private int _count;


        public Pillar()
        {
            _count = 0;
            _dominator = Color.Neutral;
        }

        public Pillar(int tokens, Color c)
        {
            _count = tokens;
            _dominator = c;
        }

        public bool isItViableDestinationFor(Player p)
        {
            if (this.Color == p.Color)
            {
                return true;
            }

            if (this.Count<=1)
            {
                return true;
            }

            return false;
        }

        public Color Color
        {
            get { return _dominator; }
        }

        public int Count
        {
            get { return _count; }
        }
        public void Increase(Player p)
        {
            if (_count == 0)
            {
                _dominator = p.Color;
            }
            _count++;
        }

        public void Increase(Color c)
        {
            if (_count == 0)
            {
                _dominator = c;
            }
            _count++;
        }

        public void Decrease()
        {
            if (_count >= 1)
            {
                _count--;
            }

            if (_count == 0)
            {
                _dominator = Color.Neutral;
            }
        }

        public bool RecieveToken(Player player)
        {
            if (player.Color == this.Color)
            {
                _count++;
                return true;
            }

            if (this.Color == Color.Neutral)
            {
                _dominator = player.Color;
                _count++;
                return true;
            }

            if (this.Count == 1)
            {
                _dominator == player.Color;
                return true;
            }

            return false;
        }
    }
}
