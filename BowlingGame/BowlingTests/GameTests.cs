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
        
        [Fact]
        public void OneGame()
        {
            for (int i = 0; i < 20; i++)
            {
                player.Roll(1);
            }
            Assert.Equal(20,player.GetScore());
        }
    }
}