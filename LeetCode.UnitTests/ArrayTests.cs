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
        public void FourSum_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>() { -2, -1, 1, 2 },
                new List<int>() { -2, 0, 0, 2 },
                new List<int>() { -1, 0, 0, 1 }
            };
            var actualResult = arrays.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
        }

        [TestMethod]
        public void FourSum_Test2()
        {
            var expectedResult = new List<IList<int>>() { new List<int>() { 2, 2, 2, 2 } };
            var actualResult = arrays.FourSum(new int[] { 2, 2, 2, 2, 2 }, 8);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(expectedResult[0].SequenceEqual(actualResult[0]));
        }

        [TestMethod]
        public void FourSum_Test3()
        {
            var actualResult = arrays.FourSum(new int[] { 1, 2, 3 }, 100);
            Assert.AreEqual(0, actualResult.Count);
        }

        [TestMethod]
        public void RemoveDuplicates_Test1()
        {
            var expectedResult = 7;
            var actualResult = arrays.RemoveDuplicates(new int[] { 1, 1, 2, 3, 4, 5, 5, 6, 6, 7 });
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveDuplicates_Test_EmptyArray()
        {
            var expectedResult = 0;
            var actualResult = arrays.RemoveDuplicates(new int[] { });
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
        public void NextPermutation_Test1()
        {
            var input = new int[] { 1, 2, 3 };
            var expectedResult = new int[] { 1, 3, 2 };
            arrays.NextPermutation(input);
            Assert.IsTrue(expectedResult.SequenceEqual(input));
        }

        [TestMethod]
        public void NextPermutation_Test2()
        {
            var input = new int[] { 3, 2, 1 };
            var expectedResult = new int[] { 1, 2, 3 };
            arrays.NextPermutation(input);
            Assert.IsTrue(expectedResult.SequenceEqual(input));
        }

        [TestMethod]
        public void NextPermutation_Test3()
        {
            var input = new int[] { 1, 1, 5 };
            var expectedResult = new int[] { 1, 5, 1 };
            arrays.NextPermutation(input);
            Assert.IsTrue(expectedResult.SequenceEqual(input));
        }

        [TestMethod]
        public void Search_Test1()
        {
            var input = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            Assert.AreEqual(4, arrays.Search(input, 0));
        }

        [TestMethod]
        public void Search_Test2()
        {
            var input = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            Assert.AreEqual(-1, arrays.Search(input, 3));
        }

        [TestMethod]
        public void Search_Test3()
        {
            var input = new int[] { 1 };
            Assert.AreEqual(0, arrays.Search(input, 1));
        }

        [TestMethod]
        public void SearchRange_Test1()
        {
            var input = new int[] { 5, 7, 7, 8, 8, 10 };
            CollectionAssert.AreEqual(new int[] { 3, 4 }, arrays.SearchRange(input, 8));
        }

        [TestMethod]
        public void SearchRange_Test2()
        {
            var input = new int[] { 5, 7, 7, 8, 8, 10 };
            CollectionAssert.AreEqual(new int[] { -1, -1 }, arrays.SearchRange(input, 6));
        }

        [TestMethod]
        public void SearchRange_Test3()
        {
            var input = new int[] { };
            CollectionAssert.AreEqual(new int[] { -1, -1 }, arrays.SearchRange(input, 0));
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

        [TestMethod]
        public void MaxProfit_Test1()
        {
            var input = new int[] { 7, 1, 5, 3, 6, 4 };
            Assert.AreEqual(5, arrays.MaxProfit(input));
        }

        [TestMethod]
        public void MaxProfit_Test2()
        {
            var input = new int[] { 7, 6, 4, 3, 1 };
            Assert.AreEqual(0, arrays.MaxProfit(input));
        }

        [TestMethod]
        public void SingleNumber_Test1()
        {
            var input = new int[] { 2, 2, 1 };
            Assert.AreEqual(1, arrays.SingleNumber(input));
        }

        [TestMethod]
        public void SingleNumber_Test2()
        {
            var input = new int[] { 4, 1, 2, 1, 2 };
            Assert.AreEqual(4, arrays.SingleNumber(input));
        }

        [TestMethod]
        public void SingleNumber_Test3()
        {
            var input = new int[] { 1 };
            Assert.AreEqual(1, arrays.SingleNumber(input));
        }

        [TestMethod]
        public void GroupAnagrams_Test1()
        {
            var input = new string[] { "bee", "ebe", "eat", "tea", "tan", "ate", "nat", "bat", "eeb" };
            var expectedResult = new List<IList<string>>()
            {
                new List<string>() { "bat" },
                new List<string>() { "nat", "tan" },
                new List<string>() { "ate", "eat", "tea" },
                new List<string>() { "bee", "ebe", "eeb" }
            };
            var actualResult = arrays.GroupAnagrams(input);
            AssertGroupAnagramsAreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GroupAnagrams_Test2()
        {
            var input = new string[] { "" };
            var expectedResult = new List<IList<string>>() { new List<string>() { "" } };
            var actualResult = arrays.GroupAnagrams(input);
            AssertGroupAnagramsAreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GroupAnagrams_Test3()
        {
            var input = new string[] { "a" };
            var expectedResult = new List<IList<string>>() { new List<string>() { "a" } };
            var actualResult = arrays.GroupAnagrams(input);
            AssertGroupAnagramsAreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TopKFrequent_Test1()
        {
            var input = new int[] { 1, 1, 1, 2, 2, 3 };
            var expectedResult = new int[] { 1, 2 };
            var actualResult = arrays.TopKFrequent(input, 2);
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void TopKFrequent_Test2()
        {
            var input = new int[] { 1 };
            var expectedResult = new int[] { 1 };
            var actualResult = arrays.TopKFrequent(input, 1);
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void TopKFrequent_Test3()
        {
            var input = new int[] { 1, 2, 1, 2, 1, 2, 3, 1, 3, 2 };
            var expectedResult = new int[] { 1, 2 };
            var actualResult = arrays.TopKFrequent(input, 2);
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsValidSudoku_Test1()
        {
            var input = new char[][]
            {
                new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Assert.IsTrue(arrays.IsValidSudoku(input));
        }

        [TestMethod]
        public void IsValidSudoku_Test2()
        {
            var input = new char[][]
            {
                new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Assert.IsFalse(arrays.IsValidSudoku(input));
        }

        [TestMethod]
        public void SolveSudoku_Test1()
        {
            var input = new char[][]
            {
                new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            var expectedResult = new char[][]
            {
                new[] { '5', '3', '4', '6', '7', '8', '9', '1', '2' },
                new[] { '6', '7', '2', '1', '9', '5', '3', '4', '8' },
                new[] { '1', '9', '8', '3', '4', '2', '5', '6', '7' },
                new[] { '8', '5', '9', '7', '6', '1', '4', '2', '3' },
                new[] { '4', '2', '6', '8', '5', '3', '7', '9', '1' },
                new[] { '7', '1', '3', '9', '2', '4', '8', '5', '6' },
                new[] { '9', '6', '1', '5', '3', '7', '2', '8', '4' },
                new[] { '2', '8', '7', '4', '1', '9', '6', '3', '5' },
                new[] { '3', '4', '5', '2', '8', '6', '1', '7', '9' }
            };

            arrays.SolveSudoku(input);

            for (int i = 0; i < 9; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void SolveSudoku_Test_AlreadyValidAndSolvable()
        {
            var input = new char[][]
            {
                new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
                new[] { '4', '5', '6', '7', '8', '9', '1', '2', '3' },
                new[] { '7', '8', '9', '1', '2', '3', '4', '5', '6' },
                new[] { '2', '3', '1', '5', '6', '4', '8', '9', '7' },
                new[] { '5', '6', '4', '8', '9', '7', '2', '3', '1' },
                new[] { '8', '9', '7', '2', '3', '1', '5', '6', '4' },
                new[] { '3', '1', '2', '6', '4', '5', '9', '7', '8' },
                new[] { '6', '4', '5', '9', '7', '8', '3', '1', '2' },
                new[] { '9', '7', '8', '3', '1', '2', '6', '4', '5' }
            };
            var expectedResult = input.Select(row => (char[])row.Clone()).ToArray();

            arrays.SolveSudoku(input);

            for (int i = 0; i < 9; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void CombinationSum_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>() { 2, 2, 3 },
                new List<int>() { 7 }
            };
            var actualResult = arrays.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
        }

        [TestMethod]
        public void CombinationSum_Test2()
        {
            var actualResult = arrays.CombinationSum(new int[] { 2 }, 1);
            Assert.AreEqual(0, actualResult.Count);
        }

        [TestMethod]
        public void CombinationSum2_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>() { 1, 1, 6 },
                new List<int>() { 1, 2, 5 },
                new List<int>() { 1, 7 },
                new List<int>() { 2, 6 },
            };
            var actualResult = arrays.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
        }

        [TestMethod]
        public void CombinationSum2_Test2()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>() { 1, 2, 2 },
                new List<int>() { 5 }
            };
            var actualResult = arrays.CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
        }

        [TestMethod]
        public void FirstMissingPositive_Test1()
        {
            Assert.AreEqual(3, arrays.FirstMissingPositive(new int[] { 1, 2, 0 }));
        }

        [TestMethod]
        public void FirstMissingPositive_Test2()
        {
            Assert.AreEqual(2, arrays.FirstMissingPositive(new int[] { 3, 4, -1, 1 }));
        }

        [TestMethod]
        public void FirstMissingPositive_Test3()
        {
            Assert.AreEqual(1, arrays.FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 }));
        }

        [TestMethod]
        public void Trap_Test1()
        {
            var input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Assert.AreEqual(6, arrays.Trap(input));
        }

        [TestMethod]
        public void Trap_Test2()
        {
            var input = new int[] { 4, 2, 0, 3, 2, 5 };
            Assert.AreEqual(9, arrays.Trap(input));
        }

        [TestMethod]
        public void Trap_Test_EmptyArray()
        {
            Assert.AreEqual(0, arrays.Trap(new int[] { }));
        }

        [TestMethod]
        public void Rotate_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 }
            };
            var expectedResult = new int[][]
            {
                new[] { 7, 4, 1 },
                new[] { 8, 5, 2 },
                new[] { 9, 6, 3 }
            };
            arrays.Rotate(input);
            for (int i = 0; i < input.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void Rotate_Test2()
        {
            var input = new int[][]
            {
                new[] { 5, 1 },
                new[] { 2, 4 }
            };
            var expectedResult = new int[][]
            {
                new[] { 2, 5 },
                new[] { 4, 1 }
            };
            arrays.Rotate(input);
            for (int i = 0; i < input.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void MaxSubArray_Test1()
        {
            var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Assert.AreEqual(6, arrays.MaxSubArray(input));
        }

        [TestMethod]
        public void MaxSubArray_Test2()
        {
            var input = new int[] { 1 };
            Assert.AreEqual(1, arrays.MaxSubArray(input));
        }

        [TestMethod]
        public void MaxSubArray_Test3()
        {
            var input = new int[] { -1, -2, -3 };
            Assert.AreEqual(-1, arrays.MaxSubArray(input));
        }

        [TestMethod]
        public void SpiralOrder_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 }
            };
            var expectedResult = new List<int>() { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            var actualResult = arrays.SpiralOrder(input);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void SpiralOrder_Test2()
        {
            var input = new int[][]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 6, 7, 8 },
                new[] { 9, 10, 11, 12 }
            };
            var expectedResult = new List<int>() { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };
            var actualResult = arrays.SpiralOrder(input);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void Merge_Intervals_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 3 },
                new[] { 2, 6 },
                new[] { 8, 10 },
                new[] { 15, 18 }
            };
            var expectedResult = new int[][]
            {
                new[] { 1, 6 },
                new[] { 8, 10 },
                new[] { 15, 18 }
            };
            var actualResult = arrays.Merge(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void Merge_Intervals_Test2()
        {
            var input = new int[][]
            {
                new[] { 1, 4 },
                new[] { 4, 5 }
            };
            var expectedResult = new int[][] { new[] { 1, 5 } };
            var actualResult = arrays.Merge(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            CollectionAssert.AreEqual(expectedResult[0], actualResult[0]);
        }

        [TestMethod]
        public void Insert_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 3 },
                new[] { 6, 9 }
            };
            var newInterval = new int[] { 2, 5 };
            var expectedResult = new int[][]
            {
                new[] { 1, 5 },
                new[] { 6, 9 }
            };
            var actualResult = arrays.Insert(input, newInterval);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void Insert_Test2()
        {
            var input = new int[][]
            {
                new[] { 1, 2 },
                new[] { 3, 5 },
                new[] { 6, 7 },
                new[] { 8, 10 },
                new[] { 12, 16 }
            };
            var newInterval = new int[] { 4, 8 };
            var expectedResult = new int[][]
            {
                new[] { 1, 2 },
                new[] { 3, 10 },
                new[] { 12, 16 }
            };
            var actualResult = arrays.Insert(input, newInterval);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void Insert_Test_EmptyList()
        {
            var input = new int[][] { };
            var newInterval = new int[] { 5, 7 };
            var expectedResult = new int[][] { new[] { 5, 7 } };
            var actualResult = arrays.Insert(input, newInterval);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            CollectionAssert.AreEqual(expectedResult[0], actualResult[0]);
        }

        [TestMethod]
        public void GenerateMatrix_Test1()
        {
            var expectedResult = new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 8, 9, 4 },
                new[] { 7, 6, 5 }
            };
            var actualResult = arrays.GenerateMatrix(3);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void GenerateMatrix_Test2()
        {
            var expectedResult = new int[][] { new[] { 1 } };
            var actualResult = arrays.GenerateMatrix(1);
            CollectionAssert.AreEqual(expectedResult[0], actualResult[0]);
        }

        [TestMethod]
        public void UniquePaths_Test1()
        {
            Assert.AreEqual(28, arrays.UniquePaths(3, 7));
        }

        [TestMethod]
        public void UniquePaths_Test2()
        {
            Assert.AreEqual(3, arrays.UniquePaths(3, 2));
        }

        [TestMethod]
        public void UniquePathsWithObstacles_Test1()
        {
            var input = new int[][]
            {
                new[] { 0, 0, 0 },
                new[] { 0, 1, 0 },
                new[] { 0, 0, 0 }
            };
            Assert.AreEqual(2, arrays.UniquePathsWithObstacles(input));
        }

        [TestMethod]
        public void UniquePathsWithObstacles_Test2()
        {
            var input = new int[][]
            {
                new[] { 0, 1 },
                new[] { 0, 0 }
            };
            Assert.AreEqual(1, arrays.UniquePathsWithObstacles(input));
        }

        [TestMethod]
        public void MinPathSum_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 3, 1 },
                new[] { 1, 5, 1 },
                new[] { 4, 2, 1 }
            };
            Assert.AreEqual(7, arrays.MinPathSum(input));
        }

        [TestMethod]
        public void MinPathSum_Test2()
        {
            var input = new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 }
            };
            Assert.AreEqual(12, arrays.MinPathSum(input));
        }

        [TestMethod]
        public void SetZeroes_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 1, 1 },
                new[] { 1, 0, 1 },
                new[] { 1, 1, 1 }
            };
            var expectedResult = new int[][]
            {
                new[] { 1, 0, 1 },
                new[] { 0, 0, 0 },
                new[] { 1, 0, 1 }
            };
            arrays.SetZeroes(input);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void SetZeroes_Test2()
        {
            var input = new int[][]
            {
                new[] { 0, 1, 2, 0 },
                new[] { 3, 4, 5, 2 },
                new[] { 1, 3, 1, 5 }
            };
            var expectedResult = new int[][]
            {
                new[] { 0, 0, 0, 0 },
                new[] { 0, 4, 5, 0 },
                new[] { 0, 3, 1, 0 }
            };
            arrays.SetZeroes(input);
            for (int i = 0; i < expectedResult.Length; i++)
                CollectionAssert.AreEqual(expectedResult[i], input[i]);
        }

        [TestMethod]
        public void SearchMatrix_Test1()
        {
            var input = new int[][]
            {
                new[] { 1, 3, 5, 7 },
                new[] { 10, 11, 16, 20 },
                new[] { 23, 30, 34, 60 }
            };
            Assert.IsTrue(arrays.SearchMatrix(input, 3));
        }

        [TestMethod]
        public void SearchMatrix_Test2()
        {
            var input = new int[][]
            {
                new[] { 1, 3, 5, 7 },
                new[] { 10, 11, 16, 20 },
                new[] { 23, 30, 34, 60 }
            };
            Assert.IsFalse(arrays.SearchMatrix(input, 13));
        }

        [TestMethod]
        public void SortColors_Test1()
        {
            var input = new int[] { 2, 0, 2, 1, 1, 0 };
            var expectedResult = new int[] { 0, 0, 1, 1, 2, 2 };
            arrays.SortColors(input);
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void SortColors_Test2()
        {
            var input = new int[] { 2, 0, 1 };
            var expectedResult = new int[] { 0, 1, 2 };
            arrays.SortColors(input);
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void Subsets_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>(),
                new List<int>() { 1 },
                new List<int>() { 1, 2 },
                new List<int>() { 1, 2, 3 },
                new List<int>() { 1, 3 },
                new List<int>() { 2 },
                new List<int>() { 2, 3 },
                new List<int>() { 3 },
            };
            var actualResult = arrays.Subsets(new int[] { 1, 2, 3 });
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subsets_Test2()
        {
            var expectedResult = new List<IList<int>>() { new List<int>(), new List<int>() { 0 } };
            var actualResult = arrays.Subsets(new int[] { 0 });
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveDuplicatesII_Test1()
        {
            var expectedResult = 5;
            var actualResult = arrays.RemoveDuplicatesII(new int[] { 1, 1, 1, 2, 2, 3 });
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveDuplicatesII_Test2()
        {
            var expectedResult = 7;
            var actualResult = arrays.RemoveDuplicatesII(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 });
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveDuplicatesII_Test_EmptyArray()
        {
            var expectedResult = 0;
            var actualResult = arrays.RemoveDuplicatesII(new int[] { });
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubsetsWithDup_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>(),
                new List<int>() { 1 },
                new List<int>() { 1, 2 },
                new List<int>() { 1, 2, 2 },
                new List<int>() { 2 },
                new List<int>() { 2, 2 },
            };
            var actualResult = arrays.SubsetsWithDup(new int[] { 1, 2, 2 });
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubsetsWithDup_Test2()
        {
            var expectedResult = new List<IList<int>>() { new List<int>(), new List<int>() { 0 } };
            var actualResult = arrays.SubsetsWithDup(new int[] { 0 });
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void ProductExceptSelf_Test1()
        {
            var input = new int[] { 1, 2, 3, 4 };
            var expectedResult = new int[] { 24, 12, 8, 6 };
            var actualResult = arrays.ProductExceptSelf(input);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ProductExceptSelf_Test2()
        {
            var input = new int[] { -1, 1, 0, -3, 3 };
            var expectedResult = new int[] { 0, 0, 9, 0, 0 };
            var actualResult = arrays.ProductExceptSelf(input);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanJump_Test1()
        {
            var input = new int[] { 2, 3, 1, 1, 4 };
            Assert.IsTrue(arrays.CanJump(input));
        }
        [TestMethod]
        public void CanJump_Test2()
        {
            var input = new int[] { 3, 2, 1, 0, 4 };
            Assert.IsFalse(arrays.CanJump(input));
        }
        [TestMethod]
        public void CanJump_Test3_SingleElement()
        {
            var input = new int[] { 0 };
            Assert.IsTrue(arrays.CanJump(input));
        }

        [TestMethod]
        public void Jump_Test1()
        {
            var input = new int[] { 2, 3, 1, 1, 4 };
            Assert.AreEqual(2, arrays.Jump(input));
        }
        [TestMethod]
        public void Jump_Test2()
        {
            var input = new int[] { 2, 3, 0, 1, 4 };
            Assert.AreEqual(2, arrays.Jump(input));
        }
        [TestMethod]
        public void Jump_Test3_SingleElement()
        {
            var input = new int[] { 0 };
            Assert.AreEqual(0, arrays.Jump(input));
        }

        [TestMethod]
        public void Permute_Test1()
        {
            var input = new int[] { 1, 2, 3 };
            var expectedResult = new List<IList<int>>()
            {
                new List<int>{1,2,3}, new List<int>{1,3,2}, new List<int>{2,1,3},
                new List<int>{2,3,1}, new List<int>{3,1,2}, new List<int>{3,2,1}
            };
            var actualResult = arrays.Permute(input);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }
        [TestMethod]
        public void Permute_Test2_SingleElement()
        {
            var input = new int[] { 1 };
            var expectedResult = new List<IList<int>>() { new List<int> { 1 } };
            var actualResult = arrays.Permute(input);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void PermuteUnique_Test1()
        {
            var input = new int[] { 1, 1, 2 };
            var expectedResult = new List<IList<int>>()
            {
                new List<int>{1,1,2}, new List<int>{1,2,1}, new List<int>{2,1,1}
            };
            var actualResult = arrays.PermuteUnique(input);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }
        [TestMethod]
        public void PermuteUnique_Test2_AllDuplicates()
        {
            var input = new int[] { 2, 2, 2 };
            var expectedResult = new List<IList<int>>() { new List<int> { 2, 2, 2 } };
            var actualResult = arrays.PermuteUnique(input);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void SolveNQueens_Test1_NEqualsFour()
        {
            var actualResult = arrays.SolveNQueens(4);
            Assert.AreEqual(2, actualResult.Count);
            foreach (var board in actualResult)
            {
                Assert.AreEqual(4, board.Count);
                Assert.IsTrue(board.All(row => row.Length == 4));
            }
        }
        [TestMethod]
        public void SolveNQueens_Test2_NEqualsOne()
        {
            var actualResult = arrays.SolveNQueens(1);
            Assert.AreEqual(1, actualResult.Count);
            Assert.AreEqual("Q", actualResult[0][0]);
        }
        [TestMethod]
        public void SolveNQueens_Test3_NoSolutionForTwoOrThree()
        {
            Assert.AreEqual(0, arrays.SolveNQueens(2).Count);
            Assert.AreEqual(0, arrays.SolveNQueens(3).Count);
        }

        [TestMethod]
        public void TotalNQueens_Test1()
        {
            Assert.AreEqual(2, arrays.TotalNQueens(4));
        }
        [TestMethod]
        public void TotalNQueens_Test2_NEqualsOne()
        {
            Assert.AreEqual(1, arrays.TotalNQueens(1));
        }
        [TestMethod]
        public void TotalNQueens_Test3_NoSolutionForTwoOrThree()
        {
            Assert.AreEqual(0, arrays.TotalNQueens(2));
            Assert.AreEqual(0, arrays.TotalNQueens(3));
        }

        [TestMethod]
        public void GetPermutation_Test1()
        {
            Assert.AreEqual("213", arrays.GetPermutation(3, 3));
        }
        [TestMethod]
        public void GetPermutation_Test2()
        {
            Assert.AreEqual("123", arrays.GetPermutation(3, 1));
        }
        [TestMethod]
        public void GetPermutation_Test3_SingleElement()
        {
            Assert.AreEqual("1", arrays.GetPermutation(1, 1));
        }
        [TestMethod]
        public void GetPermutation_Test4_LastPermutation()
        {
            Assert.AreEqual("4321", arrays.GetPermutation(4, 24));
        }

        [TestMethod]
        public void Combine_Test1()
        {
            var expectedResult = new List<IList<int>>()
            {
                new List<int>{1,2}, new List<int>{1,3}, new List<int>{1,4},
                new List<int>{2,3}, new List<int>{2,4}, new List<int>{3,4}
            };
            var actualResult = arrays.Combine(4, 2);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }
        [TestMethod]
        public void Combine_Test2_KEqualsN()
        {
            var expectedResult = new List<IList<int>>() { new List<int> { 1, 2, 3 } };
            var actualResult = arrays.Combine(3, 3);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }
        [TestMethod]
        public void Combine_Test3_KEqualsOne()
        {
            var expectedResult = new List<IList<int>>() { new List<int> { 1 }, new List<int> { 2 } };
            var actualResult = arrays.Combine(2, 1);
            AssertGroupsAreEquivalent(expectedResult, actualResult);
        }

        [TestMethod]
        public void Exist_Test1_WordFound()
        {
            var board = new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            };
            Assert.IsTrue(arrays.Exist(board, "ABCCED"));
        }
        [TestMethod]
        public void Exist_Test2_WordNotFound()
        {
            var board = new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            };
            Assert.IsFalse(arrays.Exist(board, "ABCB"));
        }
        [TestMethod]
        public void Exist_Test3_SingleCellMatch()
        {
            var board = new char[][] { new char[] { 'A' } };
            Assert.IsTrue(arrays.Exist(board, "A"));
        }

        [TestMethod]
        public void SearchII_Test1_TargetPresent()
        {
            var input = new int[] { 2, 5, 6, 0, 0, 1, 2 };
            Assert.IsTrue(arrays.SearchII(input, 0));
        }
        [TestMethod]
        public void SearchII_Test2_TargetAbsent()
        {
            var input = new int[] { 2, 5, 6, 0, 0, 1, 2 };
            Assert.IsFalse(arrays.SearchII(input, 3));
        }
        [TestMethod]
        public void SearchII_Test3_AllDuplicatesTargetAbsent()
        {
            var input = new int[] { 1, 1, 1, 1, 1 };
            Assert.IsFalse(arrays.SearchII(input, 2));
        }

        [TestMethod]
        public void LargestRectangleArea_Test1()
        {
            var input = new int[] { 2, 1, 5, 6, 2, 3 };
            Assert.AreEqual(10, arrays.LargestRectangleArea(input));
        }
        [TestMethod]
        public void LargestRectangleArea_Test2()
        {
            var input = new int[] { 2, 4 };
            Assert.AreEqual(4, arrays.LargestRectangleArea(input));
        }
        [TestMethod]
        public void LargestRectangleArea_Test3_SingleBar()
        {
            var input = new int[] { 5 };
            Assert.AreEqual(5, arrays.LargestRectangleArea(input));
        }

        [TestMethod]
        public void MaximalRectangle_Test1()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '0', '1', '0', '0' },
                new char[] { '1', '0', '1', '1', '1' },
                new char[] { '1', '1', '1', '1', '1' },
                new char[] { '1', '0', '0', '1', '0' }
            };
            Assert.AreEqual(6, arrays.MaximalRectangle(matrix));
        }
        [TestMethod]
        public void MaximalRectangle_Test2_AllZeros()
        {
            var matrix = new char[][] { new char[] { '0' } };
            Assert.AreEqual(0, arrays.MaximalRectangle(matrix));
        }
        [TestMethod]
        public void MaximalRectangle_Test3_EmptyMatrix()
        {
            var matrix = new char[][] { };
            Assert.AreEqual(0, arrays.MaximalRectangle(matrix));
        }


        [TestMethod]
        public void MinimumTotal_Test1()
        {
            var triangle = new List<IList<int>>
            {
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 6, 5, 7 },
                new List<int> { 4, 1, 8, 3 }
            };
            Assert.AreEqual(11, arrays.MinimumTotal(triangle));
        }

        [TestMethod]
        public void MinimumTotal_Test2_SingleNegative()
        {
            var triangle = new List<IList<int>> { new List<int> { -10 } };
            Assert.AreEqual(-10, arrays.MinimumTotal(triangle));
        }

        [TestMethod]
        public void MaxProfitII_Test1()
        {
            Assert.AreEqual(7, arrays.MaxProfitII(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        [TestMethod]
        public void MaxProfitII_Test2_NoProfit()
        {
            Assert.AreEqual(0, arrays.MaxProfitII(new int[] { 7, 6, 4, 3, 1 }));
        }

        [TestMethod]
        public void MaxProfitIII_Test1()
        {
            Assert.AreEqual(6, arrays.MaxProfitIII(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }));
        }

        [TestMethod]
        public void MaxProfitIII_Test2_Ascending()
        {
            Assert.AreEqual(4, arrays.MaxProfitIII(new int[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void LongestConsecutive_Test1()
        {
            Assert.AreEqual(4, arrays.LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
        }

        [TestMethod]
        public void LongestConsecutive_Test2_WithDuplicates()
        {
            Assert.AreEqual(9, arrays.LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }));
        }

        [TestMethod]
        public void CanCompleteCircuit_Test1()
        {
            Assert.AreEqual(3, arrays.CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }));
        }

        [TestMethod]
        public void CanCompleteCircuit_Test2_Impossible()
        {
            Assert.AreEqual(-1, arrays.CanCompleteCircuit(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }));
        }

        [TestMethod]
        public void Candy_Test1()
        {
            Assert.AreEqual(5, arrays.Candy(new int[] { 1, 0, 2 }));
        }

        [TestMethod]
        public void Candy_Test2_Plateau()
        {
            Assert.AreEqual(4, arrays.Candy(new int[] { 1, 2, 2 }));
        }

        [TestMethod]
        public void MaxProduct_Test1()
        {
            Assert.AreEqual(6, arrays.MaxProduct(new int[] { 2, 3, -2, 4 }));
        }

        [TestMethod]
        public void MaxProduct_Test2_WithZeroAndNegative()
        {
            Assert.AreEqual(0, arrays.MaxProduct(new int[] { -2, 0, -1 }));
        }

        [TestMethod]
        public void FindMin_Test1()
        {
            Assert.AreEqual(1, arrays.FindMin(new int[] { 3, 4, 5, 1, 2 }));
        }

        [TestMethod]
        public void FindMin_Test2_NotRotated()
        {
            Assert.AreEqual(0, arrays.FindMin(new int[] { 0, 1, 2, 4, 5, 6, 7 }));
        }

        [TestMethod]
        public void FindMinII_Test1()
        {
            Assert.AreEqual(1, arrays.FindMinII(new int[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void FindMinII_Test2_WithDuplicates()
        {
            Assert.AreEqual(0, arrays.FindMinII(new int[] { 2, 2, 2, 0, 1 }));
        }

        [TestMethod]
        public void FindPeakElement_Test1()
        {
            Assert.AreEqual(2, arrays.FindPeakElement(new int[] { 1, 2, 3, 1 }));
        }

        [TestMethod]
        public void FindPeakElement_Test2_ReturnsAnyPeak()
        {
            int[] nums = new int[] { 1, 2, 1, 3, 5, 6, 4 };
            int peak = arrays.FindPeakElement(nums);
            bool greaterThanLeft = peak == 0 || nums[peak] > nums[peak - 1];
            bool greaterThanRight = peak == nums.Length - 1 || nums[peak] > nums[peak + 1];
            Assert.IsTrue(greaterThanLeft && greaterThanRight);
        }

        [TestMethod]
        public void MaximumGap_Test1()
        {
            Assert.AreEqual(3, arrays.MaximumGap(new int[] { 3, 6, 9, 1 }));
        }

        [TestMethod]
        public void MaximumGap_Test2_SingleElement()
        {
            Assert.AreEqual(0, arrays.MaximumGap(new int[] { 10 }));
        }

        [TestMethod]
        public void TwoSumII_Test1()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2 }, arrays.TwoSumII(new int[] { 2, 7, 11, 15 }, 9));
        }

        [TestMethod]
        public void TwoSumII_Test2_Negatives()
        {
            CollectionAssert.AreEqual(new int[] { 1, 3 }, arrays.TwoSumII(new int[] { -1, 0, 1 }, 0));
        }

        [TestMethod]
        public void CalculateMinimumHP_Test1()
        {
            var dungeon = new int[][]
            {
                new[] { -2, -3, 3 },
                new[] { -5, -10, 1 },
                new[] { 10, 30, -5 }
            };
            Assert.AreEqual(7, arrays.CalculateMinimumHP(dungeon));
        }

        [TestMethod]
        public void CalculateMinimumHP_Test2_SinglePositiveRoom()
        {
            Assert.AreEqual(1, arrays.CalculateMinimumHP(new int[][] { new[] { 10 } }));
        }

        [TestMethod]
        public void MaxProfitIV_Test1()
        {
            Assert.AreEqual(2, arrays.MaxProfitIV(2, new int[] { 2, 4, 1 }));
        }

        [TestMethod]
        public void MaxProfitIV_Test2_MultipleTransactions()
        {
            Assert.AreEqual(7, arrays.MaxProfitIV(2, new int[] { 3, 2, 6, 5, 0, 3 }));
        }

        [TestMethod]
        public void Rotate_Array_Test1()
        {
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            arrays.Rotate(input, 3);
            CollectionAssert.AreEqual(new int[] { 5, 6, 7, 1, 2, 3, 4 }, input);
        }

        [TestMethod]
        public void Rotate_Array_Test2_KGreaterThanLength()
        {
            var input = new int[] { -1, -100, 3, 99 };
            arrays.Rotate(input, 2);
            CollectionAssert.AreEqual(new int[] { 3, 99, -1, -100 }, input);
        }

        [TestMethod]
        public void Rob_Test1()
        {
            Assert.AreEqual(4, arrays.Rob(new int[] { 1, 2, 3, 1 }));
        }

        [TestMethod]
        public void Rob_Test2()
        {
            Assert.AreEqual(12, arrays.Rob(new int[] { 2, 7, 9, 3, 1 }));
        }



        [TestMethod]
        public void MinSubArrayLen_Test1()
        {
            Assert.AreEqual(2, arrays.MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 }));
        }

        [TestMethod]
        public void MinSubArrayLen_Test2_NoMatch()
        {
            Assert.AreEqual(0, arrays.MinSubArrayLen(11, new int[] { 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void FindKthLargest_Test1()
        {
            Assert.AreEqual(5, arrays.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2));
        }

        [TestMethod]
        public void FindKthLargest_Test2_WithDuplicates()
        {
            Assert.AreEqual(4, arrays.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
        }

        [TestMethod]
        public void ContainsNearbyDuplicate_Test1()
        {
            Assert.IsTrue(arrays.ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1 }, 3));
        }

        [TestMethod]
        public void ContainsNearbyDuplicate_Test2_TooFar()
        {
            Assert.IsFalse(arrays.ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1, 2, 3 }, 2));
        }

        [TestMethod]
        public void ContainsNearbyAlmostDuplicate_Test1()
        {
            Assert.IsTrue(arrays.ContainsNearbyAlmostDuplicate(new int[] { 1, 2, 3, 1 }, 3, 0));
        }

        [TestMethod]
        public void ContainsNearbyAlmostDuplicate_Test2_NegativeValues()
        {
            Assert.IsFalse(arrays.ContainsNearbyAlmostDuplicate(new int[] { -3, 3 }, 2, 4));
        }

        [TestMethod]
        public void SummaryRanges_Test1()
        {
            CollectionAssert.AreEqual(new List<string> { "0->2", "4->5", "7" }, arrays.SummaryRanges(new int[] { 0, 1, 2, 4, 5, 7 }).ToList());
        }

        [TestMethod]
        public void SummaryRanges_Test2_Empty()
        {
            Assert.AreEqual(0, arrays.SummaryRanges(new int[] { }).Count);
        }

        [TestMethod]
        public void MajorityElementII_Test1()
        {
            CollectionAssert.AreEquivalent(new int[] { 3 }, arrays.MajorityElementII(new int[] { 3, 2, 3 }).ToArray());
        }

        [TestMethod]
        public void MajorityElementII_Test2_TwoMajorities()
        {
            CollectionAssert.AreEquivalent(new int[] { 1, 2 }, arrays.MajorityElementII(new int[] { 1, 1, 1, 3, 3, 2, 2, 2 }).ToArray());
        }

        [TestMethod]
        public void MaxSlidingWindow_Test1()
        {
            CollectionAssert.AreEqual(new int[] { 3, 3, 5, 5, 6, 7 }, arrays.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));
        }

        [TestMethod]
        public void MaxSlidingWindow_Test2_WindowOne()
        {
            CollectionAssert.AreEqual(new int[] { 1, -1 }, arrays.MaxSlidingWindow(new int[] { 1, -1 }, 1));
        }

        [TestMethod]
        public void SearchMatrixII_Test1()
        {
            var matrix = new int[][]
            {
                new[] { 1, 4, 7, 11, 15 },
                new[] { 2, 5, 8, 12, 19 },
                new[] { 3, 6, 9, 16, 22 },
                new[] { 10, 13, 14, 17, 24 },
                new[] { 18, 21, 23, 26, 30 }
            };
            Assert.IsTrue(arrays.SearchMatrixII(matrix, 5));
        }

        [TestMethod]
        public void SearchMatrixII_Test2_Absent()
        {
            var matrix = new int[][] { new[] { 1, 4 }, new[] { 2, 5 } };
            Assert.IsFalse(arrays.SearchMatrixII(matrix, 3));
        }

        [TestMethod]
        public void MissingNumber_Test1()
        {
            Assert.AreEqual(2, arrays.MissingNumber(new int[] { 3, 0, 1 }));
        }

        [TestMethod]
        public void MissingNumber_Test2_MissingN()
        {
            Assert.AreEqual(3, arrays.MissingNumber(new int[] { 0, 1, 2 }));
        }

        [TestMethod]
        public void HIndex_Test1()
        {
            Assert.AreEqual(3, arrays.HIndex(new int[] { 3, 0, 6, 1, 5 }));
        }

        [TestMethod]
        public void HIndex_Test2_AllZero()
        {
            Assert.AreEqual(0, arrays.HIndex(new int[] { 0, 0, 0 }));
        }

        [TestMethod]
        public void HIndexII_Test1()
        {
            Assert.AreEqual(3, arrays.HIndexII(new int[] { 0, 1, 3, 5, 6 }));
        }

        [TestMethod]
        public void HIndexII_Test2_Empty()
        {
            Assert.AreEqual(0, arrays.HIndexII(new int[] { }));
        }

        [TestMethod]
        public void MoveZeroes_Test1()
        {
            var input = new int[] { 0, 1, 0, 3, 12 };
            arrays.MoveZeroes(input);
            CollectionAssert.AreEqual(new int[] { 1, 3, 12, 0, 0 }, input);
        }

        [TestMethod]
        public void MoveZeroes_Test2_AllZeroes()
        {
            var input = new int[] { 0, 0 };
            arrays.MoveZeroes(input);
            CollectionAssert.AreEqual(new int[] { 0, 0 }, input);
        }

        [TestMethod]
        public void FindDuplicate_Test1()
        {
            Assert.AreEqual(2, arrays.FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));
        }

        [TestMethod]
        public void FindDuplicate_Test2_RepeatedManyTimes()
        {
            Assert.AreEqual(3, arrays.FindDuplicate(new int[] { 3, 1, 3, 4, 2 }));
        }

        [TestMethod]
        public void GameOfLife_Test1()
        {
            var board = new int[][]
            {
                new[] { 0, 1, 0 },
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 },
                new[] { 0, 0, 0 }
            };
            arrays.GameOfLife(board);
            AssertMatrixAreEqual(new int[][] { new[] { 0, 0, 0 }, new[] { 1, 0, 1 }, new[] { 0, 1, 1 }, new[] { 0, 1, 0 } }, board);
        }

        [TestMethod]
        public void GameOfLife_Test2_SingleCellDies()
        {
            var board = new int[][] { new[] { 1 } };
            arrays.GameOfLife(board);
            AssertMatrixAreEqual(new int[][] { new[] { 0 } }, board);
        }

        [TestMethod]
        public void LengthOfLIS_Test1()
        {
            Assert.AreEqual(4, arrays.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
        }

        [TestMethod]
        public void LengthOfLIS_Test2_AllEqual()
        {
            Assert.AreEqual(1, arrays.LengthOfLIS(new int[] { 7, 7, 7, 7 }));
        }

        [TestMethod]
        public void IncreasingTriplet_Test1()
        {
            Assert.IsTrue(arrays.IncreasingTriplet(new int[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void IncreasingTriplet_Test2_Decreasing()
        {
            Assert.IsFalse(arrays.IncreasingTriplet(new int[] { 5, 4, 3, 2, 1 }));
        }

        [TestMethod]
        public void Intersection_Test1()
        {
            CollectionAssert.AreEquivalent(new int[] { 2 }, arrays.Intersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }));
        }

        [TestMethod]
        public void Intersection_Test2_NoOverlap()
        {
            Assert.AreEqual(0, arrays.Intersection(new int[] { 1 }, new int[] { 2 }).Length);
        }

        [TestMethod]
        public void Intersect_Test1()
        {
            CollectionAssert.AreEquivalent(new int[] { 2, 2 }, arrays.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }));
        }

        [TestMethod]
        public void Intersect_Test2_DifferentLengths()
        {
            CollectionAssert.AreEquivalent(new int[] { 4, 9 }, arrays.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }));
        }

        [TestMethod]
        public void MaxRotateFunction_Test1()
        {
            Assert.AreEqual(26, arrays.MaxRotateFunction(new int[] { 4, 3, 2, 6 }));
        }

        [TestMethod]
        public void MaxRotateFunction_Test2_Single()
        {
            Assert.AreEqual(0, arrays.MaxRotateFunction(new int[] { 100 }));
        }

        [TestMethod]
        public void ThirdMax_Test1()
        {
            Assert.AreEqual(1, arrays.ThirdMax(new int[] { 3, 2, 1 }));
        }

        [TestMethod]
        public void ThirdMax_Test2_FewerDistinct()
        {
            Assert.AreEqual(2, arrays.ThirdMax(new int[] { 1, 2, 2 }));
        }

        [TestMethod]
        public void FindDisappearedNumbers_Test1()
        {
            CollectionAssert.AreEqual(new List<int> { 5, 6 }, arrays.FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }).ToList());
        }

        [TestMethod]
        public void FindDisappearedNumbers_Test2_NoneMissing()
        {
            Assert.AreEqual(0, arrays.FindDisappearedNumbers(new int[] { 1 }).Count);
        }

        [TestMethod]
        public void FindMaxConsecutiveOnes_Test1()
        {
            Assert.AreEqual(3, arrays.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 }));
        }

        [TestMethod]
        public void FindMaxConsecutiveOnes_Test2_AllZeroes()
        {
            Assert.AreEqual(0, arrays.FindMaxConsecutiveOnes(new int[] { 0, 0 }));
        }

        [TestMethod]
        public void FindDiagonalOrder_Test1()
        {
            var mat = new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            CollectionAssert.AreEqual(new int[] { 1, 2, 4, 7, 5, 3, 6, 8, 9 }, arrays.FindDiagonalOrder(mat));
        }

        [TestMethod]
        public void FindDiagonalOrder_Test2_SingleRow()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, arrays.FindDiagonalOrder(new int[][] { new[] { 1, 2, 3 } }));
        }

        [TestMethod]
        public void SubarraySum_Test1()
        {
            Assert.AreEqual(2, arrays.SubarraySum(new int[] { 1, 1, 1 }, 2));
        }

        [TestMethod]
        public void SubarraySum_Test2_WithNegatives()
        {
            Assert.AreEqual(3, arrays.SubarraySum(new int[] { 1, -1, 0 }, 0));
        }

        [TestMethod]
        public void MatrixReshape_Test1()
        {
            var result = arrays.MatrixReshape(new int[][] { new[] { 1, 2 }, new[] { 3, 4 } }, 1, 4);
            AssertMatrixAreEqual(new int[][] { new[] { 1, 2, 3, 4 } }, result);
        }

        [TestMethod]
        public void MatrixReshape_Test2_IncompatibleReturnsOriginal()
        {
            var input = new int[][] { new[] { 1, 2 }, new[] { 3, 4 } };
            var result = arrays.MatrixReshape(input, 2, 3);
            Assert.AreSame(input, result);
        }

        [TestMethod]
        public void FindUnsortedSubarray_Test1()
        {
            Assert.AreEqual(5, arrays.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 }));
        }

        [TestMethod]
        public void FindUnsortedSubarray_Test2_AlreadySorted()
        {
            Assert.AreEqual(0, arrays.FindUnsortedSubarray(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void FindMaxAverage_Test1()
        {
            Assert.AreEqual(12.75, arrays.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4));
        }

        [TestMethod]
        public void FindMaxAverage_Test2_KIsLength()
        {
            Assert.AreEqual(5.0, arrays.FindMaxAverage(new int[] { 5 }, 1));
        }

        [TestMethod]
        public void ImageSmoother_Test1()
        {
            var img = new int[][] { new[] { 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 1, 1 } };
            AssertMatrixAreEqual(new int[][] { new[] { 0, 0, 0 }, new[] { 0, 0, 0 }, new[] { 0, 0, 0 } }, arrays.ImageSmoother(img));
        }

        [TestMethod]
        public void ImageSmoother_Test2_SingleCell()
        {
            AssertMatrixAreEqual(new int[][] { new[] { 100 } }, arrays.ImageSmoother(new int[][] { new[] { 100 } }));
        }

        [TestMethod]
        public void CheckPossibility_Test1()
        {
            Assert.IsTrue(arrays.CheckPossibility(new int[] { 4, 2, 3 }));
        }

        [TestMethod]
        public void CheckPossibility_Test2_NotPossible()
        {
            Assert.IsFalse(arrays.CheckPossibility(new int[] { 4, 2, 1 }));
        }

        [TestMethod]
        public void FindLengthOfLCIS_Test1()
        {
            Assert.AreEqual(3, arrays.FindLengthOfLCIS(new int[] { 1, 3, 5, 4, 7 }));
        }

        [TestMethod]
        public void FindLengthOfLCIS_Test2_Empty()
        {
            Assert.AreEqual(0, arrays.FindLengthOfLCIS(new int[] { }));
        }

        [TestMethod]
        public void FindShortestSubArray_Test1()
        {
            Assert.AreEqual(2, arrays.FindShortestSubArray(new int[] { 1, 2, 2, 3, 1 }));
        }

        [TestMethod]
        public void FindShortestSubArray_Test2_TieChoosesShortest()
        {
            Assert.AreEqual(6, arrays.FindShortestSubArray(new int[] { 1, 2, 2, 3, 1, 4, 2 }));
        }

        [TestMethod]
        public void Search704_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.Search704(new int[] { -1, 0, 3, 5, 9, 12 }, 9));
            Assert.AreEqual(-1, arrays.Search704(new int[] { -1, 0, 3, 5, 9, 12 }, 2));
        }

        [TestMethod]
        public void NumSubarrayProductLessThanK_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(8, arrays.NumSubarrayProductLessThanK(new int[] { 10, 5, 2, 6 }, 100));
            Assert.AreEqual(0, arrays.NumSubarrayProductLessThanK(new int[] { 1, 2, 3 }, 0));
        }

        [TestMethod]
        public void MaxProfit_WithFee_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(8, arrays.MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 }, 2));
            Assert.AreEqual(0, arrays.MaxProfit(new int[] { 9, 8, 7 }, 2));
        }

        [TestMethod]
        public void FindLength_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.FindLength(new int[] { 1, 2, 3, 2, 1 }, new int[] { 3, 2, 1, 4, 7 }));
            Assert.AreEqual(0, arrays.FindLength(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));
        }

        [TestMethod]
        public void PivotIndex_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 }));
            Assert.AreEqual(-1, arrays.PivotIndex(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void AsteroidCollision_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 5, 10 }, arrays.AsteroidCollision(new int[] { 5, 10, -5 }));
            CollectionAssert.AreEqual(new int[] { }, arrays.AsteroidCollision(new int[] { 8, -8 }));
        }

        [TestMethod]
        public void DailyTemperatures_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1, 4, 2, 1, 1, 0, 0 }, arrays.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }));
            CollectionAssert.AreEqual(new int[] { 0, 0 }, arrays.DailyTemperatures(new int[] { 80, 70 }));
        }

        [TestMethod]
        public void MinCostClimbingStairs_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(15, arrays.MinCostClimbingStairs(new int[] { 10, 15, 20 }));
            Assert.AreEqual(6, arrays.MinCostClimbingStairs(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }));
        }

        [TestMethod]
        public void DominantIndex_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.DominantIndex(new int[] { 3, 6, 1, 0 }));
            Assert.AreEqual(-1, arrays.DominantIndex(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void IsToeplitzMatrix_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.IsToeplitzMatrix(new int[][] { new[] { 1, 2, 3, 4 }, new[] { 5, 1, 2, 3 }, new[] { 9, 5, 1, 2 } }));
            Assert.IsFalse(arrays.IsToeplitzMatrix(new int[][] { new[] { 1, 2 }, new[] { 2, 2 } }));
        }

        [TestMethod]
        public void NumSubarrayBoundedMax_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.NumSubarrayBoundedMax(new int[] { 2, 1, 4, 3 }, 2, 3));
            Assert.AreEqual(7, arrays.NumSubarrayBoundedMax(new int[] { 2, 9, 2, 5, 6 }, 2, 8));
        }

        [TestMethod]
        public void FlipAndInvertImage_Test_ExamplesAndEdges()
        {
            AssertMatrixAreEqual(new int[][] { new[] { 1, 0, 0 }, new[] { 0, 1, 0 }, new[] { 1, 1, 1 } }, arrays.FlipAndInvertImage(new int[][] { new[] { 1, 1, 0 }, new[] { 1, 0, 1 }, new[] { 0, 0, 0 } }));
            AssertMatrixAreEqual(new int[][] { new[] { 0 } }, arrays.FlipAndInvertImage(new int[][] { new[] { 1 } }));
        }

        [TestMethod]
        public void MaxDistToClosest_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MaxDistToClosest(new int[] { 1, 0, 0, 0, 1, 0, 1 }));
            Assert.AreEqual(3, arrays.MaxDistToClosest(new int[] { 1, 0, 0, 0 }));
        }

        [TestMethod]
        public void PeakIndexInMountainArray_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.PeakIndexInMountainArray(new int[] { 0, 1, 0 }));
            Assert.AreEqual(2, arrays.PeakIndexInMountainArray(new int[] { 0, 2, 3, 1 }));
        }

        [TestMethod]
        public void MinEatingSpeed_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8));
            Assert.AreEqual(30, arrays.MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 5));
        }

        [TestMethod]
        public void NumRescueBoats_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.NumRescueBoats(new int[] { 1, 2 }, 3));
            Assert.AreEqual(3, arrays.NumRescueBoats(new int[] { 3, 2, 2, 1 }, 3));
        }

        [TestMethod]
        public void IsMonotonic_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.IsMonotonic(new int[] { 1, 2, 2, 3 }));
            Assert.IsFalse(arrays.IsMonotonic(new int[] { 1, 3, 2 }));
        }

        [TestMethod]
        public void SortArrayByParity_Test_ExamplesAndEdges()
        {
            var result = arrays.SortArrayByParity(new int[] { 3, 1, 2, 4 });
            Assert.IsTrue(result.TakeWhile(n => n % 2 == 0).Count() == result.Count(n => n % 2 == 0));
            CollectionAssert.AreEqual(new int[] { 0 }, arrays.SortArrayByParity(new int[] { 0 }));
        }

        [TestMethod]
        public void MaxSubarraySumCircular_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.MaxSubarraySumCircular(new int[] { 1, -2, 3, -2 }));
            Assert.AreEqual(-2, arrays.MaxSubarraySumCircular(new int[] { -3, -2, -3 }));
        }

        [TestMethod]
        public void ValidMountainArray_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.ValidMountainArray(new int[] { 0, 3, 2, 1 }));
            Assert.IsFalse(arrays.ValidMountainArray(new int[] { 3, 5, 5 }));
        }

        [TestMethod]
        public void KClosest_Test_ExamplesAndEdges()
        {
            AssertMatrixAreEqual(new int[][] { new[] { -2, 2 } }, arrays.KClosest(new int[][] { new[] { 1, 3 }, new[] { -2, 2 } }, 1));
            AssertMatrixAreEqual(new int[][] { new[] { 0, 1 }, new[] { 1, 0 } }, arrays.KClosest(new int[][] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 2, 2 } }, 2));
        }

        [TestMethod]
        public void SortedSquares_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 0, 1, 9, 16, 100 }, arrays.SortedSquares(new int[] { -4, -1, 0, 3, 10 }));
            CollectionAssert.AreEqual(new int[] { 1, 4, 9 }, arrays.SortedSquares(new int[] { -3, -2, -1 }));
        }

        [TestMethod]
        public void IntervalIntersection_Test_ExamplesAndEdges()
        {
            AssertMatrixAreEqual(new int[][] { new[] { 1, 2 }, new[] { 5, 5 }, new[] { 8, 10 }, new[] { 15, 23 }, new[] { 24, 24 }, new[] { 25, 25 } }, arrays.IntervalIntersection(new int[][] { new[] { 0, 2 }, new[] { 5, 10 }, new[] { 13, 23 }, new[] { 24, 25 } }, new int[][] { new[] { 1, 5 }, new[] { 8, 12 }, new[] { 15, 24 }, new[] { 25, 26 } }));
            Assert.AreEqual(0, arrays.IntervalIntersection(new int[][] { }, new int[][] { new[] { 1, 3 } }).Length);
        }

        [TestMethod]
        public void NumPairsDivisibleBy60_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.NumPairsDivisibleBy60(new int[] { 30, 20, 150, 100, 40 }));
            Assert.AreEqual(3, arrays.NumPairsDivisibleBy60(new int[] { 60, 60, 60 }));
        }

        [TestMethod]
        public void ShipWithinDays_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(15, arrays.ShipWithinDays(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5));
            Assert.AreEqual(6, arrays.ShipWithinDays(new int[] { 3, 2, 2, 4, 1, 4 }, 3));
        }

        [TestMethod]
        public void LastStoneWeight_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 }));
            Assert.AreEqual(0, arrays.LastStoneWeight(new int[] { 1, 1 }));
        }

        [TestMethod]
        public void HeightChecker_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.HeightChecker(new int[] { 1, 1, 4, 2, 1, 3 }));
            Assert.AreEqual(0, arrays.HeightChecker(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void MaxSatisfied_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(16, arrays.MaxSatisfied(new int[] { 1, 0, 1, 2, 1, 1, 7, 5 }, new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }, 3));
            Assert.AreEqual(10, arrays.MaxSatisfied(new int[] { 10 }, new int[] { 1 }, 1));
        }

        [TestMethod]
        public void DuplicateZeros_Test_ExamplesAndEdges()
        {
            var input = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            arrays.DuplicateZeros(input);
            CollectionAssert.AreEqual(new int[] { 1, 0, 0, 2, 3, 0, 0, 4 }, input);
            input = new int[] { 1, 2, 3 };
            arrays.DuplicateZeros(input);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, input);
        }

        [TestMethod]
        public void CarPooling_Test_ExamplesAndEdges()
        {
            Assert.IsFalse(arrays.CarPooling(new int[][] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } }, 4));
            Assert.IsTrue(arrays.CarPooling(new int[][] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } }, 5));
        }

        [TestMethod]
        public void RelativeSortArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 }, arrays.RelativeSortArray(new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new int[] { 2, 1, 4, 3, 9, 6 }));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, arrays.RelativeSortArray(new int[] { 3, 1, 2 }, new int[] { }));
        }

        [TestMethod]
        public void MinimumAbsDifference_Test_ExamplesAndEdges()
        {
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int> { 1, 2 }, new List<int> { 2, 3 }, new List<int> { 3, 4 } }, arrays.MinimumAbsDifference(new int[] { 4, 2, 1, 3 }));
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int> { 1, 3 } }, arrays.MinimumAbsDifference(new int[] { 1, 3, 6 }));
        }

        [TestMethod]
        public void UniqueOccurrences_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.UniqueOccurrences(new int[] { 1, 2, 2, 1, 1, 3 }));
            Assert.IsFalse(arrays.UniqueOccurrences(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void MinTimeToVisitAllPoints_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(7, arrays.MinTimeToVisitAllPoints(new int[][] { new[] { 1, 1 }, new[] { 3, 4 }, new[] { -1, 0 } }));
            Assert.AreEqual(0, arrays.MinTimeToVisitAllPoints(new int[][] { new[] { 0, 0 } }));
        }

        [TestMethod]
        public void ReplaceElements_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 18, 6, 6, 6, 1, -1 }, arrays.ReplaceElements(new int[] { 17, 18, 5, 4, 6, 1 }));
            CollectionAssert.AreEqual(new int[] { -1 }, arrays.ReplaceElements(new int[] { 400 }));
        }

        [TestMethod]
        public void KWeakestRows_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 2, 0, 3 }, arrays.KWeakestRows(new int[][] { new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 0 }, new[] { 1, 0, 0, 0, 0 }, new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 1 } }, 3));
            CollectionAssert.AreEqual(new int[] { 0 }, arrays.KWeakestRows(new int[][] { new[] { 0 }, new[] { 1 } }, 1));
        }

        [TestMethod]
        public void CheckIfExist_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.CheckIfExist(new int[] { 10, 2, 5, 3 }));
            Assert.IsFalse(arrays.CheckIfExist(new int[] { 3, 1, 7, 11 }));
        }

        [TestMethod]
        public void CountNegatives_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(8, arrays.CountNegatives(new int[][] { new[] { 4, 3, 2, -1 }, new[] { 3, 2, 1, -1 }, new[] { 1, 1, -1, -2 }, new[] { -1, -1, -2, -3 } }));
            Assert.AreEqual(0, arrays.CountNegatives(new int[][] { new[] { 3, 2 }, new[] { 1, 0 } }));
        }

        [TestMethod]
        public void MaxScore_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(12, arrays.MaxScore(new int[] { 1, 2, 3, 4, 5, 6, 1 }, 3));
            Assert.AreEqual(4, arrays.MaxScore(new int[] { 2, 2, 2 }, 2));
        }

        [TestMethod]
        public void Shuffle_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 2, 3, 5, 4, 1, 7 }, arrays.Shuffle(new int[] { 2, 5, 1, 3, 4, 7 }, 3));
            CollectionAssert.AreEqual(new int[] { 1, 2 }, arrays.Shuffle(new int[] { 1, 2 }, 1));
        }

        [TestMethod]
        public void FinalPrices_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 4, 2, 4, 2, 3 }, arrays.FinalPrices(new int[] { 8, 4, 6, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, arrays.FinalPrices(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void RunningSum_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 3, 6, 10 }, arrays.RunningSum(new int[] { 1, 2, 3, 4 }));
            CollectionAssert.AreEqual(new int[] { 5 }, arrays.RunningSum(new int[] { 5 }));
        }

        [TestMethod]
        public void LongestSubarray_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.LongestSubarray(new int[] { 1, 1, 0, 1 }));
            Assert.AreEqual(2, arrays.LongestSubarray(new int[] { 1, 1, 1 }));
        }

        [TestMethod]
        public void FindKthPositive_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(9, arrays.FindKthPositive(new int[] { 2, 3, 4, 7, 11 }, 5));
            Assert.AreEqual(6, arrays.FindKthPositive(new int[] { 1, 2, 3, 4 }, 2));
        }

        [TestMethod]
        public void DiagonalSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(25, arrays.DiagonalSum(new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } }));
            Assert.AreEqual(5, arrays.DiagonalSum(new int[][] { new[] { 5 } }));
        }

        [TestMethod]
        public void SumOddLengthSubarrays_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(58, arrays.SumOddLengthSubarrays(new int[] { 1, 4, 2, 5, 3 }));
            Assert.AreEqual(3, arrays.SumOddLengthSubarrays(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void SpecialArray_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.SpecialArray(new int[] { 3, 5 }));
            Assert.AreEqual(-1, arrays.SpecialArray(new int[] { 0, 0 }));
        }

        [TestMethod]
        public void Decrypt_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 12, 10, 16, 13 }, arrays.Decrypt(new int[] { 5, 7, 1, 4 }, 3));
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 0 }, arrays.Decrypt(new int[] { 1, 2, 3, 4 }, 0));
        }

        [TestMethod]
        public void MaximumWealth_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(6, arrays.MaximumWealth(new int[][] { new[] { 1, 2, 3 }, new[] { 3, 2, 1 } }));
            Assert.AreEqual(10, arrays.MaximumWealth(new int[][] { new[] { 10 } }));
        }

        [TestMethod]
        public void MaxOperations_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MaxOperations(new int[] { 1, 2, 3, 4 }, 5));
            Assert.AreEqual(1, arrays.MaxOperations(new int[] { 3, 1, 3, 4, 3 }, 6));
        }


        [TestMethod]
        public void FindBall_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, -1, -1, -1, -1 }, arrays.FindBall(new int[][] { new[] { 1, 1, 1, -1, -1 }, new[] { 1, 1, 1, -1, -1 }, new[] { -1, -1, -1, 1, 1 }, new[] { 1, 1, 1, 1, -1 }, new[] { -1, -1, -1, -1, -1 } }));
            CollectionAssert.AreEqual(new int[] { -1 }, arrays.FindBall(new int[][] { new[] { -1 } }));
        }

        [TestMethod]
        public void LargestAltitude_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.LargestAltitude(new int[] { -5, 1, 5, 0, -7 }));
            Assert.AreEqual(0, arrays.LargestAltitude(new int[] { -4, -3, -2 }));
        }

        [TestMethod]
        public void RestoreArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, arrays.RestoreArray(new int[][] { new[] { 2, 1 }, new[] { 3, 4 }, new[] { 3, 2 } }));
            CollectionAssert.AreEqual(new int[] { -2, 4, 1, -3 }, arrays.RestoreArray(new int[][] { new[] { 4, -2 }, new[] { 1, 4 }, new[] { -3, 1 } }));
        }

        [TestMethod]
        public void MinOperations_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1, 3 }, arrays.MinOperations("110"));
            CollectionAssert.AreEqual(new int[] { 0 }, arrays.MinOperations("0"));
        }

        [TestMethod]
        public void NearestValidPoint_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.NearestValidPoint(3, 4, new int[][] { new[] { 1, 2 }, new[] { 3, 1 }, new[] { 2, 4 }, new[] { 2, 3 }, new[] { 4, 4 } }));
            Assert.AreEqual(-1, arrays.NearestValidPoint(1, 1, new int[][] { new[] { 2, 2 } }));
        }

        [TestMethod]
        public void ArraySign_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.ArraySign(new int[] { -1, -2, -3, -4, 3, 2, 1 }));
            Assert.AreEqual(0, arrays.ArraySign(new int[] { 1, 5, 0, 2 }));
        }

        [TestMethod]
        public void MaximumPopulation_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1993, arrays.MaximumPopulation(new int[][] { new[] { 1993, 1999 }, new[] { 2000, 2010 } }));
            Assert.AreEqual(1960, arrays.MaximumPopulation(new int[][] { new[] { 1950, 1961 }, new[] { 1960, 1971 }, new[] { 1970, 1981 } }));
        }

        [TestMethod]
        public void MinPairSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(7, arrays.MinPairSum(new int[] { 3, 5, 2, 3 }));
            Assert.AreEqual(8, arrays.MinPairSum(new int[] { 3, 5, 4, 2, 4, 6 }));
        }

        [TestMethod]
        public void BuildArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 4, 5, 3 }, arrays.BuildArray(new int[] { 0, 2, 1, 5, 3, 4 }));
            CollectionAssert.AreEqual(new int[] { 4, 5, 0, 1, 2, 3 }, arrays.BuildArray(new int[] { 5, 0, 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void GetConcatenation_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1, 1, 2, 1 }, arrays.GetConcatenation(new int[] { 1, 2, 1 }));
            CollectionAssert.AreEqual(new int[] { 7, 7 }, arrays.GetConcatenation(new int[] { 7 }));
        }

        [TestMethod]
        public void MaxMatrixSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4L, arrays.MaxMatrixSum(new int[][] { new[] { 1, -1 }, new[] { -1, 1 } }));
            Assert.AreEqual(16L, arrays.MaxMatrixSum(new int[][] { new[] { 1, 2, 3 }, new[] { -1, -2, -3 }, new[] { 1, 2, 3 } }));
        }

        [TestMethod]
        public void FindMiddleIndex_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.FindMiddleIndex(new int[] { 2, 3, -1, 8, 4 }));
            Assert.AreEqual(-1, arrays.FindMiddleIndex(new int[] { 2, 5 }));
        }

        [TestMethod]
        public void MaximumDifference_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.MaximumDifference(new int[] { 7, 1, 5, 4 }));
            Assert.AreEqual(-1, arrays.MaximumDifference(new int[] { 9, 4, 3, 2 }));
        }

        [TestMethod]
        public void GetAverages_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { -1, -1, -1, 5, 4, 4, -1, -1, -1 }, arrays.GetAverages(new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 }, 3));
            CollectionAssert.AreEqual(new int[] { 100000 }, arrays.GetAverages(new int[] { 100000 }, 0));
        }

        [TestMethod]
        public void RearrangeArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 3, -2, 1, -5, 2, -4 }, arrays.RearrangeArray(new int[] { 3, 1, -2, -5, 2, -4 }));
            CollectionAssert.AreEqual(new int[] { 1, -1 }, arrays.RearrangeArray(new int[] { -1, 1 }));
        }

        [TestMethod]
        public void PivotArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 9, 5, 3, 10, 10, 12, 14 }, arrays.PivotArray(new int[] { 9, 12, 5, 10, 14, 3, 10 }, 10));
            CollectionAssert.AreEqual(new int[] { -3, 2, 4, 3 }, arrays.PivotArray(new int[] { -3, 4, 3, 2 }, 2));
        }

        [TestMethod]
        public void FindDifference_Test_ExamplesAndEdges()
        {
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { 4, 6 } }, arrays.FindDifference(new int[] { 1, 2, 3 }, new int[] { 2, 4, 6 }));
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int>(), new List<int> { 3 } }, arrays.FindDifference(new int[] { 1, 2 }, new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void AnswerQueries_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 2, 3, 4 }, arrays.AnswerQueries(new int[] { 4, 5, 2, 1 }, new int[] { 3, 10, 21 }));
            CollectionAssert.AreEqual(new int[] { 0 }, arrays.AnswerQueries(new int[] { 10 }, new int[] { 5 }));
        }

        [TestMethod]
        public void FindArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 5, 7, 2, 3, 2 }, arrays.FindArray(new int[] { 5, 2, 0, 3, 1 }));
            CollectionAssert.AreEqual(new int[] { 13 }, arrays.FindArray(new int[] { 13 }));
        }

        [TestMethod]
        public void ApplyOperations_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 4, 2, 0, 0, 0 }, arrays.ApplyOperations(new int[] { 1, 2, 2, 1, 1, 0 }));
            CollectionAssert.AreEqual(new int[] { 2, 0, 0 }, arrays.ApplyOperations(new int[] { 0, 1, 1 }));
        }

        [TestMethod]
        public void MergeArrays_Test_ExamplesAndEdges()
        {
            AssertMatrixAreEqual(new int[][] { new[] { 1, 6 }, new[] { 2, 3 }, new[] { 3, 2 }, new[] { 4, 6 } }, arrays.MergeArrays(new int[][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 4, 5 } }, new int[][] { new[] { 1, 4 }, new[] { 3, 2 }, new[] { 4, 1 } }));
            AssertMatrixAreEqual(new int[][] { new[] { 1, 3 }, new[] { 2, 4 } }, arrays.MergeArrays(new int[][] { new[] { 1, 3 } }, new int[][] { new[] { 2, 4 } }));
        }

        [TestMethod]
        public void FindMatrix_Test_ExamplesAndEdges()
        {
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int> { 1, 3, 4, 2 }, new List<int> { 1, 3 }, new List<int> { 1 } }, arrays.FindMatrix(new int[] { 1, 3, 4, 1, 2, 3, 1 }));
            AssertGroupsAreEquivalent(new List<IList<int>> { new List<int> { 1, 2, 3, 4 } }, arrays.FindMatrix(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void DiagonalPrime_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(11, arrays.DiagonalPrime(new int[][] { new[] { 1, 2, 3 }, new[] { 5, 6, 7 }, new[] { 9, 10, 11 } }));
            Assert.AreEqual(0, arrays.DiagonalPrime(new int[][] { new[] { 1 } }));
        }

        [TestMethod]
        public void RowAndMaximumOnes_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 0, 1 }, arrays.RowAndMaximumOnes(new int[][] { new[] { 0, 1 }, new[] { 1, 0 } }));
            CollectionAssert.AreEqual(new int[] { 1, 2 }, arrays.RowAndMaximumOnes(new int[][] { new[] { 0, 0, 0 }, new[] { 0, 1, 1 } }));
        }

        [TestMethod]
        public void FindThePrefixCommonArray_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 0, 2, 3, 4 }, arrays.FindThePrefixCommonArray(new int[] { 1, 3, 2, 4 }, new int[] { 3, 1, 2, 4 }));
            CollectionAssert.AreEqual(new int[] { 0, 1, 3 }, arrays.FindThePrefixCommonArray(new int[] { 2, 3, 1 }, new int[] { 3, 1, 2 }));
        }

        [TestMethod]
        public void MatrixSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(15, arrays.MatrixSum(new int[][] { new[] { 7, 2, 1 }, new[] { 6, 4, 2 }, new[] { 6, 5, 3 }, new[] { 3, 2, 1 } }));
            Assert.AreEqual(1, arrays.MatrixSum(new int[][] { new[] { 1 } }));
        }

        [TestMethod]
        public void BuyChoco_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(0, arrays.BuyChoco(new int[] { 1, 2, 2 }, 3));
            Assert.AreEqual(3, arrays.BuyChoco(new int[] { 3, 2, 3 }, 3));
        }

        [TestMethod]
        public void FindNonMinOrMax_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.FindNonMinOrMax(new int[] { 3, 2, 1, 4 }));
            Assert.AreEqual(-1, arrays.FindNonMinOrMax(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void ContinuousSubarrays_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(8L, arrays.ContinuousSubarrays(new int[] { 5, 4, 2, 4 }));
            Assert.AreEqual(6L, arrays.ContinuousSubarrays(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void MaximumBeauty_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.MaximumBeauty(new int[] { 4, 6, 1, 2 }, 2));
            Assert.AreEqual(4, arrays.MaximumBeauty(new int[] { 1, 1, 1, 1 }, 10));
        }

        [TestMethod]
        public void MaxArrayValue_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(21L, arrays.MaxArrayValue(new int[] { 2, 3, 7, 9, 3 }));
            Assert.AreEqual(11L, arrays.MaxArrayValue(new int[] { 5, 3, 3 }));
        }

        [TestMethod]
        public void NumberOfEmployeesWhoMetTarget_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.NumberOfEmployeesWhoMetTarget(new int[] { 0, 1, 2, 3, 4 }, 2));
            Assert.AreEqual(0, arrays.NumberOfEmployeesWhoMetTarget(new int[] { 1, 1, 1 }, 2));
        }

        [TestMethod]
        public void CountPairs_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.CountPairs(new List<int> { -1, 1, 2, 3, 1 }, 2));
            Assert.AreEqual(1, arrays.CountPairs(new List<int> { -6, 2, 5, -2, -7, -1, 3 }, -10));
        }

        [TestMethod]
        public void MaxSumAlmostUnique_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(18L, arrays.MaxSum(new List<int> { 2, 6, 7, 3, 1, 7 }, 3, 4));
            Assert.AreEqual(0L, arrays.MaxSum(new List<int> { 5, 5, 5 }, 2, 2));
        }

        [TestMethod]
        public void MinOperationsMakeArrayEmpty_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.MinOperations(new int[] { 2, 3, 3, 2, 2, 4, 2, 3, 4 }));
            Assert.AreEqual(-1, arrays.MinOperations(new int[] { 2, 1, 2, 2, 3, 3 }));
        }

        [TestMethod]
        public void MaximumTripletValue_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(77L, arrays.MaximumTripletValue(new int[] { 12, 6, 1, 2, 7 }));
            Assert.AreEqual(0L, arrays.MaximumTripletValue(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void MinProcessingTime_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(16, arrays.MinProcessingTime(new List<int> { 8, 10 }, new List<int> { 2, 2, 3, 1, 8, 7, 4, 5 }));
            Assert.AreEqual(23, arrays.MinProcessingTime(new List<int> { 10, 20 }, new List<int> { 2, 3, 1, 2, 5, 8, 4, 3 }));
        }

        [TestMethod]
        public void FindIndices_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 0, 3 }, arrays.FindIndices(new int[] { 5, 1, 4, 1 }, 2, 4));
            CollectionAssert.AreEqual(new int[] { -1, -1 }, arrays.FindIndices(new int[] { 2, 1 }, 1, 2));
        }

        [TestMethod]
        public void SumCounts_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(15, arrays.SumCounts(new List<int> { 1, 2, 1 }));
            Assert.AreEqual(3, arrays.SumCounts(new List<int> { 1, 1 }));
        }

        [TestMethod]
        public void FindPeaks_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new List<int>(), arrays.FindPeaks(new int[] { 2, 4, 4 }).ToList());
            CollectionAssert.AreEqual(new List<int> { 1, 3 }, arrays.FindPeaks(new int[] { 1, 4, 3, 8, 5 }).ToList());
        }

        [TestMethod]
        public void FindMissingAndRepeatedValues_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 2, 4 }, arrays.FindMissingAndRepeatedValues(new int[][] { new[] { 1, 3 }, new[] { 2, 2 } }));
            CollectionAssert.AreEqual(new int[] { 9, 5 }, arrays.FindMissingAndRepeatedValues(new int[][] { new[] { 9, 1, 7 }, new[] { 8, 9, 2 }, new[] { 3, 4, 6 } }));
        }

        [TestMethod]
        public void DivideArray_Test_ExamplesAndEdges()
        {
            AssertMatrixAreEqual(new int[][] { new[] { 1, 1, 3 }, new[] { 3, 4, 5 }, new[] { 7, 8, 9 } }, arrays.DivideArray(new int[] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2));
            Assert.AreEqual(0, arrays.DivideArray(new int[] { 1, 3, 3, 2, 7, 3 }, 3).Length);
        }

        [TestMethod]
        public void NumberGame_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 3, 2, 5, 4 }, arrays.NumberGame(new int[] { 5, 4, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 5, 2 }, arrays.NumberGame(new int[] { 2, 5 }));
        }

        [TestMethod]
        public void MaxFrequencyElements_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.MaxFrequencyElements(new int[] { 1, 2, 2, 3, 1, 4 }));
            Assert.AreEqual(5, arrays.MaxFrequencyElements(new int[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void MinimumCost_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(6, arrays.MinimumCost(new int[] { 1, 2, 3, 12 }));
            Assert.AreEqual(12, arrays.MinimumCost(new int[] { 5, 4, 3 }));
        }

        [TestMethod]
        public void CanSortArray_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.CanSortArray(new int[] { 8, 4, 2, 30, 15 }));
            Assert.IsFalse(arrays.CanSortArray(new int[] { 3, 16, 8, 4, 2 }));
        }

        [TestMethod]
        public void ReturnToBoundaryCount_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.ReturnToBoundaryCount(new int[] { 2, 3, -5 }));
            Assert.AreEqual(0, arrays.ReturnToBoundaryCount(new int[] { 3, 2, -3, -4 }));
        }

        [TestMethod]
        public void MinOperationsThresholdI_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.MinOperations(new int[] { 2, 11, 10, 1, 3 }, 10));
            Assert.AreEqual(0, arrays.MinOperations(new int[] { 1, 1, 2, 4, 9 }, 1));
        }

        [TestMethod]
        public void MinOperationsII_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MinOperationsII(new int[] { 2, 11, 10, 1, 3 }, 10));
            Assert.AreEqual(4, arrays.MinOperationsII(new int[] { 1, 1, 2, 4, 9 }, 20));
        }

        [TestMethod]
        public void MinimumBoxes_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MinimumBoxes(new int[] { 1, 3, 2 }, new int[] { 4, 3, 1, 5, 2 }));
            Assert.AreEqual(1, arrays.MinimumBoxes(new int[] { 5 }, new int[] { 10 }));
        }

        [TestMethod]
        public void MaximumHappinessSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4L, arrays.MaximumHappinessSum(new int[] { 1, 2, 3 }, 2));
            Assert.AreEqual(1L, arrays.MaximumHappinessSum(new int[] { 1, 1, 1 }, 2));
        }

        [TestMethod]
        public void MinimumSubarrayLength_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.MinimumSubarrayLength(new int[] { 1, 2, 3 }, 2));
            Assert.AreEqual(-1, arrays.MinimumSubarrayLength(new int[] { 1, 2 }, 8));
        }

        [TestMethod]
        public void LongestMonotonicSubarray_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.LongestMonotonicSubarray(new int[] { 1, 4, 3, 3, 2 }));
            Assert.AreEqual(1, arrays.LongestMonotonicSubarray(new int[] { 3, 3, 3 }));
        }

        [TestMethod]
        public void AddedInteger_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.AddedInteger(new int[] { 2, 6, 4 }, new int[] { 9, 7, 5 }));
            Assert.AreEqual(-5, arrays.AddedInteger(new int[] { 10 }, new int[] { 5 }));
        }

        [TestMethod]
        public void IsArraySpecialI_Test_ExamplesAndEdges()
        {
            Assert.IsTrue(arrays.IsArraySpecial(new int[] { 1 }));
            Assert.IsFalse(arrays.IsArraySpecial(new int[] { 2, 1, 4, 6 }));
        }

        [TestMethod]
        public void IsArraySpecialII_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new bool[] { false }, arrays.IsArraySpecial(new int[] { 3, 4, 1, 2, 6 }, new int[][] { new[] { 0, 4 } }));
            CollectionAssert.AreEqual(new bool[] { false, true }, arrays.IsArraySpecial(new int[] { 4, 3, 1, 6 }, new int[][] { new[] { 0, 2 }, new[] { 2, 3 } }));
        }

        [TestMethod]
        public void NumberOfPairs_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(5, arrays.NumberOfPairs(new int[] { 1, 3, 4 }, new int[] { 1, 3, 4 }, 1));
            Assert.AreEqual(2, arrays.NumberOfPairs(new int[] { 1, 2, 4, 12 }, new int[] { 2, 4 }, 3));
        }

        [TestMethod]
        public void MinimumAverage_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(5.5, arrays.MinimumAverage(new int[] { 7, 8, 3, 4, 15, 13, 4, 1 }));
            Assert.AreEqual(5.0, arrays.MinimumAverage(new int[] { 1, 9 }));
        }

        [TestMethod]
        public void MinimumArea_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(6, arrays.MinimumArea(new int[][] { new[] { 0, 1, 0 }, new[] { 1, 0, 1 } }));
            Assert.AreEqual(1, arrays.MinimumArea(new int[][] { new[] { 1 } }));
        }

        [TestMethod]
        public void NumberOfAlternatingGroupsI_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(0, arrays.NumberOfAlternatingGroups(new int[] { 1, 1, 1 }));
            Assert.AreEqual(3, arrays.NumberOfAlternatingGroups(new int[] { 0, 1, 0, 0, 1 }));
        }

        [TestMethod]
        public void NumberOfAlternatingGroupsII_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.NumberOfAlternatingGroups(new int[] { 0, 1, 0, 1, 0 }, 3));
            Assert.AreEqual(2, arrays.NumberOfAlternatingGroups(new int[] { 0, 1, 0, 0, 1, 0, 1 }, 6));
        }

        [TestMethod]
        public void MinOperationsToMakeArrayValuesEqualToK_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MinOperationsToMakeArrayValuesEqualToK(new int[] { 5, 2, 5, 4, 5 }, 2));
            Assert.AreEqual(-1, arrays.MinOperationsToMakeArrayValuesEqualToK(new int[] { 2, 1, 2 }, 2));
        }

        [TestMethod]
        public void CountSubarrays_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.CountSubarrays(new int[] { 1, 2, 1, 4, 1 }));
            Assert.AreEqual(0, arrays.CountSubarrays(new int[] { 1, 1, 1 }));
        }

        [TestMethod]
        public void MaxAdjacentDistance_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.MaxAdjacentDistance(new int[] { 1, 2, 4 }));
            Assert.AreEqual(0, arrays.MaxAdjacentDistance(new int[] { 7 }));
        }

        [TestMethod]
        public void LargestInteger_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(7, arrays.LargestInteger(new int[] { 3, 9, 2, 1, 7 }, 3));
            Assert.AreEqual(-1, arrays.LargestInteger(new int[] { 1, 1 }, 1));
        }

        [TestMethod]
        public void MaxSumAfterDeletion_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(15, arrays.MaxSum(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(-1, arrays.MaxSum(new int[] { -1, -2, -3 }));
        }

        [TestMethod]
        public void SolveQueries_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new List<int> { 2, -1, 3 }, arrays.SolveQueries(new int[] { 1, 3, 1, 4, 1, 3, 2 }, new int[] { 0, 3, 5 }).ToList());
            CollectionAssert.AreEqual(new List<int> { -1, -1 }, arrays.SolveQueries(new int[] { 5, 6 }, new int[] { 0, 1 }).ToList());
        }

        [TestMethod]
        public void MinOperationsDivisibleSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(4, arrays.MinOperationsDivisibleSum(new int[] { 3, 9, 7 }, 5));
            Assert.AreEqual(0, arrays.MinOperationsDivisibleSum(new int[] { 4, 8 }, 4));
        }

        [TestMethod]
        public void CalculateScore_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1L, arrays.CalculateScore(new string[] { "jump", "add", "add", "jump", "add", "jump" }, new int[] { 2, 1, 3, 1, -2, -3 }));
            Assert.AreEqual(0L, arrays.CalculateScore(new string[] { "jump" }, new int[] { 0 }));
        }

        [TestMethod]
        public void AlternatingSum_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(-4, arrays.AlternatingSum(new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(100, arrays.AlternatingSum(new int[] { 100 }));
        }

        [TestMethod]
        public void MinimumDistance_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(6, arrays.MinimumDistance(new int[] { 1, 2, 1, 1, 3 }));
            Assert.AreEqual(-1, arrays.MinimumDistance(new int[] { 1 }));
        }

        [TestMethod]
        public void CountElements_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.CountElements(new int[] { 3, 1, 2 }, 1));
            Assert.AreEqual(3, arrays.CountElements(new int[] { 5, 5, 5 }, 0));
        }

        [TestMethod]
        public void AbsDifference_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(5, arrays.AbsDifference(new int[] { 5, 2, 2, 4 }, 2));
            Assert.AreEqual(0, arrays.AbsDifference(new int[] { 100 }, 1));
        }

        [TestMethod]
        public void MaximumScore_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(17L, arrays.MaximumScore(new int[] { 10, -1, 3, -4, -5 }));
            Assert.AreEqual(-2L, arrays.MaximumScore(new int[] { -7, -5, 3 }));
        }

        [TestMethod]
        public void MinLength_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MinLength(new int[] { 2, 2, 3, 1 }, 4));
            Assert.AreEqual(1, arrays.MinLength(new int[] { 5, 5, 4 }, 5));
        }

        [TestMethod]
        public void CountSubarraysWithFrequency_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2L, arrays.CountSubarrays(new int[] { 1, 2, 1, 2, 2 }, 2, 2));
            Assert.AreEqual(3L, arrays.CountSubarrays(new int[] { 3, 1, 2, 4 }, 2, 1));
        }

        [TestMethod]
        public void ConcatWithReverse_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 3, 2, 1 }, arrays.ConcatWithReverse(new int[] { 1, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 1, 1 }, arrays.ConcatWithReverse(new int[] { 1 }));
        }

        [TestMethod]
        public void MinimumSwaps_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(2, arrays.MinimumSwaps(new int[] { 0, 1, 0, 3, 12 }));
            Assert.AreEqual(0, arrays.MinimumSwaps(new int[] { 1, 2, 0 }));
        }

        [TestMethod]
        public void LimitOccurrences_Test_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 2, 3 }, arrays.LimitOccurrences(new int[] { 1, 1, 1, 2, 2, 3 }, 2));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, arrays.LimitOccurrences(new int[] { 1, 2, 3 }, 1));
        }

        [TestMethod]
        public void LongestSubarrayWithPrimeFactors_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(3, arrays.LongestSubarray(new int[] { 7, 6, 10, 12, 11 }, 3));
            Assert.AreEqual(1, arrays.LongestSubarray(new int[] { 6, 10, 15 }, 2));
        }

        [TestMethod]
        public void CountSpecialIntegers_Test_ExamplesAndEdges()
        {
            Assert.AreEqual(1, arrays.CountSpecialIntegers(new int[] { 1, 2, 2, 1 }));
            Assert.AreEqual(2, arrays.CountSpecialIntegers(new int[] { 3, 3, 1, 2, 2, 1 }));
        }


        private static void AssertMatrixAreEqual(int[][] expected, int[][] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                CollectionAssert.AreEqual(expected[i], actual[i]);
        }

        /// <summary>
        /// Compares grouped list-of-int results (e.g. Subsets) irrespective of group order and irrespective of element order within each group.
        /// </summary>
        private static void AssertGroupsAreEquivalent(IList<IList<int>> expected, IList<IList<int>> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            var normalizedExpected = expected
                .Select(group => string.Join(",", group.OrderBy(n => n)))
                .OrderBy(group => group)
                .ToList();
            var normalizedActual = actual
                .Select(group => string.Join(",", group.OrderBy(n => n)))
                .OrderBy(group => group)
                .ToList();

            CollectionAssert.AreEqual(normalizedExpected, normalizedActual);
        }

        /// <summary>
        /// Compares grouped anagram results irrespective of group order and irrespective of element order within each group.
        /// </summary>
        private static void AssertGroupAnagramsAreEqual(IList<IList<string>> expected, IList<IList<string>> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            var normalizedExpected = expected
                .Select(group => string.Join(",", group.OrderBy(s => s)))
                .OrderBy(group => group)
                .ToList();
            var normalizedActual = actual
                .Select(group => string.Join(",", group.OrderBy(s => s)))
                .OrderBy(group => group)
                .ToList();

            CollectionAssert.AreEqual(normalizedExpected, normalizedActual);
        }
    }
}
