using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public class Player
    {
        public readonly string Name;

        public int turn = 0;
        private readonly List<int> rolls = new List<int>();
        private readonly List<Turn> turns = new List<Turn>();
        private int playerScore;

        public bool gameOver { get; private set; }

        public Player(string name)
        {
            Name = name;
            gameOver = false;
            for (var i = 0; i < 10; i++)
            {
                turns.Add(new Turn());
            }
        }
        
        public int Roll(int roll)
        {
            if (gameOver) return turn;
            var currentTurn= turns[turn];
            currentTurn.Rolls.Add(roll);
            IncrementTurn(currentTurn);
            CheckIfGameIsOver();
            return turn;
        }

        private void IncrementTurn(Turn currentTurn)
        {
            if ((currentTurn.Rolls.Sum() == 10 || currentTurn.Rolls.Count == 2) && turn != 9)
                turn++;
            else if (turn == 9 && currentTurn.Rolls.Count == 2 && currentTurn.Rolls.Sum() < 10)
                turn++;
            else if (currentTurn.Rolls.Count == 3)
                turn++;
        }

        public int GetScore()
        {
            playerScore = 0;
            GetRolls();
            var nextRoll = 0;
            for (var index = 0; index < turns.Count; index++)
            {
                nextRoll = NextRoll(index, nextRoll);
            }

            return playerScore;
        }

        private int NextRoll(int index, int nextRoll)
        {
            var currentTurnRolls = turns[index].Rolls;
            nextRoll = CalculateScoreForTurn(currentTurnRolls, nextRoll);
            CalculateBonusPoints(currentTurnRolls, index, nextRoll);
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

        private void CalculateBonusPoints(List<int> currentTurnRolls, int index, int nextRoll)
        {
            if (currentTurnRolls.Sum() != 10 || index + 1 == turns.Count) return;
            if (currentTurnRolls.Count == 1)
                playerScore += rolls[nextRoll + 1];
            playerScore += rolls[nextRoll];
        }


        

        private void CheckIfGameIsOver()
        {
            if (turn != 10) return;

            switch (turns[9].Rolls.Count)
            {
                case 2 when turns[9].Rolls.Sum() < 10:
                case 3:
                    gameOver = true;
                    break;
            }
        }

        private void GetRolls()
        {
            foreach (var roll in turns.SelectMany(turn => turn.Rolls))
            {
                rolls.Add(roll);
            }
        }
    }
}