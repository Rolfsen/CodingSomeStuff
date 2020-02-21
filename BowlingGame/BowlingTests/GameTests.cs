using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class GameTests
    {
        private readonly BowlingGameSetup bowlingGameSetup;

        public GameTests()
        {
            bowlingGameSetup = new BowlingGameSetup();
        }
        
        [Fact]
        public void GameShouldNotBeStarted()
        {
            Assert.False(bowlingGameSetup.IsStarted);
        }


        [Fact]
        public void StartingDontStartWithoutPlayers()
        {
            bowlingGameSetup.StartGame();
            Assert.False(bowlingGameSetup.IsStarted);
        }
        
        [Fact]
        public void StartingGameWithOnePlayerShouldStartGame()
        {
            bowlingGameSetup.AddPlayer("");
            bowlingGameSetup.StartGame();
            Assert.True(bowlingGameSetup.IsStarted);
        }
        
        [Fact]
        public void AddingAPlayerAfterGameIsStartedShouldFail()
        {
            bowlingGameSetup.AddPlayer("A");
            bowlingGameSetup.StartGame();
            bowlingGameSetup.AddPlayer("B");
            Assert.Equal(1, bowlingGameSetup.GetPlayers().Count);
        }
    }

    public class BowlingGameSetup
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