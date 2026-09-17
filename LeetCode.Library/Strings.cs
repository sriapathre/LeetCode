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
        /// <a href="https://leetcode.com/problems/distinct-subsequences/">115. Distinct Subsequences (hard)</a>
        /// Counts how many distinct subsequences of <paramref name="s"/> are equal to <paramref name="t"/> using dynamic programming.
        /// </summary>
        /// <param name="s">The source string from which characters may be deleted.</param>
        /// <param name="t">The target string to form as a subsequence.</param>
        /// <returns>The number of distinct subsequences of <paramref name="s"/> that equal <paramref name="t"/>.</returns>
        public int NumDistinct(string s, string t)
        {
            if (t.Length == 0)
                return 1;
            if (s.Length < t.Length)
                return 0;

            long[] dp = new long[t.Length + 1];
            dp[0] = 1;

            foreach (char source in s)
            {
                for (int j = t.Length - 1; j >= 0; j--)
                {
                    if (source == t[j])
                        dp[j + 1] += dp[j];
                }
            }

            return (int)dp[t.Length];
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
        /// <a href="https://leetcode.com/problems/palindrome-partitioning/">131. Palindrome Partitioning (medium)</a>
        /// Returns every way to split <paramref name="s"/> into substrings where each substring is a palindrome.
        /// </summary>
        /// <param name="s">The string to partition into palindromic substrings.</param>
        /// <returns>All palindrome-only partitions of <paramref name="s"/>.</returns>
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            int n = s.Length;
            var palindrome = BuildPalindromeTable(s);
            var current = new List<string>();

            void Backtrack(int start)
            {
                if (start == n)
                {
                    result.Add(new List<string>(current));
                    return;
                }

                for (int end = start; end < n; end++)
                {
                    if (!palindrome[start, end])
                        continue;

                    current.Add(s.Substring(start, end - start + 1));
                    Backtrack(end + 1);
                    current.RemoveAt(current.Count - 1);
                }
            }

            Backtrack(0);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/palindrome-partitioning-ii/">132. Palindrome Partitioning II (hard)</a>
        /// Finds the minimum number of cuts needed so every resulting substring of <paramref name="s"/> is a palindrome.
        /// </summary>
        /// <param name="s">The string to split into palindromic pieces.</param>
        /// <returns>The fewest cuts required for a palindrome partitioning of <paramref name="s"/>.</returns>
        public int MinCut(string s)
        {
            int n = s.Length;
            if (n <= 1)
                return 0;

            var palindrome = BuildPalindromeTable(s);
            int[] cuts = new int[n];

            for (int end = 0; end < n; end++)
            {
                if (palindrome[0, end])
                {
                    cuts[end] = 0;
                    continue;
                }

                int best = end;
                for (int start = 1; start <= end; start++)
                {
                    if (palindrome[start, end])
                        best = Math.Min(best, cuts[start - 1] + 1);
                }

                cuts[end] = best;
            }

            return cuts[n - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/word-break/">139. Word Break (medium)</a>
        /// Determines whether <paramref name="s"/> can be segmented into a space-separated sequence of dictionary words.
        /// </summary>
        /// <param name="s">The string to segment.</param>
        /// <param name="wordDict">The dictionary words that may be reused.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> can be segmented; otherwise, <see langword="false"/>.</returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var words = new HashSet<string>(wordDict);
            int maxWordLength = 0;
            foreach (string word in wordDict)
                maxWordLength = Math.Max(maxWordLength, word.Length);

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int end = 1; end <= s.Length; end++)
            {
                for (int start = Math.Max(0, end - maxWordLength); start < end; start++)
                {
                    if (dp[start] && words.Contains(s.Substring(start, end - start)))
                    {
                        dp[end] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/word-break-ii/">140. Word Break II (hard)</a>
        /// Builds all sentences formed by inserting spaces into <paramref name="s"/> so every token is in the dictionary.
        /// </summary>
        /// <param name="s">The string to split into dictionary words.</param>
        /// <param name="wordDict">The dictionary words that may be reused.</param>
        /// <returns>All valid dictionary-word sentences that concatenate to <paramref name="s"/>.</returns>
        public IList<string> WordBreakII(string s, IList<string> wordDict)
        {
            var words = new HashSet<string>(wordDict);
            var memo = new Dictionary<int, IList<string>>();
            int maxWordLength = 0;
            foreach (string word in wordDict)
                maxWordLength = Math.Max(maxWordLength, word.Length);

            IList<string> SentencesFrom(int index)
            {
                if (memo.TryGetValue(index, out var cached))
                    return cached;

                var sentences = new List<string>();
                if (index == s.Length)
                {
                    sentences.Add(string.Empty);
                    memo[index] = sentences;
                    return sentences;
                }

                int maxEnd = Math.Min(s.Length, index + maxWordLength);
                for (int end = index + 1; end <= maxEnd; end++)
                {
                    string word = s.Substring(index, end - index);
                    if (!words.Contains(word))
                        continue;

                    foreach (string suffix in SentencesFrom(end))
                        sentences.Add(suffix.Length == 0 ? word : $"{word} {suffix}");
                }

                memo[index] = sentences;
                return sentences;
            }

            return SentencesFrom(0);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-words-in-a-string/">151. Reverse Words in a String (medium)</a>
        /// Reverses the order of words in <paramref name="s"/>, trimming leading/trailing spaces and reducing inner spaces to one.
        /// </summary>
        /// <param name="s">The input string containing words separated by spaces.</param>
        /// <returns>The words from <paramref name="s"/> in reverse order with single spaces between them.</returns>
        public string ReverseWords(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
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
        /// <a href="https://leetcode.com/problems/compare-version-numbers/">165. Compare Version Numbers (medium)</a>
        /// Compares two dot-separated version strings revision by revision, ignoring leading zeroes.
        /// </summary>
        /// <param name="version1">The first version string.</param>
        /// <param name="version2">The second version string.</param>
        /// <returns>1 if <paramref name="version1"/> is greater, -1 if it is smaller, or 0 if both versions are equal.</returns>
        public int CompareVersion(string version1, string version2)
        {
            int i = 0, j = 0;

            while (i < version1.Length || j < version2.Length)
            {
                int start1 = i;
                while (i < version1.Length && version1[i] != '.')
                    i++;
                int end1 = i;

                int start2 = j;
                while (j < version2.Length && version2[j] != '.')
                    j++;
                int end2 = j;

                while (start1 < end1 && version1[start1] == '0')
                    start1++;
                while (start2 < end2 && version2[start2] == '0')
                    start2++;

                int length1 = end1 - start1;
                int length2 = end2 - start2;
                if (length1 != length2)
                    return length1 > length2 ? 1 : -1;

                for (int k = 0; k < length1; k++)
                {
                    if (version1[start1 + k] != version2[start2 + k])
                        return version1[start1 + k] > version2[start2 + k] ? 1 : -1;
                }

                i++;
                j++;
            }

            return 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-number/">179. Largest Number (medium)</a>
        /// Arranges non-negative integers so their concatenation forms the largest possible number.
        /// </summary>
        /// <param name="nums">The non-negative integers to arrange.</param>
        /// <returns>The largest concatenated number that can be formed from <paramref name="nums"/>.</returns>
        public string LargestNumber(int[] nums)
        {
            string[] values = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                values[i] = nums[i].ToString();

            Array.Sort(values, (a, b) => string.CompareOrdinal(b + a, a + b));

            if (values.Length == 0 || values[0] == "0")
                return "0";

            var result = new StringBuilder();
            foreach (string value in values)
                result.Append(value);

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/repeated-dna-sequences/">187. Repeated DNA Sequences (medium)</a>
        /// Finds all 10-letter-long DNA substrings that occur more than once in <paramref name="s"/>.
        /// </summary>
        /// <param name="s">The DNA string containing only A, C, G, and T.</param>
        /// <returns>Every repeated 10-character DNA sequence in <paramref name="s"/>.</returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var result = new List<string>();
            if (s.Length < 10)
                return result;

            var seen = new Dictionary<int, int>();
            int hash = 0;
            int mask = (1 << 20) - 1;

            for (int i = 0; i < s.Length; i++)
            {
                hash = ((hash << 2) | EncodeDna(s[i])) & mask;
                if (i < 9)
                    continue;

                seen.TryGetValue(hash, out int count);
                if (count == 1)
                    result.Add(s.Substring(i - 9, 10));
                seen[hash] = count + 1;
            }

            return result;
        }

        private static bool[,] BuildPalindromeTable(string s)
        {
            int n = s.Length;
            var palindrome = new bool[n, n];

            for (int start = n - 1; start >= 0; start--)
            {
                for (int end = start; end < n; end++)
                {
                    palindrome[start, end] = s[start] == s[end] && (end - start < 2 || palindrome[start + 1, end - 1]);
                }
            }

            return palindrome;
        }

        private static int EncodeDna(char c)
        {
            return c switch
            {
                'A' => 0,
                'C' => 1,
                'G' => 2,
                _ => 3
            };
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-palindrome/">214. Shortest Palindrome (hard)</a>
        /// Finds the shortest palindrome that can be made by adding characters in front of <paramref name="s"/>.
        /// Uses a KMP prefix table over s + separator + reverse(s) to find the longest palindromic prefix.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The input string to extend at the front.</param>
        /// <returns>The shortest palindrome formed by prepending characters to <paramref name="s"/>.</returns>
        public string ShortestPalindrome(string s)
        {
            if (s.Length <= 1)
                return s;

            char[] reversedChars = s.ToCharArray();
            Array.Reverse(reversedChars);
            string reversed = new string(reversedChars);
            string combined = s + "#" + reversed;
            int[] prefix = new int[combined.Length];

            for (int i = 1; i < combined.Length; i++)
            {
                int j = prefix[i - 1];
                while (j > 0 && combined[i] != combined[j])
                    j = prefix[j - 1];
                if (combined[i] == combined[j])
                    j++;
                prefix[i] = j;
            }

            return reversed.Substring(0, s.Length - prefix[combined.Length - 1]) + s;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/basic-calculator-ii/">227. Basic Calculator II (medium)</a>
        /// Evaluates a non-negative integer expression containing '+', '-', '*', '/', and spaces using normal operator precedence.
        /// Division truncates toward zero, matching C# and LeetCode behavior.
        /// Complexity: O(n) time and O(1) extra space.
        /// </summary>
        /// <param name="s">The arithmetic expression to evaluate.</param>
        /// <returns>The integer value of <paramref name="s"/>.</returns>
        public int Calculate(string s)
        {
            int result = 0, previous = 0, current = 0;
            char operation = '+';

            for (int i = 0; i <= s.Length; i++)
            {
                char c = i < s.Length ? s[i] : '+';
                if (i < s.Length && c == ' ')
                    continue;

                if (i < s.Length && char.IsDigit(c))
                {
                    current = current * 10 + c - '0';
                    continue;
                }

                switch (operation)
                {
                    case '+':
                        result += previous;
                        previous = current;
                        break;
                    case '-':
                        result += previous;
                        previous = -current;
                        break;
                    case '*':
                        previous *= current;
                        break;
                    case '/':
                        previous /= current;
                        break;
                }

                operation = c;
                current = 0;
            }

            return result + previous;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/integer-to-english-words/">273. Integer to English Words (hard)</a>
        /// Converts a non-negative integer to its English words representation using three-digit chunks and scale names.
        /// Complexity: O(1) time and O(1) space because the integer has bounded size.
        /// </summary>
        /// <param name="num">The non-negative integer to convert.</param>
        /// <returns>The English words representation of <paramref name="num"/>.</returns>
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            string[] scales = { "", "Thousand", "Million", "Billion" };
            var parts = new List<string>();
            int scale = 0;

            while (num > 0)
            {
                int chunk = num % 1000;
                if (chunk != 0)
                {
                    string words = ThreeDigitNumberToWords(chunk);
                    if (scales[scale].Length > 0)
                        words += " " + scales[scale];
                    parts.Add(words);
                }

                num /= 1000;
                scale++;
            }

            parts.Reverse();
            return string.Join(" ", parts);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-duplicate-letters/">316. Remove Duplicate Letters (medium)</a>
        /// Removes duplicate letters so every letter appears once and the resulting string is lexicographically smallest.
        /// Maintains a monotonic stack while preserving enough future occurrences to include every distinct letter.
        /// Complexity: O(n) time and O(1) space for lowercase English letters.
        /// </summary>
        /// <param name="s">The lowercase string to reduce.</param>
        /// <returns>The lexicographically smallest subsequence containing each distinct character exactly once.</returns>
        public string RemoveDuplicateLetters(string s)
        {
            int[] remaining = new int[26];
            foreach (char c in s)
                remaining[c - 'a']++;

            bool[] used = new bool[26];
            var stack = new List<char>();
            foreach (char c in s)
            {
                int index = c - 'a';
                remaining[index]--;
                if (used[index])
                    continue;

                while (stack.Count > 0 && stack[stack.Count - 1] > c && remaining[stack[stack.Count - 1] - 'a'] > 0)
                {
                    used[stack[stack.Count - 1] - 'a'] = false;
                    stack.RemoveAt(stack.Count - 1);
                }

                stack.Add(c);
                used[index] = true;
            }

            return new string(stack.ToArray());
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-product-of-word-lengths/">318. Maximum Product of Word Lengths (medium)</a>
        /// Finds the largest product of lengths of two words that share no common letters using lowercase bit masks.
        /// Complexity: O(n^2 + total characters) time and O(n) space.
        /// </summary>
        /// <param name="words">The lowercase words to compare.</param>
        /// <returns>The maximum length product for a pair with no shared letters, or 0 if none exists.</returns>
        public int MaxProduct(string[] words)
        {
            int n = words.Length;
            int[] masks = new int[n];
            for (int i = 0; i < n; i++)
            {
                foreach (char c in words[i])
                    masks[i] |= 1 << (c - 'a');
            }

            int best = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((masks[i] & masks[j]) == 0)
                        best = Math.Max(best, words[i].Length * words[j].Length);
                }
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-vowels-of-a-string/">345. Reverse Vowels of a String (easy)</a>
        /// Reverses only the vowels in <paramref name="s"/> using a two-pointer scan.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The string whose vowels should be reversed.</param>
        /// <returns>A copy of <paramref name="s"/> with vowels reversed.</returns>
        public string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = chars.Length - 1;
            while (left < right)
            {
                while (left < right && !IsVowel(chars[left]))
                    left++;
                while (left < right && !IsVowel(chars[right]))
                    right--;
                if (left < right)
                {
                    char temp = chars[left];
                    chars[left++] = chars[right];
                    chars[right--] = temp;
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-absolute-file-path/">388. Longest Absolute File Path (medium)</a>
        /// Parses a newline-and-tab encoded file system and returns the length of the longest absolute file path.
        /// Tracks cumulative path length at each depth as entries are scanned.
        /// Complexity: O(n) time and O(d) space where d is maximum directory depth.
        /// </summary>
        /// <param name="input">The encoded file system string.</param>
        /// <returns>The character length of the longest absolute path to a file, or 0 when there is no file.</returns>
        public int LengthLongestPath(string input)
        {
            var depthLengths = new Dictionary<int, int> { [0] = 0 };
            int best = 0;

            foreach (string entry in input.Split('\n'))
            {
                int depth = 0;
                while (depth < entry.Length && entry[depth] == '\t')
                    depth++;

                string name = entry.Substring(depth);
                int length = depthLengths[depth] + name.Length;
                if (name.IndexOf('.') >= 0)
                    best = Math.Max(best, length);
                else
                    depthLengths[depth + 1] = length + 1;
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decode-string/">394. Decode String (medium)</a>
        /// Decodes bracketed repetition patterns such as "3[a2[c]]" where counts precede bracketed substrings.
        /// Uses stacks for previous builders and repeat counts while scanning once.
        /// Complexity: O(n + output length) time and O(n + output length) space.
        /// </summary>
        /// <param name="s">The encoded string to decode.</param>
        /// <returns>The fully decoded string.</returns>
        public string DecodeString(string s)
        {
            var builders = new Stack<StringBuilder>();
            var counts = new Stack<int>();
            var current = new StringBuilder();
            int count = 0;

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    count = count * 10 + c - '0';
                }
                else if (c == '[')
                {
                    counts.Push(count);
                    builders.Push(current);
                    current = new StringBuilder();
                    count = 0;
                }
                else if (c == ']')
                {
                    int repeat = counts.Pop();
                    var parent = builders.Pop();
                    for (int i = 0; i < repeat; i++)
                        parent.Append(current);
                    current = parent;
                }
                else
                {
                    current.Append(c);
                }
            }

            return current.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-k-digits/">402. Remove K Digits (medium)</a>
        /// Removes exactly k digits from a non-negative integer string so the remaining number is as small as possible.
        /// Uses a monotonic increasing stack and strips leading zeroes from the final answer.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="num">The decimal number string.</param>
        /// <param name="k">The number of digits to remove.</param>
        /// <returns>The smallest possible number string after removing <paramref name="k"/> digits.</returns>
        public string RemoveKdigits(string num, int k)
        {
            var stack = new List<char>();
            foreach (char digit in num)
            {
                while (k > 0 && stack.Count > 0 && stack[stack.Count - 1] > digit)
                {
                    stack.RemoveAt(stack.Count - 1);
                    k--;
                }
                stack.Add(digit);
            }

            while (k > 0 && stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1);
                k--;
            }

            int start = 0;
            while (start < stack.Count && stack[start] == '0')
                start++;

            return start == stack.Count ? "0" : new string(stack.GetRange(start, stack.Count - start).ToArray());
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-palindrome/">409. Longest Palindrome (easy)</a>
        /// Returns the longest palindrome length buildable from the letters of <paramref name="s"/>.
        /// Counts paired characters and allows one odd-count character in the center.
        /// Complexity: O(n) time and O(1) space for the fixed character range used by LeetCode inputs.
        /// </summary>
        /// <param name="s">The source letters.</param>
        /// <returns>The maximum length of any palindrome constructible from <paramref name="s"/>.</returns>
        public int LongestPalindromeLength(string s)
        {
            var odds = new HashSet<char>();
            foreach (char c in s)
            {
                if (!odds.Add(c))
                    odds.Remove(c);
            }

            return s.Length - Math.Max(0, odds.Count - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reconstruct-original-digits-from-english/">423. Reconstruct Original Digits from English (medium)</a>
        /// Reconstructs sorted digits from a shuffled concatenation of English digit words zero through nine.
        /// Uses letters unique to specific digit names to derive frequencies.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The shuffled lowercase English digit letters.</param>
        /// <returns>The original digits in ascending order.</returns>
        public string OriginalDigits(string s)
        {
            int[] letters = new int[26];
            foreach (char c in s)
                letters[c - 'a']++;

            int[] digits = new int[10];
            digits[0] = letters['z' - 'a'];
            digits[2] = letters['w' - 'a'];
            digits[4] = letters['u' - 'a'];
            digits[6] = letters['x' - 'a'];
            digits[8] = letters['g' - 'a'];
            digits[3] = letters['h' - 'a'] - digits[8];
            digits[5] = letters['f' - 'a'] - digits[4];
            digits[7] = letters['s' - 'a'] - digits[6];
            digits[1] = letters['o' - 'a'] - digits[0] - digits[2] - digits[4];
            digits[9] = letters['i' - 'a'] - digits[5] - digits[6] - digits[8];

            var result = new StringBuilder();
            for (int digit = 0; digit <= 9; digit++)
                result.Append((char)('0' + digit), digits[digit]);
            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-repeating-character-replacement/">424. Longest Repeating Character Replacement (medium)</a>
        /// Finds the longest substring that can be made of one repeated uppercase letter after changing at most k characters.
        /// Uses a sliding window and the maximum frequency inside the window.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The uppercase string to scan.</param>
        /// <param name="k">The maximum number of replacements allowed.</param>
        /// <returns>The length of the longest replaceable repeating-character substring.</returns>
        public int CharacterReplacement(string s, int k)
        {
            int[] counts = new int[26];
            int left = 0, maxCount = 0, best = 0;

            for (int right = 0; right < s.Length; right++)
            {
                maxCount = Math.Max(maxCount, ++counts[s[right] - 'A']);
                while (right - left + 1 - maxCount > k)
                    counts[s[left++] - 'A']--;
                best = Math.Max(best, right - left + 1);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-segments-in-a-string/">434. Number of Segments in a String (easy)</a>
        /// Counts contiguous non-space segments in <paramref name="s"/>.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string containing zero or more space-separated segments.</param>
        /// <returns>The number of non-empty segments in <paramref name="s"/>.</returns>
        public int CountSegments(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && (i == 0 || s[i - 1] == ' '))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/repeated-substring-pattern/">459. Repeated Substring Pattern (easy)</a>
        /// Determines whether <paramref name="s"/> can be built by repeating one of its proper substrings.
        /// Checks for s inside the doubled string with first and last characters removed.
        /// Complexity: O(n) practical time and O(n) space.
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> is a repetition of a smaller substring; otherwise, <see langword="false"/>.</returns>
        public bool RepeatedSubstringPattern(string s)
        {
            return s.Length > 1 && (s + s).IndexOf(s, 1, s.Length * 2 - 2, StringComparison.Ordinal) >= 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/validate-ip-address/">468. Validate IP Address (medium)</a>
        /// Classifies a string as IPv4, IPv6, or Neither according to LeetCode validation rules.
        /// Validates decimal IPv4 octets and hexadecimal IPv6 groups without using networking libraries.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="queryIP">The candidate IP address.</param>
        /// <returns>"IPv4", "IPv6", or "Neither".</returns>
        public string ValidIPAddress(string queryIP)
        {
            if (queryIP.IndexOf('.') >= 0)
                return IsValidIPv4(queryIP) ? "IPv4" : "Neither";
            if (queryIP.IndexOf(':') >= 0)
                return IsValidIPv6(queryIP) ? "IPv6" : "Neither";
            return "Neither";
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/license-key-formatting/">482. License Key Formatting (easy)</a>
        /// Reformats a license key by removing dashes, uppercasing letters, and grouping from the right in size k.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The raw license key string.</param>
        /// <param name="k">The desired group size except possibly the first group.</param>
        /// <returns>The reformatted license key.</returns>
        public string LicenseKeyFormatting(string s, int k)
        {
            var result = new StringBuilder();
            int groupCount = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '-')
                    continue;
                if (groupCount == k)
                {
                    result.Append('-');
                    groupCount = 0;
                }
                result.Append(char.ToUpperInvariant(s[i]));
                groupCount++;
            }

            char[] chars = result.ToString().ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/detect-capital/">520. Detect Capital (easy)</a>
        /// Checks whether a word uses capitals correctly: all uppercase, all lowercase, or only the first letter uppercase.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="word">The word to validate.</param>
        /// <returns><see langword="true"/> if capitalization is valid; otherwise, <see langword="false"/>.</returns>
        public bool DetectCapitalUse(string word)
        {
            int capitals = 0;
            foreach (char c in word)
            {
                if (char.IsUpper(c))
                    capitals++;
            }

            return capitals == 0 || capitals == word.Length || (capitals == 1 && char.IsUpper(word[0]));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-uncommon-subsequence-i/">521. Longest Uncommon Subsequence I (easy)</a>
        /// Returns the length of the longest string that is a subsequence of one input but not the other.
        /// If the strings differ, the longer whole string is uncommon; identical strings have no uncommon subsequence.
        /// Complexity: O(1) time excluding string equality comparison and O(1) space.
        /// </summary>
        /// <param name="a">The first string.</param>
        /// <param name="b">The second string.</param>
        /// <returns>The longest uncommon subsequence length, or -1 when none exists.</returns>
        public int FindLUSlength(string a, string b)
        {
            return a == b ? -1 : Math.Max(a.Length, b.Length);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-uncommon-subsequence-ii/">522. Longest Uncommon Subsequence II (medium)</a>
        /// Finds the longest string in the array that is not a subsequence of any other string in the array.
        /// Tests longer candidates first and checks subsequence relationships directly.
        /// Complexity: O(n^2 * m) time and O(1) extra space apart from sorting, where m is maximum string length.
        /// </summary>
        /// <param name="strs">The candidate strings.</param>
        /// <returns>The longest uncommon subsequence length, or -1 if every string is covered by another.</returns>
        public int FindLUSlength(string[] strs)
        {
            Array.Sort(strs, (a, b) => b.Length == a.Length ? string.CompareOrdinal(a, b) : b.Length - a.Length);
            for (int i = 0; i < strs.Length; i++)
            {
                bool uncommon = true;
                for (int j = 0; j < strs.Length && uncommon; j++)
                {
                    if (i != j && IsSubsequence(strs[i], strs[j]))
                        uncommon = false;
                }

                if (uncommon)
                    return strs[i].Length;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-word-in-dictionary-through-deleting/">524. Longest Word in Dictionary through Deleting (medium)</a>
        /// Chooses the longest dictionary word obtainable by deleting characters from <paramref name="s"/>, breaking ties lexicographically.
        /// Complexity: O(n*m) time where n is dictionary size and m is source length, O(1) extra space.
        /// </summary>
        /// <param name="s">The source string from which characters may be deleted.</param>
        /// <param name="dictionary">Candidate words.</param>
        /// <returns>The best matching dictionary word, or an empty string if none matches.</returns>
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            string best = string.Empty;
            foreach (string word in dictionary)
            {
                if ((word.Length > best.Length || (word.Length == best.Length && string.CompareOrdinal(word, best) < 0)) && IsSubsequence(word, s))
                    best = word;
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/complex-number-multiplication/">537. Complex Number Multiplication (medium)</a>
        /// Multiplies two complex numbers encoded as "real+imaginaryi" strings.
        /// Parses signed integer components and applies (a+bi)(c+di) = (ac-bd)+(ad+bc)i.
        /// Complexity: O(1) time and O(1) space for bounded input length.
        /// </summary>
        /// <param name="num1">The first complex number string.</param>
        /// <param name="num2">The second complex number string.</param>
        /// <returns>The product encoded as "real+imaginaryi".</returns>
        public string ComplexNumberMultiply(string num1, string num2)
        {
            ParseComplex(num1, out int real1, out int imaginary1);
            ParseComplex(num2, out int real2, out int imaginary2);
            int real = real1 * real2 - imaginary1 * imaginary2;
            int imaginary = real1 * imaginary2 + imaginary1 * real2;
            return real + "+" + imaginary + "i";
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-time-difference/">539. Minimum Time Difference (medium)</a>
        /// Finds the minimum difference in minutes between any two HH:MM time points across a 24-hour cycle.
        /// Uses a bucket for each minute of the day to detect duplicates and adjacent sorted times.
        /// Complexity: O(n + 1440) time and O(1440) space.
        /// </summary>
        /// <param name="timePoints">The list of 24-hour clock times.</param>
        /// <returns>The minimum circular difference in minutes.</returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            bool[] seen = new bool[1440];
            foreach (string time in timePoints)
            {
                int minute = ((time[0] - '0') * 10 + time[1] - '0') * 60 + (time[3] - '0') * 10 + time[4] - '0';
                if (seen[minute])
                    return 0;
                seen[minute] = true;
            }

            int first = -1, previous = -1, best = 1440;
            for (int minute = 0; minute < 1440; minute++)
            {
                if (!seen[minute])
                    continue;
                if (first == -1)
                    first = minute;
                if (previous != -1)
                    best = Math.Min(best, minute - previous);
                previous = minute;
            }

            return Math.Min(best, first + 1440 - previous);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-string-ii/">541. Reverse String II (easy)</a>
        /// For every 2k block, reverses the first k characters and leaves the rest unchanged.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The input string to transform.</param>
        /// <param name="k">The maximum number of characters to reverse in each 2k block.</param>
        /// <returns>The transformed string after block-wise reversal.</returns>
        public string ReverseStr(string s, int k)
        {
            char[] chars = s.ToCharArray();
            for (int start = 0; start < chars.Length; start += 2 * k)
                ReverseRange(chars, start, Math.Min(start + k - 1, chars.Length - 1));
            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/student-attendance-record-i/">551. Student Attendance Record I (easy)</a>
        /// Determines whether an attendance record is rewardable: fewer than two absences and no three consecutive lates.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The attendance record containing 'A', 'L', and 'P'.</param>
        /// <returns><see langword="true"/> if the student can be rewarded; otherwise, <see langword="false"/>.</returns>
        public bool CheckRecord(string s)
        {
            int absences = 0, consecutiveLate = 0;
            foreach (char c in s)
            {
                if (c == 'A')
                {
                    absences++;
                    consecutiveLate = 0;
                    if (absences == 2)
                        return false;
                }
                else if (c == 'L')
                {
                    consecutiveLate++;
                    if (consecutiveLate == 3)
                        return false;
                }
                else
                {
                    consecutiveLate = 0;
                }
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-words-in-a-string-iii/">557. Reverse Words in a String III (easy)</a>
        /// Reverses each word in a sentence while preserving word order and spaces.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The sentence whose individual words should be reversed.</param>
        /// <returns>A sentence with every word reversed in place.</returns>
        public string ReverseWordsIII(string s)
        {
            char[] chars = s.ToCharArray();
            int start = 0;
            for (int i = 0; i <= chars.Length; i++)
            {
                if (i == chars.Length || chars[i] == ' ')
                {
                    ReverseRange(chars, start, i - 1);
                    start = i + 1;
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/replace-words/">648. Replace Words (medium)</a>
        /// Replaces each sentence word with the shortest dictionary root that is its prefix.
        /// Stores roots in a trie and scans each word until a terminal root is found.
        /// Complexity: O(total dictionary characters + sentence characters) time and space for the trie/output.
        /// </summary>
        /// <param name="dictionary">The root words to use as replacements.</param>
        /// <param name="sentence">The sentence to transform.</param>
        /// <returns>The sentence after replacing matching words with shortest roots.</returns>
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            var root = new TrieNode();
            foreach (string word in dictionary)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    node.Children[index] ??= new TrieNode();
                    node = node.Children[index];
                }
                node.IsWord = true;
            }

            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
                words[i] = FindRoot(root, words[i]);
            return string.Join(" ", words);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/palindromic-substrings/">647. Palindromic Substrings (medium)</a>
        /// Counts all palindromic substrings in <paramref name="s"/> by expanding around every possible center.
        /// Complexity: O(n^2) time and O(1) extra space.
        /// </summary>
        /// <param name="s">The string to inspect.</param>
        /// <returns>The number of palindromic substrings in <paramref name="s"/>.</returns>
        public int CountSubstrings(string s)
        {
            int count = 0;
            for (int center = 0; center < s.Length; center++)
            {
                count += CountPalindromesAroundCenter(s, center, center);
                count += CountPalindromesAroundCenter(s, center, center + 1);
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/robot-return-to-origin/">657. Robot Return to Origin (easy)</a>
        /// Determines whether moves U, D, L, and R return a robot to coordinate (0, 0).
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="moves">The robot moves.</param>
        /// <returns><see langword="true"/> if the robot finishes at the origin; otherwise, <see langword="false"/>.</returns>
        public bool JudgeCircle(string moves)
        {
            int x = 0, y = 0;
            foreach (char move in moves)
            {
                switch (move)
                {
                    case 'U': y++; break;
                    case 'D': y--; break;
                    case 'L': x--; break;
                    case 'R': x++; break;
                }
            }

            return x == 0 && y == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-parenthesis-string/">678. Valid Parenthesis String (medium)</a>
        /// Validates a parenthesis string where '*' may be '(', ')', or empty.
        /// Tracks the possible range of unmatched opening parentheses while scanning left to right.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string containing '(', ')', and '*'.</param>
        /// <returns><see langword="true"/> if some interpretation is valid; otherwise, <see langword="false"/>.</returns>
        public bool CheckValidString(string s)
        {
            int low = 0, high = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    low++;
                    high++;
                }
                else if (c == ')')
                {
                    low = Math.Max(0, low - 1);
                    high--;
                }
                else
                {
                    low = Math.Max(0, low - 1);
                    high++;
                }

                if (high < 0)
                    return false;
            }

            return low == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-palindrome-ii/">680. Valid Palindrome II (easy)</a>
        /// Determines whether <paramref name="s"/> can be a palindrome after deleting at most one character.
        /// Uses two pointers and tests the two possible skips at the first mismatch.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string to validate.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> is already or can become a palindrome with one deletion; otherwise, <see langword="false"/>.</returns>
        public bool ValidPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                    return IsPalindromeRange(s, left + 1, right) || IsPalindromeRange(s, left, right - 1);
                left++;
                right--;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/repeated-string-match/">686. Repeated String Match (medium)</a>
        /// Returns the minimum repetitions of a needed so b is a substring of the repeated string.
        /// Appends until the repeated length reaches b, then checks one extra repetition for overlap.
        /// Complexity: O(|a| + |b|) practical time and O(|a| + |b|) space.
        /// </summary>
        /// <param name="a">The string to repeat.</param>
        /// <param name="b">The target substring.</param>
        /// <returns>The minimum repetition count, or -1 if impossible.</returns>
        public int RepeatedStringMatch(string a, string b)
        {
            var repeated = new StringBuilder();
            int count = 0;
            while (repeated.Length < b.Length)
            {
                repeated.Append(a);
                count++;
            }

            if (repeated.ToString().Contains(b))
                return count;
            repeated.Append(a);
            return repeated.ToString().Contains(b) ? count + 1 : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-binary-substrings/">696. Count Binary Substrings (easy)</a>
        /// Counts substrings with equal consecutive groups of 0s and 1s by summing adjacent run-length minima.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The binary string to scan.</param>
        /// <returns>The number of valid binary substrings.</returns>
        public int CountBinarySubstrings(string s)
        {
            int previousRun = 0, currentRun = 1, count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    currentRun++;
                }
                else
                {
                    count += Math.Min(previousRun, currentRun);
                    previousRun = currentRun;
                    currentRun = 1;
                }
            }

            return count + Math.Min(previousRun, currentRun);
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/to-lower-case/">709. To Lower Case (easy)</a>
        /// Converts every uppercase English letter in <paramref name="s"/> to lowercase, leaving other characters unchanged.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>A lowercase copy of <paramref name="s"/>.</returns>
        public string ToLowerCase(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 'A' && chars[i] <= 'Z')
                    chars[i] = (char)(chars[i] - 'A' + 'a');
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/jewels-and-stones/">771. Jewels and Stones (easy)</a>
        /// Counts how many stones are also listed as jewels, treating characters as case-sensitive.
        /// Complexity: O(j + s) time and O(j) space.
        /// </summary>
        /// <param name="jewels">Distinct jewel type characters.</param>
        /// <param name="stones">Stone type characters to count.</param>
        /// <returns>The number of characters in <paramref name="stones"/> that are jewels.</returns>
        public int NumJewelsInStones(string jewels, string stones)
        {
            var set = new HashSet<char>(jewels);
            int count = 0;
            foreach (char stone in stones)
            {
                if (set.Contains(stone))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotate-string/">796. Rotate String (easy)</a>
        /// Determines whether <paramref name="goal"/> can be produced by repeatedly moving the first character of <paramref name="s"/> to the end.
        /// Complexity: O(n) practical time and O(n) space.
        /// </summary>
        /// <param name="s">The original string.</param>
        /// <param name="goal">The target rotation.</param>
        /// <returns><see langword="true"/> if <paramref name="goal"/> is a rotation of <paramref name="s"/>; otherwise, <see langword="false"/>.</returns>
        public bool RotateString(string s, string goal)
        {
            return s.Length == goal.Length && (s + s).Contains(goal);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-morse-code-words/">804. Unique Morse Code Words (easy)</a>
        /// Transforms each lowercase word to Morse code and counts distinct transformations.
        /// Complexity: O(total characters) time and space.
        /// </summary>
        /// <param name="words">The lowercase English words to transform.</param>
        /// <returns>The number of unique Morse transformations.</returns>
        public int UniqueMorseRepresentations(string[] words)
        {
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            var seen = new HashSet<string>();
            foreach (string word in words)
            {
                var builder = new StringBuilder();
                foreach (char c in word)
                    builder.Append(morse[c - 'a']);
                seen.Add(builder.ToString());
            }

            return seen.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/most-common-word/">819. Most Common Word (easy)</a>
        /// Finds the most frequent non-banned word after lowercasing and treating punctuation as separators.
        /// Complexity: O(n + b) time and O(n + b) space.
        /// </summary>
        /// <param name="paragraph">The paragraph to scan.</param>
        /// <param name="banned">Words that cannot be returned.</param>
        /// <returns>The most common word not present in <paramref name="banned"/>.</returns>
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var bannedWords = new HashSet<string>(banned);
            var counts = new Dictionary<string, int>();
            string best = string.Empty;
            int bestCount = 0;
            var word = new StringBuilder();

            for (int i = 0; i <= paragraph.Length; i++)
            {
                char c = i < paragraph.Length ? paragraph[i] : ' ';
                if (char.IsLetter(c))
                {
                    word.Append(char.ToLowerInvariant(c));
                    continue;
                }

                if (word.Length == 0)
                    continue;

                string current = word.ToString();
                if (!bannedWords.Contains(current))
                {
                    counts.TryGetValue(current, out int count);
                    count++;
                    counts[current] = count;
                    if (count > bestCount)
                    {
                        bestCount = count;
                        best = current;
                    }
                }

                word.Clear();
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-distance-to-a-character/">821. Shortest Distance to a Character (easy)</a>
        /// For each index, computes the distance to the nearest occurrence of <paramref name="c"/> with left-to-right and right-to-left scans.
        /// Complexity: O(n) time and O(n) space for the result.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="c">The character to measure distances to.</param>
        /// <returns>An array of nearest distances for every index in <paramref name="s"/>.</returns>
        public int[] ShortestToChar(string s, char c)
        {
            int[] result = new int[s.Length];
            int previous = -s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                    previous = i;
                result[i] = i - previous;
            }

            previous = s.Length * 2;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == c)
                    previous = i;
                result[i] = Math.Min(result[i], previous - i);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/goat-latin/">824. Goat Latin (easy)</a>
        /// Converts a sentence to Goat Latin by moving leading consonants, appending "ma", and adding one more 'a' per word index.
        /// Complexity: O(n + w^2) time and O(n + w^2) space for the required suffixes.
        /// </summary>
        /// <param name="sentence">The sentence of space-separated words.</param>
        /// <returns>The Goat Latin conversion of <paramref name="sentence"/>.</returns>
        public string ToGoatLatin(string sentence)
        {
            string[] words = sentence.Split(' ');
            var result = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0)
                    result.Append(' ');
                string word = words[i];
                if (IsVowel(word[0]))
                    result.Append(word);
                else
                    result.Append(word.Substring(1)).Append(word[0]);
                result.Append("ma").Append('a', i + 1);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/positions-of-large-groups/">830. Positions of Large Groups (easy)</a>
        /// Returns start and end indices for each run of at least three equal consecutive characters.
        /// Complexity: O(n) time and O(g) space for g groups.
        /// </summary>
        /// <param name="s">The string to scan for large groups.</param>
        /// <returns>Pairs [start, end] for every large group.</returns>
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var result = new List<IList<int>>();
            int start = 0;
            for (int i = 1; i <= s.Length; i++)
            {
                if (i == s.Length || s[i] != s[start])
                {
                    if (i - start >= 3)
                        result.Add(new List<int> { start, i - 1 });
                    start = i;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/backspace-string-compare/">844. Backspace String Compare (easy)</a>
        /// Compares two strings after applying '#' as a backspace using reverse scans without building the edited strings.
        /// Complexity: O(m + n) time and O(1) space.
        /// </summary>
        /// <param name="s">The first typed string.</param>
        /// <param name="t">The second typed string.</param>
        /// <returns><see langword="true"/> if both strings are equal after backspaces; otherwise, <see langword="false"/>.</returns>
        public bool BackspaceCompare(string s, string t)
        {
            int i = s.Length - 1, j = t.Length - 1;
            while (i >= 0 || j >= 0)
            {
                i = PreviousTypedIndex(s, i);
                j = PreviousTypedIndex(t, j);
                if (i < 0 || j < 0)
                    return i == j;
                if (s[i] != t[j])
                    return false;
                i--;
                j--;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/buddy-strings/">859. Buddy Strings (easy)</a>
        /// Checks whether swapping exactly two characters in <paramref name="s"/> can make it equal to <paramref name="goal"/>.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="goal">The target string.</param>
        /// <returns><see langword="true"/> if one swap can make the strings equal; otherwise, <see langword="false"/>.</returns>
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            if (s == goal)
            {
                bool[] seen = new bool[26];
                foreach (char c in s)
                {
                    int index = c - 'a';
                    if (seen[index])
                        return true;
                    seen[index] = true;
                }

                return false;
            }

            int first = -1, second = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == goal[i])
                    continue;
                if (first == -1)
                    first = i;
                else if (second == -1)
                    second = i;
                else
                    return false;
            }

            return second != -1 && s[first] == goal[second] && s[second] == goal[first];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/uncommon-words-from-two-sentences/">884. Uncommon Words from Two Sentences (easy)</a>
        /// Finds words that appear exactly once across both input sentences.
        /// Complexity: O(m + n) time and space.
        /// </summary>
        /// <param name="s1">The first sentence.</param>
        /// <param name="s2">The second sentence.</param>
        /// <returns>All words whose combined frequency is one.</returns>
        public string[] UncommonFromSentences(string s1, string s2)
        {
            var counts = new Dictionary<string, int>();
            CountSentenceWords(s1, counts);
            CountSentenceWords(s2, counts);
            var result = new List<string>();
            foreach (var pair in counts)
            {
                if (pair.Value == 1)
                    result.Add(pair.Key);
            }

            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-only-letters/">917. Reverse Only Letters (easy)</a>
        /// Reverses letters in the string while leaving non-letter characters in their original positions.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The string to transform.</param>
        /// <returns>A copy of <paramref name="s"/> with only letters reversed.</returns>
        public string ReverseOnlyLetters(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = chars.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetter(chars[left]))
                    left++;
                while (left < right && !char.IsLetter(chars[right]))
                    right--;
                if (left < right)
                {
                    char temp = chars[left];
                    chars[left++] = chars[right];
                    chars[right--] = temp;
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/long-pressed-name/">925. Long Pressed Name (easy)</a>
        /// Determines whether <paramref name="typed"/> could be produced from <paramref name="name"/> by long-pressing characters.
        /// Complexity: O(n + m) time and O(1) space.
        /// </summary>
        /// <param name="name">The intended name.</param>
        /// <param name="typed">The typed characters.</param>
        /// <returns><see langword="true"/> if <paramref name="typed"/> is a valid long-pressed version; otherwise, <see langword="false"/>.</returns>
        public bool IsLongPressedName(string name, string typed)
        {
            int i = 0, j = 0;
            while (j < typed.Length)
            {
                if (i < name.Length && name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (j > 0 && typed[j] == typed[j - 1])
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }

            return i == name.Length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-email-addresses/">929. Unique Email Addresses (easy)</a>
        /// Normalizes emails by ignoring dots and plus-tags in the local name, then counts unique addresses.
        /// Complexity: O(total characters) time and space.
        /// </summary>
        /// <param name="emails">The email addresses to normalize.</param>
        /// <returns>The number of distinct normalized addresses.</returns>
        public int NumUniqueEmails(string[] emails)
        {
            var seen = new HashSet<string>();
            foreach (string email in emails)
            {
                int at = email.IndexOf('@');
                var normalized = new StringBuilder();
                for (int i = 0; i < at && email[i] != '+'; i++)
                {
                    if (email[i] != '.')
                        normalized.Append(email[i]);
                }
                normalized.Append(email.Substring(at));
                seen.Add(normalized.ToString());
            }

            return seen.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-outermost-parentheses/">1021. Remove Outermost Parentheses (easy)</a>
        /// Removes the outer pair from each primitive valid parentheses component.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">A valid parentheses string.</param>
        /// <returns>The string after deleting every primitive component's outer parentheses.</returns>
        public string RemoveOuterParentheses(string s)
        {
            var result = new StringBuilder();
            int depth = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    if (depth > 0)
                        result.Append(c);
                    depth++;
                }
                else
                {
                    depth--;
                    if (depth > 0)
                        result.Append(c);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/">1047. Remove All Adjacent Duplicates In String (easy)</a>
        /// Repeatedly removes adjacent equal character pairs using a stack-like buffer.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The string to reduce.</param>
        /// <returns>The string remaining after all adjacent duplicate removals.</returns>
        public string RemoveDuplicates(string s)
        {
            char[] stack = new char[s.Length];
            int length = 0;
            foreach (char c in s)
            {
                if (length > 0 && stack[length - 1] == c)
                    length--;
                else
                    stack[length++] = c;
            }

            return new string(stack, 0, length);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/greatest-common-divisor-of-strings/">1071. Greatest Common Divisor of Strings (easy)</a>
        /// Finds the largest string that can be concatenated repeatedly to form both inputs.
        /// Complexity: O(m + n) time and O(m + n) space for concatenation checks.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <returns>The greatest common divisor string, or empty when none exists.</returns>
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1)
                return string.Empty;
            return str1.Substring(0, Gcd(str1.Length, str2.Length));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/defanging-an-ip-address/">1108. Defanging an IP Address (easy)</a>
        /// Replaces every period in an IPv4 address with "[.]".
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="address">The IPv4 address string.</param>
        /// <returns>The defanged address.</returns>
        public string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/day-of-the-year/">1154. Day of the Year (easy)</a>
        /// Parses a yyyy-mm-dd date and returns its 1-based ordinal day within that year.
        /// Complexity: O(1) time and space.
        /// </summary>
        /// <param name="date">The date formatted as yyyy-mm-dd.</param>
        /// <returns>The day number within the year.</returns>
        public int DayOfYear(string date)
        {
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));
            int[] days = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 0; i < month - 1; i++)
                day += days[i];
            return day;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-number-of-balloons/">1189. Maximum Number of Balloons (easy)</a>
        /// Counts how many instances of the word "balloon" can be formed from the given letters.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="text">The available lowercase letters.</param>
        /// <returns>The maximum number of complete "balloon" words.</returns>
        public int MaxNumberOfBalloons(string text)
        {
            int[] counts = new int[26];
            foreach (char c in text)
                counts[c - 'a']++;
            return Math.Min(Math.Min(counts['b' - 'a'], counts['a' - 'a']), Math.Min(Math.Min(counts['l' - 'a'] / 2, counts['o' - 'a'] / 2), counts['n' - 'a']));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/split-a-string-in-balanced-strings/">1221. Split a String in Balanced Strings (easy)</a>
        /// Greedily counts balanced substrings with equal numbers of 'L' and 'R'.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">A balanced string containing only 'L' and 'R'.</param>
        /// <returns>The maximum number of balanced pieces.</returns>
        public int BalancedStringSplit(string s)
        {
            int balance = 0, count = 0;
            foreach (char c in s)
            {
                balance += c == 'L' ? 1 : -1;
                if (balance == 0)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decrypt-string-from-alphabet-to-integer-mapping/">1309. Decrypt String from Alphabet to Integer Mapping (easy)</a>
        /// Decodes digits and two-digit values followed by '#' into lowercase letters a through z.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="s">The encoded digit string.</param>
        /// <returns>The decoded lowercase string.</returns>
        public string FreqAlphabets(string s)
        {
            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                int value;
                if (i + 2 < s.Length && s[i + 2] == '#')
                {
                    value = (s[i] - '0') * 10 + s[i + 1] - '0';
                    i += 2;
                }
                else
                {
                    value = s[i] - '0';
                }

                result.Append((char)('a' + value - 1));
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/increasing-decreasing-string/">1370. Increasing Decreasing String (easy)</a>
        /// Reorders letters by repeatedly appending increasing then decreasing available characters.
        /// Complexity: O(n + alphabet*n) practical time and O(n) space.
        /// </summary>
        /// <param name="s">The lowercase string to sort in alternating passes.</param>
        /// <returns>The increasing-decreasing ordered string.</returns>
        public string SortString(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            var result = new StringBuilder(s.Length);
            while (result.Length < s.Length)
            {
                AppendAvailable(counts, result, 0, 25, 1);
                AppendAvailable(counts, result, 25, 0, -1);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-longest-substring-containing-vowels-in-even-counts/">1371. Find the Longest Substring Containing Vowels in Even Counts (medium)</a>
        /// Uses a five-bit parity mask for vowel counts and records the first index of each mask to maximize equal-mask spans.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to scan.</param>
        /// <returns>The maximum substring length whose vowels all occur even numbers of times.</returns>
        public int FindTheLongestSubstring(string s)
        {
            int[] first = new int[32];
            for (int i = 0; i < first.Length; i++)
                first[i] = int.MinValue;
            first[0] = -1;
            int mask = 0, best = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int bit = VowelBit(s[i]);
                if (bit >= 0)
                    mask ^= 1 << bit;
                if (first[mask] == int.MinValue)
                    first[mask] = i;
                else
                    best = Math.Max(best, i - first[mask]);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-k-palindrome-strings/">1400. Construct K Palindrome Strings (medium)</a>
        /// Determines whether all characters can be partitioned into exactly k non-empty palindrome strings.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The source lowercase string.</param>
        /// <param name="k">The number of palindromes to construct.</param>
        /// <returns><see langword="true"/> if exactly <paramref name="k"/> palindromes can be constructed; otherwise, <see langword="false"/>.</returns>
        public bool CanConstructPalindromes(string s, int k)
        {
            if (k > s.Length)
                return false;
            int odd = 0;
            int[] counts = new int[26];
            foreach (char c in s)
            {
                int index = c - 'a';
                counts[index]++;
                odd += counts[index] % 2 == 1 ? 1 : -1;
            }

            return odd <= k;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/html-entity-parser/">1410. HTML Entity Parser (medium)</a>
        /// Replaces the six supported HTML entities with their character equivalents while leaving unknown entities unchanged.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="text">The text containing possible HTML entities.</param>
        /// <returns>The parsed text after supported entity replacement.</returns>
        public string EntityParser(string text)
        {
            var result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '&')
                {
                    result.Append(text[i]);
                    continue;
                }

                string replacement = null;
                int consumed = 0;
                if (StartsWithAt(text, i, "&quot;")) { replacement = "\""; consumed = 6; }
                else if (StartsWithAt(text, i, "&apos;")) { replacement = "'"; consumed = 6; }
                else if (StartsWithAt(text, i, "&amp;")) { replacement = "&"; consumed = 5; }
                else if (StartsWithAt(text, i, "&gt;")) { replacement = ">"; consumed = 4; }
                else if (StartsWithAt(text, i, "&lt;")) { replacement = "<"; consumed = 4; }
                else if (StartsWithAt(text, i, "&frasl;")) { replacement = "/"; consumed = 7; }

                if (replacement == null)
                {
                    result.Append(text[i]);
                }
                else
                {
                    result.Append(replacement);
                    i += consumed - 1;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-after-splitting-a-string/">1422. Maximum Score After Splitting a String (easy)</a>
        /// Maximizes zeros on the left plus ones on the right across all non-empty binary string splits.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The binary string to split.</param>
        /// <returns>The maximum split score.</returns>
        public int MaxScore(string s)
        {
            int onesRight = 0;
            foreach (char c in s)
            {
                if (c == '1')
                    onesRight++;
            }

            int zerosLeft = 0, best = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '0')
                    zerosLeft++;
                else
                    onesRight--;
                best = Math.Max(best, zerosLeft + onesRight);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/consecutive-characters/">1446. Consecutive Characters (easy)</a>
        /// Finds the largest run length of one repeated character.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The non-empty string to scan.</param>
        /// <returns>The maximum power of <paramref name="s"/>.</returns>
        public int MaxPower(string s)
        {
            int best = 1, current = 1;
            for (int i = 1; i < s.Length; i++)
            {
                current = s[i] == s[i - 1] ? current + 1 : 1;
                best = Math.Max(best, current);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/">1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence (easy)</a>
        /// Returns the 1-based position of the first sentence word that starts with the search word.
        /// Complexity: O(n) time and O(1) extra space.
        /// </summary>
        /// <param name="sentence">The sentence to search.</param>
        /// <param name="searchWord">The prefix to find.</param>
        /// <returns>The first 1-based word index with the prefix, or -1 if none exists.</returns>
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            int wordIndex = 1;
            for (int i = 0; i < sentence.Length;)
            {
                int start = i;
                while (i < sentence.Length && sentence[i] != ' ')
                    i++;
                if (i - start >= searchWord.Length && StartsWithAt(sentence, start, searchWord))
                    return wordIndex;
                wordIndex++;
                i++;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reformat-date/">1507. Reformat Date (easy)</a>
        /// Converts dates like "20th Oct 2052" to ISO yyyy-mm-dd format.
        /// Complexity: O(1) time and space.
        /// </summary>
        /// <param name="date">The date with ordinal day, three-letter month, and year.</param>
        /// <returns>The reformatted yyyy-mm-dd date.</returns>
        public string ReformatDate(string date)
        {
            string[] parts = date.Split(' ');
            int day = 0;
            foreach (char c in parts[0])
            {
                if (char.IsDigit(c))
                    day = day * 10 + c - '0';
            }

            int month = MonthNumber(parts[1]);
            return parts[2] + "-" + month.ToString("D2") + "-" + day.ToString("D2");
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shuffle-string/">1528. Shuffle String (easy)</a>
        /// Restores a shuffled string by placing each character at its target index.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The shuffled string.</param>
        /// <param name="indices">The target index for each character.</param>
        /// <returns>The restored string.</returns>
        public string RestoreString(string s, int[] indices)
        {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
                result[indices[i]] = s[i];
            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/make-the-string-great/">1544. Make The String Great (easy)</a>
        /// Removes adjacent same-letter pairs that differ only by case until no such pair remains.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The string to reduce.</param>
        /// <returns>The good string after all removals.</returns>
        public string MakeGood(string s)
        {
            var stack = new List<char>();
            foreach (char c in s)
            {
                if (stack.Count > 0 && Math.Abs(stack[stack.Count - 1] - c) == 32)
                    stack.RemoveAt(stack.Count - 1);
                else
                    stack.Add(c);
            }

            return new string(stack.ToArray());
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters/">1576. Replace All ?'s to Avoid Consecutive Repeating Characters (easy)</a>
        /// Replaces every '?' with a lowercase letter different from its immediate neighbors.
        /// Complexity: O(n) time and O(n) space for the returned string.
        /// </summary>
        /// <param name="s">The string containing lowercase letters and question marks.</param>
        /// <returns>A valid string with all question marks replaced.</returns>
        public string ModifyString(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != '?')
                    continue;
                for (char c = 'a'; c <= 'c'; c++)
                {
                    if ((i == 0 || chars[i - 1] != c) && (i == chars.Length - 1 || chars[i + 1] != c))
                    {
                        chars[i] = c;
                        break;
                    }
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rearrange-spaces-between-words/">1592. Rearrange Spaces Between Words (easy)</a>
        /// Redistributes spaces evenly between words, putting leftover spaces at the end.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="text">The text containing words and spaces.</param>
        /// <returns>The text with spaces rearranged according to the rules.</returns>
        public string ReorderSpaces(string text)
        {
            int spaces = 0;
            var words = new List<string>();
            for (int i = 0; i < text.Length;)
            {
                if (text[i] == ' ')
                {
                    spaces++;
                    i++;
                    continue;
                }

                int start = i;
                while (i < text.Length && text[i] != ' ')
                    i++;
                words.Add(text.Substring(start, i - start));
            }

            int gap = words.Count <= 1 ? 0 : spaces / (words.Count - 1);
            int trailing = words.Count <= 1 ? spaces : spaces % (words.Count - 1);
            var result = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                if (i > 0)
                    result.Append(' ', gap);
                result.Append(words[i]);
            }
            result.Append(' ', trailing);
            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/">1614. Maximum Nesting Depth of the Parentheses (easy)</a>
        /// Computes the maximum number of open parentheses at any point in a valid parentheses string.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The valid parentheses string with other characters allowed.</param>
        /// <returns>The maximum nesting depth.</returns>
        public int MaxDepth(string s)
        {
            int depth = 0, best = 0;
            foreach (char c in s)
            {
                if (c == '(')
                    best = Math.Max(best, ++depth);
                else if (c == ')')
                    depth--;
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-substring-between-two-equal-characters/">1624. Largest Substring Between Two Equal Characters (easy)</a>
        /// Finds the maximum number of characters between two equal endpoints.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to scan.</param>
        /// <returns>The largest inner substring length, or -1 if no equal endpoints exist.</returns>
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            int[] first = new int[26];
            for (int i = 0; i < first.Length; i++)
                first[i] = -1;
            int best = -1;
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';
                if (first[index] == -1)
                    first[index] = i;
                else
                    best = Math.Max(best, i - first[index] - 1);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/">1662. Check If Two String Arrays are Equivalent (easy)</a>
        /// Compares two arrays as concatenated strings without materializing both full concatenations.
        /// Complexity: O(total characters) time and O(1) space.
        /// </summary>
        /// <param name="word1">The first string array.</param>
        /// <param name="word2">The second string array.</param>
        /// <returns><see langword="true"/> if both arrays represent the same string; otherwise, <see langword="false"/>.</returns>
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            int i = 0, j = 0, p1 = 0, p2 = 0;
            while (i < word1.Length && j < word2.Length)
            {
                if (word1[i][p1] != word2[j][p2])
                    return false;
                if (++p1 == word1[i].Length)
                {
                    i++;
                    p1 = 0;
                }
                if (++p2 == word2[j].Length)
                {
                    j++;
                    p2 = 0;
                }
            }

            return i == word1.Length && j == word2.Length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-repeating-substring/">1668. Maximum Repeating Substring (easy)</a>
        /// Finds the largest k such that word repeated k times is a substring of sequence.
        /// Complexity: O(n*k) practical time and O(n) space for repeated candidates.
        /// </summary>
        /// <param name="sequence">The string to search in.</param>
        /// <param name="word">The repeated word.</param>
        /// <returns>The maximum repeating count.</returns>
        public int MaxRepeating(string sequence, string word)
        {
            int count = 0;
            var repeated = new StringBuilder(word);
            while (sequence.Contains(repeated.ToString()))
            {
                count++;
                repeated.Append(word);
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/goal-parser-interpretation/">1678. Goal Parser Interpretation (easy)</a>
        /// Interprets Goal Parser tokens: 'G' maps to "G", "()" to "o", and "(al)" to "al".
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="command">The command string to interpret.</param>
        /// <returns>The interpreted command.</returns>
        public string Interpret(string command)
        {
            var result = new StringBuilder();
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                    result.Append('G');
                else if (command[i + 1] == ')')
                {
                    result.Append('o');
                    i++;
                }
                else
                {
                    result.Append("al");
                    i += 3;
                }
            }

            return result.ToString();
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/determine-if-string-halves-are-alike/">1704. Determine if String Halves Are Alike (easy)</a>
        /// Checks whether the two halves of a string contain the same number of vowels.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The even-length string to split into two halves.</param>
        /// <returns><see langword="true"/> if both halves have equal vowel counts; otherwise, <see langword="false"/>.</returns>
        public bool HalvesAreAlike(string s)
        {
            int balance = 0;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (IsVowel(s[i]))
                    balance++;
                if (IsVowel(s[i + s.Length / 2]))
                    balance--;
            }

            return balance == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-from-removing-substrings/">1717. Maximum Score From Removing Substrings (medium)</a>
        /// Greedily removes the higher-valued pair first, then removes the lower-valued pair from the remainder.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The string containing removable "ab" and "ba" substrings.</param>
        /// <param name="x">The score gained for removing "ab".</param>
        /// <param name="y">The score gained for removing "ba".</param>
        /// <returns>The maximum score obtainable by repeated removals.</returns>
        public int MaximumGain(string s, int x, int y)
        {
            if (x >= y)
            {
                int score = RemovePair(s, 'a', 'b', x, out string remainder);
                return score + RemovePair(remainder, 'b', 'a', y, out _);
            }
            else
            {
                int score = RemovePair(s, 'b', 'a', y, out string remainder);
                return score + RemovePair(remainder, 'a', 'b', x, out _);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/">1758. Minimum Changes To Make Alternating Binary String (easy)</a>
        /// Counts mismatches against both alternating binary patterns and returns the smaller count.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The binary string to change.</param>
        /// <returns>The minimum number of character changes needed.</returns>
        public int MinOperations(string s)
        {
            int startWithZero = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char expected = i % 2 == 0 ? '0' : '1';
                if (s[i] != expected)
                    startWithZero++;
            }

            return Math.Min(startWithZero, s.Length - startWithZero);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-number-of-homogenous-substrings/">1759. Count Number of Homogenous Substrings (medium)</a>
        /// Sums the number of same-character substrings contributed by each consecutive run.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string to scan.</param>
        /// <returns>The homogenous substring count modulo 1,000,000,007.</returns>
        public int CountHomogenous(string s)
        {
            const int Mod = 1_000_000_007;
            long result = 0, run = 0;
            char previous = '\0';
            foreach (char c in s)
            {
                run = c == previous ? run + 1 : 1;
                result = (result + run) % Mod;
                previous = c;
            }

            return (int)result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-strings-alternately/">1768. Merge Strings Alternately (easy)</a>
        /// Builds a merged string by alternating characters and appending the remainder of the longer input.
        /// Complexity: O(m + n) time and space.
        /// </summary>
        /// <param name="word1">The first string.</param>
        /// <param name="word2">The second string.</param>
        /// <returns>The alternately merged string.</returns>
        public string MergeAlternately(string word1, string word2)
        {
            var result = new StringBuilder(word1.Length + word2.Length);
            int i = 0;
            while (i < word1.Length || i < word2.Length)
            {
                if (i < word1.Length)
                    result.Append(word1[i]);
                if (i < word2.Length)
                    result.Append(word2[i]);
                i++;
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-items-matching-a-rule/">1773. Count Items Matching a Rule (easy)</a>
        /// Counts item records whose type, color, or name field equals the requested value.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="items">Items represented as [type, color, name].</param>
        /// <param name="ruleKey">The field to compare: type, color, or name.</param>
        /// <param name="ruleValue">The required field value.</param>
        /// <returns>The number of matching items.</returns>
        public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int index = ruleKey == "type" ? 0 : ruleKey == "color" ? 1 : 2;
            int count = 0;
            foreach (var item in items)
            {
                if (item[index] == ruleValue)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/">1790. Check if One String Swap Can Make Strings Equal (easy)</a>
        /// Verifies that zero mismatches or exactly two cross-matching mismatches can make the strings equal.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns><see langword="true"/> if at most one swap in one string can make them equal.</returns>
        public bool AreAlmostEqual(string s1, string s2)
        {
            int first = -1, second = -1;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                    continue;
                if (first == -1)
                    first = i;
                else if (second == -1)
                    second = i;
                else
                    return false;
            }

            return first == -1 || (second != -1 && s1[first] == s2[second] && s1[second] == s2[first]);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/truncate-sentence/">1816. Truncate Sentence (easy)</a>
        /// Returns the first k words of a space-separated sentence.
        /// Complexity: O(n) time and O(n) space for the returned prefix.
        /// </summary>
        /// <param name="s">The sentence to truncate.</param>
        /// <param name="k">The number of leading words to keep.</param>
        /// <returns>The truncated sentence.</returns>
        public string TruncateSentence(string s, int k)
        {
            int spaces = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' && ++spaces == k)
                    return s.Substring(0, i);
            }

            return s;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-the-sentence-is-pangram/">1832. Check if the Sentence Is Pangram (easy)</a>
        /// Tracks lowercase letters seen and succeeds once all 26 are present.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="sentence">The lowercase sentence to inspect.</param>
        /// <returns><see langword="true"/> if every English letter appears at least once.</returns>
        public bool CheckIfPangram(string sentence)
        {
            int mask = 0;
            foreach (char c in sentence)
                mask |= 1 << (c - 'a');
            return mask == (1 << 26) - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/replace-all-digits-with-characters/">1844. Replace All Digits with Characters (easy)</a>
        /// Replaces each digit at an odd index with the preceding character shifted by that digit.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="s">The alternating lowercase-letter and digit string.</param>
        /// <returns>The string after digit shifts are applied.</returns>
        public string ReplaceDigits(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 1; i < chars.Length; i += 2)
                chars[i] = (char)(chars[i - 1] + chars[i] - '0');
            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sorting-the-sentence/">1859. Sorting the Sentence (easy)</a>
        /// Sorts words by their trailing one-based position digit and removes that digit.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="s">The shuffled sentence with numeric suffixes.</param>
        /// <returns>The sentence restored to original word order.</returns>
        public string SortSentence(string s)
        {
            string[] words = s.Split(' ');
            string[] ordered = new string[words.Length];
            foreach (string word in words)
                ordered[word[word.Length - 1] - '1'] = word.Substring(0, word.Length - 1);
            return string.Join(" ", ordered);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-word-equals-summation-of-two-words/">1880. Check if Word Equals Summation of Two Words (easy)</a>
        /// Converts words from a=0 through j=9 digits and compares the numeric sum.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="firstWord">The first numeric word.</param>
        /// <param name="secondWord">The second numeric word.</param>
        /// <param name="targetWord">The target numeric word.</param>
        /// <returns><see langword="true"/> if the first two values sum to the target value.</returns>
        public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            return WordValue(firstWord) + WordValue(secondWord) == WordValue(targetWord);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-all-occurrences-of-a-substring/">1910. Remove All Occurrences of a Substring (medium)</a>
        /// Repeatedly removes the leftmost occurrence of part until none remain.
        /// Complexity: O(n*p) practical time and O(n) space.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="part">The substring to remove.</param>
        /// <returns>The remaining string after all removals.</returns>
        public string RemoveOccurrences(string s, string part)
        {
            var result = new StringBuilder();
            foreach (char c in s)
            {
                result.Append(c);
                if (result.Length >= part.Length && EndsWith(result, part))
                    result.Length -= part.Length;
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-length-3-palindromic-subsequences/">1930. Unique Length-3 Palindromic Subsequences (medium)</a>
        /// For each endpoint letter, counts distinct middle letters between its first and last occurrence.
        /// Complexity: O(26n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to scan.</param>
        /// <returns>The number of unique palindromic subsequences of length three.</returns>
        public int CountPalindromicSubsequence(string s)
        {
            int[] first = new int[26];
            int[] last = new int[26];
            Array.Fill(first, -1);
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';
                if (first[index] == -1)
                    first[index] = i;
                last[index] = i;
            }

            int result = 0;
            for (int c = 0; c < 26; c++)
            {
                if (first[c] == -1 || first[c] >= last[c])
                    continue;
                bool[] seen = new bool[26];
                for (int i = first[c] + 1; i < last[c]; i++)
                    seen[s[i] - 'a'] = true;
                for (int i = 0; i < 26; i++)
                    if (seen[i])
                        result++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/">1941. Check if All Characters Have Equal Number of Occurrences (easy)</a>
        /// Counts each lowercase character and verifies all non-zero counts match.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to inspect.</param>
        /// <returns><see langword="true"/> if every present character appears the same number of times.</returns>
        public bool AreOccurrencesEqual(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;
            int expected = 0;
            foreach (int count in counts)
            {
                if (count == 0)
                    continue;
                if (expected == 0)
                    expected = count;
                else if (count != expected)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-digits-of-string-after-convert/">1945. Sum of Digits of String After Convert (easy)</a>
        /// Converts letters to alphabet positions, then repeatedly sums decimal digits k times.
        /// Complexity: O(n + k log value) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to convert.</param>
        /// <param name="k">The number of digit-sum transformations.</param>
        /// <returns>The final integer value.</returns>
        public int GetLucky(string s, int k)
        {
            int value = 0;
            foreach (char c in s)
            {
                int number = c - 'a' + 1;
                value += number / 10 + number % 10;
            }

            for (int i = 1; i < k; i++)
                value = DigitSum(value);
            return value;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-string-is-a-prefix-of-array/">1961. Check If String Is a Prefix of Array (easy)</a>
        /// Concatenates leading words logically and verifies they exactly form the target string.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The target string.</param>
        /// <param name="words">The words whose prefix concatenation is tested.</param>
        /// <returns><see langword="true"/> if some leading words concatenate to <paramref name="s"/>.</returns>
        public bool IsPrefixString(string s, string[] words)
        {
            int index = 0;
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (index == s.Length || s[index++] != c)
                        return false;
                }

                if (index == s.Length)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-unique-binary-string/">1980. Find Unique Binary String (medium)</a>
        /// Uses Cantor's diagonal idea to build a binary string differing from nums[i] at position i.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="nums">Distinct binary strings of length n.</param>
        /// <returns>A binary string of length n that is absent from <paramref name="nums"/>.</returns>
        public string FindDifferentBinaryString(string[] nums)
        {
            char[] result = new char[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                result[i] = nums[i][i] == '0' ? '1' : '0';
            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-prefix-of-word/">2000. Reverse Prefix of Word (easy)</a>
        /// Reverses the prefix ending at the first occurrence of a given character.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="word">The word to transform.</param>
        /// <param name="ch">The character ending the prefix.</param>
        /// <returns>The transformed word, or the original word when <paramref name="ch"/> is absent.</returns>
        public string ReversePrefix(string word, char ch)
        {
            char[] chars = word.ToCharArray();
            int index = word.IndexOf(ch);
            if (index >= 0)
                ReverseRange(chars, 0, index);
            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence/">2042. Check if Numbers Are Ascending in a Sentence (easy)</a>
        /// Parses numbers embedded in a sentence and checks that each is strictly larger than the previous one.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The sentence containing lowercase words and positive integers.</param>
        /// <returns><see langword="true"/> if the numbers are strictly ascending.</returns>
        public bool AreNumbersAscending(string s)
        {
            int previous = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                    continue;
                int value = 0;
                while (i < s.Length && char.IsDigit(s[i]))
                    value = value * 10 + s[i++] - '0';
                if (value <= previous)
                    return false;
                previous = value;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-vowel-substrings-of-a-string/">2062. Count Vowel Substrings of a String (easy)</a>
        /// Starts at each index and extends vowel-only substrings while tracking whether all five vowels appeared.
        /// Complexity: O(n^2) time and O(1) space.
        /// </summary>
        /// <param name="word">The lowercase word to scan.</param>
        /// <returns>The number of substrings containing only vowels and all five vowels.</returns>
        public int CountVowelSubstrings(string word)
        {
            int result = 0;
            for (int start = 0; start < word.Length; start++)
            {
                int mask = 0;
                for (int end = start; end < word.Length && IsLowerVowel(word[end]); end++)
                {
                    mask |= 1 << VowelBit(word[end]);
                    if (mask == 31)
                        result++;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-common-words-with-one-occurrence/">2085. Count Common Words With One Occurrence (easy)</a>
        /// Counts words that appear exactly once in each of two arrays.
        /// Complexity: O(m + n) time and O(m + n) space.
        /// </summary>
        /// <param name="words1">The first word array.</param>
        /// <param name="words2">The second word array.</param>
        /// <returns>The number of words with exactly one occurrence in both arrays.</returns>
        public int CountWords(string[] words1, string[] words2)
        {
            var counts1 = CountWordsByValue(words1);
            var counts2 = CountWordsByValue(words2);
            int result = 0;
            foreach (var pair in counts1)
            {
                if (pair.Value == 1 && counts2.TryGetValue(pair.Key, out int count) && count == 1)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-first-palindromic-string-in-the-array/">2108. Find First Palindromic String in the Array (easy)</a>
        /// Returns the first word that reads the same forward and backward.
        /// Complexity: O(total characters) time and O(1) space.
        /// </summary>
        /// <param name="words">The words to scan in order.</param>
        /// <returns>The first palindromic word, or an empty string when none exists.</returns>
        public string FirstPalindrome(string[] words)
        {
            foreach (string word in words)
            {
                if (IsPalindromeRange(word, 0, word.Length - 1))
                    return word;
            }

            return string.Empty;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/">2114. Maximum Number of Words Found in Sentences (easy)</a>
        /// Counts spaces in each sentence to find its word count and returns the maximum.
        /// Complexity: O(total characters) time and O(1) space.
        /// </summary>
        /// <param name="sentences">The sentences to inspect.</param>
        /// <returns>The largest number of words in any sentence.</returns>
        public int MostWordsFound(string[] sentences)
        {
            int best = 0;
            foreach (string sentence in sentences)
            {
                int words = 1;
                foreach (char c in sentence)
                    if (c == ' ')
                        words++;
                best = Math.Max(best, words);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-all-as-appears-before-all-bs/">2124. Check if All A's Appears Before All B's (easy)</a>
        /// Verifies there is no 'a' after a 'b'.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string consisting only of 'a' and 'b'.</param>
        /// <returns><see langword="true"/> if all a's come before all b's.</returns>
        public bool CheckString(string s)
        {
            bool seenB = false;
            foreach (char c in s)
            {
                if (c == 'b')
                    seenB = true;
                else if (seenB)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/">2131. Longest Palindrome by Concatenating Two Letter Words (medium)</a>
        /// Pairs each two-letter word with its reverse and optionally places one symmetric word in the center.
        /// Complexity: O(n) time and O(1) space for the fixed 26 by 26 table.
        /// </summary>
        /// <param name="words">Two-letter lowercase words.</param>
        /// <returns>The maximum palindrome length that can be built.</returns>
        public int LongestPalindrome(string[] words)
        {
            int[,] counts = new int[26, 26];
            int length = 0;
            bool hasCenter = false;
            foreach (string word in words)
            {
                int a = word[0] - 'a', b = word[1] - 'a';
                if (counts[b, a] > 0)
                {
                    counts[b, a]--;
                    length += 4;
                }
                else
                {
                    counts[a, b]++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (counts[i, i] > 0)
                {
                    hasCenter = true;
                    break;
                }
            }

            return hasCenter ? length + 2 : length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divide-a-string-into-groups-of-size-k/">2138. Divide a String Into Groups of Size k (easy)</a>
        /// Splits a string into size-k groups and pads the final group with fill characters.
        /// Complexity: O(n) time and space.
        /// </summary>
        /// <param name="s">The string to divide.</param>
        /// <param name="k">The group size.</param>
        /// <param name="fill">The character used to pad the final group.</param>
        /// <returns>The array of groups.</returns>
        public string[] DivideString(string s, int k, char fill)
        {
            int groups = (s.Length + k - 1) / k;
            string[] result = new string[groups];
            for (int group = 0; group < groups; group++)
            {
                var current = new StringBuilder(k);
                for (int i = 0; i < k; i++)
                {
                    int index = group * k + i;
                    current.Append(index < s.Length ? s[index] : fill);
                }

                result[group] = current.ToString();
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/counting-words-with-a-given-prefix/">2185. Counting Words With a Given Prefix (easy)</a>
        /// Counts words that start with a specified prefix.
        /// Complexity: O(total prefix length checked) time and O(1) space.
        /// </summary>
        /// <param name="words">The words to inspect.</param>
        /// <param name="pref">The prefix to match.</param>
        /// <returns>The number of words with the prefix.</returns>
        public int PrefixCount(string[] words, string pref)
        {
            int count = 0;
            foreach (string word in words)
            {
                if (word.StartsWith(pref, StringComparison.Ordinal))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-prefixes-of-a-given-string/">2255. Count Prefixes of a Given String (easy)</a>
        /// Counts words that are prefixes of the target string.
        /// Complexity: O(total word length) time and O(1) space.
        /// </summary>
        /// <param name="words">Candidate prefix words.</param>
        /// <param name="s">The target string.</param>
        /// <returns>The number of candidates that prefix <paramref name="s"/>.</returns>
        public int CountPrefixes(string[] words, string s)
        {
            int count = 0;
            foreach (string word in words)
            {
                if (s.StartsWith(word, StringComparison.Ordinal))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-3-same-digit-number-in-string/">2264. Largest 3-Same-Digit Number in String (easy)</a>
        /// Scans for runs of three identical digits and keeps the largest such digit.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="num">The digit string to scan.</param>
        /// <returns>The largest good integer substring, or empty when none exists.</returns>
        public string LargestGoodInteger(string num)
        {
            char best = '\0';
            for (int i = 2; i < num.Length; i++)
            {
                if (num[i] == num[i - 1] && num[i] == num[i - 2] && num[i] > best)
                    best = num[i];
            }

            return best == '\0' ? string.Empty : new string(best, 3);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/">2273. Find Resultant Array After Removing Anagrams (easy)</a>
        /// Removes each word that is an anagram of the immediately previous retained word.
        /// Complexity: O(total characters) time and O(1) auxiliary space beyond the result.
        /// </summary>
        /// <param name="words">The words to process.</param>
        /// <returns>The retained words after adjacent anagram removal.</returns>
        public IList<string> RemoveAnagrams(string[] words)
        {
            var result = new List<string>();
            int[] previous = null;
            foreach (string word in words)
            {
                int[] current = LetterCounts(word);
                if (previous == null || !SameCounts(previous, current))
                {
                    result.Add(word);
                    previous = current;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/percentage-of-letter-in-string/">2278. Percentage of Letter in String (easy)</a>
        /// Computes the integer percentage of characters equal to a target letter.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string to scan.</param>
        /// <param name="letter">The letter to count.</param>
        /// <returns>The floored percentage of matching characters.</returns>
        public int PercentageLetter(string s, char letter)
        {
            int count = 0;
            foreach (char c in s)
                if (c == letter)
                    count++;
            return count * 100 / s.Length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rearrange-characters-to-make-target-string/">2287. Rearrange Characters to Make Target String (easy)</a>
        /// Compares character frequencies to find how many copies of target can be built from s.
        /// Complexity: O(n + m) time and O(1) space.
        /// </summary>
        /// <param name="s">The available lowercase characters.</param>
        /// <param name="target">The target word to build repeatedly.</param>
        /// <returns>The maximum number of target copies that can be formed.</returns>
        public int RearrangeCharacters(string s, string target)
        {
            int[] available = LetterCounts(s);
            int[] needed = LetterCounts(target);
            int result = int.MaxValue;
            for (int i = 0; i < 26; i++)
            {
                if (needed[i] > 0)
                    result = Math.Min(result, available[i] / needed[i]);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/strong-password-checker-ii/">2299. Strong Password Checker II (easy)</a>
        /// Checks length, adjacent duplicates, required character classes, and special characters.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="password">The password candidate.</param>
        /// <returns><see langword="true"/> if the password meets all strength requirements.</returns>
        public bool StrongPasswordCheckerII(string password)
        {
            if (password.Length < 8)
                return false;
            bool lower = false, upper = false, digit = false, special = false;
            const string specials = "!@#$%^&*()-+";
            for (int i = 0; i < password.Length; i++)
            {
                if (i > 0 && password[i] == password[i - 1])
                    return false;
                char c = password[i];
                lower |= char.IsLower(c);
                upper |= char.IsUpper(c);
                digit |= char.IsDigit(c);
                special |= specials.IndexOf(c) >= 0;
            }

            return lower && upper && digit && special;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/greatest-english-letter-in-upper-and-lower-case/">2309. Greatest English Letter in Upper and Lower Case (easy)</a>
        /// Finds the largest letter whose lowercase and uppercase forms both occur.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The mixed-case string to scan.</param>
        /// <returns>The greatest qualifying uppercase letter, or empty when none exists.</returns>
        public string GreatestLetter(string s)
        {
            bool[] lower = new bool[26];
            bool[] upper = new bool[26];
            foreach (char c in s)
            {
                if (char.IsLower(c))
                    lower[c - 'a'] = true;
                else if (char.IsUpper(c))
                    upper[c - 'A'] = true;
            }

            for (int i = 25; i >= 0; i--)
                if (lower[i] && upper[i])
                    return ((char)('A' + i)).ToString();
            return string.Empty;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-asterisks/">2315. Count Asterisks (easy)</a>
        /// Counts asterisks that appear outside pipe-delimited excluded sections.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The string containing asterisks and pipe pairs.</param>
        /// <returns>The number of asterisks outside pipe pairs.</returns>
        public int CountAsterisks(string s)
        {
            bool insideBars = false;
            int count = 0;
            foreach (char c in s)
            {
                if (c == '|')
                    insideBars = !insideBars;
                else if (c == '*' && !insideBars)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decode-the-message/">2325. Decode the Message (easy)</a>
        /// Builds the substitution mapping from the key's first occurrences, then decodes the message.
        /// Complexity: O(k + m) time and O(1) space.
        /// </summary>
        /// <param name="key">The substitution key sentence.</param>
        /// <param name="message">The encoded message.</param>
        /// <returns>The decoded message.</returns>
        public string DecodeMessage(string key, string message)
        {
            char[] map = new char[26];
            char next = 'a';
            foreach (char c in key)
            {
                if (c == ' ' || map[c - 'a'] != '\0')
                    continue;
                map[c - 'a'] = next++;
            }

            char[] result = message.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != ' ')
                    result[i] = map[result[i] - 'a'];
            }

            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/removing-stars-from-a-string/">2390. Removing Stars From a String (medium)</a>
        /// Treats stars as backspaces that delete the nearest kept character to their left.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The string containing lowercase letters and stars.</param>
        /// <returns>The string after all star removals.</returns>
        public string RemoveStars(string s)
        {
            char[] stack = new char[s.Length];
            int length = 0;
            foreach (char c in s)
            {
                if (c == '*')
                    length--;
                else
                    stack[length++] = c;
            }

            return new string(stack, 0, length);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-distances-between-same-letters/">2399. Check Distances Between Same Letters (easy)</a>
        /// Records first positions and validates each second occurrence against the required distance.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string where each letter appears twice.</param>
        /// <param name="distance">Required distances for letters a through z.</param>
        /// <returns><see langword="true"/> if all repeated letters have their required distance.</returns>
        public bool CheckDistances(string s, int[] distance)
        {
            int[] first = new int[26];
            Array.Fill(first, -1);
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';
                if (first[index] == -1)
                    first[index] = i;
                else if (i - first[index] - 1 != distance[index])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/optimal-partition-of-string/">2405. Optimal Partition of String (medium)</a>
        /// Greedily starts a new partition whenever a character would repeat in the current partition.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to partition.</param>
        /// <returns>The minimum number of unique-character substrings.</returns>
        public int PartitionString(string s)
        {
            int count = 1, mask = 0;
            foreach (char c in s)
            {
                int bit = 1 << (c - 'a');
                if ((mask & bit) != 0)
                {
                    count++;
                    mask = 0;
                }

                mask |= bit;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/length-of-the-longest-alphabetical-continuous-substring/">2414. Length of the Longest Alphabetical Continuous Substring (medium)</a>
        /// Finds the longest run where each character is exactly one greater than the previous character.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="s">The lowercase string to scan.</param>
        /// <returns>The maximum alphabetical continuous substring length.</returns>
        public int LongestContinuousSubstring(string s)
        {
            int best = 1, current = 1;
            for (int i = 1; i < s.Length; i++)
            {
                current = s[i] == s[i - 1] + 1 ? current + 1 : 1;
                best = Math.Max(best, current);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/using-a-robot-to-print-the-lexicographically-smallest-string/">2434. Using a Robot to Print the Lexicographically Smallest String (medium)</a>
        /// Uses remaining character counts to pop from the robot stack whenever no smaller character remains unread.
        /// Complexity: O(n + alphabet*n practical) time and O(n) space.
        /// </summary>
        /// <param name="s">The lowercase source string.</param>
        /// <returns>The lexicographically smallest string the robot can print.</returns>
        public string RobotWithString(string s)
        {
            int[] remaining = LetterCounts(s);
            var stack = new List<char>();
            var result = new StringBuilder(s.Length);
            foreach (char c in s)
            {
                remaining[c - 'a']--;
                stack.Add(c);
                while (stack.Count > 0 && stack[stack.Count - 1] <= SmallestRemaining(remaining))
                {
                    result.Append(stack[stack.Count - 1]);
                    stack.RemoveAt(stack.Count - 1);
                }
            }

            while (stack.Count > 0)
            {
                result.Append(stack[stack.Count - 1]);
                stack.RemoveAt(stack.Count - 1);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/">2486. Append Characters to String to Make Subsequence (medium)</a>
        /// Matches t as a subsequence of s and returns the unmatched suffix length of t.
        /// Complexity: O(m + n) time and O(1) space.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="t">The target subsequence string.</param>
        /// <returns>The minimum characters to append to make <paramref name="t"/> a subsequence.</returns>
        public int AppendCharacters(string s, string t)
        {
            int index = 0;
            foreach (char c in s)
            {
                if (index < t.Length && c == t[index])
                    index++;
            }

            return t.Length - index;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/circular-sentence/">2490. Circular Sentence (easy)</a>
        /// Checks that adjacent words connect by matching last and first letters, including the final-to-first link.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="sentence">The sentence to validate.</param>
        /// <returns><see langword="true"/> if the sentence is circular.</returns>
        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[sentence.Length - 1])
                return false;
            for (int i = 1; i < sentence.Length - 1; i++)
            {
                if (sentence[i] == ' ' && sentence[i - 1] != sentence[i + 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array/">2515. Shortest Distance to Target String in a Circular Array (easy)</a>
        /// Checks every target occurrence and minimizes circular distance from the start index.
        /// Complexity: O(n) time and O(1) space.
        /// </summary>
        /// <param name="words">The circular word array.</param>
        /// <param name="target">The target word.</param>
        /// <param name="startIndex">The starting index.</param>
        /// <returns>The shortest circular distance, or -1 if the target is absent.</returns>
        public int ClosetTarget(string[] words, string target, int startIndex)
        {
            int best = int.MaxValue;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != target)
                    continue;
                int distance = Math.Abs(i - startIndex);
                best = Math.Min(best, Math.Min(distance, words.Length - distance));
            }

            return best == int.MaxValue ? -1 : best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-divisibility-array-of-a-string/">2575. Find the Divisibility Array of a String (medium)</a>
        /// Maintains the rolling remainder of each numeric prefix to mark prefixes divisible by m.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="word">The decimal digit string.</param>
        /// <param name="m">The divisor.</param>
        /// <returns>An array where each position is 1 when that prefix is divisible by m, otherwise 0.</returns>
        public int[] DivisibilityArray(string word, int m)
        {
            int[] result = new int[word.Length];
            long remainder = 0;
            for (int i = 0; i < word.Length; i++)
            {
                remainder = (remainder * 10 + word[i] - '0') % m;
                result[i] = remainder == 0 ? 1 : 0;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-number-of-vowel-strings-in-range/">2586. Count the Number of Vowel Strings in Range (easy)</a>
        /// Counts words in the inclusive range whose first and last letters are vowels.
        /// Complexity: O(r - l + 1) time and O(1) space.
        /// </summary>
        /// <param name="words">The lowercase words.</param>
        /// <param name="left">The inclusive start index.</param>
        /// <param name="right">The inclusive end index.</param>
        /// <returns>The number of vowel strings in the range.</returns>
        public int VowelStrings(string[] words, int left, int right)
        {
            int count = 0;
            for (int i = left; i <= right; i++)
            {
                if (IsLowerVowel(words[i][0]) && IsLowerVowel(words[i][words[i].Length - 1]))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lexicographically-smallest-palindrome/">2697. Lexicographically Smallest Palindrome (easy)</a>
        /// Mirrors the smaller character of each symmetric pair to both positions.
        /// Complexity: O(n) time and O(n) space.
        /// </summary>
        /// <param name="s">The lowercase string to transform into a palindrome.</param>
        /// <returns>The lexicographically smallest palindrome obtainable by replacements.</returns>
        public string MakeSmallestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = chars.Length - 1;
            while (left < right)
            {
                char smaller = chars[left] < chars[right] ? chars[left] : chars[right];
                chars[left++] = smaller;
                chars[right--] = smaller;
            }

            return new string(chars);
        }

        private static readonly string[] BelowTwenty =
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] Tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        private sealed class TrieNode
        {
            public readonly TrieNode[] Children = new TrieNode[26];
            public bool IsWord;
        }


        private static int RemovePair(string s, char first, char second, int points, out string remainder)
        {
            char[] stack = new char[s.Length];
            int length = 0, score = 0;
            foreach (char c in s)
            {
                if (length > 0 && stack[length - 1] == first && c == second)
                {
                    length--;
                    score += points;
                }
                else
                {
                    stack[length++] = c;
                }
            }

            remainder = new string(stack, 0, length);
            return score;
        }

        private static int WordValue(string word)
        {
            int value = 0;
            foreach (char c in word)
                value = value * 10 + c - 'a';
            return value;
        }

        private static bool EndsWith(StringBuilder text, string suffix)
        {
            int offset = text.Length - suffix.Length;
            for (int i = 0; i < suffix.Length; i++)
            {
                if (text[offset + i] != suffix[i])
                    return false;
            }

            return true;
        }

        private static int DigitSum(int value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += value % 10;
                value /= 10;
            }

            return sum;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-trailing-zeros-from-a-string/">2710. Remove Trailing Zeros From a String (easy)</a>
        /// Removes all trailing zero characters from a positive integer string while preserving the remaining digits.
        /// </summary>
        /// <param name="num">The decimal number string to trim.</param>
        /// <returns><paramref name="num"/> without any trailing zeroes.</returns>
        public string RemoveTrailingZeros(string num)
        {
            int end = num.Length - 1;
            while (end >= 0 && num[end] == '0')
                end--;

            return num.Substring(0, end + 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimize-string-length/">2716. Minimize String Length (easy)</a>
        /// Finds the smallest possible length after repeatedly deleting duplicate occurrences of characters.
        /// </summary>
        /// <param name="s">The lowercase string to reduce.</param>
        /// <returns>The number of distinct characters in <paramref name="s"/>.</returns>
        public int MinimizedStringLength(string s)
        {
            bool[] seen = new bool[26];
            int distinct = 0;
            foreach (char c in s)
            {
                int index = c - 'a';
                if (!seen[index])
                {
                    seen[index] = true;
                    distinct++;
                }
            }

            return distinct;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lexicographically-smallest-string-after-substring-operation/">2734. Lexicographically Smallest String After Substring Operation (medium)</a>
        /// Applies one substring decrement operation to produce the lexicographically smallest possible string.
        /// </summary>
        /// <param name="s">The lowercase string to transform.</param>
        /// <returns>The lexicographically smallest string obtainable by one valid operation.</returns>
        public string SmallestString(string s)
        {
            char[] chars = s.ToCharArray();
            int index = 0;
            while (index < chars.Length && chars[index] == 'a')
                index++;

            if (index == chars.Length)
            {
                chars[chars.Length - 1] = 'z';
                return new string(chars);
            }

            while (index < chars.Length && chars[index] != 'a')
            {
                chars[index]--;
                index++;
            }

            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-maximum-number-of-string-pairs/">2744. Find Maximum Number of String Pairs (easy)</a>
        /// Counts pairs of two-letter words where one word is the reverse of the other.
        /// </summary>
        /// <param name="words">The distinct two-character words to inspect.</param>
        /// <returns>The maximum number of reverse string pairs.</returns>
        public int MaximumNumberOfStringPairs(string[] words)
        {
            var seen = new HashSet<string>();
            int pairs = 0;
            foreach (string word in words)
            {
                string reversed = new string(new[] { word[1], word[0] });
                if (seen.Contains(reversed))
                    pairs++;
                seen.Add(word);
            }

            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sort-vowels-in-a-string/">2785. Sort Vowels in a String (medium)</a>
        /// Sorts only the vowels in a string by ASCII order while all consonants stay at their original indices.
        /// </summary>
        /// <param name="s">The string whose vowels are sorted.</param>
        /// <returns>A string with sorted vowels and unchanged non-vowels.</returns>
        public string SortVowels(string s)
        {
            var vowels = new List<char>();
            foreach (char c in s)
                if (IsVowel(c))
                    vowels.Add(c);
            vowels.Sort();

            char[] result = s.ToCharArray();
            int vowelIndex = 0;
            for (int i = 0; i < result.Length; i++)
                if (IsVowel(result[i]))
                    result[i] = vowels[vowelIndex++];

            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/make-string-a-subsequence-using-cyclic-increments/">2825. Make String a Subsequence Using Cyclic Increments (medium)</a>
        /// Determines whether str2 can be a subsequence after incrementing chosen str1 characters once cyclically.
        /// </summary>
        /// <param name="str1">The source string whose characters may be incremented.</param>
        /// <param name="str2">The target subsequence to form.</param>
        /// <returns><see langword="true"/> if <paramref name="str2"/> can be formed; otherwise, <see langword="false"/>.</returns>
        public bool CanMakeSubsequence(string str1, string str2)
        {
            int target = 0;
            foreach (char c in str1)
            {
                if (target == str2.Length)
                    break;

                char next = c == 'z' ? 'a' : (char)(c + 1);
                if (str2[target] == c || str2[target] == next)
                    target++;
            }

            return target == str2.Length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-i/">2839. Check if Strings Can be Made Equal With Operations I (easy)</a>
        /// Checks equality for length-four strings when only same-parity index swaps are allowed.
        /// </summary>
        /// <param name="s1">The first four-character string.</param>
        /// <param name="s2">The target four-character string.</param>
        /// <returns><see langword="true"/> if the strings can be made equal; otherwise, <see langword="false"/>.</returns>
        public bool CanBeEqual(string s1, string s2)
        {
            return SameParityCounts(s1, s2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-ii/">2840. Check if Strings Can be Made Equal With Operations II (medium)</a>
        /// Checks equality for strings when arbitrary swaps between indices of the same parity are allowed.
        /// </summary>
        /// <param name="s1">The initial string.</param>
        /// <param name="s2">The target string.</param>
        /// <returns><see langword="true"/> if each parity group has matching character multisets; otherwise, <see langword="false"/>.</returns>
        public bool CheckStrings(string s1, string s2)
        {
            return SameParityCounts(s1, s2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-odd-binary-number/">2864. Maximum Odd Binary Number (easy)</a>
        /// Rearranges a binary string into the largest possible odd binary number.
        /// </summary>
        /// <param name="s">The binary string containing at least one one.</param>
        /// <returns>The lexicographically largest odd binary arrangement.</returns>
        public string MaximumOddBinaryNumber(string s)
        {
            int ones = 0;
            foreach (char c in s)
                if (c == '1')
                    ones++;

            var result = new StringBuilder();
            result.Append('1', ones - 1);
            result.Append('0', s.Length - ones);
            result.Append('1');
            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/make-three-strings-equal/">2937. Make Three Strings Equal (easy)</a>
        /// Removes suffix characters until three strings become equal, minimizing deletions.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <param name="s3">The third string.</param>
        /// <returns>The minimum deletions needed, or -1 when no common non-empty prefix exists.</returns>
        public int FindMinimumOperations(string s1, string s2, string s3)
        {
            int common = 0;
            int limit = Math.Min(s1.Length, Math.Min(s2.Length, s3.Length));
            while (common < limit && s1[common] == s2[common] && s1[common] == s3[common])
                common++;

            return common == 0 ? -1 : s1.Length + s2.Length + s3.Length - 3 * common;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/separate-black-and-white-balls/">2938. Separate Black and White Balls (medium)</a>
        /// Counts adjacent swaps needed to move all white balls before all black balls in a binary string.
        /// </summary>
        /// <param name="s">The string where 0 is white and 1 is black.</param>
        /// <returns>The minimum number of adjacent swaps required.</returns>
        public long MinimumSteps(string s)
        {
            long swaps = 0;
            long blackBefore = 0;
            foreach (char c in s)
            {
                if (c == '1')
                    blackBefore++;
                else
                    swaps += blackBefore;
            }

            return swaps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-words-containing-character/">2942. Find Words Containing Character (easy)</a>
        /// Returns indices of words that contain a requested character.
        /// </summary>
        /// <param name="words">The words to search.</param>
        /// <param name="x">The character to find.</param>
        /// <returns>Indices whose word contains <paramref name="x"/>.</returns>
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            var result = new List<int>();
            for (int i = 0; i < words.Length; i++)
                if (words[i].IndexOf(x) >= 0)
                    result.Add(i);

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-adjacent-almost-equal-characters/">2957. Remove Adjacent Almost-Equal Characters (medium)</a>
        /// Minimizes changes so no adjacent characters are equal or adjacent in the alphabet.
        /// </summary>
        /// <param name="word">The lowercase word to modify.</param>
        /// <returns>The minimum number of character changes required.</returns>
        public int RemoveAlmostEqualCharacters(string word)
        {
            int operations = 0;
            for (int i = 1; i < word.Length; i++)
            {
                if (Math.Abs(word[i] - word[i - 1]) <= 1)
                {
                    operations++;
                    i++;
                }
            }

            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/">3014. Minimum Number of Pushes to Type Word I (easy)</a>
        /// Computes keypad pushes when letters may be assigned in word order to eight keys.
        /// </summary>
        /// <param name="word">The word to type.</param>
        /// <returns>The minimum number of button pushes.</returns>
        public int MinimumPushes(string word)
        {
            int pushes = 0;
            for (int i = 0; i < word.Length; i++)
                pushes += i / 8 + 1;

            return pushes;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/">3016. Minimum Number of Pushes to Type Word II (medium)</a>
        /// Assigns more frequent letters to cheaper keypad positions to minimize total pushes.
        /// </summary>
        /// <param name="word">The word to type.</param>
        /// <returns>The minimum number of button pushes.</returns>
        public int MinimumPushesII(string word)
        {
            int[] counts = new int[26];
            foreach (char c in word)
                counts[c - 'a']++;
            Array.Sort(counts);
            Array.Reverse(counts);

            int pushes = 0;
            for (int i = 0; i < counts.Length && counts[i] > 0; i++)
                pushes += counts[i] * (i / 8 + 1);

            return pushes;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/existence-of-a-substring-in-a-string-and-its-reverse/">3083. Existence of a Substring in a String and Its Reverse (easy)</a>
        /// Determines whether any length-two substring also appears in the reversed string.
        /// </summary>
        /// <param name="s">The lowercase string to inspect.</param>
        /// <returns><see langword="true"/> when such a substring exists; otherwise, <see langword="false"/>.</returns>
        public bool IsSubstringPresent(string s)
        {
            bool[,] pairs = new bool[26, 26];
            for (int i = 1; i < s.Length; i++)
            {
                int first = s[i - 1] - 'a';
                int second = s[i] - 'a';
                if (first == second || pairs[second, first])
                    return true;
                pairs[first, second] = true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/score-of-a-string/">3110. Score of a String (easy)</a>
        /// Sums absolute ASCII differences between adjacent characters.
        /// </summary>
        /// <param name="s">The string to score.</param>
        /// <returns>The total adjacent-character score.</returns>
        public int ScoreOfString(string s)
        {
            int score = 0;
            for (int i = 1; i < s.Length; i++)
                score += Math.Abs(s[i] - s[i - 1]);

            return score;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-number-of-special-characters-i/">3120. Count the Number of Special Characters I (easy)</a>
        /// Counts letters that appear in both lowercase and uppercase forms.
        /// </summary>
        /// <param name="word">The word containing English letters.</param>
        /// <returns>The number of special letters.</returns>
        public int NumberOfSpecialChars(string word)
        {
            bool[] lower = new bool[26];
            bool[] upper = new bool[26];
            foreach (char c in word)
            {
                if (char.IsLower(c))
                    lower[c - 'a'] = true;
                else
                    upper[c - 'A'] = true;
            }

            int count = 0;
            for (int i = 0; i < 26; i++)
                if (lower[i] && upper[i])
                    count++;

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-number-of-special-characters-ii/">3121. Count the Number of Special Characters II (medium)</a>
        /// Counts letters whose lowercase occurrences all appear before every uppercase occurrence.
        /// </summary>
        /// <param name="word">The word containing English letters.</param>
        /// <returns>The number of special letters under the ordering rule.</returns>
        public int NumberOfSpecialCharsII(string word)
        {
            int[] lastLower = new int[26];
            int[] firstUpper = new int[26];
            Array.Fill(lastLower, -1);
            Array.Fill(firstUpper, int.MaxValue);

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (char.IsLower(c))
                    lastLower[c - 'a'] = i;
                else if (firstUpper[c - 'A'] == int.MaxValue)
                    firstUpper[c - 'A'] = i;
            }

            int count = 0;
            for (int i = 0; i < 26; i++)
                if (lastLower[i] >= 0 && firstUpper[i] != int.MaxValue && lastLower[i] < firstUpper[i])
                    count++;

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-word/">3136. Valid Word (easy)</a>
        /// Validates length, alphanumeric content, and presence of at least one vowel and consonant.
        /// </summary>
        /// <param name="word">The candidate word.</param>
        /// <returns><see langword="true"/> if <paramref name="word"/> is valid; otherwise, <see langword="false"/>.</returns>
        public bool IsValidWord(string word)
        {
            if (word.Length < 3)
                return false;

            bool hasVowel = false;
            bool hasConsonant = false;
            foreach (char c in word)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
                if (char.IsLetter(c))
                {
                    if (IsVowel(c))
                        hasVowel = true;
                    else
                        hasConsonant = true;
                }
            }

            return hasVowel && hasConsonant;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-word-k-periodic/">3137. Minimum Number of Operations to Make Word K-Periodic (medium)</a>
        /// Replaces length-k blocks so all blocks are equal using the fewest operations.
        /// </summary>
        /// <param name="word">The word split into equal length-k blocks.</param>
        /// <param name="k">The block length.</param>
        /// <returns>The minimum number of block replacements.</returns>
        public int MinimumOperationsToMakeKPeriodic(string word, int k)
        {
            var counts = new Dictionary<string, int>();
            int maxFrequency = 0;
            int blocks = word.Length / k;
            for (int i = 0; i < word.Length; i += k)
            {
                string block = word.Substring(i, k);
                counts.TryGetValue(block, out int count);
                count++;
                counts[block] = count;
                maxFrequency = Math.Max(maxFrequency, count);
            }

            return blocks - maxFrequency;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/permutation-difference-between-two-strings/">3146. Permutation Difference between Two Strings (easy)</a>
        /// Sums absolute differences between each character's positions in two permutations.
        /// </summary>
        /// <param name="s">The first permutation string.</param>
        /// <param name="t">The second permutation string.</param>
        /// <returns>The permutation difference.</returns>
        public int FindPermutationDifference(string s, string t)
        {
            int[] positions = new int[26];
            for (int i = 0; i < s.Length; i++)
                positions[s[i] - 'a'] = i;

            int difference = 0;
            for (int i = 0; i < t.Length; i++)
                difference += Math.Abs(positions[t[i] - 'a'] - i);

            return difference;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/string-compression-iii/">3163. String Compression III (medium)</a>
        /// Compresses consecutive character groups using chunks of at most nine repeated characters.
        /// </summary>
        /// <param name="word">The word to compress.</param>
        /// <returns>The compressed representation.</returns>
        public string CompressedString(string word)
        {
            var result = new StringBuilder();
            for (int i = 0; i < word.Length;)
            {
                int count = 0;
                char c = word[i];
                while (i < word.Length && word[i] == c && count < 9)
                {
                    i++;
                    count++;
                }

                result.Append(count);
                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/clear-digits/">3174. Clear Digits (easy)</a>
        /// Removes each digit and the closest non-digit character to its left.
        /// </summary>
        /// <param name="s">The string to process.</param>
        /// <returns>The remaining string after all digit-clearing operations.</returns>
        public string ClearDigits(string s)
        {
            var result = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                    result.Length--;
                else
                    result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-encrypted-string/">3210. Find the Encrypted String (easy)</a>
        /// Replaces every character by the character k positions later in circular order.
        /// </summary>
        /// <param name="s">The string to encrypt.</param>
        /// <param name="k">The circular shift distance.</param>
        /// <returns>The encrypted string.</returns>
        public string GetEncryptedString(string s, int k)
        {
            char[] result = new char[s.Length];
            int shift = k % s.Length;
            for (int i = 0; i < s.Length; i++)
                result[i] = s[(i + shift) % s.Length];

            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-length-of-string-after-operations/">3223. Minimum Length of String After Operations (medium)</a>
        /// Computes the minimum remaining length after repeatedly deleting matching pairs around equal characters.
        /// </summary>
        /// <param name="s">The lowercase string to reduce.</param>
        /// <returns>The minimum possible remaining length.</returns>
        public int MinimumLength(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            int length = 0;
            foreach (int count in counts)
            {
                if (count == 0)
                    continue;
                length += count % 2 == 0 ? 2 : 1;
            }

            return length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/hash-divided-string/">3271. Hash Divided String (easy)</a>
        /// Hashes every length-k block by summing character values modulo 26.
        /// </summary>
        /// <param name="s">The lowercase string to hash.</param>
        /// <param name="k">The block size.</param>
        /// <returns>The block hash string.</returns>
        public string StringHash(string s, int k)
        {
            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i += k)
            {
                int sum = 0;
                for (int j = i; j < i + k; j++)
                    sum += s[j] - 'a';
                result.Append((char)('a' + sum % 26));
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-date-to-binary/">3280. Convert Date to Binary (easy)</a>
        /// Converts the year, month, and day components of a yyyy-mm-dd date to binary.
        /// </summary>
        /// <param name="date">The date in yyyy-mm-dd format.</param>
        /// <returns>The binary date representation separated by hyphens.</returns>
        public string ConvertDateToBinary(string date)
        {
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));
            return System.Convert.ToString(year, 2) + "-" + System.Convert.ToString(month, 2) + "-" + System.Convert.ToString(day, 2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-original-typed-string-i/">3330. Find the Original Typed String I (easy)</a>
        /// Counts possible original strings when at most one long-pressed run may be shortened.
        /// </summary>
        /// <param name="word">The typed word.</param>
        /// <returns>The number of possible original strings.</returns>
        public int PossibleStringCount(string word)
        {
            int count = 1;
            for (int i = 1; i < word.Length; i++)
                if (word[i] == word[i - 1])
                    count++;

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-balanced-string/">3340. Check Balanced String (easy)</a>
        /// Checks whether sums of digits at even and odd indices are equal.
        /// </summary>
        /// <param name="num">The numeric string to check.</param>
        /// <returns><see langword="true"/> when the digit sums are balanced; otherwise, <see langword="false"/>.</returns>
        public bool IsBalanced(string num)
        {
            int even = 0;
            int odd = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (i % 2 == 0)
                    even += num[i] - '0';
                else
                    odd += num[i] - '0';
            }

            return even == odd;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rearrange-k-substrings-to-form-target-string/">3365. Rearrange K Substrings to Form Target String (medium)</a>
        /// Tests whether the k equal-sized substrings of s can be rearranged to form t.
        /// </summary>
        /// <param name="s">The source string to partition.</param>
        /// <param name="t">The target string to partition.</param>
        /// <param name="k">The number of equal substrings.</param>
        /// <returns><see langword="true"/> if rearranging source blocks can produce target blocks; otherwise, <see langword="false"/>.</returns>
        public bool IsPossibleToRearrange(string s, string t, int k)
        {
            int blockLength = s.Length / k;
            var counts = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i += blockLength)
            {
                string block = s.Substring(i, blockLength);
                counts.TryGetValue(block, out int count);
                counts[block] = count + 1;
            }

            for (int i = 0; i < t.Length; i += blockLength)
            {
                string block = t.Substring(i, blockLength);
                if (!counts.TryGetValue(block, out int count) || count == 0)
                    return false;
                counts[block] = count - 1;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/substring-matching-pattern/">3407. Substring Matching Pattern (easy)</a>
        /// Checks whether any substring of s matches a pattern containing exactly one wildcard asterisk.
        /// </summary>
        /// <param name="s">The string to search.</param>
        /// <param name="p">The pattern with one '*' wildcard.</param>
        /// <returns><see langword="true"/> if a matching substring exists; otherwise, <see langword="false"/>.</returns>
        public bool HasMatch(string s, string p)
        {
            int star = p.IndexOf('*');
            string prefix = p.Substring(0, star);
            string suffix = p.Substring(star + 1);
            int prefixIndex = s.IndexOf(prefix, StringComparison.Ordinal);
            while (prefixIndex >= 0)
            {
                int suffixIndex = s.IndexOf(suffix, prefixIndex + prefix.Length, StringComparison.Ordinal);
                if (suffixIndex >= 0)
                    return true;
                prefixIndex = s.IndexOf(prefix, prefixIndex + 1, StringComparison.Ordinal);
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-valid-pair-of-adjacent-digits-in-string/">3438. Find Valid Pair of Adjacent Digits in String (easy)</a>
        /// Finds the first adjacent unequal digit pair whose digit frequencies equal their digit values.
        /// </summary>
        /// <param name="s">The digit string to scan.</param>
        /// <returns>The first valid two-character pair, or an empty string if none exists.</returns>
        public string FindValidPair(string s)
        {
            int[] counts = new int[10];
            foreach (char c in s)
                counts[c - '0']++;

            for (int i = 1; i < s.Length; i++)
            {
                int first = s[i - 1] - '0';
                int second = s[i] - '0';
                if (first != second && counts[first] == first && counts[second] == second)
                    return s.Substring(i - 1, 2);
            }

            return string.Empty;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-i/">3442. Maximum Difference Between Even and Odd Frequency I (easy)</a>
        /// Maximizes odd frequency minus even frequency across characters present in the string.
        /// </summary>
        /// <param name="s">The lowercase string to inspect.</param>
        /// <returns>The maximum odd-minus-even frequency difference.</returns>
        public int MaxDifference(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            int maxOdd = int.MinValue;
            int minEven = int.MaxValue;
            foreach (int count in counts)
            {
                if (count == 0)
                    continue;
                if (count % 2 == 1)
                    maxOdd = Math.Max(maxOdd, count);
                else
                    minEven = Math.Min(minEven, count);
            }

            return maxOdd - minEven;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-special-substring-of-length-k/">3456. Find Special Substring of Length K (easy)</a>
        /// Checks for a length-k run whose characters are equal and isolated from equal neighbors.
        /// </summary>
        /// <param name="s">The string to search.</param>
        /// <param name="k">The required substring length.</param>
        /// <returns><see langword="true"/> if a special substring exists; otherwise, <see langword="false"/>.</returns>
        public bool HasSpecialSubstring(string s, int k)
        {
            for (int i = 0; i < s.Length;)
            {
                int j = i;
                while (j < s.Length && s[j] == s[i])
                    j++;
                if (j - i == k)
                    return true;
                i = j;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-most-frequent-vowel-and-consonant/">3541. Find Most Frequent Vowel and Consonant (easy)</a>
        /// Adds the highest vowel frequency and the highest consonant frequency in the string.
        /// </summary>
        /// <param name="s">The lowercase string to inspect.</param>
        /// <returns>The sum of the most frequent vowel and consonant counts.</returns>
        public int MaxFreqSum(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            int maxVowel = 0;
            int maxConsonant = 0;
            for (int i = 0; i < 26; i++)
            {
                char c = (char)('a' + i);
                if (IsLowerVowel(c))
                    maxVowel = Math.Max(maxVowel, counts[i]);
                else
                    maxConsonant = Math.Max(maxConsonant, counts[i]);
            }

            return maxVowel + maxConsonant;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-deletions-for-at-most-k-distinct-characters/">3545. Minimum Deletions for At Most K Distinct Characters (easy)</a>
        /// Deletes characters from the least frequent letters until at most k distinct letters remain.
        /// </summary>
        /// <param name="s">The lowercase string to reduce.</param>
        /// <param name="k">The maximum number of distinct characters allowed.</param>
        /// <returns>The minimum number of deletions needed.</returns>
        public int MinDeletion(string s, int k)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;
            Array.Sort(counts);

            int distinct = 0;
            foreach (int count in counts)
                if (count > 0)
                    distinct++;

            int deletions = 0;
            foreach (int count in counts)
            {
                if (distinct <= k)
                    break;
                if (count == 0)
                    continue;
                deletions += count;
                distinct--;
            }

            return deletions;
        }

        private static bool SameParityCounts(string s1, string s2)
        {
            int[,] counts = new int[2, 26];
            for (int i = 0; i < s1.Length; i++)
            {
                counts[i % 2, s1[i] - 'a']++;
                counts[i % 2, s2[i] - 'a']--;
            }

            for (int parity = 0; parity < 2; parity++)
                for (int letter = 0; letter < 26; letter++)
                    if (counts[parity, letter] != 0)
                        return false;

            return true;
        }

        private static bool IsLowerVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        private static Dictionary<string, int> CountWordsByValue(string[] words)
        {
            var counts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                counts.TryGetValue(word, out int count);
                counts[word] = count + 1;
            }

            return counts;
        }

        private static int[] LetterCounts(string word)
        {
            int[] counts = new int[26];
            foreach (char c in word)
                counts[c - 'a']++;
            return counts;
        }

        private static bool SameCounts(int[] first, int[] second)
        {
            for (int i = 0; i < 26; i++)
                if (first[i] != second[i])
                    return false;
            return true;
        }

        private static char SmallestRemaining(int[] remaining)
        {
            for (int i = 0; i < 26; i++)
                if (remaining[i] > 0)
                    return (char)('a' + i);
            return '{';
        }

        private static string ThreeDigitNumberToWords(int num)
        {
            var parts = new List<string>();
            if (num >= 100)
            {
                parts.Add(BelowTwenty[num / 100]);
                parts.Add("Hundred");
                num %= 100;
            }

            if (num >= 20)
            {
                parts.Add(Tens[num / 10]);
                num %= 10;
            }

            if (num > 0)
                parts.Add(BelowTwenty[num]);

            return string.Join(" ", parts);
        }

        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                   c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
        }

        private static bool IsValidIPv4(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4)
                return false;

            foreach (string part in parts)
            {
                if (part.Length == 0 || part.Length > 3 || (part.Length > 1 && part[0] == '0'))
                    return false;

                int value = 0;
                foreach (char c in part)
                {
                    if (!char.IsDigit(c))
                        return false;
                    value = value * 10 + c - '0';
                }

                if (value > 255)
                    return false;
            }

            return true;
        }

        private static bool IsValidIPv6(string ip)
        {
            string[] parts = ip.Split(':');
            if (parts.Length != 8)
                return false;

            foreach (string part in parts)
            {
                if (part.Length == 0 || part.Length > 4)
                    return false;
                foreach (char c in part)
                {
                    bool hex = char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
                    if (!hex)
                        return false;
                }
            }

            return true;
        }

        private static bool IsSubsequence(string candidate, string source)
        {
            int index = 0;
            foreach (char c in source)
            {
                if (index < candidate.Length && candidate[index] == c)
                    index++;
            }

            return index == candidate.Length;
        }

        private static void ParseComplex(string value, out int real, out int imaginary)
        {
            int plus = value.IndexOf('+');
            real = int.Parse(value.Substring(0, plus));
            imaginary = int.Parse(value.Substring(plus + 1, value.Length - plus - 2));
        }

        private static void ReverseRange(char[] chars, int left, int right)
        {
            while (left < right)
            {
                char temp = chars[left];
                chars[left++] = chars[right];
                chars[right--] = temp;
            }
        }

        private static string FindRoot(TrieNode root, string word)
        {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                if (node.Children[index] == null)
                    return word;
                node = node.Children[index];
                if (node.IsWord)
                    return word.Substring(0, i + 1);
            }

            return word;
        }

        private static int CountPalindromesAroundCenter(string s, int left, int right)
        {
            int count = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }

            return count;
        }

        private static int PreviousTypedIndex(string s, int index)
        {
            int skip = 0;
            while (index >= 0)
            {
                if (s[index] == '#')
                {
                    skip++;
                    index--;
                }
                else if (skip > 0)
                {
                    skip--;
                    index--;
                }
                else
                {
                    break;
                }
            }

            return index;
        }

        private static void CountSentenceWords(string sentence, Dictionary<string, int> counts)
        {
            foreach (string word in sentence.Split(' '))
            {
                counts.TryGetValue(word, out int count);
                counts[word] = count + 1;
            }
        }

        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }

        private static bool IsLeapYear(int year)
        {
            return year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
        }

        private static void AppendAvailable(int[] counts, StringBuilder result, int start, int end, int step)
        {
            for (int i = start; step > 0 ? i <= end : i >= end; i += step)
            {
                if (counts[i] > 0)
                {
                    result.Append((char)('a' + i));
                    counts[i]--;
                }
            }
        }

        private static int VowelBit(char c)
        {
            switch (c)
            {
                case 'a': return 0;
                case 'e': return 1;
                case 'i': return 2;
                case 'o': return 3;
                case 'u': return 4;
                default: return -1;
            }
        }

        private static bool StartsWithAt(string text, int index, string value)
        {
            if (index + value.Length > text.Length)
                return false;
            for (int i = 0; i < value.Length; i++)
            {
                if (text[index + i] != value[i])
                    return false;
            }

            return true;
        }

        private static int MonthNumber(string month)
        {
            switch (month)
            {
                case "Jan": return 1;
                case "Feb": return 2;
                case "Mar": return 3;
                case "Apr": return 4;
                case "May": return 5;
                case "Jun": return 6;
                case "Jul": return 7;
                case "Aug": return 8;
                case "Sep": return 9;
                case "Oct": return 10;
                case "Nov": return 11;
                default: return 12;
            }
        }

        private static bool IsPalindromeRange(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left++] != s[right--])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-k-balanced-substrings/">3703. Remove K-Balanced Substrings (medium)</a>
        /// Repeatedly removes every reducible run boundary of exactly <paramref name="k"/> opening parentheses followed by
        /// <paramref name="k"/> closing parentheses until no such suffix remains.
        /// </summary>
        /// <param name="s">The parentheses string to reduce.</param>
        /// <param name="k">The required half-length of each balanced removable block.</param>
        /// <returns>The final string after all possible removals.</returns>
        public string RemoveSubstring(string s, int k)
        {
            var chars = new List<char>();
            var counts = new List<int>();

            foreach (char c in s)
            {
                if (counts.Count > 0 && chars[^1] == c)
                    counts[^1]++;
                else
                {
                    chars.Add(c);
                    counts.Add(1);
                }

                while (counts.Count >= 2 &&
                    chars[^2] == '(' &&
                    chars[^1] == ')' &&
                    counts[^2] >= k &&
                    counts[^1] >= k)
                {
                    counts[^2] -= k;
                    counts[^1] -= k;

                    if (counts[^1] == 0)
                    {
                        counts.RemoveAt(counts.Count - 1);
                        chars.RemoveAt(chars.Count - 1);
                    }

                    if (counts.Count > 0 && counts[^1] == 0)
                    {
                        counts.RemoveAt(counts.Count - 1);
                        chars.RemoveAt(chars.Count - 1);
                    }

                    if (counts.Count >= 2 && chars[^2] == chars[^1])
                    {
                        counts[^2] += counts[^1];
                        counts.RemoveAt(counts.Count - 1);
                        chars.RemoveAt(chars.Count - 1);
                    }
                }
            }

            var result = new StringBuilder(s.Length);
            for (int i = 0; i < counts.Count; i++)
                result.Append(chars[i], counts[i]);
            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/equal-score-substrings/">3707. Equal Score Substrings (easy)</a>
        /// Checks whether some non-empty split gives equal alphabet-position sums on both sides.
        /// </summary>
        /// <param name="s">The lowercase string to split.</param>
        /// <returns><see langword="true"/> if an equal-score split exists; otherwise, <see langword="false"/>.</returns>
        public bool ScoreBalance(string s)
        {
            int total = 0;
            foreach (char c in s)
                total += c - 'a' + 1;

            int prefix = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                prefix += s[i] - 'a' + 1;
                if (prefix * 2 == total)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-balanced-substring-i/">3713. Longest Balanced Substring I (medium)</a>
        /// <a href="https://leetcode.com/problems/longest-balanced-substring-ii/">3714. Longest Balanced Substring II (hard)</a>
        /// Returns the longest non-empty substring whose distinct characters occur equally often.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <returns>The maximum balanced substring length.</returns>
        public int LongestBalanced(string s)
        {
            bool isAbc = true;
            foreach (char c in s)
            {
                if (c != 'a' && c != 'b' && c != 'c')
                    isAbc = false;
            }

            if (isAbc)
                return LongestBalancedAbc(s);
            return LongestBalancedGeneral(s);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lexicographically-smallest-permutation-greater-than-target/">3720. Lexicographically Smallest Permutation Greater Than Target (hard)</a>
        /// Builds the lexicographically smallest multiset permutation of <paramref name="s"/> that is strictly greater than <paramref name="target"/>.
        /// </summary>
        /// <param name="s">The source multiset of lowercase letters.</param>
        /// <param name="target">The comparison target.</param>
        /// <returns>The smallest permutation greater than <paramref name="target"/>, or an empty string if none exists.</returns>
        public string LexGreaterPermutation(string s, string target)
        {
            int[] original = new int[26];
            foreach (char c in s)
                original[c - 'a']++;

            int[] remaining = (int[])original.Clone();
            int bestIndex = -1;
            int bestChar = -1;

            for (int i = 0; i < target.Length; i++)
            {
                int current = target[i] - 'a';
                for (int c = current + 1; c < 26; c++)
                {
                    if (remaining[c] > 0)
                    {
                        bestIndex = i;
                        bestChar = c;
                        break;
                    }
                }

                if (remaining[current] == 0)
                    break;
                remaining[current]--;
            }

            if (bestIndex == -1)
                return "";

            remaining = (int[])original.Clone();
            var result = new StringBuilder(s.Length);
            for (int i = 0; i < bestIndex; i++)
            {
                result.Append(target[i]);
                remaining[target[i] - 'a']--;
            }

            result.Append((char)('a' + bestChar));
            remaining[bestChar]--;
            AppendSortedCounts(result, remaining);
            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lexicographically-smallest-palindromic-permutation-greater-than-target/">3734. Lexicographically Smallest Palindromic Permutation Greater Than Target (hard)</a>
        /// Finds the smallest palindromic permutation of <paramref name="s"/> that is strictly greater than <paramref name="target"/>.
        /// </summary>
        /// <param name="s">The source multiset of lowercase letters.</param>
        /// <param name="target">The comparison target.</param>
        /// <returns>The smallest qualifying palindromic permutation, or an empty string if none exists.</returns>
        public string LexPalindromicPermutation(string s, string target)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            int oddCount = 0;
            int middleIndex = -1;
            for (int i = 0; i < 26; i++)
            {
                if ((counts[i] & 1) == 1)
                {
                    oddCount++;
                    middleIndex = i;
                }
            }

            if (oddCount > 1)
                return "";

            int[] halfOriginal = new int[26];
            for (int i = 0; i < 26; i++)
                halfOriginal[i] = counts[i] / 2;

            int halfLength = s.Length / 2;
            char middle = middleIndex >= 0 ? (char)('a' + middleIndex) : '\0';
            bool hasMiddle = (s.Length & 1) == 1;

            string equalCandidate = TryBuildEqualHalfPalindrome(target, halfOriginal, halfLength, middle, hasMiddle);
            if (equalCandidate.Length > 0)
                return equalCandidate;

            int[] remaining = (int[])halfOriginal.Clone();
            int bestIndex = -1;
            int bestChar = -1;

            for (int i = 0; i < halfLength; i++)
            {
                int current = target[i] - 'a';
                for (int c = current + 1; c < 26; c++)
                {
                    if (remaining[c] > 0)
                    {
                        bestIndex = i;
                        bestChar = c;
                        break;
                    }
                }

                if (remaining[current] == 0)
                    break;
                remaining[current]--;
            }

            if (bestIndex == -1)
                return "";

            remaining = (int[])halfOriginal.Clone();
            var half = new StringBuilder(halfLength);
            for (int i = 0; i < bestIndex; i++)
            {
                half.Append(target[i]);
                remaining[target[i] - 'a']--;
            }

            half.Append((char)('a' + bestChar));
            remaining[bestChar]--;
            AppendSortedCounts(half, remaining);
            return BuildPalindrome(half.ToString(), middle, hasMiddle);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-string-length-after-balanced-removals/">3746. Minimum String Length After Balanced Removals (medium)</a>
        /// Uses the invariant that every removable substring preserves the difference between counts of <c>a</c> and <c>b</c>.
        /// </summary>
        /// <param name="s">The binary-letter string.</param>
        /// <returns>The minimum achievable length after optimal removals.</returns>
        public int MinLengthAfterRemovals(string s)
        {
            int balance = 0;
            foreach (char c in s)
                balance += c == 'a' ? 1 : -1;
            return Math.Abs(balance);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-flips-to-reverse-binary-string/">3750. Minimum Number of Flips to Reverse Binary String (easy)</a>
        /// Counts mismatched mirrored bits between the binary representation of <paramref name="n"/> and its reverse.
        /// </summary>
        /// <param name="n">The positive integer whose binary representation is inspected.</param>
        /// <returns>The minimum number of bit flips needed.</returns>
        public int MinimumFlips(int n)
        {
            string binary = System.Convert.ToString(n, 2);
            int flips = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] != binary[binary.Length - 1 - i])
                    flips++;
            }

            return flips;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-ii/">3756. Concatenate Non-Zero Digits and Multiply by Sum II (medium)</a>
        /// Answers each query by extracting the non-zero subsequence value modulo 1,000,000,007 and multiplying by its digit sum.
        /// </summary>
        /// <param name="s">The digit string.</param>
        /// <param name="queries">Inclusive substring queries.</param>
        /// <returns>The modular answer for every query.</returns>
        public int[] SumAndMultiply(string s, int[][] queries)
        {
            const int Mod = 1_000_000_007;
            var positions = new List<int>();
            var digits = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '0')
                {
                    positions.Add(i);
                    digits.Add(s[i] - '0');
                }
            }

            int m = digits.Count;
            long[] prefixValue = new long[m + 1];
            long[] prefixSum = new long[m + 1];
            long[] pow10 = new long[m + 1];
            pow10[0] = 1;
            for (int i = 1; i <= m; i++)
                pow10[i] = (pow10[i - 1] * 10) % Mod;
            for (int i = 0; i < m; i++)
            {
                prefixValue[i + 1] = (prefixValue[i] * 10 + digits[i]) % Mod;
                prefixSum[i + 1] = prefixSum[i] + digits[i];
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int start = positions.BinarySearch(left);
                if (start < 0)
                    start = ~start;
                int end = positions.BinarySearch(right);
                if (end < 0)
                    end = ~end - 1;

                if (start > end || start >= m || end < 0)
                    continue;

                int length = end - start + 1;
                long value = (prefixValue[end + 1] - (prefixValue[start] * pow10[length]) % Mod + Mod) % Mod;
                long sum = prefixSum[end + 1] - prefixSum[start];
                result[i] = (int)((value * (sum % Mod)) % Mod);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-substrings-with-distinct-start/">3760. Maximum Substrings With Distinct Start (easy)</a>
        /// The answer equals the number of distinct starting characters available in the string.
        /// </summary>
        /// <param name="s">The lowercase string to split.</param>
        /// <returns>The maximum number of substrings with pairwise distinct starting letters.</returns>
        public int MaxDistinct(string s)
        {
            bool[] seen = new bool[26];
            int count = 0;
            foreach (char c in s)
            {
                int index = c - 'a';
                if (!seen[index])
                {
                    seen[index] = true;
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-deletions-to-make-alternating-substring/">3777. Minimum Deletions to Make Alternating Substring (hard)</a>
        /// Maintains run counts in a segment tree so each range answer is substring length minus its number of runs.
        /// </summary>
        /// <param name="s">The mutable binary-letter string of <c>A</c> and <c>B</c>.</param>
        /// <param name="queries">Update and range queries.</param>
        /// <returns>The answers for every type-2 query.</returns>
        public int[] MinDeletions(string s, int[][] queries)
        {
            char[] chars = s.ToCharArray();
            int n = chars.Length;
            int size = 1;
            while (size < n)
                size <<= 1;

            int[] lengths = new int[size << 1];
            int[] runs = new int[size << 1];
            char[] first = new char[size << 1];
            char[] last = new char[size << 1];

            void Pull(int node)
            {
                int leftNode = node << 1;
                int rightNode = leftNode | 1;
                lengths[node] = lengths[leftNode] + lengths[rightNode];
                if (lengths[node] == 0)
                    return;
                if (lengths[leftNode] == 0)
                {
                    runs[node] = runs[rightNode];
                    first[node] = first[rightNode];
                    last[node] = last[rightNode];
                    return;
                }
                if (lengths[rightNode] == 0)
                {
                    runs[node] = runs[leftNode];
                    first[node] = first[leftNode];
                    last[node] = last[leftNode];
                    return;
                }

                runs[node] = runs[leftNode] + runs[rightNode] - (last[leftNode] == first[rightNode] ? 1 : 0);
                first[node] = first[leftNode];
                last[node] = last[rightNode];
            }

            void SetValue(int index, char value)
            {
                int node = index + size;
                lengths[node] = 1;
                runs[node] = 1;
                first[node] = value;
                last[node] = value;
                node >>= 1;
                while (node > 0)
                {
                    Pull(node);
                    node >>= 1;
                }
            }

            for (int i = 0; i < n; i++)
                SetValue(i, chars[i]);

            (int length, int runCount, char firstChar, char lastChar) Query(int leftIndex, int rightIndex, int node, int nodeLeft, int nodeRight)
            {
                if (rightIndex < nodeLeft || nodeRight < leftIndex)
                    return (0, 0, '\0', '\0');
                if (leftIndex <= nodeLeft && nodeRight <= rightIndex)
                    return (lengths[node], runs[node], first[node], last[node]);

                int middle = (nodeLeft + nodeRight) >> 1;
                var leftPart = Query(leftIndex, rightIndex, node << 1, nodeLeft, middle);
                var rightPart = Query(leftIndex, rightIndex, (node << 1) | 1, middle + 1, nodeRight);

                if (leftPart.length == 0)
                    return rightPart;
                if (rightPart.length == 0)
                    return leftPart;

                return (
                    leftPart.length + rightPart.length,
                    leftPart.runCount + rightPart.runCount - (leftPart.lastChar == rightPart.firstChar ? 1 : 0),
                    leftPart.firstChar,
                    rightPart.lastChar);
            }

            var answers = new List<int>();
            foreach (int[] query in queries)
            {
                if (query[0] == 1)
                {
                    int index = query[1];
                    chars[index] = chars[index] == 'A' ? 'B' : 'A';
                    SetValue(index, chars[index]);
                }
                else
                {
                    var info = Query(query[1], query[2], 1, 0, size - 1);
                    answers.Add(info.length - info.runCount);
                }
            }

            return answers.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-after-binary-swaps/">3781. Maximum Score After Binary Swaps (medium)</a>
        /// Greedily assigns each encountered one to the best available prefix position.
        /// </summary>
        /// <param name="nums">The per-index scores.</param>
        /// <param name="s">The binary string describing initial one positions.</param>
        /// <returns>The maximum obtainable score.</returns>
        public long MaximumScore(int[] nums, string s)
        {
            var heap = new PriorityQueue<int, int>();
            long score = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                heap.Enqueue(nums[i], -nums[i]);
                if (s[i] == '1')
                    score += heap.Dequeue();
            }

            return score;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-deletion-cost-to-make-all-characters-equal/">3784. Minimum Deletion Cost to Make All Characters Equal (medium)</a>
        /// Keeps every occurrence of the most valuable character class and deletes the rest.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <param name="cost">Deletion costs aligned with <paramref name="s"/>.</param>
        /// <returns>The minimum total deletion cost.</returns>
        public long MinCost(string s, int[] cost)
        {
            long total = 0;
            long[] keep = new long[26];
            for (int i = 0; i < s.Length; i++)
            {
                total += cost[i];
                keep[s[i] - 'a'] += cost[i];
            }

            long bestKeep = 0;
            foreach (long value in keep)
                bestKeep = Math.Max(bestKeep, value);
            return total - bestKeep;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-string-prefix/">3794. Reverse String Prefix (easy)</a>
        /// Reverses the first <paramref name="k"/> characters of the input string.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="k">The prefix length to reverse.</param>
        /// <returns>The transformed string.</returns>
        public string ReversePrefix(string s, int k)
        {
            char[] chars = s.ToCharArray();
            ReverseRange(chars, 0, k - 1);
            return new string(chars);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-even-number/">3798. Largest Even Number (easy)</a>
        /// Because only digits 1 and 2 are present, the optimal answer is the longest prefix ending at the last 2.
        /// </summary>
        /// <param name="s">The string of digits 1 and 2.</param>
        /// <returns>The largest even subsequence value as a string.</returns>
        public string LargestEven(string s)
        {
            int lastTwo = s.LastIndexOf('2');
            return lastTwo < 0 ? "" : s[..(lastTwo + 1)];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/word-squares-ii/">3799. Word Squares II (medium)</a>
        /// Enumerates all distinct 4-tuples and keeps those satisfying the four required corner equalities.
        /// </summary>
        /// <param name="words">Distinct four-letter words.</param>
        /// <returns>All valid word squares sorted lexicographically by tuple.</returns>
        public IList<IList<string>> WordSquares(string[] words)
        {
            var result = new List<IList<string>>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (j == i)
                        continue;
                    for (int k = 0; k < words.Length; k++)
                    {
                        if (k == i || k == j)
                            continue;
                        for (int l = 0; l < words.Length; l++)
                        {
                            if (l == i || l == j || l == k)
                                continue;
                            string top = words[i];
                            string left = words[j];
                            string right = words[k];
                            string bottom = words[l];
                            if (top[0] == left[0] &&
                                top[3] == right[0] &&
                                bottom[0] == left[3] &&
                                bottom[3] == right[3])
                            {
                                result.Add(new List<string> { top, left, right, bottom });
                            }
                        }
                    }
                }
            }

            result.Sort((a, b) =>
            {
                for (int i = 0; i < 4; i++)
                {
                    int comparison = string.CompareOrdinal(a[i], b[i]);
                    if (comparison != 0)
                        return comparison;
                }
                return 0;
            });

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-make-two-binary-strings-equal/">3800. Minimum Cost to Make Two Binary Strings Equal (medium)</a>
        /// Optimally combines flips, within-string swaps, and cross swaps by counting mismatch types.
        /// </summary>
        /// <param name="s">The first binary string.</param>
        /// <param name="t">The second binary string.</param>
        /// <param name="flipCost">The cost of flipping one bit.</param>
        /// <param name="swapCost">The cost of swapping two bits inside one string.</param>
        /// <param name="crossCost">The cost of swapping aligned bits across the two strings.</param>
        /// <returns>The minimum total cost.</returns>
        public long MinimumCost(string s, string t, int flipCost, int swapCost, int crossCost)
        {
            int zeroOne = 0;
            int oneZero = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t[i])
                    continue;
                if (s[i] == '0')
                    zeroOne++;
                else
                    oneZero++;
            }

            long flip = flipCost;
            long cost = (long)(zeroOne + oneZero) * flip;
            long pairSave = Math.Max(0L, 2L * flip - swapCost);
            long convertSave = Math.Max(0L, 2L * flip - (swapCost + (long)crossCost));
            int directPairs = Math.Min(zeroOne, oneZero);
            int leftovers = Math.Abs(zeroOne - oneZero);

            cost -= pairSave * directPairs;
            cost -= convertSave * (leftovers / 2);
            return cost;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-residue-prefixes/">3803. Count Residue Prefixes (easy)</a>
        /// Tracks the number of distinct characters in each prefix and counts those matching prefix length modulo three.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <returns>The number of residue prefixes.</returns>
        public int ResiduePrefixes(string s)
        {
            bool[] seen = new bool[26];
            int distinct = 0;
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';
                if (!seen[index])
                {
                    seen[index] = true;
                    distinct++;
                }

                if (distinct == (i + 1) % 3)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-caesar-cipher-pairs/">3805. Count Caesar Cipher Pairs (medium)</a>
        /// Normalizes each word by subtracting its first character modulo 26 and counts equal normalized patterns.
        /// </summary>
        /// <param name="words">The lowercase words.</param>
        /// <returns>The number of similar pairs.</returns>
        public long CountPairs(string[] words)
        {
            var counts = new Dictionary<string, long>();
            long result = 0;
            foreach (string word in words)
            {
                var key = new StringBuilder(word.Length);
                int shift = word[0] - 'a';
                foreach (char c in word)
                    key.Append((char)('a' + ((c - 'a' - shift + 26) % 26)));

                string normalized = key.ToString();
                if (counts.TryGetValue(normalized, out long frequency))
                    result += frequency;
                counts[normalized] = frequency + 1;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/vowel-consonant-score/">3813. Vowel-Consonant Score (easy)</a>
        /// Counts lowercase vowels and consonants while ignoring spaces and digits.
        /// </summary>
        /// <param name="s">The mixed character string.</param>
        /// <returns>The floor of vowels divided by consonants, or zero when no consonants exist.</returns>
        public int VowelConsonantScore(string s)
        {
            int vowels = 0;
            int consonants = 0;
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                    continue;
                if (IsVowel(c))
                    vowels++;
                else
                    consonants++;
            }

            return consonants == 0 ? 0 : vowels / consonants;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lexicographically-smallest-string-after-deleting-duplicate-characters/">3816. Lexicographically Smallest String After Deleting Duplicate Characters (medium)</a>
        /// Greedily keeps the smallest feasible next character while ensuring every distinct character still appears before the construction stops.
        /// </summary>
        /// <param name="s">The lowercase source string.</param>
        /// <returns>The lexicographically smallest reachable string.</returns>
        public string LexSmallestAfterDeletion(string s)
        {
            int n = s.Length;
            int[] last = new int[26];
            Array.Fill(last, -1);
            int allMask = 0;
            for (int i = 0; i < n; i++)
            {
                int index = s[i] - 'a';
                last[index] = i;
                allMask |= 1 << index;
            }

            int[][] next = new int[n + 1][];
            next[n] = new int[26];
            Array.Fill(next[n], -1);
            for (int i = n - 1; i >= 0; i--)
            {
                next[i] = (int[])next[i + 1].Clone();
                next[i][s[i] - 'a'] = i;
            }

            int keptMask = 0;
            int pos = 0;
            var result = new StringBuilder();

            while (keptMask != allMask)
            {
                int missingMask = allMask & ~keptMask;
                for (int c = 0; c < 26; c++)
                {
                    int index = next[pos][c];
                    if (index < 0)
                        continue;

                    int limit = int.MaxValue;
                    for (int x = 0; x < 26; x++)
                    {
                        if ((missingMask & (1 << x)) == 0)
                            continue;
                        if (x == c && (keptMask & (1 << c)) == 0)
                            continue;
                        limit = Math.Min(limit, last[x]);
                    }

                    if (index <= limit)
                    {
                        result.Append((char)('a' + c));
                        keptMask |= 1 << c;
                        pos = index + 1;
                        break;
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-letters-then-special-characters-in-a-string/">3823. Reverse Letters Then Special Characters in a String (easy)</a>
        /// Reverses letters among letter slots and special characters among special slots independently.
        /// </summary>
        /// <param name="s">The mixed string.</param>
        /// <returns>The transformed string.</returns>
        public string ReverseByType(string s)
        {
            var letters = new List<char>();
            var specials = new List<char>();
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                    letters.Add(c);
                else
                    specials.Add(c);
            }

            letters.Reverse();
            specials.Reverse();

            char[] result = new char[s.Length];
            int letterIndex = 0;
            int specialIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                    result[i] = letters[letterIndex++];
                else
                    result[i] = specials[specialIndex++];
            }

            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/weighted-word-mapping/">3838. Weighted Word Mapping (easy)</a>
        /// Maps each word's weighted sum modulo 26 to a reverse-alphabet character.
        /// </summary>
        /// <param name="words">The lowercase words.</param>
        /// <param name="weights">Letter weights from a to z.</param>
        /// <returns>The mapped output string.</returns>
        public string MapWordWeights(string[] words, int[] weights)
        {
            var result = new StringBuilder(words.Length);
            foreach (string word in words)
            {
                long total = 0;
                foreach (char c in word)
                    total += weights[c - 'a'];
                result.Append((char)('z' - (int)(total % 26)));
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-prefix-connected-groups/">3839. Number of Prefix Connected Groups (medium)</a>
        /// Counts prefix classes of length <paramref name="k"/> that appear at least twice.
        /// </summary>
        /// <param name="words">The words to group.</param>
        /// <param name="k">The shared prefix length.</param>
        /// <returns>The number of groups containing at least two words.</returns>
        public int PrefixConnected(string[] words, int k)
        {
            var counts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (word.Length < k)
                    continue;
                string prefix = word[..k];
                counts[prefix] = counts.TryGetValue(prefix, out int value) ? value + 1 : 1;
            }

            int result = 0;
            foreach (int value in counts.Values)
                if (value >= 2)
                    result++;
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/palindromic-path-queries-in-a-tree/">3841. Palindromic Path Queries in a Tree (hard)</a>
        /// Uses heavy-light decomposition and XOR parity masks to answer path-palindrome queries with point updates.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <param name="s">The node labels.</param>
        /// <param name="queries">Update and query commands.</param>
        /// <returns>The answers for each query command.</returns>
        public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] parent = new int[n];
            int[] depth = new int[n];
            int[] heavy = new int[n];
            int[] size = new int[n];
            Array.Fill(heavy, -1);

            var stack = new Stack<(int node, int par, bool exit)>();
            stack.Push((0, -1, false));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!current.exit)
                {
                    parent[current.node] = current.par;
                    stack.Push((current.node, current.par, true));
                    foreach (int next in graph[current.node])
                    {
                        if (next == current.par)
                            continue;
                        depth[next] = depth[current.node] + 1;
                        stack.Push((next, current.node, false));
                    }
                }
                else
                {
                    size[current.node] = 1;
                    int bestSize = 0;
                    foreach (int next in graph[current.node])
                    {
                        if (next == current.par)
                            continue;
                        size[current.node] += size[next];
                        if (size[next] > bestSize)
                        {
                            bestSize = size[next];
                            heavy[current.node] = next;
                        }
                    }
                }
            }

            int[] head = new int[n];
            int[] position = new int[n];
            int currentPosition = 0;
            var decompose = new Stack<(int node, int chainHead)>();
            decompose.Push((0, 0));
            while (decompose.Count > 0)
            {
                var (node, chainHead) = decompose.Pop();
                for (int u = node; u != -1; u = heavy[u])
                {
                    head[u] = chainHead;
                    position[u] = currentPosition++;
                    foreach (int next in graph[u])
                    {
                        if (next != parent[u] && next != heavy[u])
                            decompose.Push((next, next));
                    }
                }
            }

            int segSize = 1;
            while (segSize < n)
                segSize <<= 1;
            int[] seg = new int[segSize << 1];
            for (int i = 0; i < n; i++)
                seg[position[i] + segSize] = 1 << (s[i] - 'a');
            for (int i = segSize - 1; i > 0; i--)
                seg[i] = seg[i << 1] ^ seg[(i << 1) | 1];

            void Update(int node, char value)
            {
                int index = position[node] + segSize;
                seg[index] = 1 << (value - 'a');
                index >>= 1;
                while (index > 0)
                {
                    seg[index] = seg[index << 1] ^ seg[(index << 1) | 1];
                    index >>= 1;
                }
            }

            int QueryRange(int left, int right)
            {
                int result = 0;
                for (left += segSize, right += segSize; left <= right; left >>= 1, right >>= 1)
                {
                    if ((left & 1) == 1)
                        result ^= seg[left++];
                    if ((right & 1) == 0)
                        result ^= seg[right--];
                }
                return result;
            }

            int QueryPath(int u, int v)
            {
                int result = 0;
                while (head[u] != head[v])
                {
                    if (depth[head[u]] < depth[head[v]])
                    {
                        int temp = u;
                        u = v;
                        v = temp;
                    }

                    result ^= QueryRange(position[head[u]], position[u]);
                    u = parent[head[u]];
                }

                if (depth[u] > depth[v])
                {
                    int temp = u;
                    u = v;
                    v = temp;
                }

                result ^= QueryRange(position[u], position[v]);
                return result;
            }

            char[] labels = s.ToCharArray();
            var answers = new List<bool>();
            foreach (string query in queries)
            {
                string[] parts = query.Split(' ');
                if (parts[0] == "update")
                {
                    int node = int.Parse(parts[1]);
                    char value = parts[2][0];
                    labels[node] = value;
                    Update(node, value);
                }
                else
                {
                    int u = int.Parse(parts[1]);
                    int v = int.Parse(parts[2]);
                    int mask = QueryPath(u, v);
                    answers.Add(mask == 0 || (mask & (mask - 1)) == 0);
                }
            }

            return answers;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-almost-palindromic-substring/">3844. Longest Almost-Palindromic Substring (medium)</a>
        /// Uses dynamic programming for exact palindromes and one-deletion palindromes over all substrings.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <returns>The length of the longest almost-palindromic substring.</returns>
        public int AlmostPalindromic(string s)
        {
            int n = s.Length;
            bool[,] palindrome = new bool[n, n];
            bool[,] almost = new bool[n, n];
            int best = 1;

            for (int length = 1; length <= n; length++)
            {
                for (int left = 0; left + length <= n; left++)
                {
                    int right = left + length - 1;
                    palindrome[left, right] = s[left] == s[right] && (length <= 2 || palindrome[left + 1, right - 1]);

                    if (length <= 2)
                    {
                        almost[left, right] = true;
                    }
                    else if (s[left] == s[right])
                    {
                        almost[left, right] = almost[left + 1, right - 1];
                    }
                    else
                    {
                        almost[left, right] = palindrome[left + 1, right] || palindrome[left, right - 1];
                    }

                    if (almost[left, right])
                        best = length;
                }
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-bitwise-xor-after-rearrangement/">3849. Maximum Bitwise XOR After Rearrangement (medium)</a>
        /// Greedily places opposite bits from <paramref name="t"/> as early as possible to maximize the XOR value.
        /// </summary>
        /// <param name="s">The fixed binary string.</param>
        /// <param name="t">The rearrangeable binary string.</param>
        /// <returns>The lexicographically maximum XOR result string.</returns>
        public string MaximumXor(string s, string t)
        {
            int zeros = 0;
            int ones = 0;
            foreach (char c in t)
            {
                if (c == '0')
                    zeros++;
                else
                    ones++;
            }

            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (ones > 0)
                    {
                        result[i] = '1';
                        ones--;
                    }
                    else
                    {
                        result[i] = '0';
                        zeros--;
                    }
                }
                else
                {
                    if (zeros > 0)
                    {
                        result[i] = '1';
                        zeros--;
                    }
                    else
                    {
                        result[i] = '0';
                        ones--;
                    }
                }
            }

            return new string(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-close-characters/">3853. Merge Close Characters (medium)</a>
        /// Maintains the current string and discards a character whenever an equal kept character lies within distance <paramref name="k"/>.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <param name="k">The maximum merge distance.</param>
        /// <returns>The string after all deterministic merges complete.</returns>
        public string MergeCharacters(string s, int k)
        {
            var result = new StringBuilder();
            int[] lastPosition = new int[26];
            Array.Fill(lastPosition, -1);

            foreach (char c in s)
            {
                int index = c - 'a';
                if (lastPosition[index] >= 0 && result.Length - lastPosition[index] <= k)
                    continue;

                lastPosition[index] = result.Length;
                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/trim-trailing-vowels/">3856. Trim Trailing Vowels (easy)</a>
        /// Removes all trailing lowercase vowels from the string.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <returns>The trimmed string.</returns>
        public string TrimTrailingVowels(string s)
        {
            int end = s.Length - 1;
            while (end >= 0 && IsVowel(s[end]))
                end--;
            return s[..(end + 1)];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-partition-a-binary-string/">3864. Minimum Cost to Partition a Binary String (medium)</a>
        /// Recursively compares keeping a segment whole versus splitting it into equal halves.
        /// </summary>
        /// <param name="s">The binary string.</param>
        /// <param name="encCost">The sensitive-segment multiplier.</param>
        /// <param name="flatCost">The cost of an all-zero segment.</param>
        /// <returns>The minimum achievable partition cost.</returns>
        public long MinCost(string s, int encCost, int flatCost)
        {
            int[] prefix = new int[s.Length + 1];
            for (int i = 0; i < s.Length; i++)
                prefix[i + 1] = prefix[i] + (s[i] - '0');

            long Solve(int start, int length)
            {
                int ones = prefix[start + length] - prefix[start];
                long keep = ones == 0 ? flatCost : (long)length * ones * encCost;
                if ((length & 1) == 1)
                    return keep;

                long split = Solve(start, length / 2) + Solve(start + length / 2, length / 2);
                return Math.Min(keep, split);
            }

            return Solve(0, s.Length);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/first-matching-character-from-both-ends/">3884. First Matching Character From Both Ends (easy)</a>
        /// Scans mirrored positions from the outside inward and returns the first matching index.
        /// </summary>
        /// <param name="s">The lowercase string.</param>
        /// <returns>The smallest matching mirrored index, or -1 if none exists.</returns>
        public int FirstMatchingIndex(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == s[s.Length - 1 - i])
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/mirror-frequency-distance/">3889. Mirror Frequency Distance (easy)</a>
        /// Sums absolute frequency differences across each distinct mirrored letter or digit pair exactly once.
        /// </summary>
        /// <param name="s">The alphanumeric string.</param>
        /// <returns>The total mirrored frequency distance.</returns>
        public int MirrorFrequency(string s)
        {
            int[] letters = new int[26];
            int[] digits = new int[10];
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                    letters[c - 'a']++;
                else
                    digits[c - '0']++;
            }

            int result = 0;
            for (int i = 0; i < 13; i++)
                result += Math.Abs(letters[i] - letters[25 - i]);
            for (int i = 0; i < 5; i++)
                result += Math.Abs(digits[i] - digits[9 - i]);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/traffic-signal-color/">3894. Traffic Signal Color (easy)</a>
        /// Applies the given timer rules directly.
        /// </summary>
        /// <param name="timer">The remaining seconds on the signal.</param>
        /// <returns>The current signal state.</returns>
        public string TrafficSignal(int timer)
        {
            if (timer == 0)
                return "Green";
            if (timer == 30)
                return "Orange";
            if (timer > 30 && timer <= 90)
                return "Red";
            return "Invalid";
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/score-validator/">3921. Score Validator (easy)</a>
        /// Simulates the event stream until it ends or ten wickets have fallen.
        /// </summary>
        /// <param name="events">The event sequence.</param>
        /// <returns>The final score and wicket counter.</returns>
        public int[] ScoreValidator(string[] events)
        {
            int score = 0;
            int counter = 0;
            foreach (string e in events)
            {
                if (counter == 10)
                    break;

                switch (e)
                {
                    case "W":
                        counter++;
                        break;
                    case "WD":
                    case "NB":
                        score++;
                        break;
                    default:
                        score += e[0] - '0';
                        break;
                }
            }

            return new[] { score, counter };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-flips-to-make-binary-string-coherent/">3922. Minimum Flips to Make Binary String Coherent (medium)</a>
        /// Minimizes the Hamming distance to the small family of coherent target strings.
        /// </summary>
        /// <param name="s">The binary string.</param>
        /// <returns>The minimum number of flips required.</returns>
        public int MinFlips(string s)
        {
            int n = s.Length;
            int ones = 0;
            foreach (char c in s)
                if (c == '1')
                    ones++;

            int best = Math.Min(ones, n - ones);
            if (ones > 0)
                best = Math.Min(best, ones - 1);
            else
                best = Math.Min(best, 1);

            if (n >= 2)
            {
                int interiorOnes = ones - (s[0] == '1' ? 1 : 0) - (s[n - 1] == '1' ? 1 : 0);
                int endpointCost = interiorOnes + (s[0] == '1' ? 0 : 1) + (s[n - 1] == '1' ? 0 : 1);
                best = Math.Min(best, endpointCost);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-valid-word-occurrences/">3926. Count Valid Word Occurrences (medium)</a>
        /// Tokenizes the concatenated text using lowercase letters and joiner hyphens, then counts exact word matches.
        /// </summary>
        /// <param name="chunks">The pieces to concatenate.</param>
        /// <param name="queries">The queried words.</param>
        /// <returns>The occurrence count for each query word.</returns>
        public int[] CountWordOccurrences(string[] chunks, string[] queries)
        {
            string text = string.Concat(chunks);
            var counts = new Dictionary<string, int>();
            var current = new StringBuilder();

            bool IsJoinerHyphen(int index) =>
                text[index] == '-' &&
                index > 0 &&
                index + 1 < text.Length &&
                text[index - 1] >= 'a' && text[index - 1] <= 'z' &&
                text[index + 1] >= 'a' && text[index + 1] <= 'z';

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bool inWord = (c >= 'a' && c <= 'z') || IsJoinerHyphen(i);
                if (inWord)
                {
                    current.Append(c);
                }
                else if (current.Length > 0)
                {
                    string word = current.ToString();
                    counts[word] = counts.TryGetValue(word, out int value) ? value + 1 : 1;
                    current.Clear();
                }
            }

            if (current.Length > 0)
            {
                string word = current.ToString();
                counts[word] = counts.TryGetValue(word, out int value) ? value + 1 : 1;
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                result[i] = counts.TryGetValue(queries[i], out int value) ? value : 0;
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-adjacent-digit-differences/">3931. Check Adjacent Digit Differences (easy)</a>
        /// Verifies that every adjacent digit pair differs by at most two.
        /// </summary>
        /// <param name="s">The digit string.</param>
        /// <returns><see langword="true"/> if all adjacent differences are at most two.</returns>
        public bool IsAdjacentDiffAtMostTwo(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (Math.Abs(s[i] - s[i - 1]) > 2)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/password-strength/">3941. Password Strength (easy)</a>
        /// Adds each distinct character's category weight once.
        /// </summary>
        /// <param name="password">The password string.</param>
        /// <returns>The computed strength score.</returns>
        public int PasswordStrength(string password)
        {
            bool[] seen = new bool[128];
            int result = 0;
            foreach (char c in password)
            {
                if (seen[c])
                    continue;
                seen[c] = true;

                if (c >= 'a' && c <= 'z')
                    result += 1;
                else if (c >= 'A' && c <= 'Z')
                    result += 2;
                else if (c >= '0' && c <= '9')
                    result += 3;
                else if (c == '!' || c == '@' || c == '#' || c == '$')
                    result += 5;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-total-value-of-covered-indices/">3952. Maximum Total Value of Covered Indices (medium)</a>
        /// Chooses whether each token moves left once while accounting for indices covered by either adjacent token.
        /// </summary>
        /// <param name="nums">The index values.</param>
        /// <param name="s">The token indicator string.</param>
        /// <returns>The maximum covered total.</returns>
        public long MaxTotal(int[] nums, string s)
        {
            const long Impossible = long.MinValue / 4;
            long stay = 0;
            long move = Impossible;

            for (int i = 0; i < s.Length - 1; i++)
            {
                long nextStay = Math.Max(
                    stay + (s[i] == '1' ? nums[i] : 0),
                    move);
                long nextMove = Impossible;
                if (s[i + 1] == '1')
                    nextMove = Math.Max(stay, move) + nums[i];

                stay = nextStay;
                move = nextMove;
            }

            return Math.Max(
                stay + (s[s.Length - 1] == '1' ? nums[s.Length - 1] : 0),
                move);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-binary-strings-with-cost-limit/">3955. Valid Binary Strings With Cost Limit (medium)</a>
        /// Backtracks over all length-<paramref name="n"/> binary strings with no consecutive ones and bounded index sum.
        /// </summary>
        /// <param name="n">The target length.</param>
        /// <param name="k">The maximum allowed cost.</param>
        /// <returns>All valid strings in arbitrary order.</returns>
        public IList<string> GenerateValidStrings(int n, int k)
        {
            var result = new List<string>();
            char[] current = new char[n];

            void Dfs(int index, bool previousOne, int cost)
            {
                if (cost > k)
                    return;
                if (index == n)
                {
                    result.Add(new string(current));
                    return;
                }

                current[index] = '0';
                Dfs(index + 1, false, cost);

                if (!previousOne)
                {
                    current[index] = '1';
                    Dfs(index + 1, true, cost + index);
                }
            }

            Dfs(0, false, 0);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-manhattan-distance-after-all-moves/">3968. Maximum Manhattan Distance After All Moves (medium)</a>
        /// Each wildcard can increase the final Manhattan distance by exactly one.
        /// </summary>
        /// <param name="moves">The move string containing fixed moves and wildcards.</param>
        /// <returns>The maximum achievable Manhattan distance from the origin.</returns>
        public int MaxDistance(string moves)
        {
            int x = 0;
            int y = 0;
            int wildcards = 0;
            foreach (char move in moves)
            {
                switch (move)
                {
                    case 'L': x--; break;
                    case 'R': x++; break;
                    case 'D': y--; break;
                    case 'U': y++; break;
                    default: wildcards++; break;
                }
            }

            return Math.Abs(x) + Math.Abs(y) + wildcards;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-path-with-at-most-k-consecutive-identical-characters/">3970. Shortest Path With At Most K Consecutive Identical Characters (hard)</a>
        /// Runs Dijkstra over states consisting of a node and the current run length of its label.
        /// </summary>
        /// <param name="n">The node count.</param>
        /// <param name="edges">Directed weighted edges.</param>
        /// <param name="labels">The node labels.</param>
        /// <param name="k">The maximum allowed consecutive run length.</param>
        /// <returns>The minimum valid path cost, or -1 when no valid path exists.</returns>
        public int ShortestPath(int n, int[][] edges, string labels, int k)
        {
            if (n == 1)
                return k >= 1 ? 0 : -1;

            var graph = new List<(int to, int weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int to, int weight)>();
            foreach (int[] edge in edges)
                graph[edge[0]].Add((edge[1], edge[2]));

            long inf = long.MaxValue / 4;
            int width = k + 1;
            long[] dist = new long[n * width];
            Array.Fill(dist, inf);

            int startIndex = 1;
            dist[startIndex] = 0;
            var queue = new PriorityQueue<(int node, int run), long>();
            queue.Enqueue((0, 1), 0);

            while (queue.Count > 0)
            {
                queue.TryDequeue(out var state, out long currentDistance);
                int stateIndex = state.node * width + state.run;
                if (currentDistance != dist[stateIndex])
                    continue;

                foreach (var edge in graph[state.node])
                {
                    int nextRun = labels[edge.to] == labels[state.node] ? state.run + 1 : 1;
                    if (nextRun > k)
                        continue;

                    int nextIndex = edge.to * width + nextRun;
                    long nextDistance = currentDistance + edge.weight;
                    if (nextDistance < dist[nextIndex])
                    {
                        dist[nextIndex] = nextDistance;
                        queue.Enqueue((edge.to, nextRun), nextDistance);
                    }
                }
            }

            long answer = inf;
            for (int run = 1; run <= k; run++)
                answer = Math.Min(answer, dist[(n - 1) * width + run]);
            return answer == inf ? -1 : (int)answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-transform-binary-string/">3980. Minimum Operations to Transform Binary String (hard)</a>
        /// Uses dynamic programming over whether the edge ending at the previous position was consumed by a pair-reset operation.
        /// </summary>
        /// <param name="s1">The mutable source binary string.</param>
        /// <param name="s2">The target binary string.</param>
        /// <returns>The minimum number of operations, or -1 if impossible.</returns>
        public int MinOperations(string s1, string s2)
        {
            const int Inf = int.MaxValue / 4;

            int CostAt(int index, int degree)
            {
                int source = s1[index] - '0';
                int target = s2[index] - '0';
                if (degree == 0)
                {
                    if (source == target)
                        return 0;
                    return source == 0 && target == 1 ? 1 : Inf;
                }

                return degree - source + target;
            }

            if (s1.Length == 1)
            {
                int single = CostAt(0, 0);
                return single >= Inf ? -1 : single;
            }

            int[] dp = { 0, Inf };
            for (int i = 0; i < s1.Length - 1; i++)
            {
                int[] next = { Inf, Inf };
                for (int left = 0; left <= 1; left++)
                {
                    if (dp[left] >= Inf)
                        continue;
                    for (int right = 0; right <= 1; right++)
                    {
                        int degree = left + right;
                        int value = CostAt(i, degree);
                        if (value >= Inf)
                            continue;
                        next[right] = Math.Min(next[right], dp[left] + right + value);
                    }
                }

                dp = next;
            }

            int answer = Math.Min(
                dp[0] + CostAt(s1.Length - 1, 0),
                dp[1] + CostAt(s1.Length - 1, 1));
            return answer >= Inf ? -1 : answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-distinct-ways-to-form-target-from-two-strings/">3981. Count Distinct Ways to Form Target from Two Strings (hard)</a>
        /// Memoizes all suffix states defined by the next usable positions in both words and the next target index.
        /// </summary>
        /// <param name="word1">The first source string.</param>
        /// <param name="word2">The second source string.</param>
        /// <param name="target">The target to form.</param>
        /// <returns>The number of valid constructions modulo 1,000,000,007.</returns>
        public int InterleaveCharacters(string word1, string word2, string target)
        {
            const int Mod = 1_000_000_007;
            int[,,,] memo = new int[word1.Length + 1, word2.Length + 1, target.Length + 1, 4];
            for (int i = 0; i <= word1.Length; i++)
                for (int j = 0; j <= word2.Length; j++)
                    for (int k = 0; k <= target.Length; k++)
                        for (int mask = 0; mask < 4; mask++)
                            memo[i, j, k, mask] = -1;

            int Dfs(int i, int j, int k, int mask)
            {
                if (k == target.Length)
                    return mask == 3 ? 1 : 0;

                ref int cached = ref memo[i, j, k, mask];
                if (cached != -1)
                    return cached;

                long result = 0;
                char need = target[k];
                for (int p = i; p < word1.Length; p++)
                {
                    if (word1[p] == need)
                        result += Dfs(p + 1, j, k + 1, mask | 1);
                }
                for (int p = j; p < word2.Length; p++)
                {
                    if (word2[p] == need)
                        result += Dfs(i, p + 1, k + 1, mask | 2);
                }

                cached = (int)(result % Mod);
                return cached;
            }

            return Dfs(0, 0, 0, 0);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-elapsed-seconds-between-two-times/">3986. Number of Elapsed Seconds Between Two Times (easy)</a>
        /// Converts both times to seconds and subtracts them.
        /// </summary>
        /// <param name="startTime">The starting time in HH:MM:SS format.</param>
        /// <param name="endTime">The ending time in HH:MM:SS format.</param>
        /// <returns>The elapsed seconds.</returns>
        public int SecondsBetweenTimes(string startTime, string endTime)
        {
            return ParseSeconds(endTime) - ParseSeconds(startTime);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rearrange-string-to-avoid-character-pair/">3992. Rearrange String to Avoid Character Pair (easy)</a>
        /// Places every <paramref name="y"/> before every <paramref name="x"/> while keeping the remaining characters between them.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="x">The character that must appear after every <paramref name="y"/>.</param>
        /// <param name="y">The character that must appear before every <paramref name="x"/>.</param>
        /// <returns>Any valid rearrangement.</returns>
        public string RearrangeString(string s, char x, char y)
        {
            var before = new StringBuilder();
            var middle = new StringBuilder();
            var after = new StringBuilder();
            foreach (char c in s)
            {
                if (c == y)
                    before.Append(c);
                else if (c == x)
                    after.Append(c);
                else
                    middle.Append(c);
            }

            return before.ToString() + middle + after;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-convert-string-iii/">3995. Minimum Cost to Convert String III (hard)</a>
        /// Runs left-to-right dynamic programming over disjoint rule applications and unchanged characters.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="target">The target string.</param>
        /// <param name="rules">Pattern and replacement pairs.</param>
        /// <param name="costs">Base application costs.</param>
        /// <returns>The minimum total cost, or -1 if the transformation is impossible.</returns>
        public int MinCost(string source, string target, IList<IList<string>> rules, int[] costs)
        {
            const int Inf = int.MaxValue / 4;
            int n = source.Length;
            int[] dp = new int[n + 1];
            Array.Fill(dp, Inf);
            dp[0] = 0;

            for (int i = 0; i < n; i++)
            {
                if (dp[i] == Inf)
                    continue;

                if (source[i] == target[i])
                    dp[i + 1] = Math.Min(dp[i + 1], dp[i]);

                for (int r = 0; r < rules.Count; r++)
                {
                    string pattern = rules[r][0];
                    string replacement = rules[r][1];
                    int length = pattern.Length;
                    if (i + length > n)
                        continue;

                    bool matches = true;
                    int wildcardCount = 0;
                    for (int j = 0; j < length; j++)
                    {
                        if (replacement[j] != target[i + j])
                        {
                            matches = false;
                            break;
                        }

                        if (pattern[j] == '*')
                        {
                            wildcardCount++;
                        }
                        else if (pattern[j] != source[i + j])
                        {
                            matches = false;
                            break;
                        }
                    }

                    if (matches)
                        dp[i + length] = Math.Min(dp[i + length], dp[i] + costs[r] + wildcardCount);
                }
            }

            return dp[n] == Inf ? -1 : dp[n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/transform-binary-string-using-subsequence-sort/">3998. Transform Binary String Using Subsequence Sort (medium)</a>
        /// Tracks the feasible prefix-one-count range for each pattern string under the monotone movement of ones to the right.
        /// </summary>
        /// <param name="s">The source binary string.</param>
        /// <param name="strs">Target patterns containing optional wildcards.</param>
        /// <returns>Whether each pattern can be realized.</returns>
        public bool[] TransformStr(string s, string[] strs)
        {
            int[] prefixOnes = new int[s.Length];
            int ones = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                    ones++;
                prefixOnes[i] = ones;
            }

            bool[] result = new bool[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                int low = 0;
                int high = 0;
                bool possible = true;
                for (int j = 0; j < s.Length; j++)
                {
                    if (strs[i][j] == '1')
                    {
                        low++;
                        high++;
                    }
                    else if (strs[i][j] == '?')
                    {
                        high++;
                    }

                    if (low > prefixOnes[j])
                    {
                        possible = false;
                        break;
                    }

                    high = Math.Min(high, prefixOnes[j]);
                }

                result[i] = possible && low <= ones && ones <= high;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-string-groups-through-transformations/">3999. Minimum Number of String Groups Through Transformations (medium)</a>
        /// Canonicalizes each word by the minimum rotation of its even-index subsequence and odd-index subsequence.
        /// </summary>
        /// <param name="words">The input words.</param>
        /// <returns>The number of equivalence classes.</returns>
        public int MinimumGroups(string[] words)
        {
            var seen = new HashSet<string>();
            foreach (string word in words)
            {
                var even = new StringBuilder();
                var odd = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    if ((i & 1) == 0)
                        even.Append(word[i]);
                    else
                        odd.Append(word[i]);
                }

                string key = MinimalRotation(even.ToString()) + "|" + MinimalRotation(odd.ToString());
                seen.Add(key);
            }

            return seen.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-valid-prefixes/">4006. Count Valid Prefixes (easy)</a>
        /// Counts prefixes whose zero and one counts differ by at most one.
        /// </summary>
        /// <param name="s">The binary string.</param>
        /// <returns>The number of valid prefixes.</returns>
        public int CountValidPrefixes(string s)
        {
            int zeros = 0;
            int ones = 0;
            int result = 0;
            foreach (char c in s)
            {
                if (c == '0')
                    zeros++;
                else
                    ones++;
                if (Math.Abs(zeros - ones) <= 1)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-gap-between-stations/">4026. Maximum Gap Between Stations (medium)</a>
        /// Combines earliest-prefix and latest-suffix subsequence matches to maximize one adjacent assignment gap.
        /// </summary>
        /// <param name="skill">The worker skill sequence.</param>
        /// <param name="station">The station skill sequence.</param>
        /// <returns>The maximum possible gap between two consecutive assigned stations.</returns>
        public int MaximumGap(string skill, string station)
        {
            if (skill.Length == 1)
                return 0;

            int[] left = new int[skill.Length];
            int[] right = new int[skill.Length];

            for (int i = 0, j = 0; i < skill.Length; i++)
            {
                while (station[j] != skill[i])
                    j++;
                left[i] = j++;
            }

            for (int i = skill.Length - 1, j = station.Length - 1; i >= 0; i--)
            {
                while (station[j] != skill[i])
                    j--;
                right[i] = j--;
            }

            int result = 0;
            for (int i = 1; i < skill.Length; i++)
                result = Math.Max(result, right[i] - left[i - 1]);
            return result;
        }

        private static string TryBuildEqualHalfPalindrome(string target, int[] halfCounts, int halfLength, char middle, bool hasMiddle)
        {
            int[] remaining = (int[])halfCounts.Clone();
            for (int i = 0; i < halfLength; i++)
            {
                int index = target[i] - 'a';
                if (remaining[index] == 0)
                    return "";
                remaining[index]--;
            }

            string palindrome = BuildPalindrome(target[..halfLength], middle, hasMiddle);
            return string.CompareOrdinal(palindrome, target) > 0 ? palindrome : "";
        }

        private static string BuildPalindrome(string half, char middle, bool hasMiddle)
        {
            var result = new StringBuilder(half.Length * 2 + (hasMiddle ? 1 : 0));
            result.Append(half);
            if (hasMiddle)
                result.Append(middle);
            for (int i = half.Length - 1; i >= 0; i--)
                result.Append(half[i]);
            return result.ToString();
        }

        private static void AppendSortedCounts(StringBuilder builder, int[] counts)
        {
            for (int i = 0; i < 26; i++)
                builder.Append((char)('a' + i), counts[i]);
        }

        private static int LongestBalancedGeneral(string s)
        {
            int best = 1;
            for (int start = 0; start < s.Length; start++)
            {
                int[] counts = new int[26];
                for (int end = start; end < s.Length; end++)
                {
                    int index = s[end] - 'a';
                    counts[index]++;
                    int frequency = 0;
                    for (int i = 0; i < 26; i++)
                    {
                        if (counts[i] == 0)
                            continue;
                        if (frequency == 0)
                            frequency = counts[i];
                        else if (counts[i] != frequency)
                        {
                            frequency = -1;
                            break;
                        }
                    }

                    if (frequency != -1)
                        best = Math.Max(best, end - start + 1);
                }
            }

            return best;
        }

        private static int LongestBalancedAbc(string s)
        {
            int n = s.Length;
            int[] a = new int[n + 1];
            int[] b = new int[n + 1];
            int[] c = new int[n + 1];
            int best = 1;
            int run = 1;

            for (int i = 0; i < n; i++)
            {
                a[i + 1] = a[i] + (s[i] == 'a' ? 1 : 0);
                b[i + 1] = b[i] + (s[i] == 'b' ? 1 : 0);
                c[i + 1] = c[i] + (s[i] == 'c' ? 1 : 0);
                if (i > 0)
                {
                    run = s[i] == s[i - 1] ? run + 1 : 1;
                    best = Math.Max(best, run);
                }
            }

            void UpdatePair(int[] x, int[] y, int[] z)
            {
                var earliest = new Dictionary<(int diff, int zCount), int>
                {
                    [(0, 0)] = 0
                };
                for (int i = 1; i <= n; i++)
                {
                    var key = (x[i] - y[i], z[i]);
                    if (!earliest.TryGetValue(key, out int first))
                        earliest[key] = i;
                    else
                        best = Math.Max(best, i - first);
                }
            }

            UpdatePair(a, b, c);
            UpdatePair(a, c, b);
            UpdatePair(b, c, a);

            var triple = new Dictionary<(int ab, int ac), int>
            {
                [(0, 0)] = 0
            };
            for (int i = 1; i <= n; i++)
            {
                var key = (a[i] - b[i], a[i] - c[i]);
                if (!triple.TryGetValue(key, out int first))
                    triple[key] = i;
                else
                    best = Math.Max(best, i - first);
            }

            return best;
        }

        private static int LongestBalancedBinaryAfterSwap(string s)
        {
            int n = s.Length;
            int[] values = new int[n];
            int totalZeros = 0;
            int totalOnes = 0;
            int firstZero = n;
            int lastZero = -1;
            int firstOne = n;
            int lastOne = -1;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    values[i] = 1;
                    totalOnes++;
                    firstOne = Math.Min(firstOne, i);
                    lastOne = i;
                }
                else
                {
                    values[i] = -1;
                    totalZeros++;
                    firstZero = Math.Min(firstZero, i);
                    lastZero = i;
                }
            }

            int best = LongestSubarrayWithSum(values, 0, n - 1, 0);
            if (totalZeros > 0)
            {
                best = Math.Max(best, LongestSubarrayWithSum(values, 0, lastZero - 1, 2));
                best = Math.Max(best, LongestSubarrayWithSum(values, firstZero + 1, n - 1, 2));
            }
            if (totalOnes > 0)
            {
                best = Math.Max(best, LongestSubarrayWithSum(values, 0, lastOne - 1, -2));
                best = Math.Max(best, LongestSubarrayWithSum(values, firstOne + 1, n - 1, -2));
            }

            return best;
        }

        private static int LongestSubarrayWithSum(int[] values, int start, int end, int target)
        {
            if (start > end)
                return 0;

            var earliest = new Dictionary<int, int> { [0] = start - 1 };
            int best = 0;
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += values[i];
                if (earliest.TryGetValue(sum - target, out int index))
                    best = Math.Max(best, i - index);
                if (!earliest.ContainsKey(sum))
                    earliest[sum] = i;
            }

            return best;
        }

        private static int ParseSeconds(string time)
        {
            return ((time[0] - '0') * 10 + (time[1] - '0')) * 3600
                + ((time[3] - '0') * 10 + (time[4] - '0')) * 60
                + (time[6] - '0') * 10 + (time[7] - '0');
        }

        private static string MinimalRotation(string s)
        {
            if (s.Length <= 1)
                return s;

            string doubled = s + s;
            int i = 0;
            int j = 1;
            int k = 0;
            while (i < s.Length && j < s.Length && k < s.Length)
            {
                char a = doubled[i + k];
                char b = doubled[j + k];
                if (a == b)
                {
                    k++;
                    continue;
                }

                if (a > b)
                    i += k + 1;
                else
                    j += k + 1;
                if (i == j)
                    j++;
                k = 0;
            }

            int start = Math.Min(i, j);
            return doubled.Substring(start, s.Length);
        }
    }
}
