using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    public class ArrayTests
    {
        Arrays arrays;
        [TestInitialize]
        public void Setup()
        {
            arrays = new Arrays();
        }

        [TestMethod]
        public void TwoSum()
        {
            var expectedResult1 = new[] { 0, 1 };
            var expectedResult2 = new[] { 0, 11 };

            var actualResult1 = arrays.TwoSum(Input.NumberArrays[0], 9);
            var actualResult2 = arrays.TwoSum(Input.NumberArrays[1], 8);
            var actualResult3 = arrays.TwoSum(Input.NumberArrays[1], 4);

            Assert.IsTrue(actualResult1.SequenceEqual(expectedResult1));
            Assert.IsTrue(actualResult2.SequenceEqual(expectedResult2));
            Assert.IsTrue(actualResult3.Length == 0);
        }
    }
}
