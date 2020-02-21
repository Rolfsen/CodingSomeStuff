using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class PlayerTurnManagerTests
    {
        [Fact]
        public void InstantiatePlayerTurnManagerWithOnePlayerShouldHave1Player()
        {

            var manager = new PlayerTurnManager(
                new List<Player>()
                {
                    new Player("Player1")
                }
                );
            Assert.Equal(1, manager.Players.Count);
        }
    }

    public class PlayerTurnManager
    {
        public List<Player> Players;

        public PlayerTurnManager(List<Player> players)
        {
            Players = players;
        }
    }
}