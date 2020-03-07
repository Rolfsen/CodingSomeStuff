using System.Linq;

namespace BowlingTests
{
    public static class LastRoundValidator
    {
        public static bool ValidateLastRoundRolls(int roll, Turn turn)
        {
            if (roll > 10) return false;
            if (turn.Rolls.Count == 0) return true;
            
            var rolls = turn.Rolls;
            if (rolls.First() != 10) return rolls.First() + roll <= 10;
            
            var numberOfRolls = rolls.Count;
            
            switch (numberOfRolls)
            {
                case 1:
                    return true;
                case 2 when rolls[1] != 10:
                    return rolls[1] + roll <= 10;
                case 2 when rolls[1] == 10:
                    return true;
            }

            return rolls.First() + roll <= 10;
        }
    }
}