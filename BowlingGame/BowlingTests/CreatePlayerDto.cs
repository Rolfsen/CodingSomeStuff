namespace BowlingTests
{
    public class CreatePlayerDto
    {
        public readonly string name;

        public CreatePlayerDto(string name)
        {
            this.name = name;
        }
    }
}