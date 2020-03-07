using System.Collections.Generic;

namespace BowlingTests
{
    public interface CalculateScore
    {
        int GetScore(List<Turn> turns);
    }
}