using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public class Player
    {
        private int turn = 0;
        private readonly List<int> rolls = new List<int>();
        private readonly List<Turn> turns = new List<Turn>();
        private int playerScore;

        public Player()
        {
            for (var i = 0; i < 10; i++)
            {
                turns.Add(new Turn());
            }
        }
        
        public int GetScore()
        {
            
            GetRolls();
            var nextRoll = 0;
            for (var index = 0; index < turns.Count; index++)
            {
                var currentTurnRolls = turns[index].Rolls;
                for (var turnRoll = 0; turnRoll < currentTurnRolls.Count; turnRoll++)
                {
                    nextRoll++;
                    playerScore += currentTurnRolls[turnRoll];
                }

                if (currentTurnRolls.Sum() == 10 && index+1 != turns.Count)
                {
                    if (currentTurnRolls.Count == 1)
                        playerScore += rolls[nextRoll + 1];
                    playerScore += rolls[nextRoll];
                }
            }

            return playerScore;
        }

        private void GetRolls()
        {
            foreach (var roll in turns.SelectMany(turn => turn.Rolls))
            {
                rolls.Add(roll);
            }
        }
        public void Roll(int roll)
        {
            var currentTurn= turns[turn];
            if (currentTurn.Rolls.Sum() < 10 && currentTurn.Rolls.Count <= 1)
                currentTurn.Rolls.Add(roll);
            else if (turn == 9)
                currentTurn.Rolls.Add(roll);
            else
            {
                turn++;
                Roll(roll);
            }
        }
    }
}