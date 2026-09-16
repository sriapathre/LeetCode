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

        [TestMethod]
        public void IsPalindrome_Test1()
        {
            Assert.IsTrue(strings.IsPalindrome("A man, a plan, a canal: Panama"));
        }

        [TestMethod]
        public void IsPalindrome_Test2()
        {
            Assert.IsFalse(strings.IsPalindrome("race a car"));
        }

        [TestMethod]
        public void IsPalindrome_Test3()
        {
            Assert.IsTrue(strings.IsPalindrome(" "));
        }

        [TestMethod]
        public void LengthOfLongestSubstring_Test1()
        {
            var expectedResult = 3;
            var actualResult = strings.LengthOfLongestSubstring("abcabcbb");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LengthOfLongestSubstring_Test2()
        {
            var expectedResult = 1;
            var actualResult = strings.LengthOfLongestSubstring("bbbbb");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LengthOfLongestSubstring_Test3()
        {
            var expectedResult = 3;
            var actualResult = strings.LengthOfLongestSubstring("pwwkew");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MinWindow_Test1()
        {
            var expectedResult = "BANC";
            var actualResult = strings.MinWindow("ADOBECODEBANC", "ABC");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MinWindow_Test2()
        {
            var expectedResult = "a";
            var actualResult = strings.MinWindow("a", "a");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MinWindow_Test3()
        {
            var expectedResult = "";
            var actualResult = strings.MinWindow("a", "aa");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckInclusion_Test1()
        {
            var expectedResult = true;
            var actualResult = strings.CheckInclusion("ab", "eidbaooo");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckInclusion_Test2()
        {
            var expectedResult = false;
            var actualResult = strings.CheckInclusion("ab", "eidboaoo");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindAnagrams_Test1()
        {
            var expectedResult = new[] { 0, 6 };
            var actualResult = strings.FindAnagrams("cbaebabacd", "abc");
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; i++)
                Assert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void FindAnagrams_Test2()
        {
            var expectedResult = new[] { 0, 1, 2 };
            var actualResult = strings.FindAnagrams("abab", "ab");
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; i++)
                Assert.AreEqual(expectedResult[i], actualResult[i]);
        }

        [TestMethod]
        public void LongestPalindrome_Test1()
        {
            var actualResult = strings.LongestPalindrome("babad");
            Assert.IsTrue(actualResult == "bab" || actualResult == "aba");
        }

        [TestMethod]
        public void LongestPalindrome_Test2()
        {
            Assert.AreEqual("bb", strings.LongestPalindrome("cbbd"));
        }

        [TestMethod]
        public void LongestPalindrome_Test3()
        {
            Assert.AreEqual("a", strings.LongestPalindrome("a"));
        }

        [TestMethod]
        public void Convert_Test1()
        {
            Assert.AreEqual("PAHNAPLSIIGYIR", strings.Convert("PAYPALISHIRING", 3));
        }

        [TestMethod]
        public void Convert_Test2()
        {
            Assert.AreEqual("PINALSIGYAHRPI", strings.Convert("PAYPALISHIRING", 4));
        }

        [TestMethod]
        public void Convert_Test3()
        {
            Assert.AreEqual("A", strings.Convert("A", 1));
        }

        [TestMethod]
        public void MyAtoi_Test1()
        {
            Assert.AreEqual(42, strings.MyAtoi("42"));
        }

        [TestMethod]
        public void MyAtoi_Test2()
        {
            Assert.AreEqual(-42, strings.MyAtoi("   -42"));
        }

        [TestMethod]
        public void MyAtoi_Test3()
        {
            Assert.AreEqual(4193, strings.MyAtoi("4193 with words"));
        }

        [TestMethod]
        public void MyAtoi_Test4()
        {
            Assert.AreEqual(0, strings.MyAtoi("words and 987"));
        }

        [TestMethod]
        public void MyAtoi_Test5_Overflow()
        {
            Assert.AreEqual(int.MaxValue, strings.MyAtoi("91283472332"));
        }

        [TestMethod]
        public void IsMatchRegex_Test1()
        {
            Assert.IsFalse(strings.IsMatchRegex("aa", "a"));
        }

        [TestMethod]
        public void IsMatchRegex_Test2()
        {
            Assert.IsTrue(strings.IsMatchRegex("aa", "a*"));
        }

        [TestMethod]
        public void IsMatchRegex_Test3()
        {
            Assert.IsTrue(strings.IsMatchRegex("ab", ".*"));
        }

        [TestMethod]
        public void IsMatchRegex_Test4()
        {
            Assert.IsFalse(strings.IsMatchRegex("mississippi", "mis*is*p*."));
        }

        [TestMethod]
        public void IntToRoman_Test1()
        {
            Assert.AreEqual("III", strings.IntToRoman(3));
        }

        [TestMethod]
        public void IntToRoman_Test2()
        {
            Assert.AreEqual("LVIII", strings.IntToRoman(58));
        }

        [TestMethod]
        public void IntToRoman_Test3()
        {
            Assert.AreEqual("MCMXCIV", strings.IntToRoman(1994));
        }

        [TestMethod]
        public void LetterCombinations_Test1()
        {
            var expected = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            var actual = strings.LetterCombinations("23");
            CollectionAssert.AreEquivalent(expected, new List<string>(actual));
        }

        [TestMethod]
        public void LetterCombinations_Test2()
        {
            var actual = strings.LetterCombinations("");
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void LetterCombinations_Test3()
        {
            var actual = strings.LetterCombinations("2");
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, new List<string>(actual));
        }

        [TestMethod]
        public void GenerateParenthesis_Test1()
        {
            var expected = new[] { "((()))", "(()())", "(())()", "()(())", "()()()" };
            var actual = strings.GenerateParenthesis(3);
            CollectionAssert.AreEquivalent(expected, new List<string>(actual));
        }

        [TestMethod]
        public void GenerateParenthesis_Test2()
        {
            var actual = strings.GenerateParenthesis(1);
            CollectionAssert.AreEquivalent(new[] { "()" }, new List<string>(actual));
        }

        [TestMethod]
        public void FindSubstring_Test1()
        {
            var expected = new[] { 0, 9 };
            var actual = strings.FindSubstring("barfoothefoobarman", new[] { "foo", "bar" });
            CollectionAssert.AreEquivalent(expected, new List<int>(actual));
        }

        [TestMethod]
        public void FindSubstring_Test2()
        {
            var actual = strings.FindSubstring("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "word" });
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void FindSubstring_Test3()
        {
            var expected = new[] { 6, 9, 12 };
            var actual = strings.FindSubstring("barfoofoobarthefoobarman", new[] { "bar", "foo", "the" });
            CollectionAssert.AreEquivalent(expected, new List<int>(actual));
        }

        [TestMethod]
        public void LongestValidParentheses_Test1()
        {
            Assert.AreEqual(2, strings.LongestValidParentheses("(()"));
        }

        [TestMethod]
        public void LongestValidParentheses_Test2()
        {
            Assert.AreEqual(4, strings.LongestValidParentheses(")()())"));
        }

        [TestMethod]
        public void LongestValidParentheses_Test3()
        {
            Assert.AreEqual(0, strings.LongestValidParentheses(""));
        }

        [TestMethod]
        public void CountAndSay_Test1()
        {
            Assert.AreEqual("1", strings.CountAndSay(1));
        }

        [TestMethod]
        public void CountAndSay_Test2()
        {
            Assert.AreEqual("1211", strings.CountAndSay(4));
        }

        [TestMethod]
        public void CountAndSay_Test3()
        {
            Assert.AreEqual("111221", strings.CountAndSay(5));
        }

        [TestMethod]
        public void Multiply_Test1()
        {
            Assert.AreEqual("6", strings.Multiply("2", "3"));
        }

        [TestMethod]
        public void Multiply_Test2()
        {
            Assert.AreEqual("56088", strings.Multiply("123", "456"));
        }

        [TestMethod]
        public void Multiply_Test3()
        {
            Assert.AreEqual("0", strings.Multiply("0", "12345"));
        }

        [TestMethod]
        public void IsMatchWildcard_Test1()
        {
            Assert.IsFalse(strings.IsMatchWildcard("aa", "a"));
        }

        [TestMethod]
        public void IsMatchWildcard_Test2()
        {
            Assert.IsTrue(strings.IsMatchWildcard("aa", "*"));
        }

        [TestMethod]
        public void IsMatchWildcard_Test3()
        {
            Assert.IsFalse(strings.IsMatchWildcard("cb", "?a"));
        }

        [TestMethod]
        public void IsNumber_Test1()
        {
            Assert.IsTrue(strings.IsNumber("0"));
        }

        [TestMethod]
        public void IsNumber_Test2()
        {
            Assert.IsFalse(strings.IsNumber("e"));
        }

        [TestMethod]
        public void IsNumber_Test3()
        {
            Assert.IsTrue(strings.IsNumber("2e10"));
        }

        [TestMethod]
        public void IsNumber_Test4()
        {
            Assert.IsFalse(strings.IsNumber("99e2.5"));
        }

        [TestMethod]
        public void IsNumber_Test5()
        {
            Assert.IsTrue(strings.IsNumber("-90E3"));
        }

        [TestMethod]
        public void FullJustify_Test1()
        {
            var expected = new[] { "This    is    an", "example  of text", "justification.  " };
            var actual = strings.FullJustify(new[] { "This", "is", "an", "example", "of", "text", "justification." }, 16);
            CollectionAssert.AreEqual(expected, new List<string>(actual));
        }

        [TestMethod]
        public void FullJustify_Test2()
        {
            var expected = new[] { "What   must   be", "acknowledgment  ", "shall be        " };
            var actual = strings.FullJustify(new[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16);
            CollectionAssert.AreEqual(expected, new List<string>(actual));
        }

        [TestMethod]
        public void SimplifyPath_Test1()
        {
            Assert.AreEqual("/home", strings.SimplifyPath("/home/"));
        }

        [TestMethod]
        public void SimplifyPath_Test2()
        {
            Assert.AreEqual("/", strings.SimplifyPath("/../"));
        }

        [TestMethod]
        public void SimplifyPath_Test3()
        {
            Assert.AreEqual("/c", strings.SimplifyPath("/a/./b/../../c/"));
        }

        [TestMethod]
        public void MinDistance_Test1()
        {
            Assert.AreEqual(3, strings.MinDistance("horse", "ros"));
        }

        [TestMethod]
        public void MinDistance_Test2()
        {
            Assert.AreEqual(5, strings.MinDistance("intention", "execution"));
        }

        [TestMethod]
        public void MinDistance_Test3()
        {
            Assert.AreEqual(0, strings.MinDistance("", ""));
        }

        [TestMethod]
        public void IsScramble_Test1()
        {
            Assert.IsTrue(strings.IsScramble("great", "rgeat"));
        }

        [TestMethod]
        public void IsScramble_Test2()
        {
            Assert.IsFalse(strings.IsScramble("abcde", "caebd"));
        }

        [TestMethod]
        public void IsScramble_Test3()
        {
            Assert.IsTrue(strings.IsScramble("a", "a"));
        }

        [TestMethod]
        public void NumDecodings_Test1()
        {
            Assert.AreEqual(2, strings.NumDecodings("12"));
        }

        [TestMethod]
        public void NumDecodings_Test2()
        {
            Assert.AreEqual(3, strings.NumDecodings("226"));
        }

        [TestMethod]
        public void NumDecodings_Test3()
        {
            Assert.AreEqual(0, strings.NumDecodings("06"));
        }

        [TestMethod]
        public void RestoreIpAddresses_Test1()
        {
            var expected = new[] { "255.255.11.135", "255.255.111.35" };
            var actual = strings.RestoreIpAddresses("25525511135");
            CollectionAssert.AreEquivalent(expected, new List<string>(actual));
        }

        [TestMethod]
        public void RestoreIpAddresses_Test2()
        {
            var actual = strings.RestoreIpAddresses("0000");
            CollectionAssert.AreEquivalent(new[] { "0.0.0.0" }, new List<string>(actual));
        }

        [TestMethod]
        public void RestoreIpAddresses_Test3()
        {
            var expected = new[] { "1.1.1.1" };
            var actual = strings.RestoreIpAddresses("1111");
            CollectionAssert.AreEquivalent(expected, new List<string>(actual));
        }

        [TestMethod]
        public void IsInterleave_Test1()
        {
            Assert.IsTrue(strings.IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
        }

        [TestMethod]
        public void IsInterleave_Test2()
        {
            Assert.IsFalse(strings.IsInterleave("aabcc", "dbbca", "aadbbbaccc"));
        }

        [TestMethod]
        public void IsInterleave_Test3()
        {
            Assert.IsTrue(strings.IsInterleave("", "", ""));
        }
    }
}
