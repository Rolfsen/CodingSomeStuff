using Xunit;

namespace BowlingTests
{
    public class PlayerFactoryTest
    {
        [Fact]
        public void CreatingAPlayerWithFactoryWithNamePlayerShouldCreatePlayer()
        {
            var name = "player";
            var dto = new CreatePlayerDto(name);
            var player = PlayerFactory.CreatePlayer(dto);
            Assert.Equal(name,player.Name);
        }
    }
}