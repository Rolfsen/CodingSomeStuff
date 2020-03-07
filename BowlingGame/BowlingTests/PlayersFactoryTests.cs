using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class PlayersFactoryTests
    {
        [Fact]
        public void CreatingAPlayerListWithoutPlayersShouldGiveAnEmptyList()
        {
            List<CreatePlayerDto> playerDtoList = new List<CreatePlayerDto>();
            var players = PlayersFactory.CreatePlayerList(playerDtoList);
            Assert.Empty(players);
        }

        [Fact]
        public void CreatingListOfPlayersWithASingleDtoShouldReturnASinglePlayer()
        {
            var createPlayerDtos = new List<CreatePlayerDto>()
            {
                new CreatePlayerDto("Player1")
            };
            var players = PlayersFactory.CreatePlayerList(createPlayerDtos);
            
            Assert.Equal(1 ,players.Count);
        }

        [Fact]
        public void CreatingListOfPlayersWithATwoDtosShouldReturnATwoPlayers()
        {
            var createPlayerDtos = new List<CreatePlayerDto>()
            {
                new CreatePlayerDto("Player1"),
                new CreatePlayerDto("Player2")
            };
            var players = PlayersFactory.CreatePlayerList(createPlayerDtos);
            
            Assert.Equal(2 ,players.Count);
        }
    }
}