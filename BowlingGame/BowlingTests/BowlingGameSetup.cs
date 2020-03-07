using System.Collections.Generic;

namespace BowlingTests
{
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

        public void AddPlayer(Player player)
        {
            if (!IsStarted)
                players.Add(player);
        }
    }
}