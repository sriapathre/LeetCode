﻿using LeetCode.Library;
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
    }
}