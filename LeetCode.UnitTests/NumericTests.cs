using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.UnitTests
{
    [TestClass]
    public class NumericTests
    {
        Numeric numeric;
        [TestInitialize]
        public void Setup()
        {
            numeric = new Numeric();
        }
        [TestMethod]
        public void IsPalindrome_Test1()
        {
            var expectedResult = true;
            var actualResult = numeric.IsPalindrome(7612167);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsPalindrome_Test2()
        {
            var expectedResult = false;
            var actualResult = numeric.IsPalindrome(-121);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsPalindrome_Test3()
        {
            var expectedResult = false;
            var actualResult = numeric.IsPalindrome(10);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Reverse_Test1()
        {
            Assert.AreEqual(321, numeric.Reverse(123));
        }

        [TestMethod]
        public void Reverse_Test2()
        {
            Assert.AreEqual(-321, numeric.Reverse(-123));
        }

        [TestMethod]
        public void Reverse_Test3_Overflow()
        {
            Assert.AreEqual(0, numeric.Reverse(1534236469));
        }

        [TestMethod]
        public void Divide_Test1()
        {
            Assert.AreEqual(3, numeric.Divide(10, 3));
        }

        [TestMethod]
        public void Divide_Test2()
        {
            Assert.AreEqual(-2, numeric.Divide(7, -3));
        }

        [TestMethod]
        public void Divide_Test3_MinValueOverflow()
        {
            Assert.AreEqual(int.MaxValue, numeric.Divide(int.MinValue, -1));
        }

        [TestMethod]
        public void MyPow_Test1()
        {
            Assert.AreEqual(1024, numeric.MyPow(2, 10), 0.000001);
        }

        [TestMethod]
        public void MyPow_Test2_NegativeExponent()
        {
            Assert.AreEqual(0.25, numeric.MyPow(2, -2), 0.000001);
        }

        [TestMethod]
        public void MyPow_Test3_MinExponent()
        {
            Assert.AreEqual(1, numeric.MyPow(1, int.MinValue), 0.000001);
        }

        [TestMethod]
        public void CanWinNim_Test1()
        {
            var expectedResult = false;
            var actualResult = numeric.CanWinNim(4);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanWinNim_Test2()
        {
            var expectedResult = true;
            var actualResult = numeric.CanWinNim(5);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanWinNim_Test3()
        {
            var expectedResult = false;
            var actualResult = numeric.CanWinNim(8);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsPowerOfThree_Test1()
        {
            var expectedResult = true;
            var actualResult = numeric.IsPowerOfThree(27);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void IsPowerOfThree_Test2()
        {
            var expectedResult = false;
            var actualResult = numeric.IsPowerOfThree(18);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsPowerOfThree_Test3()
        {
            var expectedResult = true;
            var actualResult = numeric.IsPowerOfThree(9);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FizzBuzz_Test1()
        {
            var expectedResult = new List<string>() { "1", "2", "Fizz" };
            var actualResult = numeric.FizzBuzz(3);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void FizzBuzz_Test2()
        {
            var expectedResult = new List<string>() { "1", "2", "Fizz", "4", "Buzz" };
            var actualResult = numeric.FizzBuzz(5);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void FizzBuzz_Test3()
        {
            var expectedResult = new List<string>() { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz" };
            var actualResult = numeric.FizzBuzz(10);
            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void ArrangeCoins_Test1()
        {
            var expectedResult = 2;
            var actualResult = numeric.ArrangeCoins(5);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ArrangeCoins_Test2()
        {
            var expectedResult = 1;
            var actualResult = numeric.ArrangeCoins(1);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ArrangeCoins_Test3()
        {
            var expectedResult = 5;
            var actualResult = numeric.ArrangeCoins(15);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ArrangeCoins_Test4()
        {
            var expectedResult = 65535;
            var actualResult = numeric.ArrangeCoins(2147483647);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertToTitle_Test1()
        {
            var expectedResult = "A";
            var actualResult = numeric.ConvertToTitle(1);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertToTitle_Test2()
        {
            var expectedResult = "Z";
            var actualResult = numeric.ConvertToTitle(26);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConvertToTitle_Test3()
        {
            var expectedResult = "ZY";
            var actualResult = numeric.ConvertToTitle(701);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsHappy_Test1()
        {
            var expectedResult = true;
            var actualResult = numeric.IsHappy(19);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsHappy_Test2()
        {
            var expectedResult = false;
            var actualResult = numeric.IsHappy(2);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MySqrt_Test1()
        {
            var expectedResult = 2;
            var actualResult = numeric.MySqrt(4);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MySqrt_Test2()
        {
            var expectedResult = 2;
            var actualResult = numeric.MySqrt(8);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MySqrt_Test3()
        {
            var expectedResult = 46340;
            var actualResult = numeric.MySqrt(2147395600);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MySqrt_Test4_Zero()
        {
            Assert.AreEqual(0, numeric.MySqrt(0));
        }

        [TestMethod]
        public void ClimbStairs_Test1()
        {
            var expectedResult = 2;
            var actualResult = numeric.ClimbStairs(2);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ClimbStairs_Test2()
        {
            var expectedResult = 3;
            var actualResult = numeric.ClimbStairs(3);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ClimbStairs_Test3()
        {
            var expectedResult = 5;
            var actualResult = numeric.ClimbStairs(4);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Generte_Test1()
        {
            var expectedResult = new List<List<int>>() { new List<int>() { 1 } };
            var actualResult = numeric.Generate(1);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
            }
        }

        [TestMethod]
        public void Generte_Test2()
        {
            var expectedResult = new List<List<int>>() { new List<int>() { 1 }, new List<int>() { 1, 1 } };
            var actualResult = numeric.Generate(2);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
            }
        }

        [TestMethod]
        public void Generte_Test3()
        {
            var expectedResult = new List<List<int>>() {
                new List<int>() { 1 },
                new List<int>() { 1, 1 },
                new List<int>() { 1, 2, 1 } ,
                new List<int>() { 1, 3, 3, 1 } ,
                new List<int>() { 1, 4, 6, 4, 1}
            };
            var actualResult = numeric.Generate(5);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.IsTrue(expectedResult[i].SequenceEqual(actualResult[i]));
            }
        }

        [TestMethod]
        public void GetRow_Test1()
        {
            var expectedResult = new List<int>() { 1 };
            var actualResult = numeric.GetRow(0);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }
        [TestMethod]
        public void GetRow_Test2()
        {
            var expectedResult = new List<int>() { 1, 3, 3, 1 };
            var actualResult = numeric.GetRow(3);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void GetRow_Test3()
        {
            var expectedResult = new List<int>() { 1, 5, 10, 10, 5, 1 };
            var actualResult = numeric.GetRow(5);
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void GrayCode_Test1()
        {
            CollectionAssert.AreEqual(new List<int> { 0, 1, 3, 2 }, numeric.GrayCode(2).ToList());
        }

        [TestMethod]
        public void GrayCode_Test2_ZeroBits()
        {
            CollectionAssert.AreEqual(new List<int> { 0 }, numeric.GrayCode(0).ToList());
        }

        [TestMethod]
        public void GrayCode_Test3()
        {
            CollectionAssert.AreEqual(new List<int> { 0, 1, 3, 2, 6, 7, 5, 4 }, numeric.GrayCode(3).ToList());
        }

        [TestMethod]
        public void NumTrees_Test1()
        {
            Assert.AreEqual(5, numeric.NumTrees(3));
        }

        [TestMethod]
        public void NumTrees_Test2_ZeroNodes()
        {
            Assert.AreEqual(1, numeric.NumTrees(0));
        }

        [TestMethod]
        public void NumTrees_Test3()
        {
            Assert.AreEqual( Catalan(19), numeric.NumTrees(19));
        }

        private static int Catalan(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
                result = result * (n + i) / i;

            return (int)(result / (n + 1));
        }

        [TestMethod]
        public void SingleNumber_Test1()
        {
            Assert.AreEqual(3, numeric.SingleNumber(new[] { 2, 2, 3, 2 }));
        }

        [TestMethod]
        public void SingleNumber_Test2()
        {
            Assert.AreEqual(99, numeric.SingleNumber(new[] { 0, 1, 0, 1, 0, 1, 99 }));
        }

        [TestMethod]
        public void SingleNumber_Test3_NegativeUnique()
        {
            Assert.AreEqual(-4, numeric.SingleNumber(new[] { -2, -2, 1, 1, 4, 1, 4, 4, -4, -2 }));
        }

        [TestMethod]
        public void MaxPoints_Test1()
        {
            int[][] points =
            {
                new[] { 1, 1 },
                new[] { 2, 2 },
                new[] { 3, 3 }
            };

            Assert.AreEqual(3, numeric.MaxPoints(points));
        }

        [TestMethod]
        public void MaxPoints_Test2()
        {
            int[][] points =
            {
                new[] { 1, 1 },
                new[] { 3, 2 },
                new[] { 5, 3 },
                new[] { 4, 1 },
                new[] { 2, 3 },
                new[] { 1, 4 }
            };

            Assert.AreEqual(4, numeric.MaxPoints(points));
        }

        [TestMethod]
        public void MaxPoints_Test3_VerticalLineWithDuplicate()
        {
            int[][] points =
            {
                new[] { 1, 1 },
                new[] { 1, 1 },
                new[] { 1, 2 },
                new[] { 1, 3 },
                new[] { 2, 3 }
            };

            Assert.AreEqual(4, numeric.MaxPoints(points));
        }

        [TestMethod]
        public void FractionToDecimal_Test1()
        {
            Assert.AreEqual("0.5", numeric.FractionToDecimal(1, 2));
        }

        [TestMethod]
        public void FractionToDecimal_Test2_Repeating()
        {
            Assert.AreEqual("0.(6)", numeric.FractionToDecimal(2, 3));
        }

        [TestMethod]
        public void FractionToDecimal_Test3_NegativeTerminating()
        {
            Assert.AreEqual("-6.25", numeric.FractionToDecimal(-50, 8));
        }

        [TestMethod]
        public void FractionToDecimal_Test4_MinValueOverflowEdge()
        {
            Assert.AreEqual("2147483648", numeric.FractionToDecimal(int.MinValue, -1));
        }

        [TestMethod]
        public void TrailingZeroes_Test1()
        {
            Assert.AreEqual(0, numeric.TrailingZeroes(3));
        }

        [TestMethod]
        public void TrailingZeroes_Test2()
        {
            Assert.AreEqual(1, numeric.TrailingZeroes(5));
        }

        [TestMethod]
        public void TrailingZeroes_Test3_MultiplePowersOfFive()
        {
            Assert.AreEqual(7, numeric.TrailingZeroes(30));
        }

        [TestMethod]
        public void TrailingZeroes_Test4_MaxInt()
        {
            Assert.AreEqual(536870902, numeric.TrailingZeroes(int.MaxValue));
        }

        [TestMethod]
        public void ReverseBits_Test1()
        {
            uint input = 0b00000010100101000001111010011100;
            uint expectedResult = 964176192;
            var actualResult = numeric.ReverseBits(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReverseBits_Test2()
        {
            var expectedResult = 3221225471;
            var actualResult = numeric.ReverseBits(4294967293);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void HammingWeight_Test1()
        {
            var expectedResult = 3;
            var actualResult = numeric.HammingWeight(11);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void HammingWeight_Test2()
        {
            var expectedResult = 1;
            var actualResult = numeric.HammingWeight(1);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void HammingWeight_Test3()
        {
            var expectedResult = 0;
            var actualResult = numeric.HammingWeight(0);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RangeBitwiseAnd_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.RangeBitwiseAnd(5, 7));
            Assert.AreEqual(0, numeric.RangeBitwiseAnd(0, 0));
            Assert.AreEqual(0, numeric.RangeBitwiseAnd(1, int.MaxValue));
        }

        [TestMethod]
        public void CountPrimes_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.CountPrimes(10));
            Assert.AreEqual(0, numeric.CountPrimes(0));
            Assert.AreEqual(0, numeric.CountPrimes(2));
            Assert.AreEqual(25, numeric.CountPrimes(100));
        }

        [TestMethod]
        public void ComputeArea_ExamplesAndEdges()
        {
            Assert.AreEqual(45, numeric.ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2));
            Assert.AreEqual(16, numeric.ComputeArea(-2, -2, 2, 2, -2, -2, 2, 2));
            Assert.AreEqual(2, numeric.ComputeArea(0, 0, 1, 1, 1, 0, 2, 1));
        }

        [TestMethod]
        public void IsPowerOfTwo_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsPowerOfTwo(16));
            Assert.IsTrue(numeric.IsPowerOfTwo(1));
            Assert.IsFalse(numeric.IsPowerOfTwo(3));
            Assert.IsFalse(numeric.IsPowerOfTwo(0));
            Assert.IsFalse(numeric.IsPowerOfTwo(int.MinValue));
        }

        [TestMethod]
        public void CountDigitOne_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.CountDigitOne(13));
            Assert.AreEqual(0, numeric.CountDigitOne(0));
            Assert.AreEqual(1, numeric.CountDigitOne(1));
            Assert.AreEqual(20, numeric.CountDigitOne(99));
        }

        [TestMethod]
        public void AddDigits_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.AddDigits(38));
            Assert.AreEqual(0, numeric.AddDigits(0));
            Assert.AreEqual(9, numeric.AddDigits(9999));
        }

        [TestMethod]
        public void IsUgly_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsUgly(6));
            Assert.IsTrue(numeric.IsUgly(1));
            Assert.IsFalse(numeric.IsUgly(14));
            Assert.IsFalse(numeric.IsUgly(0));
        }

        [TestMethod]
        public void NthUglyNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(12, numeric.NthUglyNumber(10));
            Assert.AreEqual(1, numeric.NthUglyNumber(1));
            Assert.AreEqual(2123366400, numeric.NthUglyNumber(1690));
        }

        [TestMethod]
        public void MissingNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MissingNumber(new[] { 3, 0, 1 }));
            Assert.AreEqual(2, numeric.MissingNumber(new[] { 0, 1 }));
            Assert.AreEqual(8, numeric.MissingNumber(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }));
        }

        [TestMethod]
        public void NumSquares_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.NumSquares(12));
            Assert.AreEqual(2, numeric.NumSquares(13));
            Assert.AreEqual(1, numeric.NumSquares(1));
        }

        [TestMethod]
        public void BulbSwitch_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.BulbSwitch(3));
            Assert.AreEqual(0, numeric.BulbSwitch(0));
            Assert.AreEqual(3, numeric.BulbSwitch(9));
        }

        [TestMethod]
        public void CountBits_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 0, 1, 1 }, numeric.CountBits(2));
            CollectionAssert.AreEqual(new[] { 0 }, numeric.CountBits(0));
            CollectionAssert.AreEqual(new[] { 0, 1, 1, 2, 1, 2 }, numeric.CountBits(5));
        }

        [TestMethod]
        public void IsPowerOfFour_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsPowerOfFour(16));
            Assert.IsTrue(numeric.IsPowerOfFour(1));
            Assert.IsFalse(numeric.IsPowerOfFour(5));
            Assert.IsFalse(numeric.IsPowerOfFour(8));
            Assert.IsFalse(numeric.IsPowerOfFour(0));
        }

        [TestMethod]
        public void IntegerBreak_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.IntegerBreak(2));
            Assert.AreEqual(36, numeric.IntegerBreak(10));
            Assert.AreEqual(2, numeric.IntegerBreak(3));
        }

        [TestMethod]
        public void CountNumbersWithUniqueDigits_ExamplesAndEdges()
        {
            Assert.AreEqual(91, numeric.CountNumbersWithUniqueDigits(2));
            Assert.AreEqual(1, numeric.CountNumbersWithUniqueDigits(0));
            Assert.AreEqual(8877691, numeric.CountNumbersWithUniqueDigits(10));
            Assert.AreEqual(8877691, numeric.CountNumbersWithUniqueDigits(11));
        }

        [TestMethod]
        public void IsPerfectSquare_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsPerfectSquare(16));
            Assert.IsTrue(numeric.IsPerfectSquare(1));
            Assert.IsFalse(numeric.IsPerfectSquare(14));
            Assert.IsFalse(numeric.IsPerfectSquare(int.MaxValue));
        }

        [TestMethod]
        public void GetSum_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.GetSum(1, 2));
            Assert.AreEqual(1, numeric.GetSum(-2, 3));
            Assert.AreEqual(-5, numeric.GetSum(-2, -3));
            Assert.AreEqual(int.MinValue, numeric.GetSum(int.MaxValue, 1));
        }

        [TestMethod]
        public void SuperPow_ExamplesAndEdges()
        {
            Assert.AreEqual(8, numeric.SuperPow(2, new[] { 3 }));
            Assert.AreEqual(1024, numeric.SuperPow(2, new[] { 1, 0 }));
            Assert.AreEqual(1, numeric.SuperPow(1, new[] { 4, 3, 3, 8, 5, 2 }));
        }

        [TestMethod]
        public void IntegerReplacement_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.IntegerReplacement(8));
            Assert.AreEqual(4, numeric.IntegerReplacement(7));
            Assert.AreEqual(32, numeric.IntegerReplacement(int.MaxValue));
        }

        [TestMethod]
        public void FindNthDigit_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.FindNthDigit(3));
            Assert.AreEqual(0, numeric.FindNthDigit(11));
            Assert.AreEqual(1, numeric.FindNthDigit(1));
            Assert.AreEqual(1, numeric.FindNthDigit(10));
        }

        [TestMethod]
        public void ToHex_ExamplesAndEdges()
        {
            Assert.AreEqual("1a", numeric.ToHex(26));
            Assert.AreEqual("ffffffff", numeric.ToHex(-1));
            Assert.AreEqual("0", numeric.ToHex(0));
        }

        [TestMethod]
        public void MinMoves_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinMoves(new[] { 1, 2, 3 }));
            Assert.AreEqual(0, numeric.MinMoves(new[] { 1, 1, 1 }));
            Assert.AreEqual(6, numeric.MinMoves(new[] { -1, 0, 4 }));
        }

        [TestMethod]
        public void PoorPigs_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.PoorPigs(1000, 15, 60));
            Assert.AreEqual(0, numeric.PoorPigs(1, 15, 60));
            Assert.AreEqual(2, numeric.PoorPigs(4, 15, 15));
        }

        [TestMethod]
        public void HammingDistance_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.HammingDistance(1, 4));
            Assert.AreEqual(0, numeric.HammingDistance(0, 0));
            Assert.AreEqual(31, numeric.HammingDistance(int.MaxValue, 0));
        }

        [TestMethod]
        public void FindComplement_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.FindComplement(5));
            Assert.AreEqual(0, numeric.FindComplement(1));
            Assert.AreEqual(1, numeric.FindComplement(2));
        }

        [TestMethod]
        public void TotalHammingDistance_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.TotalHammingDistance(new[] { 4, 14, 2 }));
            Assert.AreEqual(0, numeric.TotalHammingDistance(new[] { 0, 0 }));
            Assert.AreEqual(4, numeric.TotalHammingDistance(new[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void ConstructRectangle_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 2, 2 }, numeric.ConstructRectangle(4));
            CollectionAssert.AreEqual(new[] { 1, 1 }, numeric.ConstructRectangle(1));
            CollectionAssert.AreEqual(new[] { 37, 1 }, numeric.ConstructRectangle(37));
        }

        [TestMethod]
        public void ConvertToBase7_ExamplesAndEdges()
        {
            Assert.AreEqual("202", numeric.ConvertToBase7(100));
            Assert.AreEqual("-10", numeric.ConvertToBase7(-7));
            Assert.AreEqual("0", numeric.ConvertToBase7(0));
        }

        [TestMethod]
        public void CheckPerfectNumber_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.CheckPerfectNumber(28));
            Assert.IsFalse(numeric.CheckPerfectNumber(7));
            Assert.IsFalse(numeric.CheckPerfectNumber(1));
        }

        [TestMethod]
        public void Fib_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.Fib(3));
            Assert.AreEqual(0, numeric.Fib(0));
            Assert.AreEqual(55, numeric.Fib(10));
        }

        [TestMethod]
        public void NextGreaterElement_ExamplesAndEdges()
        {
            Assert.AreEqual(21, numeric.NextGreaterElement(12));
            Assert.AreEqual(-1, numeric.NextGreaterElement(21));
            Assert.AreEqual(-1, numeric.NextGreaterElement(1999999999));
        }

        [TestMethod]
        public void MaxCount_ExamplesAndEdges()
        {
            int[][] ops = { new[] { 2, 2 }, new[] { 3, 3 } };
            Assert.AreEqual(4, numeric.MaxCount(3, 3, ops));
            Assert.AreEqual(9, numeric.MaxCount(3, 3, new int[0][]));
            Assert.AreEqual(2, numeric.MaxCount(3, 3, new[] { new[] { 1, 2 } }));
        }

        [TestMethod]
        public void JudgeSquareSum_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.JudgeSquareSum(5));
            Assert.IsTrue(numeric.JudgeSquareSum(0));
            Assert.IsFalse(numeric.JudgeSquareSum(3));
            Assert.IsFalse(numeric.JudgeSquareSum(int.MaxValue));
        }

        [TestMethod]
        public void FindErrorNums_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 2, 3 }, numeric.FindErrorNums(new[] { 1, 2, 2, 4 }));
            CollectionAssert.AreEqual(new[] { 1, 2 }, numeric.FindErrorNums(new[] { 1, 1 }));
            CollectionAssert.AreEqual(new[] { 3, 1 }, numeric.FindErrorNums(new[] { 3, 2, 3, 4, 6, 5 }));
        }

        [TestMethod]
        public void MinSteps_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinSteps(3));
            Assert.AreEqual(0, numeric.MinSteps(1));
            Assert.AreEqual(7, numeric.MinSteps(12));
        }

        [TestMethod]
        public void FlipLights_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.FlipLights(1, 1));
            Assert.AreEqual(1, numeric.FlipLights(3, 0));
            Assert.AreEqual(7, numeric.FlipLights(3, 2));
            Assert.AreEqual(8, numeric.FlipLights(4, 3));
        }

        [TestMethod]
        public void HasAlternatingBits_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.HasAlternatingBits(5));
            Assert.IsTrue(numeric.HasAlternatingBits(1));
            Assert.IsFalse(numeric.HasAlternatingBits(7));
            Assert.IsFalse(numeric.HasAlternatingBits(11));
        }

        [TestMethod]
        public void SelfDividingNumbers_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 }, numeric.SelfDividingNumbers(1, 22).ToList());
            CollectionAssert.AreEqual(new List<int> { 48 }, numeric.SelfDividingNumbers(47, 50).ToList());
        }

        [TestMethod]
        public void CountPrimeSetBits_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.CountPrimeSetBits(6, 10));
            Assert.AreEqual(5, numeric.CountPrimeSetBits(10, 15));
            Assert.AreEqual(0, numeric.CountPrimeSetBits(1, 1));
        }

        [TestMethod]
        public void ReachNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.ReachNumber(3));
            Assert.AreEqual(3, numeric.ReachNumber(2));
            Assert.AreEqual(2, numeric.ReachNumber(-3));
        }

        [TestMethod]
        public void NumRabbits_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.NumRabbits(new[] { 1, 1, 2 }));
            Assert.AreEqual(11, numeric.NumRabbits(new[] { 10, 10, 10 }));
            Assert.AreEqual(0, numeric.NumRabbits(Array.Empty<int>()));
        }

        [TestMethod]
        public void RotatedDigits_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.RotatedDigits(10));
            Assert.AreEqual(0, numeric.RotatedDigits(1));
            Assert.AreEqual(40, numeric.RotatedDigits(100));
        }

        [TestMethod]
        public void PreimageSizeFZF_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.PreimageSizeFZF(0));
            Assert.AreEqual(5, numeric.PreimageSizeFZF(3));
            Assert.AreEqual(0, numeric.PreimageSizeFZF(5));
        }

        [TestMethod]
        public void XorGame_ExamplesAndEdges()
        {
            Assert.IsFalse(numeric.XorGame(new[] { 1, 1, 2 }));
            Assert.IsTrue(numeric.XorGame(new[] { 0, 1 }));
            Assert.IsTrue(numeric.XorGame(new[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void LargestTriangleArea_ExamplesAndEdges()
        {
            int[][] points = { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, 2 }, new[] { 2, 0 } };
            Assert.AreEqual(2.0, numeric.LargestTriangleArea(points), 0.000001);
            Assert.AreEqual(0.5, numeric.LargestTriangleArea(new[] { new[] { 0, 0 }, new[] { 1, 0 }, new[] { 0, 1 } }), 0.000001);
        }

        [TestMethod]
        public void ConsecutiveNumbersSum_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.ConsecutiveNumbersSum(5));
            Assert.AreEqual(3, numeric.ConsecutiveNumbersSum(9));
            Assert.AreEqual(4, numeric.ConsecutiveNumbersSum(15));
            Assert.AreEqual(1, numeric.ConsecutiveNumbersSum(1));
        }

        [TestMethod]
        public void IsRectangleOverlap_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsRectangleOverlap(new[] { 0, 0, 2, 2 }, new[] { 1, 1, 3, 3 }));
            Assert.IsFalse(numeric.IsRectangleOverlap(new[] { 0, 0, 1, 1 }, new[] { 1, 0, 2, 1 }));
            Assert.IsFalse(numeric.IsRectangleOverlap(new[] { 0, 0, 1, 1 }, new[] { 2, 2, 3, 3 }));
        }

        [TestMethod]
        public void MirrorReflection_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MirrorReflection(2, 1));
            Assert.AreEqual(1, numeric.MirrorReflection(3, 1));
            Assert.AreEqual(2, numeric.MirrorReflection(4, 2));
        }

        [TestMethod]
        public void BinaryGap_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.BinaryGap(22));
            Assert.AreEqual(0, numeric.BinaryGap(8));
            Assert.AreEqual(2, numeric.BinaryGap(5));
        }

        [TestMethod]
        public void ReorderedPowerOf2_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.ReorderedPowerOf2(1));
            Assert.IsFalse(numeric.ReorderedPowerOf2(10));
            Assert.IsTrue(numeric.ReorderedPowerOf2(46));
        }

        [TestMethod]
        public void HasGroupsSizeX_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.HasGroupsSizeX(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }));
            Assert.IsFalse(numeric.HasGroupsSizeX(new[] { 1, 1, 1, 2, 2, 2, 3, 3 }));
            Assert.IsFalse(numeric.HasGroupsSizeX(new[] { 1 }));
        }

        [TestMethod]
        public void PowerfulIntegers_ExamplesAndEdges()
        {
            CollectionAssert.AreEquivalent(new List<int> { 2, 3, 4, 5, 7, 9, 10 }, numeric.PowerfulIntegers(2, 3, 10).ToList());
            CollectionAssert.AreEquivalent(new List<int> { 2 }, numeric.PowerfulIntegers(1, 1, 10).ToList());
            CollectionAssert.AreEquivalent(new List<int>(), numeric.PowerfulIntegers(2, 3, 1).ToList());
        }

        [TestMethod]
        public void BrokenCalc_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.BrokenCalc(2, 3));
            Assert.AreEqual(2, numeric.BrokenCalc(5, 8));
            Assert.AreEqual(9, numeric.BrokenCalc(10, 1));
        }

        [TestMethod]
        public void Clumsy_ExamplesAndEdges()
        {
            Assert.AreEqual(7, numeric.Clumsy(4));
            Assert.AreEqual(12, numeric.Clumsy(10));
            Assert.AreEqual(1, numeric.Clumsy(1));
        }

        [TestMethod]
        public void SmallestRepunitDivByK_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.SmallestRepunitDivByK(1));
            Assert.AreEqual(-1, numeric.SmallestRepunitDivByK(2));
            Assert.AreEqual(3, numeric.SmallestRepunitDivByK(3));
        }

        [TestMethod]
        public void BaseNeg2_ExamplesAndEdges()
        {
            Assert.AreEqual("110", numeric.BaseNeg2(2));
            Assert.AreEqual("111", numeric.BaseNeg2(3));
            Assert.AreEqual("0", numeric.BaseNeg2(0));
        }

        [TestMethod]
        public void DivisorGame_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.DivisorGame(2));
            Assert.IsFalse(numeric.DivisorGame(3));
            Assert.IsTrue(numeric.DivisorGame(100));
        }

        [TestMethod]
        public void NumMovesStones_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 2 }, numeric.NumMovesStones(1, 2, 5));
            CollectionAssert.AreEqual(new[] { 0, 0 }, numeric.NumMovesStones(4, 3, 2));
            CollectionAssert.AreEqual(new[] { 1, 2 }, numeric.NumMovesStones(3, 5, 1));
        }

        [TestMethod]
        public void IsBoomerang_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsBoomerang(new[] { new[] { 1, 1 }, new[] { 2, 3 }, new[] { 3, 2 } }));
            Assert.IsFalse(numeric.IsBoomerang(new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } }));
            Assert.IsFalse(numeric.IsBoomerang(new[] { new[] { 0, 0 }, new[] { 0, 0 }, new[] { 1, 1 } }));
        }

        [TestMethod]
        public void DistributeCandies_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 1 }, numeric.DistributeCandies(7, 4));
            CollectionAssert.AreEqual(new[] { 5 }, numeric.DistributeCandies(5, 1));
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, numeric.DistributeCandies(10, 4));
        }

        [TestMethod]
        public void Tribonacci_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.Tribonacci(4));
            Assert.AreEqual(0, numeric.Tribonacci(0));
            Assert.AreEqual(1389537, numeric.Tribonacci(25));
        }

        [TestMethod]
        public void NumPrimeArrangements_ExamplesAndEdges()
        {
            Assert.AreEqual(12, numeric.NumPrimeArrangements(5));
            Assert.AreEqual(682289015, numeric.NumPrimeArrangements(100));
            Assert.AreEqual(1, numeric.NumPrimeArrangements(1));
        }

        [TestMethod]
        public void DayOfTheWeek_ExamplesAndEdges()
        {
            Assert.AreEqual("Saturday", numeric.DayOfTheWeek(31, 8, 2019));
            Assert.AreEqual("Sunday", numeric.DayOfTheWeek(18, 7, 1999));
            Assert.AreEqual("Monday", numeric.DayOfTheWeek(1, 1, 2001));
        }

        [TestMethod]
        public void NthUglyNumberWithDivisors_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.NthUglyNumber(3, 2, 3, 5));
            Assert.AreEqual(6, numeric.NthUglyNumber(4, 2, 3, 4));
            Assert.AreEqual(10, numeric.NthUglyNumber(5, 2, 11, 13));
        }

        [TestMethod]
        public void MinCostToMoveChips_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.MinCostToMoveChips(new[] { 1, 2, 3 }));
            Assert.AreEqual(2, numeric.MinCostToMoveChips(new[] { 2, 2, 2, 3, 3 }));
            Assert.AreEqual(0, numeric.MinCostToMoveChips(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CheckStraightLine_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.CheckStraightLine(new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 } }));
            Assert.IsFalse(numeric.CheckStraightLine(new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 4 }, new[] { 4, 5 } }));
            Assert.IsTrue(numeric.CheckStraightLine(new[] { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, -1 } }));
        }

        [TestMethod]
        public void IsGoodArray_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsGoodArray(new[] { 12, 5, 7, 23 }));
            Assert.IsFalse(numeric.IsGoodArray(new[] { 3, 6 }));
            Assert.IsTrue(numeric.IsGoodArray(new[] { 1 }));
        }

        [TestMethod]
        public void SubtractProductAndSum_ExamplesAndEdges()
        {
            Assert.AreEqual(15, numeric.SubtractProductAndSum(234));
            Assert.AreEqual(21, numeric.SubtractProductAndSum(4421));
            Assert.AreEqual(-1, numeric.SubtractProductAndSum(10));
        }

        [TestMethod]
        public void FindNumbers_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.FindNumbers(new[] { 12, 345, 2, 6, 7896 }));
            Assert.AreEqual(1, numeric.FindNumbers(new[] { 555, 901, 482, 1771 }));
            Assert.AreEqual(1, numeric.FindNumbers(new[] { 100000 }));
        }

        [TestMethod]
        public void GetNoZeroIntegers_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 1 }, numeric.GetNoZeroIntegers(2));
            Assert.AreEqual(11, numeric.GetNoZeroIntegers(11).Sum());
            Assert.IsTrue(numeric.GetNoZeroIntegers(1010).All(value => !value.ToString().Contains('0')));
        }

        [TestMethod]
        public void Maximum69Number_ExamplesAndEdges()
        {
            Assert.AreEqual(9969, numeric.Maximum69Number(9669));
            Assert.AreEqual(9999, numeric.Maximum69Number(9999));
            Assert.AreEqual(999, numeric.Maximum69Number(699));
        }

        [TestMethod]
        public void NumberOfSteps_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.NumberOfSteps(14));
            Assert.AreEqual(0, numeric.NumberOfSteps(0));
            Assert.AreEqual(4, numeric.NumberOfSteps(8));
        }

        [TestMethod]
        public void ClosestDivisors_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 3, 3 }, numeric.ClosestDivisors(8));
            CollectionAssert.AreEqual(new[] { 5, 25 }, numeric.ClosestDivisors(123));
            CollectionAssert.AreEqual(new[] { 25, 40 }, numeric.ClosestDivisors(999));
        }

        [TestMethod]
        public void SumFourDivisors_ExamplesAndEdges()
        {
            Assert.AreEqual(32, numeric.SumFourDivisors(new[] { 21, 4, 7 }));
            Assert.AreEqual(0, numeric.SumFourDivisors(new[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(42, numeric.SumFourDivisors(new[] { 10, 15 }));
        }

        [TestMethod]
        public void CountLargestGroup_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.CountLargestGroup(13));
            Assert.AreEqual(2, numeric.CountLargestGroup(2));
            Assert.AreEqual(5, numeric.CountLargestGroup(24));
        }

        [TestMethod]
        public void SimplifiedFractions_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new List<string> { "1/2" }, numeric.SimplifiedFractions(2).ToList());
            CollectionAssert.AreEqual(new List<string> { "1/2", "1/3", "2/3", "1/4", "3/4" }, numeric.SimplifiedFractions(4).ToList());
            CollectionAssert.AreEqual(new List<string>(), numeric.SimplifiedFractions(1).ToList());
        }

        [TestMethod]
        public void XorOperation_ExamplesAndEdges()
        {
            Assert.AreEqual(8, numeric.XorOperation(5, 0));
            Assert.AreEqual(8, numeric.XorOperation(4, 3));
            Assert.AreEqual(7, numeric.XorOperation(1, 7));
        }

        [TestMethod]
        public void KthFactor_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.KthFactor(12, 3));
            Assert.AreEqual(7, numeric.KthFactor(7, 2));
            Assert.AreEqual(-1, numeric.KthFactor(4, 4));
        }

        [TestMethod]
        public void NumIdenticalPairs_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.NumIdenticalPairs(new[] { 1, 2, 3, 1, 1, 3 }));
            Assert.AreEqual(6, numeric.NumIdenticalPairs(new[] { 1, 1, 1, 1 }));
            Assert.AreEqual(0, numeric.NumIdenticalPairs(new[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void NumWaterBottles_ExamplesAndEdges()
        {
            Assert.AreEqual(13, numeric.NumWaterBottles(9, 3));
            Assert.AreEqual(19, numeric.NumWaterBottles(15, 4));
            Assert.AreEqual(2, numeric.NumWaterBottles(2, 3));
        }

        [TestMethod]
        public void CountOdds_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.CountOdds(3, 7));
            Assert.AreEqual(1, numeric.CountOdds(8, 10));
            Assert.AreEqual(0, numeric.CountOdds(2, 2));
        }

        [TestMethod]
        public void MinOperations_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinOperations(3));
            Assert.AreEqual(9, numeric.MinOperations(6));
            Assert.AreEqual(0, numeric.MinOperations(1));
        }

        [TestMethod]
        public void MinimumOneBitOperations_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinimumOneBitOperations(3));
            Assert.AreEqual(4, numeric.MinimumOneBitOperations(6));
            Assert.AreEqual(0, numeric.MinimumOneBitOperations(0));
        }

        [TestMethod]
        public void CountVowelStrings_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.CountVowelStrings(1));
            Assert.AreEqual(15, numeric.CountVowelStrings(2));
            Assert.AreEqual(66045, numeric.CountVowelStrings(33));
        }

        [TestMethod]
        public void ConcatenatedBinary_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.ConcatenatedBinary(1));
            Assert.AreEqual(27, numeric.ConcatenatedBinary(3));
            Assert.AreEqual(505379714, numeric.ConcatenatedBinary(12));
        }

        [TestMethod]
        public void NumberOfMatches_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.NumberOfMatches(7));
            Assert.AreEqual(13, numeric.NumberOfMatches(14));
            Assert.AreEqual(0, numeric.NumberOfMatches(1));
        }

        [TestMethod]
        public void TotalMoney_ExamplesAndEdges()
        {
            Assert.AreEqual(10, numeric.TotalMoney(4));
            Assert.AreEqual(37, numeric.TotalMoney(10));
            Assert.AreEqual(96, numeric.TotalMoney(20));
        }

        [TestMethod]
        public void DecodeXoredArray_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 0, 2, 1 }, numeric.Decode(new[] { 1, 2, 3 }, 1));
            CollectionAssert.AreEqual(new[] { 4, 2, 0, 7, 4 }, numeric.Decode(new[] { 6, 2, 7, 3 }, 4));
        }

        [TestMethod]
        public void CountGoodRectangles_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.CountGoodRectangles(new[] { new[] { 5, 8 }, new[] { 3, 9 }, new[] { 5, 12 }, new[] { 16, 5 } }));
            Assert.AreEqual(3, numeric.CountGoodRectangles(new[] { new[] { 2, 3 }, new[] { 3, 7 }, new[] { 4, 3 }, new[] { 3, 7 } }));
        }

        [TestMethod]
        public void DecodeXoredPermutation_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, numeric.Decode(new[] { 3, 1 }));
            CollectionAssert.AreEqual(new[] { 2, 4, 1, 5, 3 }, numeric.Decode(new[] { 6, 5, 4, 6 }));
        }

        [TestMethod]
        public void MaximumScore_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.MaximumScore(2, 4, 6));
            Assert.AreEqual(7, numeric.MaximumScore(4, 4, 6));
            Assert.AreEqual(8, numeric.MaximumScore(1, 8, 8));
        }

        [TestMethod]
        public void CheckPowersOfThree_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.CheckPowersOfThree(12));
            Assert.IsFalse(numeric.CheckPowersOfThree(21));
            Assert.IsTrue(numeric.CheckPowersOfThree(1));
        }

        [TestMethod]
        public void SquareIsWhite_ExamplesAndEdges()
        {
            Assert.IsFalse(numeric.SquareIsWhite("a1"));
            Assert.IsTrue(numeric.SquareIsWhite("h3"));
            Assert.IsFalse(numeric.SquareIsWhite("c7"));
        }

        [TestMethod]
        public void CountNicePairs_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountNicePairs(new[] { 42, 11, 1, 97 }));
            Assert.AreEqual(4, numeric.CountNicePairs(new[] { 13, 10, 35, 24, 76 }));
        }

        [TestMethod]
        public void CountPoints_ExamplesAndEdges()
        {
            int[][] points = { new[] { 1, 3 }, new[] { 3, 3 }, new[] { 5, 3 }, new[] { 2, 2 } };
            int[][] queries = { new[] { 2, 3, 1 }, new[] { 4, 3, 1 }, new[] { 1, 1, 2 } };
            CollectionAssert.AreEqual(new[] { 3, 2, 2 }, numeric.CountPoints(points, queries));
        }

        [TestMethod]
        public void SumBase_ExamplesAndEdges()
        {
            Assert.AreEqual(9, numeric.SumBase(34, 6));
            Assert.AreEqual(1, numeric.SumBase(10, 10));
        }

        [TestMethod]
        public void MemLeak_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 3, 1, 0 }, numeric.MemLeak(2, 2));
            CollectionAssert.AreEqual(new[] { 6, 0, 4 }, numeric.MemLeak(8, 11));
        }

        [TestMethod]
        public void CountGoodNumbers_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.CountGoodNumbers(1));
            Assert.AreEqual(400, numeric.CountGoodNumbers(4));
            Assert.AreEqual(564908303, numeric.CountGoodNumbers(50));
        }

        [TestMethod]
        public void CountTriples_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountTriples(5));
            Assert.AreEqual(4, numeric.CountTriples(10));
            Assert.AreEqual(0, numeric.CountTriples(4));
        }

        [TestMethod]
        public void IsThree_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsThree(4));
            Assert.IsFalse(numeric.IsThree(2));
            Assert.IsFalse(numeric.IsThree(16));
        }

        [TestMethod]
        public void MinNonZeroProduct_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.MinNonZeroProduct(1));
            Assert.AreEqual(6, numeric.MinNonZeroProduct(2));
            Assert.AreEqual(1512, numeric.MinNonZeroProduct(3));
        }

        [TestMethod]
        public void FindGCD_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.FindGCD(new[] { 2, 5, 6, 9, 10 }));
            Assert.AreEqual(1, numeric.FindGCD(new[] { 7, 5, 6, 8, 3 }));
        }

        [TestMethod]
        public void InterchangeableRectangles_ExamplesAndEdges()
        {
            Assert.AreEqual(6L, numeric.InterchangeableRectangles(new[] { new[] { 4, 8 }, new[] { 3, 6 }, new[] { 10, 20 }, new[] { 15, 30 } }));
            Assert.AreEqual(0L, numeric.InterchangeableRectangles(new[] { new[] { 4, 5 }, new[] { 7, 8 } }));
        }

        [TestMethod]
        public void MissingRolls_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 6, 6 }, numeric.MissingRolls(new[] { 3, 2, 4, 3 }, 4, 2));
            CollectionAssert.AreEqual(Array.Empty<int>(), numeric.MissingRolls(new[] { 1, 2, 3, 4 }, 6, 4));
            Assert.AreEqual(4, numeric.MissingRolls(new[] { 1, 5, 6 }, 3, 4).Length);
        }

        [TestMethod]
        public void CountMaxOrSubsets_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountMaxOrSubsets(new[] { 3, 1 }));
            Assert.AreEqual(7, numeric.CountMaxOrSubsets(new[] { 2, 2, 2 }));
            Assert.AreEqual(6, numeric.CountMaxOrSubsets(new[] { 3, 2, 1, 5 }));
        }

        [TestMethod]
        public void NextBeautifulNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(22, numeric.NextBeautifulNumber(1));
            Assert.AreEqual(1333, numeric.NextBeautifulNumber(1000));
            Assert.AreEqual(3133, numeric.NextBeautifulNumber(3000));
        }

        [TestMethod]
        public void CountOperations_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.CountOperations(2, 3));
            Assert.AreEqual(1, numeric.CountOperations(10, 10));
            Assert.AreEqual(0, numeric.CountOperations(0, 7));
        }

        [TestMethod]
        public void SumOfThree_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new long[] { 10, 11, 12 }, numeric.SumOfThree(33));
            CollectionAssert.AreEqual(Array.Empty<long>(), numeric.SumOfThree(4));
            CollectionAssert.AreEqual(new long[] { -1, 0, 1 }, numeric.SumOfThree(0));
        }

        [TestMethod]
        public void CountEven_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountEven(4));
            Assert.AreEqual(14, numeric.CountEven(30));
            Assert.AreEqual(0, numeric.CountEven(1));
        }

        [TestMethod]
        public void MinimalKSum_ExamplesAndEdges()
        {
            Assert.AreEqual(5L, numeric.MinimalKSum(new[] { 1, 4, 25, 10, 25 }, 2));
            Assert.AreEqual(25L, numeric.MinimalKSum(new[] { 5, 6 }, 6));
            Assert.AreEqual(9L, numeric.MinimalKSum(new[] { 1, 1, 1 }, 3));
        }

        [TestMethod]
        public void MinBitFlips_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinBitFlips(10, 7));
            Assert.AreEqual(3, numeric.MinBitFlips(3, 4));
            Assert.AreEqual(0, numeric.MinBitFlips(0, 0));
        }

        [TestMethod]
        public void Sum_ExamplesAndEdges()
        {
            Assert.AreEqual(17, numeric.Sum(12, 5));
            Assert.AreEqual(-10, numeric.Sum(-10, 0));
        }

        [TestMethod]
        public void WaysToBuyPensPencils_ExamplesAndEdges()
        {
            Assert.AreEqual(9L, numeric.WaysToBuyPensPencils(20, 10, 5));
            Assert.AreEqual(1L, numeric.WaysToBuyPensPencils(5, 10, 10));
        }

        [TestMethod]
        public void LargestCombination_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.LargestCombination(new[] { 16, 17, 71, 62, 12, 24, 14 }));
            Assert.AreEqual(2, numeric.LargestCombination(new[] { 8, 8 }));
        }

        [TestMethod]
        public void MinimumNumbers_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinimumNumbers(58, 9));
            Assert.AreEqual(-1, numeric.MinimumNumbers(37, 2));
            Assert.AreEqual(0, numeric.MinimumNumbers(0, 7));
        }

        [TestMethod]
        public void MaximumXOR_ExamplesAndEdges()
        {
            Assert.AreEqual(7, numeric.MaximumXOR(new[] { 3, 2, 4, 6 }));
            Assert.AreEqual(11, numeric.MaximumXOR(new[] { 1, 2, 3, 9, 2 }));
        }

        [TestMethod]
        public void ZeroFilledSubarray_ExamplesAndEdges()
        {
            Assert.AreEqual(6L, numeric.ZeroFilledSubarray(new[] { 1, 3, 0, 0, 2, 0, 0, 4 }));
            Assert.AreEqual(9L, numeric.ZeroFilledSubarray(new[] { 0, 0, 0, 2, 0, 0 }));
            Assert.AreEqual(0L, numeric.ZeroFilledSubarray(new[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void CountExcellentPairs_ExamplesAndEdges()
        {
            Assert.AreEqual(5L, numeric.CountExcellentPairs(new[] { 1, 2, 3, 1 }, 3));
            Assert.AreEqual(0L, numeric.CountExcellentPairs(new[] { 5, 1, 1 }, 10));
        }

        [TestMethod]
        public void SmallestEvenMultiple_ExamplesAndEdges()
        {
            Assert.AreEqual(10, numeric.SmallestEvenMultiple(5));
            Assert.AreEqual(6, numeric.SmallestEvenMultiple(6));
        }

        [TestMethod]
        public void CommonFactors_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.CommonFactors(12, 6));
            Assert.AreEqual(2, numeric.CommonFactors(25, 30));
            Assert.AreEqual(1, numeric.CommonFactors(1, 1));
        }

        [TestMethod]
        public void XorAllNums_ExamplesAndEdges()
        {
            Assert.AreEqual(13, numeric.XorAllNums(new[] { 2, 1, 3 }, new[] { 10, 2, 5, 0 }));
            Assert.AreEqual(0, numeric.XorAllNums(new[] { 1, 2 }, new[] { 3, 4 }));
        }

        [TestMethod]
        public void SumOfNumberAndReverse_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.SumOfNumberAndReverse(443));
            Assert.IsFalse(numeric.SumOfNumberAndReverse(63));
            Assert.IsTrue(numeric.SumOfNumberAndReverse(0));
        }

        [TestMethod]
        public void AverageValue_ExamplesAndEdges()
        {
            Assert.AreEqual(9, numeric.AverageValue(new[] { 1, 3, 6, 10, 12, 15 }));
            Assert.AreEqual(0, numeric.AverageValue(new[] { 1, 2, 4, 7, 10 }));
        }

        [TestMethod]
        public void ConvertTemperature_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 309.65, 97.7 }, numeric.ConvertTemperature(36.5));
            CollectionAssert.AreEqual(new[] { 273.15, 32.0 }, numeric.ConvertTemperature(0.0));
        }

        [TestMethod]
        public void NumberOfCuts_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.NumberOfCuts(4));
            Assert.AreEqual(3, numeric.NumberOfCuts(3));
            Assert.AreEqual(0, numeric.NumberOfCuts(1));
        }

        [TestMethod]
        public void CountDigits_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.CountDigits(7));
            Assert.AreEqual(2, numeric.CountDigits(121));
            Assert.AreEqual(4, numeric.CountDigits(1248));
        }

        [TestMethod]
        public void DistinctPrimeFactors_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.DistinctPrimeFactors(new[] { 2, 4, 3, 7, 10, 6 }));
            Assert.AreEqual(1, numeric.DistinctPrimeFactors(new[] { 2, 4, 8, 16 }));
        }

        [TestMethod]
        public void AlternateDigitSum_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.AlternateDigitSum(521));
            Assert.AreEqual(1, numeric.AlternateDigitSum(111));
            Assert.AreEqual(0, numeric.AlternateDigitSum(886996));
        }

        [TestMethod]
        public void DistinctIntegers_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.DistinctIntegers(5));
            Assert.AreEqual(1, numeric.DistinctIntegers(1));
        }

        [TestMethod]
        public void MonkeyMove_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.MonkeyMove(3));
            Assert.AreEqual(14, numeric.MonkeyMove(4));
            Assert.AreEqual(0, numeric.MonkeyMove(1));
        }

        [TestMethod]
        public void MinMaxDifference_ExamplesAndEdges()
        {
            Assert.AreEqual(99009, numeric.MinMaxDifference(11891));
            Assert.AreEqual(99, numeric.MinMaxDifference(90));
        }

        [TestMethod]
        public void ColoredCells_ExamplesAndEdges()
        {
            Assert.AreEqual(1L, numeric.ColoredCells(1));
            Assert.AreEqual(5L, numeric.ColoredCells(2));
            Assert.AreEqual(25L, numeric.ColoredCells(4));
        }

        [TestMethod]
        public void PassThePillow_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.PassThePillow(4, 5));
            Assert.AreEqual(3, numeric.PassThePillow(3, 2));
            Assert.AreEqual(1, numeric.PassThePillow(2, 2));
        }

        [TestMethod]
        public void DistMoney_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.DistMoney(20, 3));
            Assert.AreEqual(2, numeric.DistMoney(16, 2));
            Assert.AreEqual(-1, numeric.DistMoney(2, 3));
        }

        [TestMethod]
        public void SumOfMultiples_ExamplesAndEdges()
        {
            Assert.AreEqual(21, numeric.SumOfMultiples(7));
            Assert.AreEqual(40, numeric.SumOfMultiples(10));
            Assert.AreEqual(0, numeric.SumOfMultiples(2));
        }

        [TestMethod]
        public void PunishmentNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.PunishmentNumber(1));
            Assert.AreEqual(182, numeric.PunishmentNumber(10));
            Assert.AreEqual(1478, numeric.PunishmentNumber(37));
        }

        [TestMethod]
        public void IsFascinating_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsFascinating(192));
            Assert.IsFalse(numeric.IsFascinating(100));
            Assert.IsFalse(numeric.IsFascinating(783));
        }

        [TestMethod]
        public void DistanceTraveled_ExamplesAndEdges()
        {
            Assert.AreEqual(60, numeric.DistanceTraveled(5, 10));
            Assert.AreEqual(10, numeric.DistanceTraveled(1, 2));
        }

        [TestMethod]
        public void CountBeautifulPairs_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.CountBeautifulPairs(new[] { 2, 5, 1, 4 }));
            Assert.AreEqual(2, numeric.CountBeautifulPairs(new[] { 11, 21, 12 }));
        }

        [TestMethod]
        public void TheMaximumAchievableX_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.TheMaximumAchievableX(4, 1));
            Assert.AreEqual(7, numeric.TheMaximumAchievableX(3, 2));
            Assert.AreEqual(0, numeric.TheMaximumAchievableX(0, 0));
        }

        [TestMethod]
        public void AccountBalanceAfterPurchase_ExamplesAndEdges()
        {
            Assert.AreEqual(90, numeric.AccountBalanceAfterPurchase(9));
            Assert.AreEqual(80, numeric.AccountBalanceAfterPurchase(15));
            Assert.AreEqual(100, numeric.AccountBalanceAfterPurchase(0));
        }

        [TestMethod]
        public void CountSymmetricIntegers_ExamplesAndEdges()
        {
            Assert.AreEqual(9, numeric.CountSymmetricIntegers(1, 100));
            Assert.AreEqual(4, numeric.CountSymmetricIntegers(1200, 1230));
        }

        [TestMethod]
        public void DifferenceOfSums_ExamplesAndEdges()
        {
            Assert.AreEqual(19, numeric.DifferenceOfSums(10, 3));
            Assert.AreEqual(15, numeric.DifferenceOfSums(5, 6));
            Assert.AreEqual(-15, numeric.DifferenceOfSums(5, 1));
        }

        [TestMethod]
        public void FindKOr_ExamplesAndEdges()
        {
            Assert.AreEqual(9, numeric.FindKOr(new[] { 7, 12, 9, 8, 9, 15 }, 4));
            Assert.AreEqual(0, numeric.FindKOr(new[] { 2, 12, 1, 11, 4, 5 }, 6));
            Assert.AreEqual(15, numeric.FindKOr(new[] { 10, 8, 5, 9, 11, 6, 8 }, 1));
        }

        [TestMethod]
        public void DistributeCandiesAmongChildren_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.DistributeCandiesAmongChildren(5, 2));
            Assert.AreEqual(10, numeric.DistributeCandiesAmongChildren(3, 3));
            Assert.AreEqual(1, numeric.DistributeCandiesAmongChildren(0, 1));
        }

        [TestMethod]
        public void DistributeCandiesAmongChildrenII_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.DistributeCandiesAmongChildrenII(5, 2));
            Assert.AreEqual(10L, numeric.DistributeCandiesAmongChildrenII(3, 3));
            Assert.AreEqual(1L, numeric.DistributeCandiesAmongChildrenII(0, 1));
        }

        [TestMethod]
        public void GetGoodIndices_ExamplesAndEdges()
        {
            int[][] variables =
            {
                new[] { 2, 3, 3, 10 },
                new[] { 3, 3, 3, 1 },
                new[] { 6, 1, 1, 4 }
            };

            CollectionAssert.AreEqual(new List<int> { 0, 2 }, numeric.GetGoodIndices(variables, 2).ToList());
            CollectionAssert.AreEqual(new List<int>(), numeric.GetGoodIndices(variables, 3).ToList());
        }

        [TestMethod]
        public void MostExpensiveItem_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MostExpensiveItem(2, 5));
            Assert.AreEqual(23, numeric.MostExpensiveItem(5, 7));
        }

        [TestMethod]
        public void MinOperationsXor_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinOperationsXor(new[] { 2, 1, 3, 4 }, 1));
            Assert.AreEqual(0, numeric.MinOperationsXor(new[] { 2, 0, 2, 0 }, 0));
        }

        [TestMethod]
        public void MinMovesToCaptureTheQueen_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinMovesToCaptureTheQueen(1, 1, 8, 8, 2, 3));
            Assert.AreEqual(1, numeric.MinMovesToCaptureTheQueen(5, 3, 3, 4, 5, 2));
            Assert.AreEqual(1, numeric.MinMovesToCaptureTheQueen(4, 3, 3, 4, 1, 6));
        }

        [TestMethod]
        public void MaxFrequencyElements_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.MaxFrequencyElements(new[] { 1, 2, 2, 3, 1, 4 }));
            Assert.AreEqual(5, numeric.MaxFrequencyElements(new[] { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void MinimumArrayLength_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.MinimumArrayLength(new[] { 1, 4, 3, 1 }));
            Assert.AreEqual(2, numeric.MinimumArrayLength(new[] { 5, 5, 5, 10, 5 }));
            Assert.AreEqual(1, numeric.MinimumArrayLength(new[] { 2, 3, 4 }));
        }

        [TestMethod]
        public void FlowerGame_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.FlowerGame(3, 2));
            Assert.AreEqual(0L, numeric.FlowerGame(1, 1));
            Assert.AreEqual(50L, numeric.FlowerGame(10, 10));
        }

        [TestMethod]
        public void SumOfEncryptedInt_ExamplesAndEdges()
        {
            Assert.AreEqual(6, numeric.SumOfEncryptedInt(new[] { 1, 2, 3 }));
            Assert.AreEqual(66, numeric.SumOfEncryptedInt(new[] { 10, 21, 31 }));
        }

        [TestMethod]
        public void SumOfTheDigitsOfHarshadNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(9, numeric.SumOfTheDigitsOfHarshadNumber(18));
            Assert.AreEqual(-1, numeric.SumOfTheDigitsOfHarshadNumber(23));
        }

        [TestMethod]
        public void MaximumPrimeDifference_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MaximumPrimeDifference(new[] { 4, 2, 9, 5, 3 }));
            Assert.AreEqual(0, numeric.MaximumPrimeDifference(new[] { 4, 8, 2, 8 }));
        }

        [TestMethod]
        public void MinEnd_ExamplesAndEdges()
        {
            Assert.AreEqual(6L, numeric.MinEnd(3, 4));
            Assert.AreEqual(15L, numeric.MinEnd(2, 7));
            Assert.AreEqual(1L, numeric.MinEnd(1, 1));
        }

        [TestMethod]
        public void DuplicateNumbersXOR_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.DuplicateNumbersXOR(new[] { 1, 2, 1, 3 }));
            Assert.AreEqual(0, numeric.DuplicateNumbersXOR(new[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void NumberOfPairsII_ExamplesAndEdges()
        {
            Assert.AreEqual(5L, numeric.NumberOfPairsII(new[] { 1, 3, 4 }, new[] { 1, 3, 4 }, 1));
            Assert.AreEqual(2L, numeric.NumberOfPairsII(new[] { 1, 2, 4, 12 }, new[] { 2, 4 }, 3));
        }

        [TestMethod]
        public void NumberOfChild_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.NumberOfChild(3, 5));
            Assert.AreEqual(0, numeric.NumberOfChild(5, 8));
        }

        [TestMethod]
        public void MinimumOperations_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinimumOperations(new[] { 1, 2, 3, 4 }));
            Assert.AreEqual(0, numeric.MinimumOperations(new[] { 3, 6, 9 }));
        }

        [TestMethod]
        public void MaxHeightOfTriangle_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MaxHeightOfTriangle(2, 4));
            Assert.AreEqual(2, numeric.MaxHeightOfTriangle(2, 1));
            Assert.AreEqual(0, numeric.MaxHeightOfTriangle(0, 0));
        }

        [TestMethod]
        public void LosingPlayer_ExamplesAndEdges()
        {
            Assert.AreEqual("Alice", numeric.LosingPlayer(2, 7));
            Assert.AreEqual("Bob", numeric.LosingPlayer(4, 11));
        }

        [TestMethod]
        public void MinChanges_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.MinChanges(13, 4));
            Assert.AreEqual(0, numeric.MinChanges(7, 7));
            Assert.AreEqual(-1, numeric.MinChanges(10, 7));
        }

        [TestMethod]
        public void CanAliceWin_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.CanAliceWin(new[] { 1, 2, 3, 4, 5, 14 }));
            Assert.IsFalse(numeric.CanAliceWin(new[] { 5, 5, 10 }));
        }

        [TestMethod]
        public void NonSpecialCount_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.NonSpecialCount(5, 7));
            Assert.AreEqual(11, numeric.NonSpecialCount(4, 16));
        }

        [TestMethod]
        public void GetSneakyNumbers_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1, 0 }, numeric.GetSneakyNumbers(new[] { 0, 1, 1, 0 }));
            CollectionAssert.AreEqual(new[] { 3, 2 }, numeric.GetSneakyNumbers(new[] { 0, 3, 2, 1, 3, 2 }));
        }

        [TestMethod]
        public void MinElement_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.MinElement(new[] { 10, 12, 13, 14 }));
            Assert.AreEqual(10, numeric.MinElement(new[] { 99999, 19 }));
        }

        [TestMethod]
        public void KthCharacter_ExamplesAndEdges()
        {
            Assert.AreEqual('b', numeric.KthCharacter(5));
            Assert.AreEqual('c', numeric.KthCharacter(10));
            Assert.AreEqual('a', numeric.KthCharacter(1));
        }

        [TestMethod]
        public void MaxGoodNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(30, numeric.MaxGoodNumber(new[] { 1, 2, 3 }));
            Assert.AreEqual(1296, numeric.MaxGoodNumber(new[] { 2, 8, 16 }));
        }

        [TestMethod]
        public void MinBitwiseArray_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { -1, 1, 4, 3 }, numeric.MinBitwiseArray(new List<int> { 2, 3, 5, 7 }));
            CollectionAssert.AreEqual(new[] { 9, 7 }, numeric.MinBitwiseArray(new List<int> { 11, 15 }));
        }

        [TestMethod]
        public void SmallestNumber_ExamplesAndEdges()
        {
            Assert.AreEqual(10, numeric.SmallestNumber(10, 2));
            Assert.AreEqual(16, numeric.SmallestNumber(15, 3));
            Assert.AreEqual(20, numeric.SmallestNumber(19, 5));
        }

        [TestMethod]
        public void SmallestNumberWithAllSetBits_ExamplesAndEdges()
        {
            Assert.AreEqual(7, numeric.SmallestNumberWithAllSetBits(5));
            Assert.AreEqual(15, numeric.SmallestNumberWithAllSetBits(10));
            Assert.AreEqual(1, numeric.SmallestNumberWithAllSetBits(1));
        }

        [TestMethod]
        public void MinOperationsDivisibleByK_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.MinOperationsDivisibleByK(new[] { 3, 9, 7 }, 5));
            Assert.AreEqual(0, numeric.MinOperationsDivisibleByK(new[] { 4, 1, 3 }, 4));
        }

        [TestMethod]
        public void FindClosest_ExamplesAndEdges()
        {
            Assert.AreEqual(1, numeric.FindClosest(2, 7, 4));
            Assert.AreEqual(2, numeric.FindClosest(2, 5, 6));
            Assert.AreEqual(0, numeric.FindClosest(1, 5, 3));
        }

        [TestMethod]
        public void MaxProduct_ExamplesAndEdges()
        {
            Assert.AreEqual(81, numeric.MaxProduct(99));
            Assert.AreEqual(8, numeric.MaxProduct(124));
            Assert.AreEqual(0, numeric.MaxProduct(100));
        }

        [TestMethod]
        public void ConcatHex36_ExamplesAndEdges()
        {
            Assert.AreEqual("A91P1", numeric.ConcatHex36(13));
            Assert.AreEqual("5101000", numeric.ConcatHex36(36));
        }

        [TestMethod]
        public void CountNoZeroPairs_ExamplesAndEdges()
        {
            Assert.AreEqual(1L, numeric.CountNoZeroPairs(2));
            Assert.AreEqual(8L, numeric.CountNoZeroPairs(11));
            Assert.AreEqual(BruteCountNoZeroPairs(105), numeric.CountNoZeroPairs(105));
        }

        [TestMethod]
        public void MaxSumOfSquares_ExamplesAndEdges()
        {
            Assert.AreEqual("30", numeric.MaxSumOfSquares(2, 3));
            Assert.AreEqual("990", numeric.MaxSumOfSquares(3, 18));
            Assert.AreEqual(string.Empty, numeric.MaxSumOfSquares(2, 19));
        }

        [TestMethod]
        public void RemoveZeros_ExamplesAndEdges()
        {
            Assert.AreEqual(123L, numeric.RemoveZeros(1020030));
            Assert.AreEqual(1L, numeric.RemoveZeros(1));
            Assert.AreEqual(1L, numeric.RemoveZeros(1000));
        }

        [TestMethod]
        public void CountDistinct_ExamplesAndEdges()
        {
            Assert.AreEqual(9L, numeric.CountDistinct(10));
            Assert.AreEqual(3L, numeric.CountDistinct(3));
            Assert.AreEqual(BruteCountDistinct(105), numeric.CountDistinct(105));
        }

        [TestMethod]
        public void MinimumFlips_ExamplesAndEdges()
        {
            Assert.AreEqual(0, numeric.MinimumFlips(7));
            Assert.AreEqual(4, numeric.MinimumFlips(10));
            Assert.AreEqual(2, numeric.MinimumFlips(13));
        }

        [TestMethod]
        public void TotalWavinessInt_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.TotalWaviness(120, 130));
            Assert.AreEqual(0, numeric.TotalWaviness(1, 99));
            Assert.AreEqual((int)BruteTotalWaviness(98, 130), numeric.TotalWaviness(98, 130));
        }

        [TestMethod]
        public void TotalWavinessLong_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.TotalWaviness(120L, 130L));
            Assert.AreEqual(1L, numeric.TotalWaviness(121L, 121L));
            Assert.AreEqual(BruteTotalWaviness(100, 150), numeric.TotalWaviness(100L, 150L));
        }

        [TestMethod]
        public void SumAndMultiply_ExamplesAndEdges()
        {
            Assert.AreEqual(12340L, numeric.SumAndMultiply(10203004));
            Assert.AreEqual(1L, numeric.SumAndMultiply(1000));
            Assert.AreEqual(0L, numeric.SumAndMultiply(0));
        }

        [TestMethod]
        public void CompletePrime_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.CompletePrime(23));
            Assert.IsFalse(numeric.CompletePrime(39));
            Assert.IsTrue(numeric.CompletePrime(2));
        }

        [TestMethod]
        public void LastInteger_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.LastInteger(8));
            Assert.AreEqual(1L, numeric.LastInteger(1));
            Assert.AreEqual(BruteLastInteger(25), numeric.LastInteger(25));
        }

        [TestMethod]
        public void MirrorDistance_ExamplesAndEdges()
        {
            Assert.AreEqual(27, numeric.MirrorDistance(25));
            Assert.AreEqual(9, numeric.MirrorDistance(10));
            Assert.AreEqual(0, numeric.MirrorDistance(7));
        }

        [TestMethod]
        public void MinimumCost_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.MinimumCost(3, 2, 1, 3, 2));
            Assert.AreEqual(13L, numeric.MinimumCost(3, 2, 10, 3, 2));
            Assert.AreEqual(15L, numeric.MinimumCost(10, 1, 5, 3, 0));
        }

        [TestMethod]
        public void MinAllOneMultiple_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinAllOneMultiple(3));
            Assert.AreEqual(6, numeric.MinAllOneMultiple(7));
            Assert.AreEqual(-1, numeric.MinAllOneMultiple(2));
        }

        [TestMethod]
        public void NthSmallest_ExamplesAndEdges()
        {
            Assert.AreEqual(9L, numeric.NthSmallest(4, 2));
            Assert.AreEqual(4L, numeric.NthSmallest(3, 1));
            Assert.AreEqual(12L, numeric.NthSmallest(6, 2));
        }

        [TestMethod]
        public void CountMonobit_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountMonobit(1));
            Assert.AreEqual(3, numeric.CountMonobit(4));
            Assert.AreEqual(1, numeric.CountMonobit(0));
        }

        [TestMethod]
        public void IsDigitorialPermutation_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.IsDigitorialPermutation(145));
            Assert.IsFalse(numeric.IsDigitorialPermutation(10));
            Assert.IsTrue(numeric.IsDigitorialPermutation(40585));
        }

        [TestMethod]
        public void SumOfNumbers_ExamplesAndEdges()
        {
            Assert.AreEqual(66, numeric.SumOfNumbers(1, 2, 2));
            Assert.AreEqual(444, numeric.SumOfNumbers(0, 1, 3));
            Assert.AreEqual(555555520, numeric.SumOfNumbers(5, 5, 10));
        }

        [TestMethod]
        public void MinCostSplitIntoOnes_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinCost(3));
            Assert.AreEqual(6, numeric.MinCost(4));
            Assert.AreEqual(0, numeric.MinCost(1));
        }

        [TestMethod]
        public void CountFancy_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.CountFancy(8, 10));
            Assert.AreEqual(1L, numeric.CountFancy(12340, 12341));
            Assert.AreEqual(BruteCountFancy(1, 250), numeric.CountFancy(1, 250));
        }

        [TestMethod]
        public void CountCommasInt_ExamplesAndEdges()
        {
            Assert.AreEqual(0, numeric.CountCommas(999));
            Assert.AreEqual(1, numeric.CountCommas(1000));
            Assert.AreEqual(235, numeric.CountCommas(1234));
        }

        [TestMethod]
        public void CountCommasLong_ExamplesAndEdges()
        {
            Assert.AreEqual(1L, numeric.CountCommas(1000L));
            Assert.AreEqual(999002L, numeric.CountCommas(1_000_000L));
            Assert.AreEqual(235L, numeric.CountCommas(1234L));
        }

        [TestMethod]
        public void CountVisiblePeople_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountVisiblePeople(3, 1, 0));
            Assert.AreEqual(4, numeric.CountVisiblePeople(3, 2, 1));
            Assert.AreEqual(2, numeric.CountVisiblePeople(1, 0, 0));
        }

        [TestMethod]
        public void FindGoodIntegers_ExamplesAndEdges()
        {
            CollectionAssert.AreEqual(new[] { 1729, 4104 }, numeric.FindGoodIntegers(4104).ToArray());
            CollectionAssert.AreEqual(Array.Empty<int>(), numeric.FindGoodIntegers(578).ToArray());
        }

        [TestMethod]
        public void TrafficSignal_ExamplesAndEdges()
        {
            Assert.AreEqual("Red", numeric.TrafficSignal(60));
            Assert.AreEqual("Orange", numeric.TrafficSignal(30));
            Assert.AreEqual("Invalid", numeric.TrafficSignal(5));
            Assert.AreEqual("Green", numeric.TrafficSignal(0));
        }

        [TestMethod]
        public void ValidDigit_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.ValidDigit(101, 0));
            Assert.IsFalse(numeric.ValidDigit(232, 2));
            Assert.IsFalse(numeric.ValidDigit(5, 1));
            Assert.IsFalse(numeric.ValidDigit(0, 0));
        }

        [TestMethod]
        public void SumOfPrimesInRange_ExamplesAndEdges()
        {
            Assert.AreEqual(132, numeric.SumOfPrimesInRange(13));
            Assert.AreEqual(17, numeric.SumOfPrimesInRange(10));
            Assert.AreEqual(0, numeric.SumOfPrimesInRange(8));
        }

        [TestMethod]
        public void CountKthRoots_ExamplesAndEdges()
        {
            Assert.AreEqual(2, numeric.CountKthRoots(1, 9, 3));
            Assert.AreEqual(3, numeric.CountKthRoots(8, 30, 2));
            Assert.AreEqual(1, numeric.CountKthRoots(0, 0, 5));
        }

        [TestMethod]
        public void DigitFrequencyScore_ExamplesAndEdges()
        {
            Assert.AreEqual(5, numeric.DigitFrequencyScore(122));
            Assert.AreEqual(2, numeric.DigitFrequencyScore(101));
            Assert.AreEqual(36, numeric.DigitFrequencyScore(9999));
        }

        [TestMethod]
        public void ConsecutiveSetBits_ExamplesAndEdges()
        {
            Assert.IsTrue(numeric.ConsecutiveSetBits(6));
            Assert.IsFalse(numeric.ConsecutiveSetBits(5));
            Assert.IsFalse(numeric.ConsecutiveSetBits(7));
        }

        [TestMethod]
        public void SumOfGoodIntegers_ExamplesAndEdges()
        {
            Assert.AreEqual(10, numeric.SumOfGoodIntegers(2, 3));
            Assert.AreEqual(0, numeric.SumOfGoodIntegers(5, 1));
            Assert.AreEqual(30, numeric.SumOfGoodIntegers(1, 10));
        }

        [TestMethod]
        public void CheckGoodInteger_ExamplesAndEdges()
        {
            Assert.IsFalse(numeric.CheckGoodInteger(1000));
            Assert.IsTrue(numeric.CheckGoodInteger(19));
            Assert.IsTrue(numeric.CheckGoodInteger(68));
        }

        [TestMethod]
        public void GoodIntegers_ExamplesAndEdges()
        {
            Assert.AreEqual(3L, numeric.GoodIntegers(10, 15, 1));
            Assert.AreEqual(2L, numeric.GoodIntegers(201, 204, 2));
            Assert.AreEqual(BruteCountGoodIntegers(10, 200, 2), numeric.GoodIntegers(10, 200, 2));
        }

        [TestMethod]
        public void SecondsBetweenTimes_ExamplesAndEdges()
        {
            Assert.AreEqual(25, numeric.SecondsBetweenTimes("01:00:00", "01:00:25"));
            Assert.AreEqual(1504, numeric.SecondsBetweenTimes("12:34:56", "13:00:00"));
            Assert.AreEqual(0, numeric.SecondsBetweenTimes("00:00:00", "00:00:00"));
        }

        [TestMethod]
        public void MaximumValue_ExamplesAndEdges()
        {
            Assert.AreEqual(12L, numeric.MaximumValue(4, 3, 5));
            Assert.AreEqual(7L, numeric.MaximumValue(2, 4, 3));
            Assert.AreEqual(9L, numeric.MaximumValue(1, 9, 100));
        }

        [TestMethod]
        public void LargestInteger_ExamplesAndEdges()
        {
            Assert.AreEqual(90, numeric.LargestInteger(2, 9));
            Assert.AreEqual(-1, numeric.LargestInteger(2, 19));
            Assert.AreEqual(0, numeric.LargestInteger(5, 0));
            Assert.AreEqual(992, numeric.LargestInteger(3, 20));
        }

        [TestMethod]
        public void CountValidSequences_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.CountValidSequences(5, 3));
            Assert.AreEqual(2, numeric.CountValidSequences(3, 2));
            Assert.AreEqual(0, numeric.CountValidSequences(5, 5));
        }

        [TestMethod]
        public void KthDigit_ExamplesAndEdges()
        {
            Assert.AreEqual(4, numeric.KthDigit(4));
            Assert.AreEqual(7, numeric.KthDigit(15));
            Assert.AreEqual(9, numeric.KthDigit(11));
            Assert.AreEqual(ExpectedKthDigit(40), numeric.KthDigit(40));
        }

        [TestMethod]
        public void MinDays_ExamplesAndEdges()
        {
            Assert.AreEqual(3, numeric.MinDays(2));
            Assert.AreEqual(6, numeric.MinDays(9));
            Assert.AreEqual(7, numeric.MinDays(12));
            Assert.AreEqual(1, numeric.MinDays(1));
        }

        private static long BruteCountNoZeroPairs(long n)
        {
            long count = 0;
            for (long left = 1; left < n; left++)
            {
                if (!HasZero(left) && !HasZero(n - left))
                    count++;
            }

            return count;
        }

        private static long BruteCountDistinct(long n)
        {
            var seen = new HashSet<long>();
            for (long value = 1; value <= n; value++)
                seen.Add(RemoveZeros(value));

            return seen.Count;
        }

        private static long BruteTotalWaviness(long left, long right)
        {
            long total = 0;
            for (long value = left; value <= right; value++)
                total += Waviness(value);

            return total;
        }

        private static long BruteLastInteger(long n)
        {
            var values = Enumerable.Range(1, (int)n).Select(value => (long)value).ToList();
            bool fromLeft = true;
            while (values.Count > 1)
            {
                var next = new List<long>();
                if (fromLeft)
                {
                    for (int i = 0; i < values.Count; i += 2)
                        next.Add(values[i]);
                }
                else
                {
                    int parity = values.Count % 2 == 0 ? 1 : 0;
                    for (int i = parity; i < values.Count; i += 2)
                        next.Add(values[i]);
                }

                values = next;
                fromLeft = !fromLeft;
            }

            return values[0];
        }

        private static long BruteCountFancy(long left, long right)
        {
            long count = 0;
            for (long value = left; value <= right; value++)
            {
                if (IsStrictMonotone(value) || IsStrictMonotone(DigitSum(value)))
                    count++;
            }

            return count;
        }

        private static long BruteCountGoodIntegers(long left, long right, int k)
        {
            long count = 0;
            for (long value = left; value <= right; value++)
            {
                string digits = value.ToString();
                bool good = true;
                for (int i = 1; i < digits.Length; i++)
                {
                    if (Math.Abs(digits[i] - digits[i - 1]) > k)
                    {
                        good = false;
                        break;
                    }
                }

                if (good)
                    count++;
            }

            return count;
        }

        private static int ExpectedKthDigit(int k)
        {
            var builder = new StringBuilder();
            builder.Append("123456789");
            for (int block = 1; builder.Length < k + 20; block++)
            {
                if ((block & 1) == 0)
                {
                    for (int value = block * 10; value < block * 10 + 10; value++)
                        builder.Append(value);
                }
                else
                {
                    for (int value = block * 10 + 9; value >= block * 10; value--)
                        builder.Append(value);
                }
            }

            return builder[k - 1] - '0';
        }

        private static bool HasZero(long value)
        {
            while (value > 0)
            {
                if (value % 10 == 0)
                    return true;
                value /= 10;
            }

            return false;
        }

        private static long RemoveZeros(long value)
        {
            long result = 0;
            long place = 1;
            while (value > 0)
            {
                long digit = value % 10;
                if (digit != 0)
                {
                    result += digit * place;
                    place *= 10;
                }

                value /= 10;
            }

            return result;
        }

        private static int Waviness(long value)
        {
            string digits = value.ToString();
            int result = 0;
            for (int i = 1; i + 1 < digits.Length; i++)
            {
                if ((digits[i] > digits[i - 1] && digits[i] > digits[i + 1]) ||
                    (digits[i] < digits[i - 1] && digits[i] < digits[i + 1]))
                    result++;
            }

            return result;
        }

        private static bool IsStrictMonotone(long value)
        {
            if (value < 10)
                return value > 0;

            string digits = value.ToString();
            bool increasing = true;
            bool decreasing = true;
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] <= digits[i - 1])
                    increasing = false;
                if (digits[i] >= digits[i - 1])
                    decreasing = false;
            }

            return increasing || decreasing;
        }

        private static int DigitSum(long value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += (int)(value % 10);
                value /= 10;
            }

            return sum;
        }
    }
}