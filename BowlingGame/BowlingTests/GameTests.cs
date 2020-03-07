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
}