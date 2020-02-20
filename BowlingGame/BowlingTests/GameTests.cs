using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class GameTests
    {
        private Player player;
        
        public GameTests()
        {
            this.player = new Player();
        }

        [Fact]
        public void Rolling0ShouldReturn0()
        {
            player.Roll(0);
            Assert.Equal(0, player.GetScore());
        }

        [Fact]
        public void Rolling1ShouldReturn1()
        {
            player.Roll(1);
            Assert.Equal(1,player.GetScore());
        }

        [Fact]
        public void Rolling1And3ShouldSetScoreTo4()
        {
            player.Roll(1);
            player.Roll(3);
            Assert.Equal(4,player.GetScore());
        }

        [Fact]
        public void PlayerShouldHave14PointsAfterRolling2AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(2);
            Assert.Equal(14, player.GetScore());
        }
        
        [Fact]
        public void PlayerShouldHave12PointsAfterRolling1AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(1);
            Assert.Equal(12, player.GetScore());
        }
    }

    public class Player
    {
        private readonly List<int> rolls = new List<int>();
        private readonly List<Turn> turns = new List<Turn>();
        private int playerScore;

        public int GetScore()
        {
            var previousRoll = 0;
            for (var index = 0; index < rolls.Count; index++)
            { 
                var roll = rolls[index];
                if (roll + previousRoll == 10)
                { 
                    playerScore += rolls[index + 1]; 
                } 
                playerScore += roll; 
                previousRoll = roll;
            }

            return playerScore;
        }
        public void Roll(int roll)
        {
            rolls.Add(roll);
        }
    }

    public class Turn
    {
        public List<int> Rolls = new List<int>();
    }
}