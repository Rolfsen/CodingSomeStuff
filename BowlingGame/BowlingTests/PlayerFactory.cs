namespace BowlingTests
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(CreatePlayerDto dto)
        {
            return new Player(dto.name);
        }
    }
}