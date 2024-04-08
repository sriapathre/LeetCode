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
            var input = new int[] { 2, 7, 11, 15 };
            var actualResult = arrays.TwoSum(input, 9);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }
        [TestMethod]
        public void TwoSum_Test2()
        {
            var expectedResult = new[] { 0, 11 };
            var input = new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 };
            var actualResult = arrays.TwoSum(input, 8);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }
        [TestMethod]
        public void TwoSum_Test3()
        {
            var input = new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 };
            var actualResult = arrays.TwoSum(input, 4);
            Assert.IsTrue(actualResult.Length == 0);
        }

        [TestMethod]
        public void FindMedianSortedArrays_Test1()
        {
            double expectedResult = 2.0;
            var actualResult = arrays.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void FindMedianSortedArrays_Test2()
        {
            double expectedResult = 2.5;
            var actualResult = arrays.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void FindMedianSortedArrays_Test3()
        {
            double expectedResult = 4.0;
            var actualResult = arrays.FindMedianSortedArrays(new int[] { 3, 4, 5, 6, 7 }, new int[] { 3, 4 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void MaxArea_Test1()
        {
            int expectedResult = 1;
            var actualResult = arrays.MaxArea(new int[] { 1, 1 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void MaxArea_Test2()
        {
            int expectedResult = 49;
            var actualResult = arrays.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ThreeSum_Test1()
        {
            var expectedResult = new List<IList<int>>() { new List<int>() { -1, -1, 2 }, new List<int>() { -1, 0, 1 } };
            var actualResult = arrays.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
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
            var actualResult = arrays.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveDuplicates_Test1()
        {
            var expectedResult = 7;
            var actualResult = arrays.RemoveDuplicates(new int[] { 1, 1, 2, 3, 4, 5, 5, 6, 6, 7 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveDuplicates_Test2()
        {
            var expectedResult = 5;
            var actualResult = arrays.RemoveDuplicates(new int[] { 3, 4, 5, 6, 7 });
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveElement_Test1()
        {
            var expectedResult = 8;
            var actualResult = arrays.RemoveElement(new int[] { 2, 3, 4, 5, 5, 6, 6, 7, 8, 9 }, 6);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveElement_Test2()
        {
            var expectedResult = 4;
            var actualResult = arrays.RemoveElement(new int[] { 3, 4, 5, 6, 7 }, 7);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ContainsDuplicate_Test1()
        {
            var input = new int[] { 1, 2, 3, 1 };
            Assert.IsTrue(arrays.ContainsDuplicate(input));
        }
        [TestMethod]
        public void ContainsDuplicate_Test2()
        {
            var input = new int[] { 1, 2, 3, 4 };
            Assert.IsFalse(arrays.ContainsDuplicate(input));
        }
        [TestMethod]
        public void ContainsDuplicate_Test3()
        {
            var input = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            Assert.IsTrue(arrays.ContainsDuplicate(input));
        }

        [TestMethod]
        public void MajorityElement_Test1()
        {
            var input = new int[] { 3, 2, 3 };
            var expectedResult = 3;
            var actualResult = arrays.MajorityElement(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MajorityElement_Test2()
        {
            var input = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var expectedResult = 2;
            var actualResult = arrays.MajorityElement(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MajorityElement_Test3()
        {
            var input = new int[] { 1 };
            var expectedResult = 1;
            var actualResult = arrays.MajorityElement(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LongestCommonPrefix_Test1()
        {
            var input = new string[] { "flower", "flow", "flight" };
            var expectedResult = "fl";
            var actualResult = arrays.LongestCommonPrefix(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LongestCommonPrefix_Test2()
        {
            var input = new string[] { "dog", "racecar", "car" };
            var expectedResult = "";
            var actualResult = arrays.LongestCommonPrefix(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LongestCommonPrefix_Test3()
        {
            var input = new string[] { "flower", "flower", "flower" };
            var expectedResult = "flower";
            var actualResult = arrays.LongestCommonPrefix(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SearchInsert_Test1()
        {
            var input = new int[] { 1, 3, 5, 6 };
            var expectedResult = 2;
            var actualResult = arrays.SearchInsert(input, 5);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SearchInsert_Test2()
        {
            var input = new int[] { 1, 3, 5, 6 };
            var expectedResult = 1;
            var actualResult = arrays.SearchInsert(input, 2);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SearchInsert_Test3()
        {
            var input = new int[] { 1, 3, 5, 6 };
            var expectedResult = 4;
            var actualResult = arrays.SearchInsert(input, 7);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PlusOne_Test1()
        {
            var input = new int[] { 1, 2, 3 };
            var expectedResult = new int[] { 1, 2, 4 };
            var actualResult = arrays.PlusOne(input);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void PlusOne_Test2()
        {
            var input = new int[] { 4, 3, 2, 1 };
            var expectedResult = new int[] { 4, 3, 2, 2 };
            var actualResult = arrays.PlusOne(input);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void PlusOne_Test3()
        {
            var input = new int[] { 9, 9, 9, 9 };
            var expectedResult = new int[] { 1, 0, 0, 0, 0 };
            var actualResult = arrays.PlusOne(input);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void Merge_Test1()
        {
            var input1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var input2 = new int[] { 2, 5, 6 };
            var m = 3;
            var n = 3;
            var expectedResult = new int[] { 1, 2, 2, 3, 5, 6 };
            arrays.Merge(input1, m, input2, n);
            Assert.IsTrue(expectedResult.SequenceEqual(input1));
        }

        [TestMethod]
        public void Merge_Test2()
        {
            var input1 = new int[] { 1 };
            var input2 = new int[] { };
            var m = 1;
            var n = 0;
            var expectedResult = new int[] { 1 };
            arrays.Merge(input1, m, input2, n);
            Assert.IsTrue(expectedResult.SequenceEqual(input1));
        }

        [TestMethod]
        public void Merge_Test3()
        {
            var input1 = new int[] { 0 };
            var input2 = new int[] { 1 };
            var m = 0;
            var n = 1;
            var expectedResult = new int[] { 1 };
            arrays.Merge(input1, m, input2, n);
            Assert.IsTrue(expectedResult.SequenceEqual(input1));
        }

    }
}
