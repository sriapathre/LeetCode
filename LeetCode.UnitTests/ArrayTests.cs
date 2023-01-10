using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
        public void TwoSum_Test1()
        {
            var expectedResult = new[] { 0, 1 };
            var actualResult = arrays.TwoSum(Input.NumberArrays[0], 9);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }
        [TestMethod]
        public void TwoSum_Test2()
        {
            var expectedResult = new[] { 0, 11 };
            var actualResult = arrays.TwoSum(Input.NumberArrays[1], 8);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }
        [TestMethod]
        public void TwoSum_Test3()
        {
            var actualResult = arrays.TwoSum(Input.NumberArrays[1], 4);
            Assert.IsTrue(actualResult.Length == 0);
        }

        [TestMethod]
        public void FindMedianSortedArrays_Test1()
        {
            double expectedResult = 2.0;
            var actualResult = arrays.FindMedianSortedArrays(Input.SortedNumberArrays[0], Input.SortedNumberArrays[1]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void FindMedianSortedArrays_Test2()
        {
            double expectedResult = 2.5;
            var actualResult = arrays.FindMedianSortedArrays(Input.SortedNumberArrays[0], Input.SortedNumberArrays[2]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void FindMedianSortedArrays_Test3()
        {
            double expectedResult = 4.0;
            var actualResult = arrays.FindMedianSortedArrays(Input.SortedNumberArrays[3], Input.SortedNumberArrays[2]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void MaxArea_Test1()
        {
            int expectedResult = 1;
            var actualResult = arrays.MaxArea(Input.NumberArrays[2]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void MaxArea_Test2()
        {
            int expectedResult = 49;
            var actualResult = arrays.MaxArea(Input.NumberArrays[3]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ThreeSum_Test1()
        {
            var expectedResult = new List<IList<int>>() { new List<int>() { -1, -1, 2 }, new List<int>() { -1, 0, 1 } };
            var actualResult = arrays.ThreeSum(Input.NumberArrays[4]);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
            }
        }
        [TestMethod]
        public void ThreeSumClosest_Test1()
        {
            var expectedResult = 2;
            var actualResult = arrays.ThreeSumClosest(Input.NumberArrays[5],1);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveDuplicates_Test1()
        {
            var expectedResult = 7;
            var actualResult = arrays.RemoveDuplicates(Input.SortedNumberArrays[4]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveDuplicates_Test2()
        {
            var expectedResult = 5;
            var actualResult = arrays.RemoveDuplicates(Input.SortedNumberArrays[3]);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveElement_Test1()
        {
            var expectedResult = 8;
            var actualResult = arrays.RemoveElement(Input.SortedNumberArrays[5],6);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveElement_Test2()
        {
            var expectedResult = 4;
            var actualResult = arrays.RemoveElement(Input.SortedNumberArrays[3],7);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
