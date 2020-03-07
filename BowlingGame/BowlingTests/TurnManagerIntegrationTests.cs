using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class TurnManagerIntegrationTests
    {
        private PlayerTurnManager manager;
        
        public TurnManagerIntegrationTests()
        {
            this.manager = new PlayerTurnManager(new List<Player>()
            {
                new Player("P1"),
                new Player("P2")
            });
        }
        
        
        [Fact]
        public void Game1 ()
        {
            List<int> rolls = new List<int>()
            {
                3,5,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10,
                10
            };

            foreach (var ro in rolls)
            {
                manager.Roll(ro);
            }

            var scoreCalculator = new BowlingScoreCalculator();
            
            Assert.Equal(300, scoreCalculator.GetScore(manager.Players[1].turns));
            Assert.Equal(278, scoreCalculator.GetScore(manager.Players[0].turns));

        }
    }
}