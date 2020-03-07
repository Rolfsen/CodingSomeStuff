using Xunit;

namespace BowlingTests
{
    public class PlayerTests
    {
        private Player player;
        private CalculateScore BowlingScoreCalculator;
        
        public PlayerTests()
        {
            this.BowlingScoreCalculator = new BowlingScoreCalculator();
            this.player = new Player("Player");
        }
        
        [Fact]
        public void Rolling0ShouldReturn0()
        {
            player.Roll(0);
            Assert.Equal(0, BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void Rolling1ShouldReturn1()
        {
            player.Roll(1);
            Assert.Equal(1,BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void Rolling1And3ShouldSetScoreTo4()
        {
            player.Roll(1);
            player.Roll(3);
            Assert.Equal(4,BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void PlayerShouldHave14PointsAfterRolling2AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(2);
            Assert.Equal(14, BowlingScoreCalculator.GetScore(player.turns));
        }
        
        [Fact]
        public void PlayerShouldHave12PointsAfterRolling1AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(1);
            Assert.Equal(12, BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void PlayerShouldHave16PointsAfterStrikeFollowedUpByTwo3()
        {
            player.Roll(10);
            player.Roll(2);
            player.Roll(2);
            Assert.Equal(18,BowlingScoreCalculator.GetScore(player.turns));
        }
        [Fact] public void PerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                player.Roll(10);
            }
            
            Assert.Equal(300, BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void FluckGame()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(0);
            }
            Assert.Equal(0,BowlingScoreCalculator.GetScore(player.turns));
        }
        
        [Fact] public void GameShouldEndAfter10TurnsInCaseOfNoStrikeAndSparesInTurn10()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(0);
            }
            
            Assert.True(player.GameOver);
        }

        [Fact]
        public void OneGame()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(1);
            }
            Assert.Equal(20,BowlingScoreCalculator.GetScore(player.turns));
        }
        
        [Fact] public void GameShouldNotEndAfter9TurnsAnd1Throw()
        {
            for (int i = 0; i < 19; i++)
            {
                player.Roll(0);
            }
            
            Assert.False(player.GameOver);
        }
        
        [Fact] public void GameShouldNotEndAfter1Turn()
        {
            player.Roll(1);           
            player.Roll(1);
            Assert.False(player.GameOver);
        }

        [Fact]
        public void GameShouldNotEndAfterTwoThrowsInTurn9InCaseOfStrike()
        {
            for (int i = 0; i < 19; i++)
            {
                player.Roll(0);
            }
            player.Roll(10);
            Assert.False(player.GameOver);
        }
        
        [Fact]
        public void GameShouldEndAfterThreeThrowsInTurn9InCaseOfStrike()
        {
            for (int i = 0; i < 19; i++)
            {
                player.Roll(0);
            }
            player.Roll(10);
            player.Roll(10);
            Assert.True(player.GameOver);
        }

        [Fact]
        public void RollingAfterTheGameIsOverShouldNotIncrementScore()
        {
            
            for (int i = 0; i < 20; i++)
            {
                player.Roll(1);
            }

            var a = BowlingScoreCalculator.GetScore(player.turns);
            player.Roll(5);
            Assert.Equal(a,BowlingScoreCalculator.GetScore(player.turns));
        }

        [Fact]
        public void PlayerShouldHaveAName()
        {
            Assert.Equal("Player", player.Name);
        }
        
        [Fact]
        public void RollingOver10ShouldBeInvalid()
        {
            player.Roll(11);
            var a = BowlingScoreCalculator.GetScore(player.turns);
            Assert.Equal(0,a);
        }
        
        [Fact]
        public void RollingOver4And7InOneTurnShouldBeInvalid()
        {
            player.Roll(4);
            player.Roll(7);
            var a = BowlingScoreCalculator.GetScore(player.turns);
            Assert.Equal(4,a);
        }
    }
}