using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class GameTests
    {
        private readonly BowlingGame bowlingGame;

        public GameTests()
        {
            bowlingGame = new BowlingGame();
        }
        
        [Fact]
        public void GameShouldNotBeStarted()
        {
            Assert.False(bowlingGame.IsStarted);
        }


        [Fact]
        public void StartingDontStartWithoutPlayers()
        {
            bowlingGame.StartGame();
            Assert.False(bowlingGame.IsStarted);
        }
        
        [Fact]
        public void StartingGameWithOnePlayerShouldStartGame()
        {
            bowlingGame.AddPlayer("");
            bowlingGame.StartGame();
            Assert.True(bowlingGame.IsStarted);
        }
        
        [Fact]
        public void AddingAPlayerAfterGameIsStartedShouldFail()
        {
            bowlingGame.AddPlayer("A");
            bowlingGame.StartGame();
            bowlingGame.AddPlayer("B");
            Assert.Equal(1, bowlingGame.GetPlayers().Count);
        }
    }

    public class BowlingGame
    {
        public bool IsStarted;
        private readonly List<Player> players = new List<Player>();

        public List<Player> GetPlayers() => players;

        public void StartGame()
        {
            if (players.Count > 0)
                IsStarted = true;
        }

        public void AddPlayer(string name)
        {
            if(!IsStarted)
                players.Add(new Player(name));
        }
    }
}