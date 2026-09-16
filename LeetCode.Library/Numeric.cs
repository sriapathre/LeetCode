using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Numeric
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-integer/">7. Reverse Integer (medium)</a>
        /// Given a signed 32-bit integer, reverse its digits and return 0 when the reversed value overflows.
        /// </summary>
        /// <param name="x">The signed 32-bit integer to reverse.</param>
        /// <returns>The reversed integer, or 0 if it overflows.</returns>
        public int Reverse(int x)
        {
            long reversed = 0;
            while (x != 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }

            return reversed < int.MinValue || reversed > int.MaxValue ? 0 : (int)reversed;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/palindrome-number/">9. Palindrome Number (easy)</a>
        /// Determine whether an integer reads the same forward and backward without converting it to a string.
        /// </summary>
        /// <param name="x">The integer to check for palindrome symmetry.</param>
        /// <returns><see langword="true"/> if the digits of <paramref name="x"/> form a palindrome; otherwise, <see langword="false"/>.</returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int original = x;
            int reversed = 0;
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }
            return reversed == original;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sqrtx/">69. Sqrt(x) (easy)</a>
        /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
        /// </summary>
        /// <param name="x">The non-negative integer whose integer square root is requested.</param>
        /// <returns>The truncated square root of <paramref name="x"/>.</returns>
        public int MySqrt(int x)
        {
            long low, high;
            low = 0;
            high = x;
            long mid = (low + high) / 2;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (mid * mid <= x)
                    low = mid + 1;

                else
                    high = mid - 1;
            }
            return (int)high;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divide-two-integers/">29. Divide Two Integers (medium)</a>
        /// Divide two integers without using multiplication, division, or modulo, truncating the result toward zero.
        /// </summary>
        /// <param name="dividend">The integer to divide.</param>
        /// <param name="divisor">The non-zero divisor.</param>
        /// <returns>The quotient clamped to the signed 32-bit integer range.</returns>
        public int Divide(int dividend, int divisor)
        {
            long dividendValue = dividend;
            long divisorValue = divisor;
            bool negative = (dividendValue < 0) != (divisorValue < 0);
            dividendValue = Math.Abs(dividendValue);
            divisorValue = Math.Abs(divisorValue);
            long quotient = 0;

            while (dividendValue >= divisorValue)
            {
                long value = divisorValue;
                long multiple = 1;
                while (dividendValue >= value + value)
                {
                    value += value;
                    multiple += multiple;
                }

                dividendValue -= value;
                quotient += multiple;
            }

            if (negative)
                quotient = -quotient;

            return quotient > int.MaxValue ? int.MaxValue : (int)quotient;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/powx-n/">50. Pow(x, n) (medium)</a>
        /// Return x raised to the power n using exponentiation by squaring.
        /// </summary>
        /// <param name="x">The base value.</param>
        /// <param name="n">The signed exponent.</param>
        /// <returns>x raised to the power n.</returns>
        public double MyPow(double x, int n)
        {
            long exponent = n;
            if (exponent < 0)
            {
                x = 1 / x;
                exponent = -exponent;
            }

            double result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result *= x;

                x *= x;
                exponent >>= 1;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/climbing-stairs/">70. Climbing Stairs (easy)</a>
        /// Count how many distinct ways there are to reach the top of a staircase with n steps when each move can climb 1 or 2 steps.
        /// </summary>
        /// <param name="n">The total number of steps to reach the top.</param>
        /// <returns>The number of distinct ways to climb to step <paramref name="n"/>.</returns>
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            int first = 1;
            int last = 2;
            for (int i = 3; i <= n; i++)
            {
                var r = first + last;
                first = last;
                last = r;
            }

            return last;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pascals-triangle/">118. Pascal's Triangle (easy)</a>
        /// Generate the first numRows rows of Pascal's triangle.
        /// </summary>
        /// <param name="numRows">The number of rows of Pascal's triangle to produce.</param>
        /// <returns>A list containing the first <paramref name="numRows"/> rows of Pascal's triangle.</returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> lastrow = new List<int>();
            while (numRows-- > 0)
            {
                List<int> newrow = new List<int>();
                if (lastrow.Count == 0)
                {
                    newrow.Add(1);
                }
                else
                {
                    newrow.Add(1);
                    for (int i = 0; i < lastrow.Count - 1; i++)
                    {
                        newrow.Add(lastrow[i] + lastrow[i + 1]);
                    }
                    newrow.Add(1);
                }
                result.Add(newrow);
                lastrow = newrow;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pascals-triangle-ii/">119. Pascal's Triangle II (easy)</a>
        /// Return the rowIndexth row of Pascal's triangle using zero-based indexing.
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the Pascal's triangle row to return.</param>
        /// <returns>The values in the requested row of Pascal's triangle.</returns>
        public IList<int> GetRow(int rowIndex)
        {
            var list = new List<int>(rowIndex + 1) { 1 };
            for (int row = 1; row <= rowIndex; row++)
            {
                for (int i = row - 1; i >= 1; i--)
                {
                    list[i] += list[i - 1];
                }
                list.Add(1);
            }
            return list;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/gray-code/">89. Gray Code (medium)</a>
        /// Return an n-bit Gray code sequence in which adjacent values differ by one bit.
        /// </summary>
        /// <param name="n">The number of bits.</param>
        /// <returns>A sequence containing all 2^n Gray code values.</returns>
        public IList<int> GrayCode(int n)
        {
            int count = 1 << n;
            var result = new List<int>(count);
            for (int value = 0; value < count; value++)
                result.Add(value ^ (value >> 1));

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-binary-search-trees/">96. Unique Binary Search Trees (medium)</a>
        /// Return the number of structurally unique binary search trees that store values 1 through n.
        /// </summary>
        /// <param name="n">The number of distinct values.</param>
        /// <returns>The number of structurally unique binary search trees.</returns>
        public int NumTrees(int n)
        {
            var counts = new long[n + 1];
            counts[0] = 1;
            for (int nodes = 1; nodes <= n; nodes++)
            {
                for (int leftNodes = 0; leftNodes < nodes; leftNodes++)
                    counts[nodes] += counts[leftNodes] * counts[nodes - 1 - leftNodes];
            }

            return (int)counts[n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/excel-sheet-column-title/">168. Excel Sheet Column Title (easy)</a>
        /// Convert a positive column number into its corresponding Excel-style column title.
        /// </summary>
        /// <param name="columnNumber">The 1-based Excel column number to convert.</param>
        /// <returns>The Excel column title for <paramref name="columnNumber"/>.</returns>
        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder sb = new StringBuilder();
            while (columnNumber > 0)
            {
                columnNumber--;
                sb.Insert(0, (char)('A' + columnNumber % 26));
                columnNumber /= 26;
            }

            return sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-bits/">190. Reverse Bits (easy)</a>
        /// Reverse the bit order of a 32-bit unsigned integer.
        /// </summary>
        /// <param name="n">The 32-bit unsigned integer whose bits should be reversed.</param>
        /// <returns>The value produced by reversing the bits of <paramref name="n"/>.</returns>
        public uint ReverseBits(uint n)
        {
            uint result = 0;

            for (int i = 0; i < 32; i++)
            {
                if (n % 2 == 1)
                    result++;

                n = n >> 1;

                //because for the 32nd bit, we don't want to left shift
                if (i < 31)
                    result = result << 1;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-1-bits/">191. Number of 1 Bits (easy)</a>
        /// Count the number of set bits in the binary representation of an integer.
        /// </summary>
        /// <param name="n">The integer whose set bits should be counted.</param>
        /// <returns>The number of 1 bits present in <paramref name="n"/>.</returns>
        public int HammingWeight(int n)
        {
            int cnt = 0;
            while (n > 0)
            {
                if ((n & 1) == 1) cnt++;
                n /= 2;
            }
            return cnt;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/happy-number/">202. Happy Number (easy)</a>
        /// Determine whether repeatedly replacing a number with the sum of the squares of its digits eventually reaches 1.
        /// </summary>
        /// <param name="n">The positive integer to evaluate.</param>
        /// <returns><see langword="true"/> if the process ends at 1; otherwise, <see langword="false"/>.</returns>
        public bool IsHappy(int n)
        {
            if (n == 1)
            {
                return true;
            }
            HashSet<int> seen = new HashSet<int>();
            while (n != 1)
            {
                int sum = 0;
                while (n != 0)
                {
                    sum += (n % 10) * (n % 10);
                    n /= 10;
                }
                if (seen.Contains(sum))
                {
                    return false;
                }
                seen.Add(sum);
                n = sum;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/nim-game/">292. Nim Game (easy)</a>
        /// Determine whether the starting player can force a win in Nim when 1 to 3 stones may be removed each turn.
        /// </summary>
        /// <param name="n">The number of stones in the heap at the start of the game.</param>
        /// <returns><see langword="true"/> if the first player can force a win; otherwise, <see langword="false"/>.</returns>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/power-of-three/">326. Power of Three (easy)</a>
        /// Determine whether an integer is an exact power of three.
        /// </summary>
        /// <param name="n">The integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="n"/> equals 3 raised to some non-negative power; otherwise, <see langword="false"/>.</returns>
        public bool IsPowerOfThree(int n)
        {
            if (n == 0)
            {
                return false;
            }

            while (n != 1)
            {
                if ((n - (3 * (n / 3))) != 0)// not cleanly divisible by 3
                {
                    return false;
                }
                else
                {
                    n = (n / 3);
                }
            }
            return true;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/fizz-buzz/">412. Fizz Buzz (easy)</a>
        /// Produce the numbers from 1 through n, replacing multiples of 3 with Fizz, multiples of 5 with Buzz, and multiples of both with FizzBuzz.
        /// </summary>
        /// <param name="n">The inclusive upper bound of the sequence to generate.</param>
        /// <returns>A list of FizzBuzz strings for the values from 1 through <paramref name="n"/>.</returns>
        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                    result.Add("FizzBuzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else if (i % 5 == 0)
                    result.Add("Buzz");
                else
                    result.Add(i.ToString());
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/arranging-coins/">441. Arranging Coins (easy)</a>
        /// Determine how many complete staircase rows can be formed from n coins when each row uses one more coin than the previous row.
        /// </summary>
        /// <param name="n">The total number of coins available.</param>
        /// <returns>The number of complete rows that can be formed.</returns>
        public int ArrangeCoins(int n)
        {
            int l = 1, r = n;
            int total = 0;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                double coins = (double)(mid) / 2.0 * (mid + 1);
                if (coins > n)
                    r = mid - 1;
                else
                {
                    // coins <= n, we need to record total for coins == n
                    l = mid + 1;
                    total = Math.Max(total, mid);
                }
            }
            return total;
        }
    }
}
