using Xunit;

namespace BowlingTests
{
    public class PlayerTests
    {
        private Player player;
        
        public PlayerTests()
        {
            this.player = new Player("Player");
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

        [Fact]
        public void PlayerShouldHave16PointsAfterStrikeFollowedUpByTwo3()
        {
            player.Roll(10);
            player.Roll(2);
            player.Roll(2);
            Assert.Equal(18,player.GetScore());
        }
        [Fact] public void PerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                player.Roll(10);
            }
            
            Assert.Equal(300, player.GetScore());
        }

        [Fact]
        public void FluckGame()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(0);
            }
            Assert.Equal(0,player.GetScore());
        }
        
        [Fact] public void GameShouldEndAfter10TurnsInCaseOfNoStrikeAndSparesInTurn10()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(0);
            }
            
            Assert.True(player.gameOver);
        }

        [Fact]
        public void OneGame()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(1);
            }
            Assert.Equal(20,player.GetScore());
        }
        
        [Fact] public void GameShouldNotEndAfter9TurnsAnd1Throw()
        {
            for (int i = 0; i < 19; i++)
            {
                player.Roll(0);
            }
            
            Assert.False(player.gameOver);
        }
        
        [Fact] public void GameShouldNotEndAfter1Turn()
        {
            player.Roll(1);           
            player.Roll(1);
            Assert.False(player.gameOver);
        }

        [Fact]
        public void GameShouldNotEndAfterTwoThrowsInTurn9InCaseOfStrike()
        {
            for (int i = 0; i < 19; i++)
            {
                player.Roll(0);
            }
            player.Roll(10);
            Assert.False(player.gameOver);
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
            Assert.True(player.gameOver);
        }

        [Fact]
        public void RollingAfterTheGameIsOverShouldNotIncrementScore()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(1);
            }

            var a = player.GetScore();
            player.Roll(5);
            Assert.Equal(a,player.GetScore());
        }

        [Fact]
        public void PlayerShouldHaveAName()
        {
            Assert.Equal("Player", player.Name);
        }
    }
}