using Xunit;

namespace BowlingTests
{
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