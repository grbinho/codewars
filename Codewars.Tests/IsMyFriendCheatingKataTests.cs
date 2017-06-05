using Xunit;
using System.Collections.Generic;

namespace Codewars.Tests
{
    public class IsMyFriedCheatingKataTests 
    {
        [Fact]
        public void Test1() {
            List<long[]> r = new List<long[]> {
                new long[] { 15, 21 },
                new long[] { 21, 15 }
            };
            Assert.Equal(r, RemovedNumbers.removNb(26));
        }
        [Fact]
        public void Test2() {
            Assert.Equal(new List<long[]>(), RemovedNumbers.removNb(100));
        }

        [Fact]
        public void Test3() {
            List<long[]> r = new List<long[]> {
                new long[] { 70, 73 },
                new long[] { 73, 70 }
            };
            Assert.Equal(r, RemovedNumbers.removNb(102));
        }
    }
}