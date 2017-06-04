using Xunit;

namespace Codewars.Tests
{
    public class PigItKataTest
	{
		[Fact]
		public void KataTests()
		{
            Assert.Equal("igPay atinlay siay oolcay", PigItKata.PigIt("Pig latin is cool"));
			Assert.Equal("hisTay siay ymay tringsay", PigItKata.PigIt("This is my string"));
		}
	}
}
