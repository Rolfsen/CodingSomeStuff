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
            manager.CurrentPlayer.Roll(5);
            manager.CurrentPlayer.Roll(3);
            Assert.Equal(manager.Players[1],manager.CurrentPlayer);
        }
    }

    public class PlayerTurnManager
    {
        private int currentTurn = 0; 
        
        public List<Player> Players;
        public Player CurrentPlayer { get; private set; }
        
        public PlayerTurnManager(List<Player> players)
        {
            Players = players;
            CurrentPlayer = players[0];
        }

        public void Roll(int roll)
        {
           CurrentPlayer.Roll(roll);
        }
    }
}