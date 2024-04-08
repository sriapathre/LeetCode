using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Strings
    {
        /// <summary>
        /// 13. Roman to Integer (easy)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            Dictionary<char, int> RomanValues = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && RomanValues[s[i]] < RomanValues[s[i + 1]])
                {
                    result += (RomanValues[s[i + 1]] - RomanValues[s[i]]);
                    i++;
                }
                else
                    result += RomanValues[s[i]];
            }
            return result;
        }

        /// <summary>
        /// 20. Valid Parentheses (easy)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> chars = new Stack<char>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        chars.Push(c);
                        break;
                    case ')':
                        if (chars.Count == 0 || chars.Pop() != '(')
                            return false;
                        break;
                    case '}':
                        if (chars.Count == 0 || chars.Pop() != '{')
                            return false;
                        break;
                    case ']':
                        if (chars.Count == 0 || chars.Pop() != '[')
                            return false;
                        break;
                }
            }
            return chars.Count == 0;
        }

        /// <summary>
        /// 28. Find the Index of the First Occurrence in a String (easy)
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;
            for (int i = 0; i <= haystack.Length; i++)
            {
                if (haystack.Length - i < needle.Length)
                    break;
                int h = i, n = 0;
                while (n < needle.Length && haystack[h] == needle[n])
                {
                    h++;
                    n++;
                }
                if (h == i + needle.Length)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 58. Length of Last Word (easy)
        /// Given a string s consisting of words and spaces, return the length of the last word in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != ' ')
                    count++;
                else if (count > 0)
                    break;
            }

            return count;
        }

        /// <summary>
        /// 67. Add Binary (easy)
        /// Given two binary strings a and b, return their sum as a binary string.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = a.Length - 1, j = b.Length - 1, carry = 0; i >= 0 || j >= 0 || carry == 1; i--, j--)
            {
                int sum = carry;
                if (i >= 0)
                    sum += a[i] - '0';
                if (j >= 0)
                    sum += b[j] - '0';
                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }
            return sb.ToString();
        }
        /// <summary>
        /// 171. Excel Sheet Column Number (easy)
        /// </summary>
        /// <param name="columnTitle"></param>
        /// <returns></returns>
        public int TitleToNumber(string columnTitle)
        {
            int total = 0;
            for (int i = 0; i < columnTitle.Length; i++)
            {
                total *= 26;
                total += columnTitle[i] - 'A' + 1;
            }
            return total;
        }

        /// <summary>
        /// 205. Isomorphic Strings (easy)
        /// </summary>
        /// <param name="s">First String</param>
        /// <param name="t">Second String</param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            if (s?.Length != t?.Length)
                return false;
            Dictionary<char, char> map = new Dictionary<char, char>();
            Dictionary<char, char> reverseMap = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];
                if (!map.ContainsKey(c1) && !reverseMap.ContainsKey(c2))
                {
                    map.Add(c1, c2);
                    reverseMap.Add(c2, c1);
                }
                else
                {
                    map.TryGetValue(c1, out char val1);
                    reverseMap.TryGetValue(c2, out char val2);
                    if (val1 != c2 || val2 != c1)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 242. Valid Anagram (easy)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if ((s?.Length != t?.Length) || (s == null && t == null))
                return false;
            int[] map = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i] - 'a']++;
                map[t[i] - 'a']--;
            }
            foreach (var item in map)
            {
                if (item != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 290. Word Pattern (easy)
        /// Given a pattern and a string s, find if s follows the same pattern.
        /// Similar to 205. Isomorphic Strings
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool WordPattern(string pattern, string s)
        {
            Dictionary<char, string> map = new Dictionary<char, string>();
            Dictionary<string, char> reverseMap = new Dictionary<string, char>();
            var words = s.Split(' ');
            if (pattern.Length != words.Length)
                return false;
            for (int i = 0; i < pattern.Length; i++)
            {
                var c = pattern[i];
                var word = words[i];
                if (!map.ContainsKey(c) && !reverseMap.ContainsKey(word))
                {
                    map.Add(c, words[i]);
                    reverseMap.Add(words[i], c);
                }
                else
                {
                    map.TryGetValue(c, out string val1);
                    reverseMap.TryGetValue(word, out char val2);
                    if (val1 != word || val2 != c)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 344. Reverse string (easy)
        /// Write a function that reverses a string. The input string is given as an array of characters s.
        /// You must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }

        /// <summary>
        /// 383. Ransom Note (easy)
        /// Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length)
                return false;
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (var c in magazine)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }
            foreach (var c in ransomNote)
            {
                if (map.ContainsKey(c))
                {
                    map[c]--;
                    if (map[c] < 0)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 387. First Unique Character in a String (easy)
        /// Given a string s, return the first non-repeating character in it and return its index. If it does
        public int FirstUniqChar(string s)
        {
            int[] map = new int[26];
            foreach (var c in s)
            {
                map[c - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i] - 'a'] == 1)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 389. Find the Difference (easy)
        /// String t is generated by random shuffling string s and then add one more letter at a random position.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns>Return the letter that was added to t.</returns>
        public char FindTheDifference(string s, string t)
        {
            if (s.Length + 1 != t.Length)
                throw new ArgumentException("Invalid input");
            int[] map = new int[26];
            foreach (var c in s)
            {
                map[c - 'a']++;
            }
            foreach (var c in t)
            {
                map[c - 'a']--;
                if (map[c - 'a'] < 0)
                    return c;
            }

            return '\0';
        }

        /// <summary>
        /// 415. Add Strings (easy)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            var l1 = num1.Length;
            var l2 = num2.Length;
            int carry = 0;
            for (int i = l1 - 1, j = l2 - 1; i >= 0 || j >= 0; i--, j--)
            {
                var n1 = i >= 0 ? num1[i] - '0' : 0;
                var n2 = j >= 0 ? num2[j] - '0' : 0;
                var sum = n1 + n2 + carry;
                sb.Insert(0, sum % 10);
                carry = sum / 10;
            }
            if (carry > 0)
                sb.Insert(0, carry);
            return sb.ToString();
        }
    }
}
