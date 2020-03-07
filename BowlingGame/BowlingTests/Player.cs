using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public class Player
    {
        public readonly string Name;

        public readonly List<Turn> turns = new List<Turn>();

        public int Turn { get; private set; }
        public bool GameOver { get; private set; }

        public Player(string name)
        {
            Name = name;
            GameOver = false;
            for (var i = 0; i < 10; i++)
            {
                turns.Add(new Turn());
            }
        }
        
        public int Roll(int roll)
        {
            if (IsRollInvalid(roll)) return Turn;
            
            var currentTurn= turns[Turn];
            currentTurn.Rolls.Add(roll);
            IncrementTurn(currentTurn);
            CheckIfGameIsOver();
            return Turn;
        }

        private bool IsRollInvalid(int roll)
        {
            if (GameOver) return true;
            if (roll < 0) return true;
            if (roll > 10) return true;
            if (roll + turns[Turn].Rolls.Sum() > 10 && Turn != 9)
                return true;
            if (Turn != 9) return false;
            var a = LastRoundValidator.ValidateLastRoundRolls(roll, turns[9]);
            return a == false;
        }


        private void IncrementTurn(Turn currentTurn)
        {
            if ((currentTurn.Rolls.Sum() == 10 || currentTurn.Rolls.Count == 2) && Turn != 9)
                Turn++;
            else if (Turn == 9 && currentTurn.Rolls.Count == 2 && currentTurn.Rolls.Sum() < 10)
                Turn++;
            else if (currentTurn.Rolls.Count == 3)
                Turn++;
        }
        
        private void CheckIfGameIsOver()
        {
            if (Turn != 10) return;

            switch (turns[9].Rolls.Count)
            {
                case 2 when turns[9].Rolls.Sum() < 10:
                case 3:
                    GameOver = true;
                    break;
            }
        }
    }
}