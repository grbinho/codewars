using Xunit;

namespace Codewars.Tests
{
    public class okkOokOoTests
    {
        [Fact]
		public void ExampleTests()
		{
			Assert.Equal("H", okkOokOoKata.okkOokOo("Ok, Ook, Ooo!"));
            Assert.Equal("e", okkOokOoKata.okkOokOo("Okk, Ook, Ok!"));
			Assert.Equal("l", okkOokOoKata.okkOokOo("Okk, Okk, Oo!"));
			Assert.Equal("o", okkOokOoKata.okkOokOo("Okk, Okkkk!"));
			Assert.Equal("W", okkOokOoKata.okkOokOo("Ok, Ok, Okkk!"));
			Assert.Equal("r", okkOokOoKata.okkOokOo("Okkk, Ook, O!"));
			Assert.Equal("d", okkOokOoKata.okkOokOo("Okk, Ook, Oo!"));
			Assert.Equal("@", okkOokOoKata.okkOokOo("Oko, Ooo, Oo!"));
		}
    }
}