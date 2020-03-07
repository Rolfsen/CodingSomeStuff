using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class PlayerTurnManagerTests
    {
        private static List<CreatePlayerDto> CreatePlayerDtos()
        {
            List<CreatePlayerDto> dto = new List<CreatePlayerDto>()
            {
                new CreatePlayerDto("Player1"),
                new CreatePlayerDto("Player2")
            };
            return dto;
        }
        
        private static PlayerTurnManager CreatePlayerTurnManager()
        {
            var dto = CreatePlayerDtos();
            var manager = new PlayerTurnManager(PlayersFactory.CreatePlayerList(dto));
            return manager;
        }
        
        [Fact]
        public void InstantiatePlayerTurnManagerWithOnePlayerShouldHave1Player()
        {
            List<CreatePlayerDto> dto = new List<CreatePlayerDto>()
            {
                new CreatePlayerDto("Player1")
            };
            var manager = new PlayerTurnManager(PlayersFactory.CreatePlayerList(dto));
            Assert.Equal(1, manager.Players.Count);
        }
        
        [Fact]
        public void InstantiatePlayerTurnManagerWithTwoPlayerShouldHave2Player()
        {
            var manager = CreatePlayerTurnManager();
            Assert.Equal(2, manager.Players.Count);
        }
        
        [Fact]
        public void WhenGameStartsItShouldBePlayerOneTurn()
        {
            var manager = CreatePlayerTurnManager();
            Assert.Equal(manager.Players[0],manager.CurrentPlayer);
        }
        
        [Fact]
        public void WhenPlayerOnesTurnIsOverItShouldBePlayers2Turn()
        {
            var manager = CreatePlayerTurnManager();
            manager.Roll(3);
            manager.Roll(5);
            Assert.Equal(manager.Players[1],manager.CurrentPlayer);
        }
        
        [Fact]
        public void WhenPlayerTwoTurnIsOverItShouldBePlayers1Turn()
        {
            var manager = CreatePlayerTurnManager();
            manager.Roll(3);
            manager.Roll(5);
            manager.Roll(3);
            manager.Roll(5);
            Assert.Equal(manager.Players[0],manager.CurrentPlayer);
        }
        
        
        [Fact]
        public void WhenAllPlayersHavePlayed1TurnsGameShouldNotBeOver()
        {
            var manager = CreatePlayerTurnManager();
            manager.Roll(3);
            manager.Roll(5);
            manager.Roll(3);
            manager.Roll(5);
            Assert.False(manager.GameOver);
        }

        [Fact]
        public void WhenAllPlayersHavePlayed10TurnsGameShouldBeOver()
        {
            var manager = CreatePlayerTurnManager();
            for (var i = 0; i < 40; i++)
            {
                manager.Roll(1);
            }
            Assert.True(manager.GameOver);
        }
    }
}