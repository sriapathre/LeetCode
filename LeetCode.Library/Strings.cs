using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Strings
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-substring-without-repeating-characters/">3. Longest Substring Without Repeating Characters (medium)</a>
        /// Given a string s, return the length of the longest substring that contains no repeated characters.
        /// </summary>
        /// <param name="s">The string to scan for the longest substring with all unique characters.</param>
        /// <returns>The maximum length of a substring in <paramref name="s"/> without repeating characters.</returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var lastSeen = new Dictionary<char, int>();
            int left = 0;
            int longest = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (lastSeen.TryGetValue(s[right], out int previousIndex) &&
                    previousIndex >= left)
                {
                    left = previousIndex + 1;
                }

                lastSeen[s[right]] = right;
                longest = Math.Max(longest, right - left + 1);
            }

            return longest;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/roman-to-integer/">13. Roman to Integer (easy)</a>
        /// Given a Roman numeral, convert it to its integer value using standard subtraction rules.
        /// </summary>
        /// <param name="s">The Roman numeral string to convert.</param>
        /// <returns>The integer value represented by <paramref name="s"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/valid-parentheses/">20. Valid Parentheses (easy)</a>
        /// Given a string containing only brackets, determine whether every opening bracket is closed in the correct order.
        /// </summary>
        /// <param name="s">The bracket string to validate.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> is well-formed; otherwise, <see langword="false"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/">28. Find the Index of the First Occurrence in a String (easy)</a>
        /// Return the index of the first occurrence of <paramref name="needle"/> in <paramref name="haystack"/>, or -1 if it does not appear.
        /// </summary>
        /// <param name="haystack">The string to search within.</param>
        /// <param name="needle">The substring to find.</param>
        /// <returns>The zero-based index of the first match, or -1 when no match exists.</returns>
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
        /// <a href="https://leetcode.com/problems/length-of-last-word/">58. Length of Last Word (easy)</a>
        /// Given a string of words and spaces, return the length of its last word.
        /// </summary>
        /// <param name="s">The input string containing words separated by spaces.</param>
        /// <returns>The number of characters in the last word of <paramref name="s"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/add-binary/">67. Add Binary (easy)</a>
        /// Given two binary strings, return their sum as another binary string.
        /// </summary>
        /// <param name="a">The first binary number.</param>
        /// <param name="b">The second binary number.</param>
        /// <returns>The binary representation of the sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/minimum-window-substring/">76. Minimum Window Substring (hard)</a>
        /// Given strings s and t, return the smallest substring of s that contains every character from t.
        /// </summary>
        /// <param name="s">The source string to search for a covering window.</param>
        /// <param name="t">The string whose characters must all appear in the window.</param>
        /// <returns>The minimum covering substring, or an empty string if no such window exists.</returns>
        public string MinWindow(string s, string t)
        {
            Span<int> window = stackalloc int[128];
            Span<int> need = stackalloc int[128];

            int required = 0;
            foreach (var c in t)
            {
                if (need[(int)c] == 0) required++;
                need[(int)c]++;
            }

            int i = 0;
            int minLen = int.MaxValue, start = -1;
            int match = 0;

            for (int j = 0; j < s.Length; j++)
            {
                var c = (int)s[j];
                window[c]++;

                if (need[c] == window[c]) match++;

                while (i <= j && match == required)
                {
                    if ((j - i + 1) < minLen)
                    {
                        minLen = j - i + 1;
                        start = i;
                    }

                    var idx = (int)s[i];
                    if (need[idx] == window[idx]) match--;
                    window[idx]--;
                    i++;
                }
            }

            return start == -1 ? "" : s[start..(start + minLen)];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-palindrome/">125. Valid Palindrome (easy)</a>
        /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        /// </summary>
        /// <param name="s">a string s</param>
        /// <returns>true if it is a palindrome, or false otherwise</returns>
        public bool IsPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s) && s.Length == 0)
                return true;
            int start = 0, last = s.Length - 1;
            while (start < last)
            {
                while (start < s.Length && !Char.IsLetter(s[start]) && !Char.IsDigit(s[start]))
                    start++;
                while (last >= 0 && !Char.IsLetter(s[last]) && !Char.IsDigit(s[last]))
                    last--;
                if (start < last && !Char.ToUpper(s[start++]).Equals(Char.ToUpper(s[last--])))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/excel-sheet-column-number/">171. Excel Sheet Column Number (easy)</a>
        /// Given an Excel-style column title, return its corresponding 1-based column number.
        /// </summary>
        /// <param name="columnTitle">The Excel column title to convert.</param>
        /// <returns>The numeric index represented by <paramref name="columnTitle"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/isomorphic-strings/">205. Isomorphic Strings (easy)</a>
        /// Determine whether characters in one string can be replaced to get the other string with a one-to-one mapping.
        /// </summary>
        /// <param name="s">The source string that defines the original character pattern.</param>
        /// <param name="t">The target string to compare against the pattern in <paramref name="s"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> and <paramref name="t"/> are isomorphic; otherwise, <see langword="false"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/valid-anagram/">242. Valid Anagram (easy)</a>
        /// Determine whether two strings contain the same characters with the same frequencies.
        /// </summary>
        /// <param name="s">The first string to compare.</param>
        /// <param name="t">The second string to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="t"/> is an anagram of <paramref name="s"/>; otherwise, <see langword="false"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/word-pattern/">290. Word Pattern (easy)</a>
        /// Given a character pattern and a space-delimited string, determine whether the words follow the same bijective pattern.
        /// </summary>
        /// <param name="pattern">The pattern string whose characters define the expected mapping.</param>
        /// <param name="s">The space-delimited words to validate against <paramref name="pattern"/>.</param>
        /// <returns><see langword="true"/> if the words follow the pattern; otherwise, <see langword="false"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/reverse-string/">344. Reverse String (easy)</a>
        /// Reverse the characters of the input array in place using constant extra space.
        /// </summary>
        /// <param name="s">The character array to reverse in place.</param>
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
        /// <a href="https://leetcode.com/problems/ransom-note/">383. Ransom Note (easy)</a>
        /// Determine whether <paramref name="ransomNote"/> can be formed using the characters available in <paramref name="magazine"/>.
        /// </summary>
        /// <param name="ransomNote">The note string that needs to be constructed.</param>
        /// <param name="magazine">The source string that provides available characters.</param>
        /// <returns><see langword="true"/> if the ransom note can be constructed; otherwise, <see langword="false"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/first-unique-character-in-a-string/">387. First Unique Character in a String (easy)</a>
        /// Given a string, return the index of its first non-repeating character, or -1 if every character repeats.
        /// </summary>
        /// <param name="s">The string to scan for a unique character.</param>
        /// <returns>The index of the first unique character in <paramref name="s"/>, or -1 if none exists.</returns>
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
        /// <a href="https://leetcode.com/problems/find-the-difference/">389. Find the Difference (easy)</a>
        /// String t is formed by shuffling string s and adding one extra character. Return the added character.
        /// </summary>
        /// <param name="s">The original string before the extra character was added.</param>
        /// <param name="t">The shuffled string containing all characters from <paramref name="s"/> plus one extra.</param>
        /// <returns>The character that appears in <paramref name="t"/> but not in <paramref name="s"/>.</returns>
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
        /// <a href="https://leetcode.com/problems/add-strings/">415. Add Strings (easy)</a>
        /// Add two non-negative integers represented as strings and return the sum as a string.
        /// </summary>
        /// <param name="num1">The first non-negative integer string.</param>
        /// <param name="num2">The second non-negative integer string.</param>
        /// <returns>The decimal sum of <paramref name="num1"/> and <paramref name="num2"/> as a string.</returns>
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-all-anagrams-in-a-string/">438. Find All Anagrams in a String (medium)</a>
        /// Given strings s and p, return all starting indices where an anagram of p appears in s.
        /// </summary>
        /// <param name="s">The string to search for anagram matches.</param>
        /// <param name="p">The pattern string whose anagrams should be found.</param>
        /// <returns>A list of zero-based starting indices for each anagram of <paramref name="p"/> in <paramref name="s"/>.</returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            if (string.IsNullOrEmpty(p) || p.Length > s.Length)
                return result;

            Span<int> difference = stackalloc int[26];
            foreach (char c in p)
                difference[c - 'a']++;

            int remaining = p.Length;
            for (int i = 0; i < s.Length; i++)
            {
                int incoming = s[i] - 'a';
                if (difference[incoming] > 0)
                    remaining--;
                difference[incoming]--;

                if (i >= p.Length)
                {
                    int outgoing = s[i - p.Length] - 'a';
                    difference[outgoing]++;
                    if (difference[outgoing] > 0)
                        remaining++;
                }

                if (remaining == 0)
                    result.Add(i - p.Length + 1);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/permutation-in-string/">567. Permutation in String (medium)</a>
        /// Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        /// </summary>
        /// <param name="s1">The string whose permutations are being searched for.</param>
        /// <param name="s2">The string that may contain a permutation of <paramref name="s1"/>.</param>
        /// <returns><see langword="true"/> if any permutation of <paramref name="s1"/> appears in <paramref name="s2"/>; otherwise, <see langword="false"/>.</returns>
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            Span<int> difference = stackalloc int[26];
            foreach (char c in s1)
                difference[c - 'a']++;

            int remaining = s1.Length;
            for (int i = 0; i < s2.Length; i++)
            {
                int incoming = s2[i] - 'a';
                if (difference[incoming] > 0)
                    remaining--;
                difference[incoming]--;

                if (i >= s1.Length)
                {
                    int outgoing = s2[i - s1.Length] - 'a';
                    difference[outgoing]++;
                    if (difference[outgoing] > 0)
                        remaining++;
                }

                if (remaining == 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-palindromic-substring/">5. Longest Palindromic Substring (medium)</a>
        /// Given a string s, return the longest palindromic substring in s.
        /// Example: s = "babad" -> "bab" (or "aba").
        /// Example: s = "cbbd" -> "bb".
        /// Complexity: O(n^2) time, O(1) extra space using expand-around-center.
        /// </summary>
        /// <param name="s">The string to search for its longest palindromic substring.</param>
        /// <returns>The longest contiguous substring of <paramref name="s"/> that is a palindrome.</returns>
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            int start = 0, maxLen = 1;

            int Expand(int left, int right)
            {
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    left--;
                    right++;
                }
                return right - left - 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = Expand(i, i);
                int len2 = Expand(i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > maxLen)
                {
                    maxLen = len;
                    start = i - (len - 1) / 2;
                }
            }

            return s.Substring(start, maxLen);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/zigzag-conversion/">6. Zigzag Conversion (medium)</a>
        /// The string is written in a zigzag pattern on a given number of rows and then read line by line.
        /// Example: s = "PAYPALISHIRING", numRows = 3 -> "PAHNAPLSIIGYIR".
        /// Example: numRows = 1 -> returns s unchanged.
        /// Complexity: O(n) time, O(n) space.
        /// </summary>
        /// <param name="s">The input string to write in zigzag order.</param>
        /// <param name="numRows">The number of rows in the zigzag pattern.</param>
        /// <returns>The string read row by row after arranging <paramref name="s"/> in zigzag form.</returns>
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1 || numRows >= s.Length)
                return s;

            var rows = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
                rows[i] = new StringBuilder();

            int row = 0;
            int direction = -1;
            foreach (var c in s)
            {
                rows[row].Append(c);
                if (row == 0 || row == numRows - 1)
                    direction = -direction;
                row += direction;
            }

            var result = new StringBuilder();
            foreach (var sb in rows)
                result.Append(sb);

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/string-to-integer-atoi/">8. String to Integer (atoi) (medium)</a>
        /// Converts a string to a 32-bit signed integer, skipping leading whitespace, honoring an optional sign,
        /// consuming digits until a non-digit is found, and clamping to the Int32 range on overflow.
        /// Example: "42" -> 42. Example: "   -42" -> -42. Example: "4193 with words" -> 4193. Example: "words and 987" -> 0.
        /// Complexity: O(n) time, O(1) space.
        /// </summary>
        /// <param name="s">The string to parse according to the atoi conversion rules.</param>
        /// <returns>The parsed 32-bit signed integer value after applying atoi rules to <paramref name="s"/>.</returns>
        public int MyAtoi(string s)
        {
            int i = 0;
            int n = s.Length;
            while (i < n && s[i] == ' ')
                i++;

            if (i == n)
                return 0;

            int sign = 1;
            if (s[i] == '+' || s[i] == '-')
            {
                sign = s[i] == '-' ? -1 : 1;
                i++;
            }

            long result = 0;
            while (i < n && char.IsDigit(s[i]))
            {
                result = result * 10 + (s[i] - '0');
                if (sign == 1 && result > int.MaxValue)
                    return int.MaxValue;
                if (sign == -1 && -result < int.MinValue)
                    return int.MinValue;
                i++;
            }

            return (int)(sign * result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/regular-expression-matching/">10. Regular Expression Matching (hard)</a>
        /// Implements regular expression matching supporting '.' (any single character) and '*' (zero or more of
        /// the preceding element), matching the entire input string s against pattern p.
        /// Example: s = "aa", p = "a*" -> true. Example: s = "mississippi", p = "mis*is*p*." -> false.
        /// Complexity: O(m*n) time and space using bottom-up dynamic programming.
        /// </summary>
        /// <param name="s">The input string to match.</param>
        /// <param name="p">The pattern that may contain '.' and '*'.</param>
        /// <returns><see langword="true"/> if <paramref name="p"/> matches the entire string <paramref name="s"/>; otherwise, <see langword="false"/>.</returns>
        public bool IsMatchRegex(string s, string p)
        {
            int m = s.Length, n = p.Length;
            var dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;

            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*' && j >= 2)
                    dp[0, j] = dp[0, j - 2];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                            dp[i, j] = dp[i, j] || dp[i - 1, j];
                    }
                }
            }

            return dp[m, n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/integer-to-roman/">12. Integer to Roman (medium)</a>
        /// Given an integer, convert it to a Roman numeral. 1 &lt;= num &lt;= 3999.
        /// Example: num = 3749 -> "MMMDCCXLIX". Example: num = 58 -> "LVIII". Example: num = 1994 -> "MCMXCIV".
        /// Complexity: O(1) time (bounded by fixed symbol table), O(1) space.
        /// </summary>
        /// <param name="num">The integer value to convert to Roman numerals.</param>
        /// <returns>The Roman numeral representation of <paramref name="num"/>.</returns>
        public string IntToRoman(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var sb = new StringBuilder();
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(symbols[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/letter-combinations-of-a-phone-number/">17. Letter Combinations of a Phone Number (medium)</a>
        /// Given a string containing digits 2-9, return all possible letter combinations that the number could
        /// represent, based on a standard telephone keypad mapping.
        /// Example: digits = "23" -> ["ad","ae","af","bd","be","bf","cd","ce","cf"]. Example: digits = "" -> [].
        /// Complexity: O(4^n * n) time in the worst case (digit 7/9 map to 4 letters), O(n) recursion depth.
        /// </summary>
        /// <param name="digits">The digit string from 2 to 9 to expand into keypad letters.</param>
        /// <returns>All possible letter combinations represented by <paramref name="digits"/>.</returns>
        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return result;

            var map = new Dictionary<char, string>
            {
                {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
                {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
            };

            var current = new StringBuilder();

            void Backtrack(int index)
            {
                if (index == digits.Length)
                {
                    result.Add(current.ToString());
                    return;
                }

                foreach (var c in map[digits[index]])
                {
                    current.Append(c);
                    Backtrack(index + 1);
                    current.Length--;
                }
            }

            Backtrack(0);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/generate-parentheses/">22. Generate Parentheses (medium)</a>
        /// Given n pairs of parentheses, generate all combinations of well-formed parentheses.
        /// Example: n = 3 -> ["((()))","(()())","(())()","()(())","()()()"]. Example: n = 1 -> ["()"].
        /// Complexity: O(4^n / sqrt(n)) time (Catalan number of valid combinations), O(n) recursion depth.
        /// </summary>
        /// <param name="n">The number of parenthesis pairs to generate.</param>
        /// <returns>All valid combinations of <paramref name="n"/> pairs of parentheses.</returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var current = new StringBuilder();

            void Backtrack(int open, int close)
            {
                if (current.Length == n * 2)
                {
                    result.Add(current.ToString());
                    return;
                }

                if (open < n)
                {
                    current.Append('(');
                    Backtrack(open + 1, close);
                    current.Length--;
                }

                if (close < open)
                {
                    current.Append(')');
                    Backtrack(open, close + 1);
                    current.Length--;
                }
            }

            Backtrack(0, 0);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/substring-with-concatenation-of-all-words/">30. Substring with Concatenation of All Words (hard)</a>
        /// Given a string s and an array of same-length words, return the starting indices of substrings in s
        /// that are a concatenation of each word in words exactly once, in any order, without intervening characters.
        /// Example: s = "barfoothefoobarman", words = ["foo","bar"] -> [0,9].
        /// Complexity: O(n*k) time where n = s.Length and k = words.Length, O(k) space for the word counts.
        /// </summary>
        /// <param name="s">The string to search for concatenated word sequences.</param>
        /// <param name="words">The list of equal-length words that must each appear exactly once.</param>
        /// <returns>A list of starting indices where a valid concatenation of all <paramref name="words"/> begins.</returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            if (words == null || words.Length == 0)
                return result;

            int wordLen = words[0].Length;
            int wordCount = words.Length;
            int totalLen = wordLen * wordCount;
            if (s.Length < totalLen)
                return result;

            var wordFreq = new Dictionary<string, int>();
            foreach (var w in words)
            {
                wordFreq.TryGetValue(w, out int c);
                wordFreq[w] = c + 1;
            }

            for (int i = 0; i <= s.Length - totalLen; i++)
            {
                var seen = new Dictionary<string, int>();
                int j = 0;
                for (; j < wordCount; j++)
                {
                    int start = i + j * wordLen;
                    var word = s.Substring(start, wordLen);
                    if (!wordFreq.ContainsKey(word))
                        break;

                    seen.TryGetValue(word, out int c);
                    seen[word] = c + 1;
                    if (seen[word] > wordFreq[word])
                        break;
                }

                if (j == wordCount)
                    result.Add(i);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-valid-parentheses/">32. Longest Valid Parentheses (hard)</a>
        /// Given a string containing just the characters '(' and ')', find the length of the longest valid
        /// (well-formed) parentheses substring.
        /// Example: s = "(()" -> 2. Example: s = ")()())" -> 4. Example: s = "" -> 0.
        /// Complexity: O(n) time, O(n) space using an index stack.
        /// </summary>
        /// <param name="s">The parentheses string to evaluate.</param>
        /// <returns>The length of the longest well-formed parentheses substring in <paramref name="s"/>.</returns>
        public int LongestValidParentheses(string s)
        {
            var stack = new Stack<int>();
            stack.Push(-1);
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        stack.Push(i);
                    else
                        maxLen = Math.Max(maxLen, i - stack.Peek());
                }
            }

            return maxLen;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-and-say/">38. Count and Say (medium)</a>
        /// The count-and-say sequence is a sequence of strings where countAndSay(1) = "1" and countAndSay(n) is the
        /// run-length encoded description of countAndSay(n - 1).
        /// Example: n = 1 -> "1". Example: n = 4 -> "1211" (from "1" -> "11" -> "21" -> "1211").
        /// Complexity: O(n * m) time where m is the resulting string length (grows exponentially with n), O(m) space.
        /// </summary>
        /// <param name="n">The 1-based position of the term to produce in the count-and-say sequence.</param>
        /// <returns>The <paramref name="n"/>th term of the count-and-say sequence.</returns>
        public string CountAndSay(int n)
        {
            string result = "1";
            for (int i = 1; i < n; i++)
            {
                var sb = new StringBuilder();
                int count = 1;
                for (int j = 1; j <= result.Length; j++)
                {
                    if (j < result.Length && result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count).Append(result[j - 1]);
                        count = 1;
                    }
                }
                result = sb.ToString();
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/multiply-strings/">43. Multiply Strings (medium)</a>
        /// Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and
        /// num2, also represented as a string, without converting the inputs directly to integers.
        /// Example: num1 = "2", num2 = "3" -> "6". Example: num1 = "123", num2 = "456" -> "56088".
        /// Complexity: O(m*n) time where m, n are the input lengths, O(m+n) space.
        /// </summary>
        /// <param name="num1">The first non-negative integer string to multiply.</param>
        /// <param name="num2">The second non-negative integer string to multiply.</param>
        /// <returns>The product of <paramref name="num1"/> and <paramref name="num2"/> as a string.</returns>
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            int m = num1.Length, n = num2.Length;
            var product = new int[m + n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int sumIndex = i + j + 1;
                    int sum = mul + product[sumIndex];

                    product[sumIndex] = sum % 10;
                    product[sumIndex - 1] += sum / 10;
                }
            }

            var sb = new StringBuilder();
            foreach (var digit in product)
            {
                if (!(sb.Length == 0 && digit == 0))
                    sb.Append(digit);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/wildcard-matching/">44. Wildcard Matching (hard)</a>
        /// Implements wildcard pattern matching with support for '?' (matches any single character) and '*'
        /// (matches any sequence of characters, including the empty sequence), matching the entire string s.
        /// Example: s = "aa", p = "*" -> true. Example: s = "cb", p = "?a" -> false.
        /// Complexity: O(m*n) time and space using bottom-up dynamic programming.
        /// </summary>
        /// <param name="s">The input string to match.</param>
        /// <param name="p">The wildcard pattern that may contain '?' and '*'.</param>
        /// <returns><see langword="true"/> if <paramref name="p"/> matches the entire string <paramref name="s"/>; otherwise, <see langword="false"/>.</returns>
        public bool IsMatchWildcard(string s, string p)
        {
            int m = s.Length, n = p.Length;
            var dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;

            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                    dp[0, j] = dp[0, j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '*')
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    else if (p[j - 1] == '?' || p[j - 1] == s[i - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                }
            }

            return dp[m, n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-number/">65. Valid Number (hard)</a>
        /// Determines if a string is a valid number, optionally signed, with an optional decimal point and/or an
        /// optional exponent ('e'/'E') followed by a signed integer.
        /// Example: "0" -> true. Example: "e" -> false. Example: "2e10" -> true. Example: "99e2.5" -> false.
        /// Complexity: O(n) time, O(1) space using a single left-to-right scan.
        /// </summary>
        /// <param name="s">The string to validate as a numeric literal.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> is a valid number; otherwise, <see langword="false"/>.</returns>
        public bool IsNumber(string s)
        {
            int i = 0, n = s.Length;
            bool sawDigit = false, sawDot = false, sawExp = false;

            if (i < n && (s[i] == '+' || s[i] == '-'))
                i++;

            while (i < n)
            {
                if (char.IsDigit(s[i]))
                {
                    sawDigit = true;
                    i++;
                }
                else if (s[i] == '.' && !sawDot && !sawExp)
                {
                    sawDot = true;
                    i++;
                }
                else if ((s[i] == 'e' || s[i] == 'E') && !sawExp && sawDigit)
                {
                    sawExp = true;
                    sawDigit = false;
                    i++;
                    if (i < n && (s[i] == '+' || s[i] == '-'))
                        i++;
                }
                else
                {
                    return false;
                }
            }

            return sawDigit;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/text-justification/">68. Text Justification (hard)</a>
        /// Given an array of words and a maxWidth, format the text so that each line has exactly maxWidth
        /// characters, fully justified (left and right), padding extra spaces as evenly as possible between words
        /// (favoring the left when uneven), except the last line which is left-justified.
        /// Example: words = ["This","is","an","example","of","text","justification."], maxWidth = 16 ->
        /// ["This    is    an", "example  of text", "justification.  "].
        /// Complexity: O(n) time overall where n is the total character count, O(n) space for the output.
        /// </summary>
        /// <param name="words">The sequence of words to format into justified lines.</param>
        /// <param name="maxWidth">The required width of each output line.</param>
        /// <returns>A list of fully justified lines built from <paramref name="words"/>.</returns>
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var result = new List<string>();
            int index = 0;

            while (index < words.Length)
            {
                int lineLen = words[index].Length;
                int last = index + 1;

                while (last < words.Length && lineLen + 1 + words[last].Length <= maxWidth)
                {
                    lineLen += 1 + words[last].Length;
                    last++;
                }

                int wordCount = last - index;
                var sb = new StringBuilder();

                if (last == words.Length || wordCount == 1)
                {
                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1)
                            sb.Append(' ');
                    }
                    sb.Append(' ', maxWidth - sb.Length);
                }
                else
                {
                    int totalSpaces = maxWidth - (lineLen - (wordCount - 1));
                    int gaps = wordCount - 1;
                    int spacePerGap = totalSpaces / gaps;
                    int extra = totalSpaces % gaps;

                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1)
                        {
                            int spaces = spacePerGap + (i - index < extra ? 1 : 0);
                            sb.Append(' ', spaces);
                        }
                    }
                }

                result.Add(sb.ToString());
                index = last;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/simplify-path/">71. Simplify Path (medium)</a>
        /// Given an absolute Unix-style file path, converts it to the simplified canonical path by resolving
        /// "." (current directory), ".." (parent directory) and collapsing multiple consecutive slashes.
        /// Example: path = "/home/" -> "/home". Example: path = "/../" -> "/". Example: path = "/a/./b/../../c/" -> "/c".
        /// Complexity: O(n) time, O(n) space using a stack of path segments.
        /// </summary>
        /// <param name="path">The absolute Unix-style path to simplify.</param>
        /// <returns>The canonical simplified form of <paramref name="path"/>.</returns>
        public string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            var segments = path.Split('/');

            foreach (var segment in segments)
            {
                if (segment == "" || segment == ".")
                    continue;
                if (segment == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(segment);
                }
            }

            if (stack.Count == 0)
                return "/";

            var parts = stack.ToArray();
            Array.Reverse(parts);
            return "/" + string.Join("/", parts);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/edit-distance/">72. Edit Distance (medium)</a>
        /// Given two strings word1 and word2, return the minimum number of single-character insert, delete, or
        /// replace operations required to convert word1 into word2 (Levenshtein distance).
        /// Example: word1 = "horse", word2 = "ros" -> 3. Example: word1 = "intention", word2 = "execution" -> 5.
        /// Complexity: O(m*n) time and space using bottom-up dynamic programming.
        /// </summary>
        /// <param name="word1">The source word to transform.</param>
        /// <param name="word2">The target word to reach.</param>
        /// <returns>The minimum number of insert, delete, or replace operations needed to convert <paramref name="word1"/> into <paramref name="word2"/>.</returns>
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            var dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
                dp[i, 0] = i;
            for (int j = 0; j <= n; j++)
                dp[0, j] = j;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1]));
                }
            }

            return dp[m, n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/scramble-string/">87. Scramble String (hard)</a>
        /// Determines whether s2 is a scrambled string of s1, where scrambling recursively splits a string into
        /// two non-empty substrings at some index and optionally swaps them, applying the process recursively.
        /// Example: s1 = "great", s2 = "rgeat" -> true. Example: s1 = "abcde", s2 = "caebd" -> false.
        /// Complexity: O(n^4) time with memoization, O(n^3) space for the memo cache.
        /// </summary>
        /// <param name="s1">The original string to compare.</param>
        /// <param name="s2">The candidate scrambled string.</param>
        /// <returns><see langword="true"/> if <paramref name="s2"/> is a scramble of <paramref name="s1"/>; otherwise, <see langword="false"/>.</returns>
        public bool IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var memo = new Dictionary<string, bool>();

            bool Helper(string a, string b)
            {
                if (a == b)
                    return true;

                string key = a + "#" + b;
                if (memo.TryGetValue(key, out bool cached))
                    return cached;

                var counts = new int[26];
                for (int i = 0; i < a.Length; i++)
                {
                    counts[a[i] - 'a']++;
                    counts[b[i] - 'a']--;
                }
                foreach (var c in counts)
                {
                    if (c != 0)
                    {
                        memo[key] = false;
                        return false;
                    }
                }

                int n = a.Length;
                for (int i = 1; i < n; i++)
                {
                    if (Helper(a.Substring(0, i), b.Substring(0, i)) && Helper(a.Substring(i), b.Substring(i)))
                    {
                        memo[key] = true;
                        return true;
                    }
                    if (Helper(a.Substring(0, i), b.Substring(n - i)) && Helper(a.Substring(i), b.Substring(0, n - i)))
                    {
                        memo[key] = true;
                        return true;
                    }
                }

                memo[key] = false;
                return false;
            }

            return Helper(s1, s2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decode-ways/">91. Decode Ways (medium)</a>
        /// Given a string s containing only digits, return the number of ways to decode it, where 'A'-'Z' map to
        /// "1"-"26".
        /// Example: s = "12" -> 2 ("AB", "L"). Example: s = "226" -> 3 ("BZ", "VF", "BBF"). Example: s = "06" -> 0.
        /// Complexity: O(n) time, O(1) space using rolling DP variables.
        /// </summary>
        /// <param name="s">The digit string to decode into alphabet mappings.</param>
        /// <returns>The number of valid decodings of <paramref name="s"/>.</returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            int n = s.Length;
            int prev2 = 1;
            int prev1 = 1;

            for (int i = 1; i < n; i++)
            {
                int current = 0;
                if (s[i] != '0')
                    current += prev1;

                int twoDigit = (s[i - 1] - '0') * 10 + (s[i] - '0');
                if (twoDigit >= 10 && twoDigit <= 26)
                    current += prev2;

                if (current == 0)
                    return 0;

                prev2 = prev1;
                prev1 = current;
            }

            return prev1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/restore-ip-addresses/">93. Restore IP Addresses (medium)</a>
        /// Given a string s containing only digits, return all possible valid IP address combinations that can be
        /// formed by inserting dots into s (four segments 0-255 each, no leading zeros unless the segment is "0").
        /// Example: s = "25525511135" -> ["255.255.11.135","255.255.111.35"]. Example: s = "0000" -> ["0.0.0.0"].
        /// Complexity: O(1) time in practice (bounded by fixed 4-segment structure, at most 3^4 candidates), O(1) extra space beyond output.
        /// </summary>
        /// <param name="s">The digit string to split into valid IP address segments.</param>
        /// <returns>All valid IP addresses that can be formed from <paramref name="s"/>.</returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            var result = new List<string>();
            if (s.Length < 4 || s.Length > 12)
                return result;

            var segments = new string[4];

            void Backtrack(int start, int segmentIndex)
            {
                if (segmentIndex == 4)
                {
                    if (start == s.Length)
                        result.Add(string.Join(".", segments));
                    return;
                }

                for (int len = 1; len <= 3 && start + len <= s.Length; len++)
                {
                    string segment = s.Substring(start, len);
                    if ((segment.Length > 1 && segment[0] == '0') || int.Parse(segment) > 255)
                        continue;

                    segments[segmentIndex] = segment;
                    Backtrack(start + len, segmentIndex + 1);
                }
            }

            Backtrack(0, 0);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/interleaving-string/">97. Interleaving String (medium)</a>
        /// Given strings s1, s2, and s3, return true if s3 is formed by an interleaving of s1 and s2, preserving
        /// the relative order of characters from each source string.
        /// Example: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac" -> true.
        /// Example: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc" -> false.
        /// Complexity: O(m*n) time and space using bottom-up dynamic programming.
        /// </summary>
        /// <param name="s1">The first source string.</param>
        /// <param name="s2">The second source string.</param>
        /// <param name="s3">The candidate string formed by interleaving <paramref name="s1"/> and <paramref name="s2"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="s3"/> is a valid interleaving of <paramref name="s1"/> and <paramref name="s2"/>; otherwise, <see langword="false"/>.</returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int m = s1.Length, n = s2.Length;
            if (m + n != s3.Length)
                return false;

            var dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;

            for (int i = 1; i <= m; i++)
                dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
            for (int j = 1; j <= n; j++)
                dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) ||
                               (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                }
            }

            return dp[m, n];
        }
    }
}
