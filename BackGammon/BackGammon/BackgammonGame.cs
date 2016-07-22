using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon
{
    class BackgammonGame
    {
        private GameBoard _board;
        private Player _playerOne, _playerTwo;
        private int _TurnOfPlayer;
        private List<int> _cubeResults;
        private List<Move> _legalMovesForThisTurn;



        public Player TurnOfWhichPlayer()
        {
            if (_TurnOfPlayer==1)
            {
                return _playerOne;
            }
            else
            {
                return _playerTwo;
            }
        }
        
        public void generateAllLegalMoves()
        {
            _legalMovesForThisTurn.Clear();
            if (playerHasImprisonedTokens() == true)
            {
                _legalMovesForThisTurn = _board.GeneratePrisonBreakMovesForPlayer(TurnOfWhichPlayer(), _cubeResults);
                return;
            }

            if (CanTheCorrectPlayerBearOff() == true)
            {
                _legalMovesForThisTurn = _board.GenerateBearOffMoves(TurnOfWhichPlayer(), _cubeResults);
                return;
            }


            _legalMovesForThisTurn = _board.GenerateAllNormalMoves(TurnOfWhichPlayer(), _cubeResults);
            
        }

        public bool CanTheCorrectPlayerBearOff()
        {
            return _board.CanThePlayerBearOff(TurnOfWhichPlayer());
        }

        public bool playerHasImprisonedTokens()
        {
            return _board.PlayerHasImprisonedTokens(this.TurnOfWhichPlayer());
        }

        private void generateAllLegalPrisonBreakMoves()
        {
            throw new NotImplementedException();
        }

        public bool AttemptToMove(Move move)
        {
            throw new NotImplementedException();
        }

        

        public void RollTheDice()
        {
            _cubeResults.Clear();

            Random roll = new Random();
            int firstCube = roll.Next(1, 7);
            int secondCube = roll.Next(1, 7);

            if (firstCube == secondCube)
            {
                _cubeResults.Add(firstCube);
                _cubeResults.Add(firstCube);
                _cubeResults.Add(firstCube);
                _cubeResults.Add(firstCube);
            }
            else
            {
                _cubeResults.Add(firstCube);
                _cubeResults.Add(secondCube);
            }
        }



        public int NextTurn()
        {
            if (_TurnOfPlayer == 1)
            {
                _TurnOfPlayer = 2;
            }
            else
            {
                _TurnOfPlayer = 1;
            }

            return _TurnOfPlayer;
        }
        
    
    }
}
