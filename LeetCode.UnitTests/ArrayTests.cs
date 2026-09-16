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
