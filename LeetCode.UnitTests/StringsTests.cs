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

        [TestMethod]
        public void NumDistinct_Test1()
        {
            Assert.AreEqual(3, strings.NumDistinct("rabbbit", "rabbit"));
        }

        [TestMethod]
        public void NumDistinct_Test2()
        {
            Assert.AreEqual(5, strings.NumDistinct("babgbag", "bag"));
        }

        [TestMethod]
        public void NumDistinct_Test3_EmptyTarget()
        {
            Assert.AreEqual(1, strings.NumDistinct("abc", ""));
        }

        [TestMethod]
        public void Partition_Test1()
        {
            var actual = strings.Partition("aab");
            AssertNestedEquivalent(new[] { "a|a|b", "aa|b" }, actual);
        }

        [TestMethod]
        public void Partition_Test2_SingleCharacter()
        {
            var actual = strings.Partition("a");
            AssertNestedEquivalent(new[] { "a" }, actual);
        }

        [TestMethod]
        public void Partition_Test3_AllPalindromicChoices()
        {
            var actual = strings.Partition("aaa");
            AssertNestedEquivalent(new[] { "a|a|a", "a|aa", "aa|a", "aaa" }, actual);
        }

        [TestMethod]
        public void MinCut_Test1()
        {
            Assert.AreEqual(1, strings.MinCut("aab"));
        }

        [TestMethod]
        public void MinCut_Test2_SingleCharacter()
        {
            Assert.AreEqual(0, strings.MinCut("a"));
        }

        [TestMethod]
        public void MinCut_Test3_NoCutNeeded()
        {
            Assert.AreEqual(0, strings.MinCut("abccba"));
        }

        [TestMethod]
        public void WordBreak_Test1()
        {
            Assert.IsTrue(strings.WordBreak("leetcode", new[] { "leet", "code" }));
        }

        [TestMethod]
        public void WordBreak_Test2()
        {
            Assert.IsTrue(strings.WordBreak("applepenapple", new[] { "apple", "pen" }));
        }

        [TestMethod]
        public void WordBreak_Test3_False()
        {
            Assert.IsFalse(strings.WordBreak("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }));
        }

        [TestMethod]
        public void WordBreakII_Test1()
        {
            var actual = strings.WordBreakII("catsanddog", new[] { "cat", "cats", "and", "sand", "dog" });
            CollectionAssert.AreEquivalent(new[] { "cats and dog", "cat sand dog" }, new List<string>(actual));
        }

        [TestMethod]
        public void WordBreakII_Test2()
        {
            var actual = strings.WordBreakII("pineapplepenapple", new[] { "apple", "pen", "applepen", "pine", "pineapple" });
            CollectionAssert.AreEquivalent(new[] { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" }, new List<string>(actual));
        }

        [TestMethod]
        public void WordBreakII_Test3_NoSentences()
        {
            var actual = strings.WordBreakII("catsandog", new[] { "cats", "dog", "sand", "and", "cat" });
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void ReverseWords_Test1()
        {
            Assert.AreEqual("blue is sky the", strings.ReverseWords("the sky is blue"));
        }

        [TestMethod]
        public void ReverseWords_Test2_TrimsAndCollapsesSpaces()
        {
            Assert.AreEqual("world hello", strings.ReverseWords("  hello world  "));
        }

        [TestMethod]
        public void ReverseWords_Test3_MultipleInnerSpaces()
        {
            Assert.AreEqual("example good a", strings.ReverseWords("a good   example"));
        }

        [TestMethod]
        public void CompareVersion_Test1()
        {
            Assert.AreEqual(0, strings.CompareVersion("1.01", "1.001"));
        }

        [TestMethod]
        public void CompareVersion_Test2_MissingRevisionsAreZero()
        {
            Assert.AreEqual(0, strings.CompareVersion("1.0", "1.0.0"));
        }

        [TestMethod]
        public void CompareVersion_Test3_GreaterRevision()
        {
            Assert.AreEqual(1, strings.CompareVersion("1.0.1", "1"));
        }

        [TestMethod]
        public void CompareVersion_Test4_LargeRevisionWithoutOverflow()
        {
            Assert.AreEqual(-1, strings.CompareVersion("1.999999999999999999", "1.1000000000000000000"));
        }

        [TestMethod]
        public void LargestNumber_Test1()
        {
            Assert.AreEqual("210", strings.LargestNumber(new[] { 10, 2 }));
        }

        [TestMethod]
        public void LargestNumber_Test2()
        {
            Assert.AreEqual("9534330", strings.LargestNumber(new[] { 3, 30, 34, 5, 9 }));
        }

        [TestMethod]
        public void LargestNumber_Test3_AllZeroes()
        {
            Assert.AreEqual("0", strings.LargestNumber(new[] { 0, 0 }));
        }

        [TestMethod]
        public void FindRepeatedDnaSequences_Test1()
        {
            var actual = strings.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
            CollectionAssert.AreEquivalent(new[] { "AAAAACCCCC", "CCCCCAAAAA" }, new List<string>(actual));
        }

        [TestMethod]
        public void FindRepeatedDnaSequences_Test2_OverlappingRepeat()
        {
            var actual = strings.FindRepeatedDnaSequences("AAAAAAAAAAAAA");
            CollectionAssert.AreEquivalent(new[] { "AAAAAAAAAA" }, new List<string>(actual));
        }

        [TestMethod]
        public void FindRepeatedDnaSequences_Test3_TooShort()
        {
            var actual = strings.FindRepeatedDnaSequences("ACGTACGTA");
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void ShortestPalindrome_ExamplesAndEdges()
        {
            Assert.AreEqual("aaacecaaa", strings.ShortestPalindrome("aacecaaa"));
            Assert.AreEqual("dcbabcd", strings.ShortestPalindrome("abcd"));
            Assert.AreEqual("", strings.ShortestPalindrome(""));
        }

        [TestMethod]
        public void Calculate_ExamplesAndPrecedence()
        {
            Assert.AreEqual(7, strings.Calculate("3+2*2"));
            Assert.AreEqual(1, strings.Calculate(" 3/2 "));
            Assert.AreEqual(5, strings.Calculate(" 3+5 / 2 "));
        }

        [TestMethod]
        public void NumberToWords_ExamplesAndEdges()
        {
            Assert.AreEqual("One Hundred Twenty Three", strings.NumberToWords(123));
            Assert.AreEqual("Twelve Thousand Three Hundred Forty Five", strings.NumberToWords(12345));
            Assert.AreEqual("Zero", strings.NumberToWords(0));
        }

        [TestMethod]
        public void RemoveDuplicateLetters_ExamplesAndEdges()
        {
            Assert.AreEqual("abc", strings.RemoveDuplicateLetters("bcabc"));
            Assert.AreEqual("acdb", strings.RemoveDuplicateLetters("cbacdcbc"));
            Assert.AreEqual("a", strings.RemoveDuplicateLetters("aaaa"));
        }

        [TestMethod]
        public void MaxProduct_ExamplesAndNoPair()
        {
            Assert.AreEqual(16, strings.MaxProduct(new[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" }));
            Assert.AreEqual(4, strings.MaxProduct(new[] { "a", "ab", "abc", "d", "cd", "bcd", "abcd" }));
            Assert.AreEqual(0, strings.MaxProduct(new[] { "a", "aa", "aaa", "aaaa" }));
        }

        [TestMethod]
        public void ReverseVowels_ExamplesAndNoVowels()
        {
            Assert.AreEqual("holle", strings.ReverseVowels("hello"));
            Assert.AreEqual("leotcede", strings.ReverseVowels("leetcode"));
            Assert.AreEqual("bcdf", strings.ReverseVowels("bcdf"));
        }

        [TestMethod]
        public void LengthLongestPath_ExamplesAndNoFile()
        {
            Assert.AreEqual(20, strings.LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
            Assert.AreEqual(32, strings.LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"));
            Assert.AreEqual(0, strings.LengthLongestPath("dir\n\tsubdir"));
        }

        [TestMethod]
        public void DecodeString_ExamplesAndNested()
        {
            Assert.AreEqual("aaabcbc", strings.DecodeString("3[a]2[bc]"));
            Assert.AreEqual("accaccacc", strings.DecodeString("3[a2[c]]"));
            Assert.AreEqual("abcabccdcdcdef", strings.DecodeString("2[abc]3[cd]ef"));
        }

        [TestMethod]
        public void RemoveKdigits_ExamplesAndAllRemoved()
        {
            Assert.AreEqual("1219", strings.RemoveKdigits("1432219", 3));
            Assert.AreEqual("200", strings.RemoveKdigits("10200", 1));
            Assert.AreEqual("0", strings.RemoveKdigits("10", 2));
        }

        [TestMethod]
        public void LongestPalindromeLength_ExamplesAndCaseSensitive()
        {
            Assert.AreEqual(7, strings.LongestPalindromeLength("abccccdd"));
            Assert.AreEqual(1, strings.LongestPalindromeLength("a"));
            Assert.AreEqual(1, strings.LongestPalindromeLength("Aa"));
        }

        [TestMethod]
        public void OriginalDigits_ExamplesAndAllDigits()
        {
            Assert.AreEqual("012", strings.OriginalDigits("owoztneoer"));
            Assert.AreEqual("45", strings.OriginalDigits("fviefuro"));
            Assert.AreEqual("0123456789", strings.OriginalDigits("zeroonetwothreefourfivesixseveneightnine"));
        }

        [TestMethod]
        public void CharacterReplacement_ExamplesAndNoReplacement()
        {
            Assert.AreEqual(4, strings.CharacterReplacement("ABAB", 2));
            Assert.AreEqual(4, strings.CharacterReplacement("AABABBA", 1));
            Assert.AreEqual(2, strings.CharacterReplacement("AABA", 0));
        }

        [TestMethod]
        public void CountSegments_ExamplesAndEmpty()
        {
            Assert.AreEqual(5, strings.CountSegments("Hello, my name is John"));
            Assert.AreEqual(1, strings.CountSegments("Hello"));
            Assert.AreEqual(0, strings.CountSegments("   "));
        }

        [TestMethod]
        public void RepeatedSubstringPattern_ExamplesAndSingle()
        {
            Assert.IsTrue(strings.RepeatedSubstringPattern("abab"));
            Assert.IsFalse(strings.RepeatedSubstringPattern("aba"));
            Assert.IsFalse(strings.RepeatedSubstringPattern("a"));
        }

        [TestMethod]
        public void ValidIPAddress_ExamplesAndInvalids()
        {
            Assert.AreEqual("IPv4", strings.ValidIPAddress("172.16.254.1"));
            Assert.AreEqual("IPv6", strings.ValidIPAddress("2001:0db8:85a3:0:0:8A2E:0370:7334"));
            Assert.AreEqual("Neither", strings.ValidIPAddress("256.256.256.256"));
        }

        [TestMethod]
        public void LicenseKeyFormatting_ExamplesAndOnlyDashes()
        {
            Assert.AreEqual("5F3Z-2E9W", strings.LicenseKeyFormatting("5F3Z-2e-9-w", 4));
            Assert.AreEqual("2-5G-3J", strings.LicenseKeyFormatting("2-5g-3-J", 2));
            Assert.AreEqual("", strings.LicenseKeyFormatting("---", 3));
        }

        [TestMethod]
        public void DetectCapitalUse_ExamplesAndEdges()
        {
            Assert.IsTrue(strings.DetectCapitalUse("USA"));
            Assert.IsFalse(strings.DetectCapitalUse("FlaG"));
            Assert.IsTrue(strings.DetectCapitalUse("leetcode"));
        }

        [TestMethod]
        public void FindLUSlengthI_ExamplesAndEqual()
        {
            Assert.AreEqual(3, strings.FindLUSlength("aba", "cdc"));
            Assert.AreEqual(-1, strings.FindLUSlength("aaa", "aaa"));
            Assert.AreEqual(4, strings.FindLUSlength("abcd", "ab"));
        }

        [TestMethod]
        public void FindLUSlengthII_ExamplesAndDuplicates()
        {
            Assert.AreEqual(3, strings.FindLUSlength(new[] { "aba", "cdc", "eae" }));
            Assert.AreEqual(-1, strings.FindLUSlength(new[] { "aaa", "aaa", "aa" }));
            Assert.AreEqual(2, strings.FindLUSlength(new[] { "aabbcc", "aabbcc", "cb", "abc" }));
        }

        [TestMethod]
        public void FindLongestWord_ExamplesAndTie()
        {
            Assert.AreEqual("apple", strings.FindLongestWord("abpcplea", new[] { "ale", "apple", "monkey", "plea" }));
            Assert.AreEqual("a", strings.FindLongestWord("abpcplea", new[] { "a", "b", "c" }));
            Assert.AreEqual("", strings.FindLongestWord("abpcplea", new[] { "x", "y" }));
        }

        [TestMethod]
        public void ComplexNumberMultiply_ExamplesAndNegative()
        {
            Assert.AreEqual("0+2i", strings.ComplexNumberMultiply("1+1i", "1+1i"));
            Assert.AreEqual("0+-2i", strings.ComplexNumberMultiply("1+-1i", "1+-1i"));
            Assert.AreEqual("-1+0i", strings.ComplexNumberMultiply("0+1i", "0+1i"));
        }

        [TestMethod]
        public void FindMinDifference_ExamplesAndDuplicate()
        {
            Assert.AreEqual(1, strings.FindMinDifference(new[] { "23:59", "00:00" }));
            Assert.AreEqual(0, strings.FindMinDifference(new[] { "00:00", "23:59", "00:00" }));
            Assert.AreEqual(60, strings.FindMinDifference(new[] { "01:00", "02:00", "04:00" }));
        }

        [TestMethod]
        public void ReverseStr_ExamplesAndShortTail()
        {
            Assert.AreEqual("bacdfeg", strings.ReverseStr("abcdefg", 2));
            Assert.AreEqual("bacd", strings.ReverseStr("abcd", 2));
            Assert.AreEqual("dcba", strings.ReverseStr("abcd", 4));
        }

        [TestMethod]
        public void CheckRecord_ExamplesAndLateRun()
        {
            Assert.IsTrue(strings.CheckRecord("PPALLP"));
            Assert.IsFalse(strings.CheckRecord("PPALLL"));
            Assert.IsFalse(strings.CheckRecord("PAPPA"));
        }

        [TestMethod]
        public void ReverseWordsIII_ExamplesAndSingle()
        {
            Assert.AreEqual("s'teL ekat edoCteeL tsetnoc", strings.ReverseWordsIII("Let's take LeetCode contest"));
            Assert.AreEqual("doG gniD", strings.ReverseWordsIII("God Ding"));
            Assert.AreEqual("a", strings.ReverseWordsIII("a"));
        }

        [TestMethod]
        public void ReplaceWords_ExamplesAndNoReplacement()
        {
            Assert.AreEqual("the cat was rat by the bat", strings.ReplaceWords(new[] { "cat", "bat", "rat" }, "the cattle was rattled by the battery"));
            Assert.AreEqual("a a b c", strings.ReplaceWords(new[] { "a", "aa", "aaa" }, "a aa b c"));
            Assert.AreEqual("unchanged words", strings.ReplaceWords(new[] { "cat" }, "unchanged words"));
        }

        [TestMethod]
        public void CountSubstrings_ExamplesAndEmpty()
        {
            Assert.AreEqual(3, strings.CountSubstrings("abc"));
            Assert.AreEqual(6, strings.CountSubstrings("aaa"));
            Assert.AreEqual(0, strings.CountSubstrings(""));
        }

        [TestMethod]
        public void JudgeCircle_ExamplesAndEdges()
        {
            Assert.IsTrue(strings.JudgeCircle("UD"));
            Assert.IsFalse(strings.JudgeCircle("LL"));
            Assert.IsTrue(strings.JudgeCircle(""));
        }

        [TestMethod]
        public void CheckValidString_ExamplesAndInvalid()
        {
            Assert.IsTrue(strings.CheckValidString("()"));
            Assert.IsTrue(strings.CheckValidString("(*)"));
            Assert.IsFalse(strings.CheckValidString("((*"));
        }

        [TestMethod]
        public void ValidPalindrome_ExamplesAndInvalid()
        {
            Assert.IsTrue(strings.ValidPalindrome("aba"));
            Assert.IsTrue(strings.ValidPalindrome("abca"));
            Assert.IsFalse(strings.ValidPalindrome("abc"));
        }

        [TestMethod]
        public void RepeatedStringMatch_ExamplesAndImpossible()
        {
            Assert.AreEqual(3, strings.RepeatedStringMatch("abcd", "cdabcdab"));
            Assert.AreEqual(2, strings.RepeatedStringMatch("a", "aa"));
            Assert.AreEqual(-1, strings.RepeatedStringMatch("abc", "wxyz"));
        }

        [TestMethod]
        public void CountBinarySubstrings_ExamplesAndSingleRun()
        {
            Assert.AreEqual(6, strings.CountBinarySubstrings("00110011"));
            Assert.AreEqual(4, strings.CountBinarySubstrings("10101"));
            Assert.AreEqual(0, strings.CountBinarySubstrings("1111"));
        }


        [TestMethod]
        public void ToLowerCase_ExamplesAndNonLetters()
        {
            Assert.AreEqual("hello", strings.ToLowerCase("Hello"));
            Assert.AreEqual("here", strings.ToLowerCase("here"));
            Assert.AreEqual("123!abc", strings.ToLowerCase("123!ABC"));
        }

        [TestMethod]
        public void NumJewelsInStones_ExamplesAndCaseSensitive()
        {
            Assert.AreEqual(3, strings.NumJewelsInStones("aA", "aAAbbbb"));
            Assert.AreEqual(0, strings.NumJewelsInStones("z", "ZZ"));
        }

        [TestMethod]
        public void RotateString_ExamplesAndEdges()
        {
            Assert.IsTrue(strings.RotateString("abcde", "cdeab"));
            Assert.IsFalse(strings.RotateString("abcde", "abced"));
            Assert.IsTrue(strings.RotateString("", ""));
        }

        [TestMethod]
        public void UniqueMorseRepresentations_ExamplesAndDuplicates()
        {
            Assert.AreEqual(2, strings.UniqueMorseRepresentations(new[] { "gin", "zen", "gig", "msg" }));
            Assert.AreEqual(1, strings.UniqueMorseRepresentations(new[] { "a", "a" }));
        }

        [TestMethod]
        public void MostCommonWord_ExamplesAndPunctuation()
        {
            Assert.AreEqual("ball", strings.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] { "hit" }));
            Assert.AreEqual("a", strings.MostCommonWord("a, a, a, b,b,c", new[] { "b" }));
        }

        [TestMethod]
        public void ShortestToChar_ExamplesAndTargetAtEdges()
        {
            CollectionAssert.AreEqual(new[] { 3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0 }, strings.ShortestToChar("loveleetcode", 'e'));
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 1, 0 }, strings.ShortestToChar("abxba", 'a'));
        }

        [TestMethod]
        public void ToGoatLatin_ExamplesAndVowels()
        {
            Assert.AreEqual("Imaa peaksmaaa oatGmaaaa atinLmaaaaa", strings.ToGoatLatin("I speak Goat Latin"));
            Assert.AreEqual("applemaa", strings.ToGoatLatin("apple"));
        }

        [TestMethod]
        public void LargeGroupPositions_ExamplesAndNoGroups()
        {
            AssertIntNestedEquivalent(new[] { "3,6" }, strings.LargeGroupPositions("abbxxxxzzy"));
            AssertIntNestedEquivalent(Array.Empty<string>(), strings.LargeGroupPositions("abc"));
        }

        [TestMethod]
        public void BackspaceCompare_ExamplesAndAllDeleted()
        {
            Assert.IsTrue(strings.BackspaceCompare("ab#c", "ad#c"));
            Assert.IsFalse(strings.BackspaceCompare("a#c", "b"));
            Assert.IsTrue(strings.BackspaceCompare("ab##", "c#d#"));
        }

        [TestMethod]
        public void BuddyStrings_ExamplesAndDuplicates()
        {
            Assert.IsTrue(strings.BuddyStrings("ab", "ba"));
            Assert.IsFalse(strings.BuddyStrings("ab", "ab"));
            Assert.IsTrue(strings.BuddyStrings("aa", "aa"));
        }

        [TestMethod]
        public void UncommonFromSentences_ExamplesAndRepeats()
        {
            CollectionAssert.AreEquivalent(new[] { "sweet", "sour" }, strings.UncommonFromSentences("this apple is sweet", "this apple is sour"));
            CollectionAssert.AreEquivalent(new[] { "banana" }, strings.UncommonFromSentences("apple apple", "banana"));
        }

        [TestMethod]
        public void ReverseOnlyLetters_ExamplesAndSymbols()
        {
            Assert.AreEqual("dc-ba", strings.ReverseOnlyLetters("ab-cd"));
            Assert.AreEqual("j-Ih-gfE-dCba", strings.ReverseOnlyLetters("a-bC-dEf-ghIj"));
            Assert.AreEqual("123", strings.ReverseOnlyLetters("123"));
        }

        [TestMethod]
        public void IsLongPressedName_ExamplesAndInvalid()
        {
            Assert.IsTrue(strings.IsLongPressedName("alex", "aaleex"));
            Assert.IsFalse(strings.IsLongPressedName("saeed", "ssaaedd"));
            Assert.IsFalse(strings.IsLongPressedName("alex", "alexxr"));
        }

        [TestMethod]
        public void NumUniqueEmails_ExamplesAndDuplicates()
        {
            Assert.AreEqual(2, strings.NumUniqueEmails(new[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }));
            Assert.AreEqual(1, strings.NumUniqueEmails(new[] { "a@leetcode.com", "a+tag@leetcode.com", "a.@leetcode.com" }));
        }

        [TestMethod]
        public void RemoveOuterParentheses_ExamplesAndEmptyResult()
        {
            Assert.AreEqual("()()()", strings.RemoveOuterParentheses("(()())(())"));
            Assert.AreEqual("", strings.RemoveOuterParentheses("()()"));
        }

        [TestMethod]
        public void RemoveDuplicates_ExamplesAndFullyRemoved()
        {
            Assert.AreEqual("ca", strings.RemoveDuplicates("abbaca"));
            Assert.AreEqual("", strings.RemoveDuplicates("azxxzyya"));
        }

        [TestMethod]
        public void GcdOfStrings_ExamplesAndNoDivisor()
        {
            Assert.AreEqual("ABC", strings.GcdOfStrings("ABCABC", "ABC"));
            Assert.AreEqual("AB", strings.GcdOfStrings("ABABAB", "ABAB"));
            Assert.AreEqual("", strings.GcdOfStrings("LEET", "CODE"));
        }

        [TestMethod]
        public void DefangIPaddr_ExamplesAndEdges()
        {
            Assert.AreEqual("1[.]1[.]1[.]1", strings.DefangIPaddr("1.1.1.1"));
            Assert.AreEqual("255[.]100[.]50[.]0", strings.DefangIPaddr("255.100.50.0"));
        }

        [TestMethod]
        public void DayOfYear_ExamplesAndLeapYear()
        {
            Assert.AreEqual(9, strings.DayOfYear("2019-01-09"));
            Assert.AreEqual(41, strings.DayOfYear("2019-02-10"));
            Assert.AreEqual(60, strings.DayOfYear("2020-02-29"));
        }

        [TestMethod]
        public void MaxNumberOfBalloons_ExamplesAndMissingLetters()
        {
            Assert.AreEqual(1, strings.MaxNumberOfBalloons("nlaebolko"));
            Assert.AreEqual(2, strings.MaxNumberOfBalloons("loonbalxballpoon"));
            Assert.AreEqual(0, strings.MaxNumberOfBalloons("leetcode"));
        }

        [TestMethod]
        public void BalancedStringSplit_ExamplesAndSinglePiece()
        {
            Assert.AreEqual(4, strings.BalancedStringSplit("RLRRLLRLRL"));
            Assert.AreEqual(1, strings.BalancedStringSplit("LLRR"));
        }

        [TestMethod]
        public void FreqAlphabets_ExamplesAndMixedTokens()
        {
            Assert.AreEqual("jkab", strings.FreqAlphabets("10#11#12"));
            Assert.AreEqual("acz", strings.FreqAlphabets("1326#"));
        }

        [TestMethod]
        public void SortString_ExamplesAndSingleCharacter()
        {
            Assert.AreEqual("abccbaabccba", strings.SortString("aaaabbbbcccc"));
            Assert.AreEqual("art", strings.SortString("rat"));
            Assert.AreEqual("g", strings.SortString("g"));
        }

        [TestMethod]
        public void FindTheLongestSubstring_ExamplesAndNoVowels()
        {
            Assert.AreEqual(13, strings.FindTheLongestSubstring("eleetminicoworoep"));
            Assert.AreEqual(5, strings.FindTheLongestSubstring("leetcodeisgreat"));
            Assert.AreEqual(6, strings.FindTheLongestSubstring("bcbcbc"));
        }

        [TestMethod]
        public void CanConstructPalindromes_ExamplesAndTooMany()
        {
            Assert.IsTrue(strings.CanConstructPalindromes("annabelle", 2));
            Assert.IsFalse(strings.CanConstructPalindromes("leetcode", 3));
            Assert.IsFalse(strings.CanConstructPalindromes("abc", 4));
        }

        [TestMethod]
        public void EntityParser_ExamplesAndUnknownEntities()
        {
            Assert.AreEqual("& is an HTML entity but &ambassador; is not.", strings.EntityParser("&amp; is an HTML entity but &ambassador; is not."));
            Assert.AreEqual("x > y && x < z", strings.EntityParser("x &gt; y &amp;&amp; x &lt; z"));
        }

        [TestMethod]
        public void MaxScore_ExamplesAndEdges()
        {
            Assert.AreEqual(5, strings.MaxScore("011101"));
            Assert.AreEqual(5, strings.MaxScore("00111"));
            Assert.AreEqual(1, strings.MaxScore("11"));
        }

        [TestMethod]
        public void MaxPower_ExamplesAndSingle()
        {
            Assert.AreEqual(2, strings.MaxPower("leetcode"));
            Assert.AreEqual(5, strings.MaxPower("abbcccddddeeeeedcba"));
            Assert.AreEqual(1, strings.MaxPower("a"));
        }

        [TestMethod]
        public void IsPrefixOfWord_ExamplesAndMissing()
        {
            Assert.AreEqual(4, strings.IsPrefixOfWord("i love eating burger", "burg"));
            Assert.AreEqual(2, strings.IsPrefixOfWord("this problem is an easy problem", "pro"));
            Assert.AreEqual(-1, strings.IsPrefixOfWord("i am tired", "you"));
        }

        [TestMethod]
        public void ReformatDate_ExamplesAndSingleDigitDay()
        {
            Assert.AreEqual("2052-10-20", strings.ReformatDate("20th Oct 2052"));
            Assert.AreEqual("1933-06-06", strings.ReformatDate("6th Jun 1933"));
        }

        [TestMethod]
        public void RestoreString_ExamplesAndAlreadyOrdered()
        {
            Assert.AreEqual("leetcode", strings.RestoreString("codeleet", new[] { 4, 5, 6, 7, 0, 2, 1, 3 }));
            Assert.AreEqual("abc", strings.RestoreString("abc", new[] { 0, 1, 2 }));
        }

        [TestMethod]
        public void MakeGood_ExamplesAndFullyRemoved()
        {
            Assert.AreEqual("leetcode", strings.MakeGood("leEeetcode"));
            Assert.AreEqual("", strings.MakeGood("abBAcC"));
            Assert.AreEqual("s", strings.MakeGood("s"));
        }

        [TestMethod]
        public void ModifyString_ExamplesAndAllQuestions()
        {
            AssertModifiedString("ubv?w", strings.ModifyString("ubv?w"));
            AssertModifiedString("??", strings.ModifyString("??"));
        }

        [TestMethod]
        public void ReorderSpaces_ExamplesAndSingleWord()
        {
            Assert.AreEqual("this   is   a   sentence", strings.ReorderSpaces("  this   is  a sentence "));
            Assert.AreEqual("practice   makes   perfect ", strings.ReorderSpaces(" practice   makes   perfect"));
            Assert.AreEqual("hello   ", strings.ReorderSpaces("  hello "));
        }

        [TestMethod]
        public void MaxDepth_ExamplesAndNoParentheses()
        {
            Assert.AreEqual(3, strings.MaxDepth("(1+(2*3)+((8)/4))+1"));
            Assert.AreEqual(0, strings.MaxDepth("abc"));
        }

        [TestMethod]
        public void MaxLengthBetweenEqualCharacters_ExamplesAndMissing()
        {
            Assert.AreEqual(0, strings.MaxLengthBetweenEqualCharacters("aa"));
            Assert.AreEqual(2, strings.MaxLengthBetweenEqualCharacters("abca"));
            Assert.AreEqual(-1, strings.MaxLengthBetweenEqualCharacters("cbzxy"));
        }

        [TestMethod]
        public void ArrayStringsAreEqual_ExamplesAndDifferent()
        {
            Assert.IsTrue(strings.ArrayStringsAreEqual(new[] { "ab", "c" }, new[] { "a", "bc" }));
            Assert.IsFalse(strings.ArrayStringsAreEqual(new[] { "a", "cb" }, new[] { "ab", "c" }));
        }

        [TestMethod]
        public void MaxRepeating_ExamplesAndNone()
        {
            Assert.AreEqual(2, strings.MaxRepeating("ababc", "ab"));
            Assert.AreEqual(1, strings.MaxRepeating("ababc", "ba"));
            Assert.AreEqual(0, strings.MaxRepeating("ababc", "ac"));
        }

        [TestMethod]
        public void Interpret_ExamplesAndEdges()
        {
            Assert.AreEqual("Goal", strings.Interpret("G()(al)"));
            Assert.AreEqual("Gooooal", strings.Interpret("G()()()()(al)"));
            Assert.AreEqual("alGalooG", strings.Interpret("(al)G(al)()()G"));
        }


        [TestMethod]
        public void HalvesAreAlike_ExamplesAndCaseInsensitiveVowels()
        {
            Assert.IsTrue(strings.HalvesAreAlike("book"));
            Assert.IsFalse(strings.HalvesAreAlike("textbook"));
            Assert.IsTrue(strings.HalvesAreAlike("AbCdEfGh"));
        }

        [TestMethod]
        public void MaximumGain_ExamplesAndPriorityOrder()
        {
            Assert.AreEqual(19, strings.MaximumGain("cdbcbbaaabab", 4, 5));
            Assert.AreEqual(20, strings.MaximumGain("aabbaaxybbaabb", 5, 4));
            Assert.AreEqual(0, strings.MaximumGain("cccc", 3, 4));
        }

        [TestMethod]
        public void MinOperations_ExamplesAndAlreadyAlternating()
        {
            Assert.AreEqual(1, strings.MinOperations("0100"));
            Assert.AreEqual(0, strings.MinOperations("10"));
            Assert.AreEqual(2, strings.MinOperations("1111"));
        }

        [TestMethod]
        public void CountHomogenous_ExamplesAndModulo()
        {
            Assert.AreEqual(13, strings.CountHomogenous("abbcccaa"));
            Assert.AreEqual(2, strings.CountHomogenous("xy"));
            Assert.AreEqual(15, strings.CountHomogenous("zzzzz"));
        }

        [TestMethod]
        public void MergeAlternately_ExamplesAndUnevenLengths()
        {
            Assert.AreEqual("apbqcr", strings.MergeAlternately("abc", "pqr"));
            Assert.AreEqual("apbqrs", strings.MergeAlternately("ab", "pqrs"));
            Assert.AreEqual("apbqcd", strings.MergeAlternately("abcd", "pq"));
        }

        [TestMethod]
        public void CountMatches_ExamplesAndDifferentRuleKeys()
        {
            var items = new List<IList<string>>
            {
                new List<string> { "phone", "blue", "pixel" },
                new List<string> { "computer", "silver", "lenovo" },
                new List<string> { "phone", "gold", "iphone" }
            };
            Assert.AreEqual(1, strings.CountMatches(items, "color", "silver"));
            Assert.AreEqual(2, strings.CountMatches(items, "type", "phone"));
            Assert.AreEqual(0, strings.CountMatches(items, "name", "galaxy"));
        }

        [TestMethod]
        public void AreAlmostEqual_ExamplesAndMismatchCounts()
        {
            Assert.IsTrue(strings.AreAlmostEqual("bank", "kanb"));
            Assert.IsFalse(strings.AreAlmostEqual("attack", "defend"));
            Assert.IsTrue(strings.AreAlmostEqual("kelb", "kelb"));
            Assert.IsFalse(strings.AreAlmostEqual("abcd", "dcba"));
        }

        [TestMethod]
        public void TruncateSentence_ExamplesAndWholeSentence()
        {
            Assert.AreEqual("Hello how are you", strings.TruncateSentence("Hello how are you Contestant", 4));
            Assert.AreEqual("What is", strings.TruncateSentence("What is the solution to this problem", 2));
            Assert.AreEqual("single", strings.TruncateSentence("single", 1));
        }

        [TestMethod]
        public void CheckIfPangram_ExamplesAndMissingLetter()
        {
            Assert.IsTrue(strings.CheckIfPangram("thequickbrownfoxjumpsoverthelazydog"));
            Assert.IsFalse(strings.CheckIfPangram("leetcode"));
        }

        [TestMethod]
        public void ReplaceDigits_ExamplesAndSingleLetter()
        {
            Assert.AreEqual("abcdef", strings.ReplaceDigits("a1c1e1"));
            Assert.AreEqual("abbdcfdhe", strings.ReplaceDigits("a1b2c3d4e"));
            Assert.AreEqual("a", strings.ReplaceDigits("a"));
        }

        [TestMethod]
        public void SortSentence_ExamplesAndSingleWord()
        {
            Assert.AreEqual("This is a sentence", strings.SortSentence("is2 sentence4 This1 a3"));
            Assert.AreEqual("Me Myself and I", strings.SortSentence("Myself2 Me1 I4 and3"));
            Assert.AreEqual("Word", strings.SortSentence("Word1"));
        }

        [TestMethod]
        public void IsSumEqual_ExamplesAndLeadingZeroWords()
        {
            Assert.IsTrue(strings.IsSumEqual("acb", "cba", "cdb"));
            Assert.IsFalse(strings.IsSumEqual("aaa", "a", "aab"));
            Assert.IsTrue(strings.IsSumEqual("aaa", "a", "aaaa"));
        }

        [TestMethod]
        public void RemoveOccurrences_ExamplesAndOverlaps()
        {
            Assert.AreEqual("dab", strings.RemoveOccurrences("daabcbaabcbc", "abc"));
            Assert.AreEqual("axxb", strings.RemoveOccurrences("axxxxyyb", "xy"));
            Assert.AreEqual("", strings.RemoveOccurrences("aaaa", "a"));
        }

        [TestMethod]
        public void CountPalindromicSubsequence_ExamplesAndNone()
        {
            Assert.AreEqual(3, strings.CountPalindromicSubsequence("aabca"));
            Assert.AreEqual(0, strings.CountPalindromicSubsequence("adc"));
            Assert.AreEqual(4, strings.CountPalindromicSubsequence("bbcbaba"));
        }

        [TestMethod]
        public void AreOccurrencesEqual_ExamplesAndSingleCharacter()
        {
            Assert.IsTrue(strings.AreOccurrencesEqual("abacbc"));
            Assert.IsFalse(strings.AreOccurrencesEqual("aaabb"));
            Assert.IsTrue(strings.AreOccurrencesEqual("z"));
        }

        [TestMethod]
        public void GetLucky_ExamplesAndRepeatedTransforms()
        {
            Assert.AreEqual(36, strings.GetLucky("iiii", 1));
            Assert.AreEqual(6, strings.GetLucky("leetcode", 2));
            Assert.AreEqual(8, strings.GetLucky("zbax", 2));
        }

        [TestMethod]
        public void IsPrefixString_ExamplesAndExactBoundary()
        {
            Assert.IsTrue(strings.IsPrefixString("iloveleetcode", new[] { "i", "love", "leetcode", "apples" }));
            Assert.IsFalse(strings.IsPrefixString("iloveleetcode", new[] { "apples", "i", "love", "leetcode" }));
            Assert.IsFalse(strings.IsPrefixString("a", new[] { "aa" }));
        }

        [TestMethod]
        public void FindDifferentBinaryString_ExamplesAndAbsentResult()
        {
            var result = strings.FindDifferentBinaryString(new[] { "01", "10" });
            Assert.AreEqual(2, result.Length);
            CollectionAssert.DoesNotContain(new List<string> { "01", "10" }, result);
            Assert.AreEqual("1", strings.FindDifferentBinaryString(new[] { "0" }));
        }

        [TestMethod]
        public void ReversePrefix_ExamplesAndMissingCharacter()
        {
            Assert.AreEqual("dcbaefd", strings.ReversePrefix("abcdefd", 'd'));
            Assert.AreEqual("zxyxxe", strings.ReversePrefix("xyxzxe", 'z'));
            Assert.AreEqual("abcd", strings.ReversePrefix("abcd", 'z'));
        }

        [TestMethod]
        public void AreNumbersAscending_ExamplesAndEqualOrDescending()
        {
            Assert.IsTrue(strings.AreNumbersAscending("1 box has 3 blue 4 red 6 green and 12 yellow marbles"));
            Assert.IsFalse(strings.AreNumbersAscending("hello world 5 x 5"));
            Assert.IsFalse(strings.AreNumbersAscending("sunset is at 7 51 pm overnight lows will be in the low 50 and 60 s"));
        }

        [TestMethod]
        public void CountVowelSubstrings_ExamplesAndConsonantBoundaries()
        {
            Assert.AreEqual(2, strings.CountVowelSubstrings("aeiouu"));
            Assert.AreEqual(0, strings.CountVowelSubstrings("unicornarihan"));
            Assert.AreEqual(7, strings.CountVowelSubstrings("cuaieuouac"));
        }

        [TestMethod]
        public void CountWords_ExamplesAndNoCommonUniqueWords()
        {
            Assert.AreEqual(2, strings.CountWords(new[] { "leetcode", "is", "amazing", "as", "is" }, new[] { "amazing", "leetcode", "is" }));
            Assert.AreEqual(0, strings.CountWords(new[] { "b", "bb", "bbb" }, new[] { "a", "aa", "aaa" }));
            Assert.AreEqual(1, strings.CountWords(new[] { "a", "ab" }, new[] { "a", "a", "ab" }));
        }

        [TestMethod]
        public void FirstPalindrome_ExamplesAndMissing()
        {
            Assert.AreEqual("ada", strings.FirstPalindrome(new[] { "abc", "car", "ada", "racecar", "cool" }));
            Assert.AreEqual("racecar", strings.FirstPalindrome(new[] { "notapalindrome", "racecar" }));
            Assert.AreEqual("", strings.FirstPalindrome(new[] { "def", "ghi" }));
        }

        [TestMethod]
        public void MostWordsFound_ExamplesAndSingleWords()
        {
            Assert.AreEqual(6, strings.MostWordsFound(new[] { "alice and bob love leetcode", "i think so too", "this is great thanks very much" }));
            Assert.AreEqual(3, strings.MostWordsFound(new[] { "please wait", "continue to fight", "continue to win" }));
            Assert.AreEqual(1, strings.MostWordsFound(new[] { "hello" }));
        }

        [TestMethod]
        public void CheckString_ExamplesAndOnlyOneLetter()
        {
            Assert.IsTrue(strings.CheckString("aaabbb"));
            Assert.IsFalse(strings.CheckString("abab"));
            Assert.IsTrue(strings.CheckString("bbb"));
        }

        [TestMethod]
        public void LongestPalindromeByTwoLetterWords_ExamplesAndCenter()
        {
            Assert.AreEqual(6, strings.LongestPalindrome(new[] { "lc", "cl", "gg" }));
            Assert.AreEqual(8, strings.LongestPalindrome(new[] { "ab", "ty", "yt", "lc", "cl", "ab" }));
            Assert.AreEqual(2, strings.LongestPalindrome(new[] { "cc", "ll", "xx" }));
        }

        [TestMethod]
        public void DivideString_ExamplesAndNoPadding()
        {
            CollectionAssert.AreEqual(new[] { "abc", "def", "ghi" }, strings.DivideString("abcdefghi", 3, 'x'));
            CollectionAssert.AreEqual(new[] { "abc", "def", "ghi", "jxx" }, strings.DivideString("abcdefghij", 3, 'x'));
            CollectionAssert.AreEqual(new[] { "a" }, strings.DivideString("a", 1, 'z'));
        }

        [TestMethod]
        public void PrefixCount_ExamplesAndNone()
        {
            Assert.AreEqual(2, strings.PrefixCount(new[] { "pay", "attention", "practice", "attend" }, "at"));
            Assert.AreEqual(0, strings.PrefixCount(new[] { "leetcode", "win", "loops", "success" }, "code"));
            Assert.AreEqual(1, strings.PrefixCount(new[] { "a" }, "a"));
        }

        [TestMethod]
        public void CountPrefixes_ExamplesAndWholeWord()
        {
            Assert.AreEqual(3, strings.CountPrefixes(new[] { "a", "b", "c", "ab", "bc", "abc" }, "abc"));
            Assert.AreEqual(2, strings.CountPrefixes(new[] { "a", "a" }, "aa"));
            Assert.AreEqual(0, strings.CountPrefixes(new[] { "z" }, "abc"));
        }

        [TestMethod]
        public void LargestGoodInteger_ExamplesAndMissing()
        {
            Assert.AreEqual("777", strings.LargestGoodInteger("6777133339"));
            Assert.AreEqual("000", strings.LargestGoodInteger("2300019"));
            Assert.AreEqual("", strings.LargestGoodInteger("42352338"));
        }

        [TestMethod]
        public void RemoveAnagrams_ExamplesAndAdjacentOnly()
        {
            CollectionAssert.AreEqual(new[] { "abba", "cd" }, new List<string>(strings.RemoveAnagrams(new[] { "abba", "baba", "bbaa", "cd", "cd" })));
            CollectionAssert.AreEqual(new[] { "a", "b", "c", "d", "e" }, new List<string>(strings.RemoveAnagrams(new[] { "a", "b", "c", "d", "e" })));
        }

        [TestMethod]
        public void PercentageLetter_ExamplesAndFlooring()
        {
            Assert.AreEqual(33, strings.PercentageLetter("foobar", 'o'));
            Assert.AreEqual(0, strings.PercentageLetter("jjjj", 'k'));
            Assert.AreEqual(100, strings.PercentageLetter("aaaa", 'a'));
        }

        [TestMethod]
        public void RearrangeCharacters_ExamplesAndInsufficientLetters()
        {
            Assert.AreEqual(2, strings.RearrangeCharacters("ilovecodingonleetcode", "code"));
            Assert.AreEqual(1, strings.RearrangeCharacters("abcba", "abc"));
            Assert.AreEqual(1, strings.RearrangeCharacters("abbaccaddaeea", "aaaaa"));
        }

        [TestMethod]
        public void StrongPasswordCheckerII_ExamplesAndFailures()
        {
            Assert.IsTrue(strings.StrongPasswordCheckerII("IloveLe3tcode!"));
            Assert.IsFalse(strings.StrongPasswordCheckerII("Me+You--IsMyDream"));
            Assert.IsFalse(strings.StrongPasswordCheckerII("1aB!"));
            Assert.IsFalse(strings.StrongPasswordCheckerII("Aa1!!a1A"));
        }

        [TestMethod]
        public void GreatestLetter_ExamplesAndMissing()
        {
            Assert.AreEqual("E", strings.GreatestLetter("lEeTcOdE"));
            Assert.AreEqual("R", strings.GreatestLetter("arRAzFif"));
            Assert.AreEqual("", strings.GreatestLetter("abc"));
        }

        [TestMethod]
        public void CountAsterisks_ExamplesAndBars()
        {
            Assert.AreEqual(2, strings.CountAsterisks("l|*e*et|c**o|*de|"));
            Assert.AreEqual(0, strings.CountAsterisks("iamprogrammer"));
            Assert.AreEqual(5, strings.CountAsterisks("yo|uar|e**|b|e***au|tifu|l"));
        }

        [TestMethod]
        public void DecodeMessage_ExamplesAndSpaces()
        {
            Assert.AreEqual("this is a secret", strings.DecodeMessage("the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv"));
            Assert.AreEqual("the five boxing wizards jump quickly", strings.DecodeMessage("eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb"));
        }

        [TestMethod]
        public void RemoveStars_ExamplesAndAllRemoved()
        {
            Assert.AreEqual("lecoe", strings.RemoveStars("leet**cod*e"));
            Assert.AreEqual("", strings.RemoveStars("erase*****"));
            Assert.AreEqual("abc", strings.RemoveStars("abc"));
        }

        [TestMethod]
        public void CheckDistances_ExamplesAndInvalidDistance()
        {
            Assert.IsTrue(strings.CheckDistances("abaccb", new[] { 1, 3, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            Assert.IsFalse(strings.CheckDistances("aa", new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }

        [TestMethod]
        public void PartitionString_ExamplesAndUniqueString()
        {
            Assert.AreEqual(4, strings.PartitionString("abacaba"));
            Assert.AreEqual(6, strings.PartitionString("ssssss"));
            Assert.AreEqual(1, strings.PartitionString("abcdef"));
        }

        [TestMethod]
        public void LongestContinuousSubstring_ExamplesAndSingle()
        {
            Assert.AreEqual(2, strings.LongestContinuousSubstring("abacaba"));
            Assert.AreEqual(5, strings.LongestContinuousSubstring("abcde"));
            Assert.AreEqual(1, strings.LongestContinuousSubstring("z"));
        }

        [TestMethod]
        public void RobotWithString_ExamplesAndRepeatedLetters()
        {
            Assert.AreEqual("azz", strings.RobotWithString("zza"));
            Assert.AreEqual("abc", strings.RobotWithString("bac"));
            Assert.AreEqual("addb", strings.RobotWithString("bdda"));
        }

        [TestMethod]
        public void AppendCharacters_ExamplesAndAlreadySubsequence()
        {
            Assert.AreEqual(4, strings.AppendCharacters("coaching", "coding"));
            Assert.AreEqual(0, strings.AppendCharacters("abcde", "a"));
            Assert.AreEqual(5, strings.AppendCharacters("z", "abcde"));
        }

        [TestMethod]
        public void IsCircularSentence_ExamplesAndSingleWord()
        {
            Assert.IsTrue(strings.IsCircularSentence("leetcode exercises sound delightful"));
            Assert.IsTrue(strings.IsCircularSentence("eetcode"));
            Assert.IsFalse(strings.IsCircularSentence("Leetcode is cool"));
        }

        [TestMethod]
        public void ClosetTarget_ExamplesAndAbsent()
        {
            Assert.AreEqual(1, strings.ClosetTarget(new[] { "hello", "i", "am", "leetcode", "hello" }, "hello", 1));
            Assert.AreEqual(1, strings.ClosetTarget(new[] { "a", "b", "leetcode" }, "leetcode", 0));
            Assert.AreEqual(-1, strings.ClosetTarget(new[] { "i", "eat", "leetcode" }, "ate", 0));
        }

        [TestMethod]
        public void DivisibilityArray_ExamplesAndLargePrefix()
        {
            CollectionAssert.AreEqual(new[] { 1, 1, 0, 0, 0, 1, 1, 0, 0 }, strings.DivisibilityArray("998244353", 3));
            CollectionAssert.AreEqual(new[] { 0, 1, 0, 1 }, strings.DivisibilityArray("1010", 10));
        }

        [TestMethod]
        public void VowelStrings_ExamplesAndSubrange()
        {
            Assert.AreEqual(2, strings.VowelStrings(new[] { "are", "amy", "u" }, 0, 2));
            Assert.AreEqual(3, strings.VowelStrings(new[] { "hey", "aeo", "mu", "ooo", "artro" }, 1, 4));
            Assert.AreEqual(0, strings.VowelStrings(new[] { "bc" }, 0, 0));
        }

        [TestMethod]
        public void MakeSmallestPalindrome_ExamplesAndAlreadyPalindrome()
        {
            Assert.AreEqual("efcfe", strings.MakeSmallestPalindrome("egcfe"));
            Assert.AreEqual("abba", strings.MakeSmallestPalindrome("abcd"));
            Assert.AreEqual("neven", strings.MakeSmallestPalindrome("seven"));
            Assert.AreEqual("aba", strings.MakeSmallestPalindrome("aba"));
        }


        [TestMethod]
        public void RemoveTrailingZeros_ExamplesAndNoTrailingZeros()
        {
            Assert.AreEqual("512301", strings.RemoveTrailingZeros("51230100"));
            Assert.AreEqual("123", strings.RemoveTrailingZeros("123"));
            Assert.AreEqual("1", strings.RemoveTrailingZeros("1000"));
        }

        [TestMethod]
        public void MinimizedStringLength_ExamplesAndSingleDistinct()
        {
            Assert.AreEqual(3, strings.MinimizedStringLength("aaabc"));
            Assert.AreEqual(3, strings.MinimizedStringLength("cbbd"));
            Assert.AreEqual(4, strings.MinimizedStringLength("dddaaaeeeff"));
        }

        [TestMethod]
        public void SmallestString_ExamplesAndAllAs()
        {
            Assert.AreEqual("baabc", strings.SmallestString("cbabc"));
            Assert.AreEqual("abaab", strings.SmallestString("acbbc"));
            Assert.AreEqual("az", strings.SmallestString("aa"));
        }

        [TestMethod]
        public void MaximumNumberOfStringPairs_ExamplesAndNone()
        {
            Assert.AreEqual(2, strings.MaximumNumberOfStringPairs(new[] { "cd", "ac", "dc", "ca", "zz" }));
            Assert.AreEqual(1, strings.MaximumNumberOfStringPairs(new[] { "ab", "ba", "cc" }));
            Assert.AreEqual(0, strings.MaximumNumberOfStringPairs(new[] { "aa", "ab" }));
        }

        [TestMethod]
        public void SortVowels_ExamplesAndNoVowels()
        {
            Assert.AreEqual("lEOtcede", strings.SortVowels("lEetcOde"));
            Assert.AreEqual("lYmpH", strings.SortVowels("lYmpH"));
            Assert.AreEqual("Aa", strings.SortVowels("aA"));
        }

        [TestMethod]
        public void CanMakeSubsequence_ExamplesAndImpossible()
        {
            Assert.IsTrue(strings.CanMakeSubsequence("abc", "ad"));
            Assert.IsTrue(strings.CanMakeSubsequence("zc", "ad"));
            Assert.IsFalse(strings.CanMakeSubsequence("ab", "d"));
        }

        [TestMethod]
        public void CanBeEqual_ExamplesAndParityMismatch()
        {
            Assert.IsTrue(strings.CanBeEqual("abcd", "cdab"));
            Assert.IsFalse(strings.CanBeEqual("abcd", "dacb"));
        }

        [TestMethod]
        public void CheckStrings_ExamplesAndParityMismatch()
        {
            Assert.IsTrue(strings.CheckStrings("abcdba", "cabdab"));
            Assert.IsFalse(strings.CheckStrings("abe", "bea"));
            Assert.IsTrue(strings.CheckStrings("abcd", "cdab"));
        }

        [TestMethod]
        public void MaximumOddBinaryNumber_ExamplesAndSingleOne()
        {
            Assert.AreEqual("001", strings.MaximumOddBinaryNumber("010"));
            Assert.AreEqual("1001", strings.MaximumOddBinaryNumber("0101"));
            Assert.AreEqual("1", strings.MaximumOddBinaryNumber("1"));
        }

        [TestMethod]
        public void FindMinimumOperations_ExamplesAndNoCommonPrefix()
        {
            Assert.AreEqual(2, strings.FindMinimumOperations("abc", "abb", "ab"));
            Assert.AreEqual(-1, strings.FindMinimumOperations("dac", "bac", "cac"));
            Assert.AreEqual(0, strings.FindMinimumOperations("a", "a", "a"));
        }

        [TestMethod]
        public void MinimumSteps_ExamplesAndAlreadySeparated()
        {
            Assert.AreEqual(1L, strings.MinimumSteps("101"));
            Assert.AreEqual(2L, strings.MinimumSteps("100"));
            Assert.AreEqual(0L, strings.MinimumSteps("0011"));
        }

        [TestMethod]
        public void FindWordsContaining_ExamplesAndAbsent()
        {
            CollectionAssert.AreEqual(new[] { 0, 1 }, new List<int>(strings.FindWordsContaining(new[] { "leet", "code" }, 'e')));
            CollectionAssert.AreEqual(new[] { 0, 2 }, new List<int>(strings.FindWordsContaining(new[] { "abc", "bcd", "aaaa", "cbc" }, 'a')));
            CollectionAssert.AreEqual(Array.Empty<int>(), new List<int>(strings.FindWordsContaining(new[] { "abc" }, 'z')));
        }

        [TestMethod]
        public void RemoveAlmostEqualCharacters_ExamplesAndSeparated()
        {
            Assert.AreEqual(2, strings.RemoveAlmostEqualCharacters("aaaaa"));
            Assert.AreEqual(2, strings.RemoveAlmostEqualCharacters("abddez"));
            Assert.AreEqual(3, strings.RemoveAlmostEqualCharacters("zyxyxyz"));
        }

        [TestMethod]
        public void MinimumPushes_ExamplesAndMoreThanEightLetters()
        {
            Assert.AreEqual(5, strings.MinimumPushes("abcde"));
            Assert.AreEqual(12, strings.MinimumPushes("xycdefghij"));
            Assert.AreEqual(10, strings.MinimumPushes("abcdefghi"));
        }

        [TestMethod]
        public void MinimumPushesII_FrequencyWeightedExamples()
        {
            Assert.AreEqual(5, strings.MinimumPushesII("abcde"));
            Assert.AreEqual(12, strings.MinimumPushesII("xyzxyzxyzxyz"));
            Assert.AreEqual(9, strings.MinimumPushesII("aabbccdde"));
        }

        [TestMethod]
        public void IsSubstringPresent_ExamplesAndSingleCharacter()
        {
            Assert.IsTrue(strings.IsSubstringPresent("leetcode"));
            Assert.IsTrue(strings.IsSubstringPresent("abcba"));
            Assert.IsFalse(strings.IsSubstringPresent("abcd"));
            Assert.IsFalse(strings.IsSubstringPresent("z"));
        }

        [TestMethod]
        public void ScoreOfString_ExamplesAndUniformString()
        {
            Assert.AreEqual(13, strings.ScoreOfString("hello"));
            Assert.AreEqual(50, strings.ScoreOfString("zaz"));
            Assert.AreEqual(0, strings.ScoreOfString("aa"));
        }

        [TestMethod]
        public void NumberOfSpecialChars_ExamplesAndNone()
        {
            Assert.AreEqual(3, strings.NumberOfSpecialChars("aaAbcBC"));
            Assert.AreEqual(0, strings.NumberOfSpecialChars("abc"));
            Assert.AreEqual(1, strings.NumberOfSpecialChars("abBCab"));
        }

        [TestMethod]
        public void NumberOfSpecialCharsII_ExamplesAndOrderingRule()
        {
            Assert.AreEqual(3, strings.NumberOfSpecialCharsII("aaAbcBC"));
            Assert.AreEqual(0, strings.NumberOfSpecialCharsII("abc"));
            Assert.AreEqual(0, strings.NumberOfSpecialCharsII("AbBCab"));
        }

        [TestMethod]
        public void IsValidWord_ExamplesAndInvalidCharacters()
        {
            Assert.IsTrue(strings.IsValidWord("234Adas"));
            Assert.IsFalse(strings.IsValidWord("b3"));
            Assert.IsFalse(strings.IsValidWord("a3$e"));
            Assert.IsFalse(strings.IsValidWord("123"));
        }

        [TestMethod]
        public void MinimumOperationsToMakeKPeriodic_ExamplesAndAlreadyPeriodic()
        {
            Assert.AreEqual(1, strings.MinimumOperationsToMakeKPeriodic("leetcodeleet", 4));
            Assert.AreEqual(0, strings.MinimumOperationsToMakeKPeriodic("ababab", 2));
            Assert.AreEqual(2, strings.MinimumOperationsToMakeKPeriodic("ababcdcd", 2));
        }

        [TestMethod]
        public void FindPermutationDifference_ExamplesAndReverse()
        {
            Assert.AreEqual(2, strings.FindPermutationDifference("abc", "bac"));
            Assert.AreEqual(12, strings.FindPermutationDifference("abcde", "edbac"));
            Assert.AreEqual(0, strings.FindPermutationDifference("z", "z"));
        }

        [TestMethod]
        public void CompressedString_ExamplesAndLongRun()
        {
            Assert.AreEqual("1a1b1c1d1e", strings.CompressedString("abcde"));
            Assert.AreEqual("9a5a2b", strings.CompressedString("aaaaaaaaaaaaaabb"));
            Assert.AreEqual("1x", strings.CompressedString("x"));
        }

        [TestMethod]
        public void ClearDigits_ExamplesAndNoDigits()
        {
            Assert.AreEqual("abc", strings.ClearDigits("abc"));
            Assert.AreEqual("", strings.ClearDigits("cb34"));
            Assert.AreEqual("", strings.ClearDigits("a1b2"));
        }

        [TestMethod]
        public void GetEncryptedString_ExamplesAndLargeShift()
        {
            Assert.AreEqual("tdar", strings.GetEncryptedString("dart", 3));
            Assert.AreEqual("aaa", strings.GetEncryptedString("aaa", 1));
            Assert.AreEqual("abc", strings.GetEncryptedString("abc", 3));
        }

        [TestMethod]
        public void MinimumLength_ExamplesAndSmallCounts()
        {
            Assert.AreEqual(5, strings.MinimumLength("abaacbcbb"));
            Assert.AreEqual(2, strings.MinimumLength("aa"));
            Assert.AreEqual(1, strings.MinimumLength("aaa"));
        }

        [TestMethod]
        public void StringHash_ExamplesAndSingleBlock()
        {
            Assert.AreEqual("bf", strings.StringHash("abcd", 2));
            Assert.AreEqual("i", strings.StringHash("mxz", 3));
            Assert.AreEqual("abc", strings.StringHash("abc", 1));
        }

        [TestMethod]
        public void ConvertDateToBinary_ExamplesAndLeadingZeros()
        {
            Assert.AreEqual("100000100000-10-11101", strings.ConvertDateToBinary("2080-02-29"));
            Assert.AreEqual("11101101100-1-1", strings.ConvertDateToBinary("1900-01-01"));
        }

        [TestMethod]
        public void PossibleStringCount_ExamplesAndNoLongPress()
        {
            Assert.AreEqual(5, strings.PossibleStringCount("abbcccc"));
            Assert.AreEqual(1, strings.PossibleStringCount("abcd"));
            Assert.AreEqual(4, strings.PossibleStringCount("aaaa"));
        }

        [TestMethod]
        public void IsBalanced_ExamplesAndOddLength()
        {
            Assert.IsTrue(strings.IsBalanced("24123"));
            Assert.IsFalse(strings.IsBalanced("1234"));
            Assert.IsTrue(strings.IsBalanced("11"));
        }

        [TestMethod]
        public void IsPossibleToRearrange_ExamplesAndMismatch()
        {
            Assert.IsTrue(strings.IsPossibleToRearrange("abcd", "cdab", 2));
            Assert.IsFalse(strings.IsPossibleToRearrange("aabb", "abab", 2));
            Assert.IsTrue(strings.IsPossibleToRearrange("abc", "abc", 1));
        }

        [TestMethod]
        public void HasMatch_ExamplesAndEmptySide()
        {
            Assert.IsTrue(strings.HasMatch("leetcode", "ee*e"));
            Assert.IsFalse(strings.HasMatch("car", "c*v"));
            Assert.IsTrue(strings.HasMatch("abc", "*bc"));
        }

        [TestMethod]
        public void FindValidPair_ExamplesAndAbsent()
        {
            Assert.AreEqual("12", strings.FindValidPair("12233"));
            Assert.AreEqual("", strings.FindValidPair("111"));
            Assert.AreEqual("", strings.FindValidPair("222"));
        }

        [TestMethod]
        public void MaxDifference_ExamplesAndMixedFrequencies()
        {
            Assert.AreEqual(3, strings.MaxDifference("aaaaabbc"));
            Assert.AreEqual(1, strings.MaxDifference("abcabcab"));
            Assert.AreEqual(-1, strings.MaxDifference("aabbc"));
        }

        [TestMethod]
        public void HasSpecialSubstring_ExamplesAndBoundaries()
        {
            Assert.IsTrue(strings.HasSpecialSubstring("aaabaaa", 3));
            Assert.IsFalse(strings.HasSpecialSubstring("abc", 2));
            Assert.IsTrue(strings.HasSpecialSubstring("h", 1));
        }

        [TestMethod]
        public void MaxFreqSum_ExamplesAndMissingClass()
        {
            Assert.AreEqual(6, strings.MaxFreqSum("successes"));
            Assert.AreEqual(3, strings.MaxFreqSum("aeiaeia"));
            Assert.AreEqual(1, strings.MaxFreqSum("bcdf"));
        }

        [TestMethod]
        public void MinDeletion_ExamplesAndAlreadyLimited()
        {
            Assert.AreEqual(1, strings.MinDeletion("abc", 2));
            Assert.AreEqual(0, strings.MinDeletion("aabb", 2));
            Assert.AreEqual(3, strings.MinDeletion("abc", 0));
        }

        [TestMethod]
        public void RemoveSubstring_ExamplesAndEdge()
        {
            Assert.AreEqual("", strings.RemoveSubstring("(())", 1));
            Assert.AreEqual("((", strings.RemoveSubstring("(()(", 1));
            Assert.AreEqual("()()()", strings.RemoveSubstring("((()))()()()", 3));
            Assert.AreEqual("", strings.RemoveSubstring("()", 1));
        }

        [TestMethod]
        public void ScoreBalance_ExamplesAndSplit()
        {
            Assert.IsTrue(strings.ScoreBalance("adcb"));
            Assert.IsFalse(strings.ScoreBalance("bace"));
            Assert.IsTrue(strings.ScoreBalance("aa"));
        }

        [TestMethod]
        public void LongestBalanced_ExamplesAcrossSupportedDomains()
        {
            Assert.AreEqual(4, strings.LongestBalanced("abbac"));
            Assert.AreEqual(3, strings.LongestBalanced("aabcc"));
            Assert.AreEqual(4, strings.LongestBalanced("zzabccy"));
            Assert.AreEqual(2, strings.LongestBalanced("ad"));
        }

        [TestMethod]
        public void LexGreaterPermutation_Examples()
        {
            Assert.AreEqual("bca", strings.LexGreaterPermutation("abc", "bba"));
            Assert.AreEqual("eelt", strings.LexGreaterPermutation("leet", "code"));
            Assert.AreEqual("", strings.LexGreaterPermutation("baba", "bbaa"));
        }

        [TestMethod]
        public void LexPalindromicPermutation_Examples()
        {
            Assert.AreEqual("baab", strings.LexPalindromicPermutation("baba", "abba"));
            Assert.AreEqual("", strings.LexPalindromicPermutation("baba", "bbaa"));
            Assert.AreEqual("", strings.LexPalindromicPermutation("abc", "abb"));
            Assert.AreEqual("aca", strings.LexPalindromicPermutation("aac", "abb"));
        }

        [TestMethod]
        public void MinLengthAfterRemovals_Examples()
        {
            Assert.AreEqual(0, strings.MinLengthAfterRemovals("aabbab"));
            Assert.AreEqual(4, strings.MinLengthAfterRemovals("aaaa"));
            Assert.AreEqual(1, strings.MinLengthAfterRemovals("aaabb"));
        }

        [TestMethod]
        public void MinimumFlips_IntegerExamples()
        {
            Assert.AreEqual(0, strings.MinimumFlips(7));
            Assert.AreEqual(4, strings.MinimumFlips(10));
            Assert.AreEqual(0, strings.MinimumFlips(9));
        }

        [TestMethod]
        public void SumAndMultiply_Examples()
        {
            CollectionAssert.AreEqual(new[] { 12340, 4, 9 }, strings.SumAndMultiply("10203004", new[]
            {
                new[] { 0, 7 },
                new[] { 1, 3 },
                new[] { 4, 6 }
            }));

            CollectionAssert.AreEqual(new[] { 1, 0 }, strings.SumAndMultiply("1000", new[]
            {
                new[] { 0, 3 },
                new[] { 1, 1 }
            }));

            CollectionAssert.AreEqual(new[] { 444444137 }, strings.SumAndMultiply("9876543210", new[]
            {
                new[] { 0, 9 }
            }));
        }

        [TestMethod]
        public void MaxDistinct_Examples()
        {
            Assert.AreEqual(2, strings.MaxDistinct("abab"));
            Assert.AreEqual(4, strings.MaxDistinct("abcd"));
            Assert.AreEqual(1, strings.MaxDistinct("aaaa"));
        }

        [TestMethod]
        public void MinDeletions_ExamplesAndSingleCharacter()
        {
            CollectionAssert.AreEqual(new[] { 0, 2 }, strings.MinDeletions("ABA", new[]
            {
                new[] { 2, 1, 2 },
                new[] { 1, 1 },
                new[] { 2, 0, 2 }
            }));

            CollectionAssert.AreEqual(new[] { 1, 0 }, strings.MinDeletions("ABB", new[]
            {
                new[] { 2, 0, 2 },
                new[] { 1, 2 },
                new[] { 2, 0, 2 }
            }));

            CollectionAssert.AreEqual(new[] { 0 }, strings.MinDeletions("A", new[]
            {
                new[] { 2, 0, 0 }
            }));
        }

        [TestMethod]
        public void MaximumScore_ExamplesAndEdge()
        {
            Assert.AreEqual(7L, strings.MaximumScore(new[] { 2, 1, 5, 2, 3 }, "01010"));
            Assert.AreEqual(0L, strings.MaximumScore(new[] { 4, 7, 2, 9 }, "0000"));
            Assert.AreEqual(100L, strings.MaximumScore(new[] { 1, 100 }, "01"));
        }

        [TestMethod]
        public void MinCost_StringAndArrayExamples()
        {
            Assert.AreEqual(11L, strings.MinCost("aabaac", new[] { 1, 2, 3, 4, 1, 10 }));
            Assert.AreEqual(13L, strings.MinCost("abc", new[] { 10, 5, 8 }));
            Assert.AreEqual(0L, strings.MinCost("zzzzz", new[] { 67, 67, 67, 67, 67 }));
        }

        [TestMethod]
        public void ReversePrefix_IntegerExamples()
        {
            Assert.AreEqual("bacd", strings.ReversePrefix("abcd", 2));
            Assert.AreEqual("zyx", strings.ReversePrefix("xyz", 3));
            Assert.AreEqual("hey", strings.ReversePrefix("hey", 1));
        }

        [TestMethod]
        public void LargestEven_Examples()
        {
            Assert.AreEqual("1112", strings.LargestEven("1112"));
            Assert.AreEqual("22", strings.LargestEven("221"));
            Assert.AreEqual("", strings.LargestEven("1"));
        }

        [TestMethod]
        public void WordSquares_Examples()
        {
            AssertNestedEquivalent(
                new[] { "able|area|echo|also", "area|able|also|echo" },
                strings.WordSquares(new[] { "able", "area", "echo", "also" }));

            AssertNestedEquivalent(Array.Empty<string>(), strings.WordSquares(new[] { "code", "cafe", "eden", "edge" }));
        }

        [TestMethod]
        public void MinimumCost_Examples()
        {
            Assert.AreEqual(16L, strings.MinimumCost("01000", "10111", 10, 2, 2));
            Assert.AreEqual(6L, strings.MinimumCost("001", "110", 2, 100, 100));
            Assert.AreEqual(0L, strings.MinimumCost("1010", "1010", 5, 5, 5));
        }

        [TestMethod]
        public void ResiduePrefixes_Examples()
        {
            Assert.AreEqual(2, strings.ResiduePrefixes("abc"));
            Assert.AreEqual(1, strings.ResiduePrefixes("dd"));
            Assert.AreEqual(2, strings.ResiduePrefixes("bob"));
        }

        [TestMethod]
        public void CountPairs_CaesarExamples()
        {
            Assert.AreEqual(1L, strings.CountPairs(new[] { "fusion", "layout" }));
            Assert.AreEqual(2L, strings.CountPairs(new[] { "ab", "aa", "za", "aa" }));
            Assert.AreEqual(3L, strings.CountPairs(new[] { "a", "b", "c" }));
        }

        [TestMethod]
        public void VowelConsonantScore_Examples()
        {
            Assert.AreEqual(2, strings.VowelConsonantScore("cooear"));
            Assert.AreEqual(1, strings.VowelConsonantScore("axeyizou"));
            Assert.AreEqual(0, strings.VowelConsonantScore("au 123"));
        }

        [TestMethod]
        public void LexSmallestAfterDeletion_ExamplesAndEdge()
        {
            Assert.AreEqual("aacb", strings.LexSmallestAfterDeletion("aaccb"));
            Assert.AreEqual("z", strings.LexSmallestAfterDeletion("z"));
            Assert.AreEqual("ba", strings.LexSmallestAfterDeletion("bba"));
            Assert.AreEqual("acab", strings.LexSmallestAfterDeletion("acab"));
        }

        [TestMethod]
        public void ReverseByType_Examples()
        {
            Assert.AreEqual("(fad@cb#e)", strings.ReverseByType(")ebc#da@f("));
            Assert.AreEqual("z", strings.ReverseByType("z"));
            Assert.AreEqual(")(*^%$#@!", strings.ReverseByType("!@#$%^*()"));
        }

        [TestMethod]
        public void MapWordWeights_Examples()
        {
            CollectionAssert.AreEqual("rij".ToCharArray(), strings.MapWordWeights(
                new[] { "abcd", "def", "xyz" },
                new[] { 5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2 }).ToCharArray());

            Assert.AreEqual("yyy", strings.MapWordWeights(
                new[] { "a", "b", "c" },
                new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));

            Assert.AreEqual("g", strings.MapWordWeights(
                new[] { "abcd" },
                new[] { 7, 5, 3, 4, 3, 5, 4, 9, 4, 2, 2, 7, 10, 2, 5, 10, 6, 1, 2, 2, 4, 1, 3, 4, 4, 5 }));
        }

        [TestMethod]
        public void PrefixConnected_Examples()
        {
            Assert.AreEqual(2, strings.PrefixConnected(new[] { "apple", "apply", "banana", "bandit" }, 2));
            Assert.AreEqual(1, strings.PrefixConnected(new[] { "car", "cat", "cartoon" }, 3));
            Assert.AreEqual(2, strings.PrefixConnected(new[] { "bat", "dog", "dog", "doggy", "bat" }, 3));
        }

        [TestMethod]
        public void PalindromePath_ExamplesAndEdge()
        {
            CollectionAssert.AreEqual(new[] { true, false }, new List<bool>(strings.PalindromePath(
                3,
                new[] { new[] { 0, 1 }, new[] { 1, 2 } },
                "aac",
                new[] { "query 0 2", "update 1 b", "query 0 2" })));

            CollectionAssert.AreEqual(new[] { false, false, true }, new List<bool>(strings.PalindromePath(
                4,
                new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } },
                "abca",
                new[] { "query 1 2", "update 0 b", "query 2 3", "update 3 a", "query 1 3" })));

            CollectionAssert.AreEqual(new[] { true, true }, new List<bool>(strings.PalindromePath(
                1,
                Array.Empty<int[]>(),
                "a",
                new[] { "query 0 0", "update 0 b", "query 0 0" })));
        }

        [TestMethod]
        public void AlmostPalindromic_ExamplesAndEdge()
        {
            Assert.AreEqual(4, strings.AlmostPalindromic("abca"));
            Assert.AreEqual(4, strings.AlmostPalindromic("abba"));
            Assert.AreEqual(5, strings.AlmostPalindromic("zzabba"));
            Assert.AreEqual(2, strings.AlmostPalindromic("ab"));
        }

        [TestMethod]
        public void MaximumXor_Examples()
        {
            Assert.AreEqual("110", strings.MaximumXor("101", "011"));
            Assert.AreEqual("1101", strings.MaximumXor("0110", "1110"));
            Assert.AreEqual("1111", strings.MaximumXor("0101", "1001"));
        }

        [TestMethod]
        public void MergeCharacters_Examples()
        {
            Assert.AreEqual("abc", strings.MergeCharacters("abca", 3));
            Assert.AreEqual("abca", strings.MergeCharacters("aabca", 2));
            Assert.AreEqual("ybzybz", strings.MergeCharacters("yybyzybz", 2));
        }

        [TestMethod]
        public void TrimTrailingVowels_Examples()
        {
            Assert.AreEqual("id", strings.TrimTrailingVowels("idea"));
            Assert.AreEqual("day", strings.TrimTrailingVowels("day"));
            Assert.AreEqual("", strings.TrimTrailingVowels("aeiou"));
        }

        [TestMethod]
        public void MinCost_BinaryPartitionExamples()
        {
            Assert.AreEqual(6L, strings.MinCost("1010", 2, 1));
            Assert.AreEqual(12L, strings.MinCost("1010", 3, 10));
            Assert.AreEqual(2L, strings.MinCost("00", 1, 2));
        }

        [TestMethod]
        public void FirstMatchingIndex_Examples()
        {
            Assert.AreEqual(1, strings.FirstMatchingIndex("abcacbd"));
            Assert.AreEqual(1, strings.FirstMatchingIndex("abc"));
            Assert.AreEqual(-1, strings.FirstMatchingIndex("abcdab"));
        }

        [TestMethod]
        public void MirrorFrequency_Examples()
        {
            Assert.AreEqual(3, strings.MirrorFrequency("ab1z9"));
            Assert.AreEqual(2, strings.MirrorFrequency("4m7n"));
            Assert.AreEqual(0, strings.MirrorFrequency("byby"));
        }

        [TestMethod]
        public void TrafficSignal_ExamplesAndEdges()
        {
            Assert.AreEqual("Red", strings.TrafficSignal(60));
            Assert.AreEqual("Invalid", strings.TrafficSignal(5));
            Assert.AreEqual("Green", strings.TrafficSignal(0));
            Assert.AreEqual("Orange", strings.TrafficSignal(30));
        }

        [TestMethod]
        public void ScoreValidator_Examples()
        {
            CollectionAssert.AreEqual(new[] { 12, 1 }, strings.ScoreValidator(new[] { "1", "4", "W", "6", "WD" }));
            CollectionAssert.AreEqual(new[] { 10, 0 }, strings.ScoreValidator(new[] { "WD", "NB", "0", "4", "4" }));
            CollectionAssert.AreEqual(new[] { 0, 10 }, strings.ScoreValidator(new[] { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }));
        }

        [TestMethod]
        public void MinFlips_StringExamples()
        {
            Assert.AreEqual(1, strings.MinFlips("1010"));
            Assert.AreEqual(1, strings.MinFlips("0110"));
            Assert.AreEqual(0, strings.MinFlips("1000"));
            Assert.AreEqual(0, strings.MinFlips("111"));
        }

        [TestMethod]
        public void CountWordOccurrences_Examples()
        {
            CollectionAssert.AreEqual(new[] { 2, 1, 0 }, strings.CountWordOccurrences(
                new[] { "hello wor", "ld hello" },
                new[] { "hello", "world", "wor" }));

            CollectionAssert.AreEqual(new[] { 2, 1, 1 }, strings.CountWordOccurrences(
                new[] { "a-b a--b ", "a-", "b" },
                new[] { "a-b", "a", "b" }));

            CollectionAssert.AreEqual(new[] { 1, 1, 1, 0 }, strings.CountWordOccurrences(
                new[] { "-cat dog- mouse" },
                new[] { "cat", "dog", "mouse", "cat-dog" }));
        }

        [TestMethod]
        public void IsAdjacentDiffAtMostTwo_Examples()
        {
            Assert.IsTrue(strings.IsAdjacentDiffAtMostTwo("132"));
            Assert.IsFalse(strings.IsAdjacentDiffAtMostTwo("129"));
            Assert.IsTrue(strings.IsAdjacentDiffAtMostTwo("11"));
        }

        [TestMethod]
        public void PasswordStrength_Examples()
        {
            Assert.AreEqual(11, strings.PasswordStrength("aA1!"));
            Assert.AreEqual(11, strings.PasswordStrength("bbB11#"));
            Assert.AreEqual(1, strings.PasswordStrength("aaaa"));
        }

        [TestMethod]
        public void MaxTotal_Examples()
        {
            Assert.AreEqual(15L, strings.MaxTotal(new[] { 9, 2, 6, 1 }, "0101"));
            Assert.AreEqual(4L, strings.MaxTotal(new[] { 5, 1, 4 }, "001"));
            Assert.AreEqual(14L, strings.MaxTotal(new[] { 9, 3, 5 }, "011"));
            Assert.AreEqual(11L, strings.MaxTotal(new[] { 6, 5, 2 }, "011"));
        }

        [TestMethod]
        public void GenerateValidStrings_ExamplesAndEdge()
        {
            CollectionAssert.AreEquivalent(new[] { "000", "010", "100" }, new List<string>(strings.GenerateValidStrings(3, 1)));
            CollectionAssert.AreEquivalent(new[] { "0", "1" }, new List<string>(strings.GenerateValidStrings(1, 0)));
            CollectionAssert.AreEquivalent(new[] { "00", "01", "10" }, new List<string>(strings.GenerateValidStrings(2, 1)));
        }

        [TestMethod]
        public void MaxDistance_Examples()
        {
            Assert.AreEqual(4, strings.MaxDistance("L_D_"));
            Assert.AreEqual(3, strings.MaxDistance("U_R"));
            Assert.AreEqual(2, strings.MaxDistance("LR__"));
        }

        [TestMethod]
        public void ShortestPath_ExamplesAndEdge()
        {
            Assert.AreEqual(3, strings.ShortestPath(3, new[]
            {
                new[] { 0, 1, 1 },
                new[] { 1, 2, 1 },
                new[] { 0, 2, 3 }
            }, "aab", 1));

            Assert.AreEqual(2, strings.ShortestPath(3, new[]
            {
                new[] { 0, 1, 1 },
                new[] { 1, 2, 1 },
                new[] { 0, 2, 3 }
            }, "aab", 2));

            Assert.AreEqual(-1, strings.ShortestPath(3, new[]
            {
                new[] { 0, 1, 1 },
                new[] { 1, 2, 1 }
            }, "aaa", 2));

            Assert.AreEqual(0, strings.ShortestPath(1, Array.Empty<int[]>(), "a", 1));
        }

        [TestMethod]
        public void MinOperations_TwoStringExamples()
        {
            Assert.AreEqual(1, strings.MinOperations("11", "00"));
            Assert.AreEqual(3, strings.MinOperations("01", "10"));
            Assert.AreEqual(-1, strings.MinOperations("1", "0"));
            Assert.AreEqual(2, strings.MinOperations("00", "11"));
        }

        [TestMethod]
        public void InterleaveCharacters_ExamplesAndEdge()
        {
            Assert.AreEqual(5, strings.InterleaveCharacters("abc", "bac", "abc"));
            Assert.AreEqual(4, strings.InterleaveCharacters("cd", "cd", "ccd"));
            Assert.AreEqual(1, strings.InterleaveCharacters("ab", "cde", "ace"));
        }

        [TestMethod]
        public void SecondsBetweenTimes_Examples()
        {
            Assert.AreEqual(25, strings.SecondsBetweenTimes("01:00:00", "01:00:25"));
            Assert.AreEqual(1504, strings.SecondsBetweenTimes("12:34:56", "13:00:00"));
            Assert.AreEqual(0, strings.SecondsBetweenTimes("00:00:00", "00:00:00"));
        }

        [TestMethod]
        public void RearrangeString_Examples()
        {
            AssertRearrangedAvoidingPair("aabc", 'a', 'c', strings.RearrangeString("aabc", 'a', 'c'));
            AssertRearrangedAvoidingPair("dcab", 'd', 'b', strings.RearrangeString("dcab", 'd', 'b'));
            AssertRearrangedAvoidingPair("axe", 'o', 'x', strings.RearrangeString("axe", 'o', 'x'));
        }

        [TestMethod]
        public void MinCost_StringConversionExamples()
        {
            Assert.AreEqual(7, strings.MinCost(
                "hello",
                "world",
                new List<IList<string>> { new List<string> { "he", "wo" }, new List<string> { "llo", "rld" } },
                new[] { 3, 4 }));

            Assert.AreEqual(3, strings.MinCost(
                "cat",
                "dog",
                new List<IList<string>> { new List<string> { "c*t", "dog" } },
                new[] { 2 }));

            Assert.AreEqual(6, strings.MinCost(
                "test",
                "next",
                new List<IList<string>> { new List<string> { "*e*t", "next" } },
                new[] { 4 }));

            Assert.AreEqual(-1, strings.MinCost(
                "ab",
                "bc",
                new List<IList<string>> { new List<string> { "a*", "bd" } },
                new[] { 9 }));
        }

        [TestMethod]
        public void TransformStr_ExamplesAndEdge()
        {
            CollectionAssert.AreEqual(new[] { true, true, false }, strings.TransformStr("101", new[] { "1?1", "0?1", "0?0" }));
            CollectionAssert.AreEqual(new[] { true, false, true }, strings.TransformStr("1100", new[] { "0011", "11?1", "1?1?" }));
            CollectionAssert.AreEqual(new[] { true }, strings.TransformStr("1010", new[] { "0011" }));
        }

        [TestMethod]
        public void MinimumGroups_Examples()
        {
            Assert.AreEqual(1, strings.MinimumGroups(new[] { "ntgwz", "zwntg" }));
            Assert.AreEqual(3, strings.MinimumGroups(new[] { "abc", "cab", "bac", "acb", "bca", "cba" }));
            Assert.AreEqual(5, strings.MinimumGroups(new[] { "leet", "abb", "bab", "deed", "edde", "code", "bba" }));
        }

        [TestMethod]
        public void CountValidPrefixes_Examples()
        {
            Assert.AreEqual(3, strings.CountValidPrefixes("00101"));
            Assert.AreEqual(3, strings.CountValidPrefixes("101"));
            Assert.AreEqual(1, strings.CountValidPrefixes("00"));
        }

        [TestMethod]
        public void MaximumGap_Examples()
        {
            Assert.AreEqual(3, strings.MaximumGap("aa", "aaaa"));
            Assert.AreEqual(2, strings.MaximumGap("xyz", "xyzz"));
            Assert.AreEqual(4, strings.MaximumGap("cbc", "cbcdbc"));
        }

        private static void AssertRearrangedAvoidingPair(string original, char x, char y, string actual)
        {
            Assert.AreEqual(original.Length, actual.Length);
            CollectionAssert.AreEquivalent(original.ToCharArray(), actual.ToCharArray());
            int lastY = actual.LastIndexOf(y);
            int firstX = actual.IndexOf(x);
            if (lastY >= 0 && firstX >= 0)
                Assert.IsTrue(lastY < firstX);
        }

        private static void AssertIntNestedEquivalent(string[] expected, IList<IList<int>> actual)
        {
            var normalized = new List<string>();
            foreach (var group in actual)
                normalized.Add(string.Join(",", group));

            CollectionAssert.AreEquivalent(expected, normalized);
        }

        private static void AssertModifiedString(string original, string actual)
        {
            Assert.AreEqual(original.Length, actual.Length);
            Assert.IsFalse(actual.Contains("?"));
            for (int i = 0; i < actual.Length; i++)
            {
                if (original[i] != '?')
                    Assert.AreEqual(original[i], actual[i]);
                if (i > 0)
                    Assert.AreNotEqual(actual[i - 1], actual[i]);
            }
        }

        private static void AssertNestedEquivalent(string[] expected, IList<IList<string>> actual)
        {
            var normalized = new List<string>();
            foreach (var partition in actual)
                normalized.Add(string.Join("|", partition));

            CollectionAssert.AreEquivalent(expected, normalized);
        }
    }
}
