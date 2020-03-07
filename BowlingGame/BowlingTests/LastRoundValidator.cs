using System.Linq;
using Xunit;

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

    public class GivenLastRoundWithOnePlayer
    {
        [Fact]
        public void Rolling3And4ShouldBeValid()
        {
            Turn turn = new Turn();
            turn.Rolls.Add(3);
            Assert.True(LastRoundValidator.ValidateLastRoundRolls(4, turn));
        }
        
        [Fact]
        public void Rolling10And4And7ShouldBeInvalid()
        {
            Turn turn = new Turn();
            turn.Rolls.Add(10);
            turn.Rolls.Add(6);
            Assert.False(LastRoundValidator.ValidateLastRoundRolls(5, turn));
        }
        
        [Fact]
        public void Rolling3And8ShouldBeInvalid()
        {
            Turn turn = new Turn();
            turn.Rolls.Add(3);
            Assert.False(LastRoundValidator.ValidateLastRoundRolls(8, turn));
        }
        
        [Fact]
        public void Rolling1010And10ShouldBeValid()
        {
            Turn turn = new Turn();
            turn.Rolls.Add(10);
            turn.Rolls.Add(10);
            Assert.True(LastRoundValidator.ValidateLastRoundRolls(10, turn));
        }
        
    }
}