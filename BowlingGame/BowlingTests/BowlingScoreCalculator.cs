using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public class BowlingScoreCalculator : CalculateScore
    {
        private int playerScore = 0;
        private readonly List<int> rolls = new List<int>();

        public int GetScore(List<Turn> turns)
        {
            playerScore = 0;
            GetRolls(turns);
            var nextRoll = 0;
            for (var index = 0; index < turns.Count; index++)
            {
                nextRoll = NextRoll(index, nextRoll, turns);
            }

            return playerScore;
        }

        private int NextRoll(int index, int nextRoll, List<Turn> turns)
        {
            var currentTurnRolls = turns[index].Rolls;
            nextRoll = CalculateScoreForTurn(currentTurnRolls, nextRoll);
            CalculateBonusPoints(currentTurnRolls, index, nextRoll, turns);
            return nextRoll;
        }

        private int CalculateScoreForTurn(List<int> currentTurnRolls, int nextRoll)
        {
            foreach (var roll in currentTurnRolls)
            {
                nextRoll++;
                playerScore += roll;
            }

            return nextRoll;
        }

        private void CalculateBonusPoints(List<int> currentTurnRolls, int index, int nextRoll, List<Turn> turns)
        {
            if (currentTurnRolls.Sum() != 10 || index + 1 == turns.Count) return;
            if (currentTurnRolls.Count == 1)
                playerScore += rolls[nextRoll + 1];
            playerScore += rolls[nextRoll];
        }

        private void GetRolls(List<Turn> turns)
        {
            foreach (var roll in turns.SelectMany(turn => turn.Rolls))
            {
                rolls.Add(roll);
            }
        }
    }
}