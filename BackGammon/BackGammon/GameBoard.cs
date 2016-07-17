using System;
using System.Text;

namespace BackGammon
{
    public enum Color { Red, Green }

    public class GameBoard
    {

        private Pillar[] _pillars;
        private int _freedRedTokens;
        private int _freedGreenTokens;
        private int _imprisonedRedTokens;
        private int _imprisonedGreenTokens;

        public GameBoard()
        {
            _pillars = new Pillar[24];

            for (int i = 0; i < 24; i++)
            {
                _pillars[i] = new Pillar();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //the upper half of the board
            sb.AppendLine("===================================================================");
            for (int i = 0; i < 6; ++i)
            {
                sb.Append("|");
                for (int j = 0; j < 6; ++j)
                {
                    sb.Append(" ");
                    if (_pillars[j].Count > i)
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append("|R|");
                        }
                        else
                        {
                            sb.Append("|G|");
                        }
                    }
                    else
                    {
                        sb.Append("| |");
                    }
                    if(j==5)
                    { 
                        sb.Append("  ");
                    }
                    else
                    {
                        sb.Append(" ");
                    }

                }

                sb.Append("|||");
                sb.Append(" ");
                for (int j = 6; j < 12; ++j)
                {

                    if (_pillars[j].Count > i)
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append("|R|");
                        }
                        else
                        {
                            sb.Append("|G|");
                        }
                    }
                    else
                    { 
                        sb.Append("| |");
                    }
                    sb.Append("  ");
                }

                sb.Append("|");
                sb.AppendLine();
            }
            
            //lower half of the board
            sb.AppendLine("-------------------------------------------------------------------");

            for (int i = 0; i < 6; ++i)
            {
                sb.Append("|");
                for (int j = 0; j < 6; ++j)
                {
                    sb.Append(" ");
                    if (  6-i <= _pillars[j].Count  )
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append("|R|");
                        }
                        else
                        {
                            sb.Append("|G|");
                        }
                    }
                    else
                    {
                        sb.Append("| |");
                    }
                    if (j == 5)
                    {
                        sb.Append("  ");
                    }
                    else
                    {
                        sb.Append(" ");
                    }

                }

                sb.Append("|||");
                sb.Append(" ");
                for (int j = 6; j < 12; ++j)
                {

                    if ( 6 - i <= _pillars[j].Count)
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append("|R|");
                        }
                        else
                        {
                            sb.Append("|G|");
                        }
                    }
                    else
                    {
                        sb.Append("| |");
                    }
                    if(i==11)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                    
                }

                sb.Append("|");
                sb.AppendLine();
            }

            sb.AppendLine("===================================================================");


            return sb.ToString();
        }

        public bool AttemptToMove(int start, int end, Player player)
        {
            int trueStart = start - 1;
            int trueEnd = end - 1;

            //if attempting to move more than 6 spaces
            if (Math.Abs(start-end) > 6)
            {
                return false;
            }

            //check if start or end destination are out of the board
            if (trueStart < 0 || trueStart > 23 || trueEnd< -1 || trueEnd>24)
            {
                return false;
            }

            //check if the start pillar is not in the control of the currect player
            if (_pillars[trueStart].Color != player.Color || _pillars[trueStart].Count == 0)
            {
                return false;
            }

            if (trueEnd==-1 || trueEnd==24)
            {
                if (this.DoesTheCurrentPlayerHasAllHisTokensOnHomeBoard() == false)
                {
                    return false;
                }
                else
                {
                    _pillars[trueStart].Decrease();
                }
            }

            return true;
        }

        private bool DoesTheCurrentPlayerHasAllHisTokensOnHomeBoard()
        {
            throw new NotImplementedException();
        }

        private bool AttemptToFree(int start)
    }
}
