using Xunit;

namespace Codewars.Tests
{
    public class LetsPlayDartsKataTests
    {
        [Theory]
        [InlineData("X", -133.69, -147.38)]
        [InlineData("DB", 4.06, 0.71)]
        [InlineData("SB", 2.38, -6.06)]
        [InlineData("20", -5.43, 117.95)]
        [InlineData("7", -73.905, -95.94)]
        [InlineData("T2", 55.53, -87.95)]
        [InlineData("D9", -145.19, 86.53)]
        public void GetScoreTest(string expected, double x, double y)
        {
            var dartboard = new Dartboard();
            Assert.Equal(expected, dartboard.GetScore(x, y));
        }
    }
}