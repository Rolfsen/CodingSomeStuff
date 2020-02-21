using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public static class PlayersFactory
    {
        public static List<Player> CreatePlayerList(List<CreatePlayerDto> playerDtos)
        {
            return playerDtos.Select(playerDto => new Player(playerDto.name)).ToList();
        }
    }
}