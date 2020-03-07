using System.Collections.Generic;
using System.Linq;

namespace BowlingTests
{
    public class PlayerTurnManager
    {
        private int currentTurn = 0; 
        
        public List<Player> Players { get; }
        public Player CurrentPlayer { get; private set; }
        
        public PlayerTurnManager(List<Player> players)
        {
            Players = players;
            CurrentPlayer = players[0];
        }

        public void Roll(int roll)
        {
            var playerTurn = CurrentPlayer.Turn;
            var turn = CurrentPlayer.Roll(roll);
            if (turn == playerTurn) return;
            var currentIndex = Players.FindIndex(player => ReferenceEquals(player, CurrentPlayer));
            CurrentPlayer = currentIndex + 1 == Players.Count ? Players.First() : Players[currentTurn + 1];
        }
    }
}