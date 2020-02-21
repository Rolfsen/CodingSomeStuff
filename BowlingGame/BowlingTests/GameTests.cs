using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BowlingTests
{
    public class GameTests
    {
        private Player player;
        
        public GameTests()
        {
            this.player = new Player();
        }

    

        [Fact]
        public void Rolling0ShouldReturn0()
        {
            player.Roll(0);
            Assert.Equal(0, player.GetScore());
        }

        [Fact]
        public void Rolling1ShouldReturn1()
        {
            player.Roll(1);
            Assert.Equal(1,player.GetScore());
        }

        [Fact]
        public void Rolling1And3ShouldSetScoreTo4()
        {
            player.Roll(1);
            player.Roll(3);
            Assert.Equal(4,player.GetScore());
        }

        [Fact]
        public void PlayerShouldHave14PointsAfterRolling2AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(2);
            Assert.Equal(14, player.GetScore());
        }
        
        [Fact]
        public void PlayerShouldHave12PointsAfterRolling1AfterSpare()
        {
            player.Roll(1);
            player.Roll(9);
            player.Roll(1);
            Assert.Equal(12, player.GetScore());
        }

        [Fact]
        public void PlayerShouldHave16PointsAfterStrikeFollowedUpByTwo3()
        {
            player.Roll(10);
            player.Roll(2);
            player.Roll(2);
            Assert.Equal(18,player.GetScore());
        }
    }

    public class Player
    {
        private int turn = 0;
        private readonly List<int> rolls = new List<int>();
        private readonly List<Turn> turns = new List<Turn>();
        private int playerScore;

        public Player()
        {
            for (var i = 0; i < 10; i++)
            {
                turns.Add(new Turn());
            }
        }
        public int GetScore()
        {
            for (var index = 0; index < turns.Count; index++)
            {
                var currentTurnRolls = turns[index].Rolls;
                for (var turnRoll = 0; turnRoll < currentTurnRolls.Count; turnRoll++)
                {
                    playerScore += currentTurnRolls[turnRoll];
                }

                if (currentTurnRolls.Sum() == 10)
                {
                    if (currentTurnRolls.Count == 1)
                        playerScore += turns[index + 1].Rolls[1];
                    playerScore += turns[index + 1].Rolls[0];
                }
            }

            return playerScore;
        }
        public void Roll(int roll)
        {
           var currentTurn= turns[turn];
           if (currentTurn.Rolls.Sum() < 10 && currentTurn.Rolls.Count <= 1)
               currentTurn.Rolls.Add(roll);
           else
           {
               turn++;
               Roll(roll);
           }
        }
    }

    public class Turn
    {
        public List<int> Rolls;

        public Turn()
        {
            Rolls = new List<int>();
        }
    }
}