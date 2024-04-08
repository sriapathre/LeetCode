using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.UnitTests
{
    [TestClass]
    public class StringsTests
    {
        Strings strings;
        [TestInitialize]
        public void Setup()
        {
            strings = new Strings();
        }

        [TestMethod]
        public void IsIsomorphic_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.IsIsomorphic("egg", "add");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsIsomorphic_Test2()
        {
            var expectedResult = false;
            var actualResult = strings.IsIsomorphic("badc", "baba");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsIsomorphic_Test3()
        {
            var expectedResult = true;
            var actualResult = strings.IsIsomorphic("paper", "title");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WordPattern_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.WordPattern("abba", "dog cat cat dog");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WordPattern_Test2()
        {
            var expectedResult = false;
            var actualResult = strings.WordPattern("abda", "dog cat cat fish");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WordPattern_Test3()
        {
            var expectedResult = false;
            var actualResult = strings.WordPattern("aaaa", "dog cat cat dog");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReverseString_Test1()
        {
            var expectedResult = ("olleh").ToCharArray();
            var input = ("hello").ToCharArray();
            strings.ReverseString(input);
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void ReverseString_Test2()
        {
            var expectedResult = ("madamb").ToCharArray();
            var input = ("bmadam").ToCharArray();
            strings.ReverseString(input);
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void ReverseString_Test3()
        {
            var expectedResult = ("hannaH").ToCharArray();
            var input = ("Hannah").ToCharArray();
            strings.ReverseString(input);
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void CanConstruct_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.CanConstruct("aa", "aab");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanConstruct_Test2()
        {
            var expectedResult = true;
            var actualResult = strings.CanConstruct("ba", "aab");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanConstruct_Test3()
        {
            var expectedResult = false;
            var actualResult = strings.CanConstruct("a", "b");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FirstUniqChar_Test1()
        {
            var expectedResult = 0;
            var actualResult = strings.FirstUniqChar("leetcode");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FirstUniqChar_Test2()
        {
            var expectedResult = 2;
            var actualResult = strings.FirstUniqChar("loveleetcode");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FirstUniqChar_Test3()
        {
            var expectedResult = -1;
            var actualResult = strings.FirstUniqChar("aabbcc");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindTheDifference_Test1()
        {
            var expectedResult = 'e';
            var actualResult = strings.FindTheDifference("abcd", "abcde");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindTheDifference_Test2()
        {
            var expectedResult = 'y';
            var actualResult = strings.FindTheDifference("a", "ay");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindTheDifference_Test3()
        {
            var expectedResult = 'a';
            var actualResult = strings.FindTheDifference("ae", "aea");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddStrings_Test1()
        {
            var expectedResult = "1";
            var actualResult = strings.AddStrings("1", "0");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddStrings_Test2()
        {
            var expectedResult = "10";
            var actualResult = strings.AddStrings("9", "1");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddStrings_Test3()
        {
            var expectedResult = "10000000000000000000000000000000000000000000000000000000000010";
            var actualResult = strings.AddStrings("10000000000000000000000000000000000000000000000000000000000009", "1");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TitleToNumber_Test1()
        {
            var expectedResult = 1;
            var actualResult = strings.TitleToNumber("A");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TitleToNumber_Test2()
        {
            var expectedResult = 28;
            var actualResult = strings.TitleToNumber("AB");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TitleToNumber_Test3()
        {
            var expectedResult = 701;
            var actualResult = strings.TitleToNumber("ZY");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsAnagram_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.IsAnagram("anagram", "nagaram");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsAnagram_Test2()
        {
            var expectedResult = false;
            var actualResult = strings.IsAnagram("rat", "car");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsAnagram_Test3()
        {
            var expectedResult = false;
            var actualResult = strings.IsAnagram("aacc", "ccac");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RomanToInt_Test1()
        {
            var expectedResult = 3;
            var actualResult = strings.RomanToInt("III");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RomanToInt_Test2()
        {
            var expectedResult = 58;
            var actualResult = strings.RomanToInt("LVIII");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RomanToInt_Test3()
        {
            var expectedResult = 1994;
            var actualResult = strings.RomanToInt("MCMXCIV");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsValid_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.IsValid("()");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsValid_Test2()
        {
            var expectedResult = true;
            var actualResult = strings.IsValid("[()[]{}]");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsValid_Test3()
        {
            var expectedResult = false;
            var actualResult = strings.IsValid("(]");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StrStr_Test1()
        {
            var expectedResult = 2;
            var actualResult = strings.StrStr("hello", "ll");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StrStr_Test2()
        {
            var expectedResult = -1;
            var actualResult = strings.StrStr("aaaaa", "bba");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StrStr_Test3()
        {
            var expectedResult = 0;
            var actualResult = strings.StrStr("", "");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LengthOfLastWord_Test1()
        {
            var expectedResult = 5;
            var actualResult = strings.LengthOfLastWord("Hello World");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LengthOfLastWord_Test2()
        {
            var expectedResult = 4;
            var actualResult = strings.LengthOfLastWord("   fly me   to   the moon  ");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LengthOfLastWord_Test3()
        {
            var expectedResult = 0;
            var actualResult = strings.LengthOfLastWord(" ");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddBinary_Test1()
        {
            var expectedResult = "100";
            var actualResult = strings.AddBinary("11", "1");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddBinary_Test2()
        {
            var expectedResult = "10101";
            var actualResult = strings.AddBinary("1010", "1011");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddBinary_Test3()
        {
            var expectedResult = "110";
            var actualResult = strings.AddBinary("100", "10");
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
