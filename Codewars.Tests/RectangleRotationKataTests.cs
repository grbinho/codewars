using Xunit;
namespace Codewars.Tests
{
    public class RectangleRotationKataTests
    {
        [Fact]
        public void BasicTests()
        {
            var kata = new RectangleRotationKata();

            Assert.Equal(23, kata.RectangleRotation(6, 4));
            Assert.Equal(65, kata.RectangleRotation(30, 2));
            Assert.Equal(49, kata.RectangleRotation(8, 6));
            Assert.Equal(333, kata.RectangleRotation(16, 20));

            
        }
    }
}
