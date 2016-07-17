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



        private Player TurnOfWhichPlayer()
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
       
        public bool AttemptToMove(string moveString)
        {
            bool firstNumConvertion;
            bool secondNumConvertion;
            int start, end;

            string[] splitNums = moveString.Split(',');
            

            firstNumConvertion = int.TryParse(splitNums[0], out start);
            secondNumConvertion = int.TryParse(splitNums[1], out end);

            if (firstNumConvertion && secondNumConvertion)
            {
                if ()
                return _board.AttemptToMove(start, end, this.TurnOfWhichPlayer());
            }
            else
            {
                return false;
            }
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
