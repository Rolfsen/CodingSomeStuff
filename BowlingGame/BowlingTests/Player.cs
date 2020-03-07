﻿using System.Collections.Generic;
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
            this.Name = name;
            gameOver = false;
            for (var i = 0; i < 10; i++)
            {
                turns.Add(new Turn());
            }
        }
        
        public int GetScore()
        {
            playerScore = 0;
            GetRolls();
            var nextRoll = 0;
            for (var index = 0; index < turns.Count; index++)
            {
                var currentTurnRolls = turns[index].Rolls;
                nextRoll = CalculateScoreForTurn(currentTurnRolls, nextRoll);
                CalculateBonusPoints(currentTurnRolls, index, nextRoll);
            }

            return playerScore;
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


        public int Roll(int roll)
        {
            if (gameOver) return turn;
            
            var currentTurn= turns[turn];
            if (currentTurn.Rolls.Sum() < 10 && currentTurn.Rolls.Count <= 1)
                currentTurn.Rolls.Add(roll);
            else if (turn == 9)
            {
                currentTurn.Rolls.Add(roll);
            }
            
            if ((currentTurn.Rolls.Sum() == 10 || currentTurn.Rolls.Count == 2) && turn != 9)
            {
                turn++;
            }
            else if (turn == 9 && currentTurn.Rolls.Count == 2 && currentTurn.Rolls.Sum() < 10)
            {
                turn++;
            }
            else if (currentTurn.Rolls.Count == 3)
                turn++;

            CheckIfGameIsOver();
            return turn;
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