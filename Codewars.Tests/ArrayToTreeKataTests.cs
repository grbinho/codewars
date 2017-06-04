using Xunit;

namespace Codewars.Tests
{
    
    public class ArrayToTreeKataTests {

        [Fact]
        public void EmptyArray()
        {
            TreeNode expected = null;
            Assert.Equal(expected, ArrayToTreeKata.ArrayToTree(new int[] {}));
        }
        
        [Fact]
        public void ArrayWithMultipleElements()
        {
            TreeNode expected = new TreeNode(17, new TreeNode(0, new TreeNode(3), new TreeNode(15)), new TreeNode(-4));
            Assert.Equal(expected, ArrayToTreeKata.ArrayToTree(new int[] {17, 0, -4, 3, 15}));
        }
    }
}