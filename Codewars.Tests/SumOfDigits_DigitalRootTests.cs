using Xunit;

namespace Codewars.Tests
{
    public class SumOfDigits_DigitalRootTests
    {
        private Number num;
  
        public SumOfDigits_DigitalRootTests() 
        {
            num = new Number();
        }

        [Fact]
        public void Tests()
        {
            Assert.Equal(7, num.DigitalRoot(16));  
            Assert.Equal(6, num.DigitalRoot(942));       
        }
    }
}