using System;
using System.Collections.Generic;
using System.Text;


namespace BackGammon
{
    public enum Color { Red, Green , Neutral}

    public class GameBoard
    {

        private Pillar[] _pillars;
        private int[]  _freedTokens;
        private int[] _imprisonedTokens;


        public GameBoard()
        {
            _pillars = new Pillar[24];

            for (int i = 0; i < 24; i++)
            {
                _pillars[i] = new Pillar();
            }

            _freedTokens = new int[2] {0,0};
            _imprisonedTokens = new int[2] { 0, 0 };
        }


        public bool PlayerControlsPillar(int pillarID,Player player)
        {
            if (_pillars[pillarID].Color == player.Color )
            {
                return true;
            }

            return false;
        }

        public List<Move> GeneratePrisonBreakMovesForPlayer(Player player, List<int> cubeRolls)
        {
            List<Move> moveList = new List<Move>();

            if (cubeRolls.Count == 0)
            {
                return moveList;
            }

            int direction = player.MovementDirection;
            int endPillar = player.StartPillar +6*direction;
            if (CheckForDouble(cubeRolls) == true)
            {
                for (int i = player.StartPillar - 1; i != endPillar - 1; i += direction)
                {
                        if (_pillars[i].isItViableDestinationFor(player) == true)
                        {
                            moveList.Add(new BackGammon.Move(-1, cubeRolls[0] - player.MovementDirection, cubeRolls[0], Move.moveType.PrisonBreak));
                        }
                }
            }
            else
            {
                for (int i = player.StartPillar - 1; i != endPillar - 1; i += direction)
                {
                    foreach (int cube in cubeRolls)
                    {
                        if (_pillars[i].isItViableDestinationFor(player) == true)
                        {
                            moveList.Add(new BackGammon.Move(-1, cube - player.MovementDirection, cube, Move.moveType.PrisonBreak));
                        }
                    }
                }

            }

            return moveList;
        }

        public List<Move> GenerateAllNormalMoves(Player player, List<int> cubeRolls)
        {
            List<Move> moveList = new List<Move>();

            if (cubeRolls.Count == 0)
            {
                return moveList;
            }

            bool doubleRoll = CheckForDouble(cubeRolls);
            int direction = player.MovementDirection;
            if (doubleRoll == true)
            {
                for (int i =player.StartPillar-1; i!=player.TargetPillar; i+=direction)
                {
                    if (_pillars[i].Color == player.Color)
                    {
                        if (i+cubeRolls[0] <24 && _pillars[i+cubeRolls[0]].isItViableDestinationFor(player)==true )
                        {
                            moveList.Add(new Move(i + 1, i + 1 + cubeRolls[0], cubeRolls[0] ,Move.moveType.Normal));
                        }
                    }
                }
            }
            else
            {
                for (int i = player.StartPillar - 1; i != player.TargetPillar; i += direction)
                {
                    if (_pillars[i].Color == player.Color)
                    {
                        foreach (int cube in cubeRolls)
                        {
                            if (i + cube < 24 && _pillars[i + cube].isItViableDestinationFor(player) == true)
                            {
                                moveList.Add(new Move(i + 1, i + 1 + cube, cube, Move.moveType.Normal));
                            }
                        }
                    }
                }

            }

            return moveList;
        }

        public List<Move> GenerateBearOffMoves(Player p, List<int> cubeRolls)
        {
            List<Move> moveList = new List<Move>();

            if (cubeRolls.Count == 0)
            {
                return moveList;
            }
            int startPillar = p.HomeBoardStartIndex - 1;
            int endPillar = p.HomeBoardEndIndex - 1;
            int direction = p.MovementDirection;
            Move currentMove;
            bool doubleRoll = CheckForDouble(cubeRolls);

            if (doubleRoll == true)
            {
                int cube = cubeRolls[0];
                for (int i = startPillar; i <= endPillar; i += direction)
                {
                        if (Math.Abs(i - endPillar) < cube)
                        {
                            moveList.Add(new Move(i, -1, cube, Move.moveType.BearingOff));
                        }
                }
            }
            else
            { 
                for (int i = startPillar; i <= endPillar; i += direction)
                {
                    foreach (int cube in cubeRolls)
                    {
                        if (Math.Abs(i - endPillar) < cube)
                        {
                            moveList.Add(new Move(i, -1, cube, Move.moveType.BearingOff));
                        }
                    }
                }
            }

            return moveList;
        }

        public bool CheckForDouble(List<int> rolls)
        {
            int firstRoll = rolls[0];
            int count = 0;
            
            foreach (int i in rolls)
            {
                if (i == firstRoll)
                {
                    count++;
                    if (count==2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanThePlayerBearOff(Player player)
        {
            if (_imprisonedTokens[player.ID - 1] > 0)
            {
                return false;
            }

            int start = player.HomeBoardStartIndex - 1;
            int end = player.HomeBoardEndIndex;
            int count = 0;
            int direction = player.MovementDirection;

            for (int i = start; i != end ; i += direction)
            {
                if (_pillars[i].Color == player.Color)
                {
                    count += _pillars[i].Count;
                }
            }

            count += _freedTokens[player.ID - 1];

            if (count == 15)
            {
                return true;
            }

            return false;
        }

        public bool PlayerHasImprisonedTokens(Player p)
        {
            if (_imprisonedTokens[p.ID-1] > 0)
            {
                return true;
            }

            return false;
        }

        public bool AttemptToMove(Move move, Player player)
        {
            bool success = false;

            switch (move.Type)
            {
                case Move.moveType.BearingOff:
                    if (CanThePlayerBearOff(player)==true &&  move.Start + move.CubeUsed > 24)
                    {
                        _pillars[move.Start - 1].Decrease();
                        _freedTokens[player.ID - 1]++;
                        success = true;
                    }
                    break;
                case Move.moveType.PrisonBreak:
                    bool playerHasTokensInJail = _imprisonedTokens[player.ID - 1] > 0;
                    bool destinationPillarIsAlright = _pillars[move.End - 1].isItViableDestinationFor(player);
                    bool cubeGetsPlayerToTheDestination =  (move.End - 1 == player.StartPillar + move.CubeUsed - 1);

                    if (playerHasTokensInJail && destinationPillarIsAlright && cubeGetsPlayerToTheDestination)
                    {
                        success = MoveATokenIntoPillar(player , move.End);
                    }
                    break;

                default:
                    bool pillarBelongsToPlayer = _pillars[move.Start - 1].Color == player.Color;
                    bool destinationAvailable = _pillars[move.End - 1].isItViableDestinationFor(player);

                    if (pillarBelongsToPlayer && destinationAvailable)
                    {
                        success = MoveATokenIntoPillar(player, move.End);
                        if (success == true)
                        {
                            _pillars[move.Start - 1].Decrease();
                        }
                    }
                    break;
            }

            return success;
        }

        private bool MoveATokenIntoPillar(Player player, int whichPillar)
        {
            Pillar pillar = _pillars[whichPillar - 1];
            Color before = pillar.Color;
            bool movedAToken = pillar.RecieveToken(player);
            if (movedAToken == true && pillar.Color != before)
            {
                if (player.ID == 1)
                {
                    _imprisonedTokens[1]++;
                }
                else
                {
                    _imprisonedTokens[0]++;
                }
            }

            return movedAToken;
        }
    }
}
