using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Numeric
    {
        private const int Modulo = 1_000_000_007;

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
        /// <a href="https://leetcode.com/problems/single-number-ii/">137. Single Number II (medium)</a>
        /// Find the element that appears exactly once when every other element appears exactly three times.
        /// </summary>
        /// <param name="nums">The array containing one unique value and all other values repeated three times.</param>
        /// <returns>The value that appears exactly once.</returns>
        public int SingleNumber(int[] nums)
        {
            int ones = 0;
            int twos = 0;

            foreach (int num in nums)
            {
                ones = (ones ^ num) & ~twos;
                twos = (twos ^ num) & ~ones;
            }

            return ones;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/max-points-on-a-line/">149. Max Points on a Line (hard)</a>
        /// Return the maximum number of points that lie on the same straight line.
        /// </summary>
        /// <param name="points">The two-dimensional integer coordinates of the points.</param>
        /// <returns>The largest count of points sharing one line.</returns>
        public int MaxPoints(int[][] points)
        {
            if (points.Length <= 2)
                return points.Length;

            int best = 0;
            for (int i = 0; i < points.Length; i++)
            {
                var slopes = new Dictionary<(long dx, long dy), int>();
                int duplicates = 1;
                int currentBest = 0;

                for (int j = i + 1; j < points.Length; j++)
                {
                    long dx = (long)points[j][0] - points[i][0];
                    long dy = (long)points[j][1] - points[i][1];

                    if (dx == 0 && dy == 0)
                    {
                        duplicates++;
                        continue;
                    }

                    NormalizeSlope(ref dx, ref dy);
                    var slope = (dx, dy);
                    slopes.TryGetValue(slope, out int count);
                    slopes[slope] = ++count;
                    currentBest = Math.Max(currentBest, count);
                }

                best = Math.Max(best, currentBest + duplicates);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/fraction-to-recurring-decimal/">166. Fraction to Recurring Decimal (medium)</a>
        /// Convert a fraction to its decimal string representation, enclosing any repeating fractional part in parentheses.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The non-zero denominator of the fraction.</param>
        /// <returns>The terminating or recurring decimal representation of the fraction.</returns>
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
                return "0";

            var result = new StringBuilder();
            long dividend = numerator;
            long divisor = denominator;

            if ((dividend < 0) != (divisor < 0))
                result.Append('-');

            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            result.Append(dividend / divisor);
            long remainder = dividend % divisor;
            if (remainder == 0)
                return result.ToString();

            result.Append('.');
            var remainderPositions = new Dictionary<long, int>();
            while (remainder != 0)
            {
                if (remainderPositions.TryGetValue(remainder, out int repeatStart))
                {
                    result.Insert(repeatStart, "(");
                    result.Append(')');
                    break;
                }

                remainderPositions[remainder] = result.Length;
                remainder *= 10;
                result.Append(remainder / divisor);
                remainder %= divisor;
            }

            return result.ToString();
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
        /// <a href="https://leetcode.com/problems/factorial-trailing-zeroes/">172. Factorial Trailing Zeroes (medium)</a>
        /// Count the trailing zeroes in n! by counting factors of five.
        /// </summary>
        /// <param name="n">The non-negative integer whose factorial should be evaluated.</param>
        /// <returns>The number of trailing zeroes in n!.</returns>
        public int TrailingZeroes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n /= 5;
                count += n;
            }

            return count;
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

        private static void NormalizeSlope(ref long dx, ref long dy)
        {
            if (dx == 0)
            {
                dy = 1;
                return;
            }

            if (dy == 0)
            {
                dx = 1;
                return;
            }

            long gcd = GreatestCommonDivisor(Math.Abs(dx), Math.Abs(dy));
            dx /= gcd;
            dy /= gcd;

            if (dx < 0)
            {
                dx = -dx;
                dy = -dy;
            }
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/bitwise-and-of-numbers-range/">201. Bitwise AND of Numbers Range (medium)</a>
        /// Find the bitwise AND of every integer in the inclusive range by keeping only the common binary prefix.
        /// </summary>
        /// <param name="left">The inclusive lower bound.</param>
        /// <param name="right">The inclusive upper bound.</param>
        /// <returns>The bitwise AND of all values from <paramref name="left"/> through <paramref name="right"/>.</returns>
        public int RangeBitwiseAnd(int left, int right)
        {
            int shifts = 0;
            while (left < right)
            {
                left >>= 1;
                right >>= 1;
                shifts++;
            }

            return left << shifts;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-primes/">204. Count Primes (medium)</a>
        /// Count prime numbers less than n using the Sieve of Eratosthenes.
        /// </summary>
        /// <param name="n">The exclusive upper bound.</param>
        /// <returns>The number of primes less than <paramref name="n"/>.</returns>
        public int CountPrimes(int n)
        {
            if (n <= 2)
                return 0;

            bool[] composite = new bool[n];
            int count = 0;
            for (int number = 2; number < n; number++)
            {
                if (composite[number])
                    continue;

                count++;
                if ((long)number * number >= n)
                    continue;

                for (int multiple = number * number; multiple < n; multiple += number)
                    composite[multiple] = true;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rectangle-area/">223. Rectangle Area (medium)</a>
        /// Compute the total area covered by two axis-aligned rectangles while subtracting overlap once.
        /// </summary>
        /// <param name="ax1">The first rectangle's left x-coordinate.</param>
        /// <param name="ay1">The first rectangle's bottom y-coordinate.</param>
        /// <param name="ax2">The first rectangle's right x-coordinate.</param>
        /// <param name="ay2">The first rectangle's top y-coordinate.</param>
        /// <param name="bx1">The second rectangle's left x-coordinate.</param>
        /// <param name="by1">The second rectangle's bottom y-coordinate.</param>
        /// <param name="bx2">The second rectangle's right x-coordinate.</param>
        /// <param name="by2">The second rectangle's top y-coordinate.</param>
        /// <returns>The combined covered area.</returns>
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            long first = (long)(ax2 - ax1) * (ay2 - ay1);
            long second = (long)(bx2 - bx1) * (by2 - by1);
            long overlapWidth = Math.Max(0, Math.Min(ax2, bx2) - Math.Max(ax1, bx1));
            long overlapHeight = Math.Max(0, Math.Min(ay2, by2) - Math.Max(ay1, by1));
            return (int)(first + second - overlapWidth * overlapHeight);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/power-of-two/">231. Power of Two (easy)</a>
        /// Determine whether an integer has exactly one set bit and is positive.
        /// </summary>
        /// <param name="n">The integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="n"/> is a power of two; otherwise, <see langword="false"/>.</returns>
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-digit-one/">233. Number of Digit One (hard)</a>
        /// Count how many digit 1 characters appear in every number from 0 through n by place value contribution.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The total number of digit 1 occurrences.</returns>
        public int CountDigitOne(int n)
        {
            long count = 0;
            for (long factor = 1; factor <= n; factor *= 10)
            {
                long lower = n % factor;
                long current = (n / factor) % 10;
                long higher = n / (factor * 10);

                if (current == 0)
                    count += higher * factor;
                else if (current == 1)
                    count += higher * factor + lower + 1;
                else
                    count += (higher + 1) * factor;
            }

            return (int)count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/add-digits/">258. Add Digits (easy)</a>
        /// Repeatedly add decimal digits until one digit remains using the digital root formula.
        /// </summary>
        /// <param name="num">The non-negative integer to reduce.</param>
        /// <returns>The one-digit digital root.</returns>
        public int AddDigits(int num)
        {
            return num == 0 ? 0 : 1 + (num - 1) % 9;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/ugly-number/">263. Ugly Number (easy)</a>
        /// Determine whether a positive integer's only prime factors are 2, 3, and 5.
        /// </summary>
        /// <param name="n">The integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="n"/> is ugly; otherwise, <see langword="false"/>.</returns>
        public bool IsUgly(int n)
        {
            if (n <= 0)
                return false;

            foreach (int factor in new[] { 2, 3, 5 })
            {
                while (n % factor == 0)
                    n /= factor;
            }

            return n == 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/ugly-number-ii/">264. Ugly Number II (medium)</a>
        /// Return the nth positive number whose only prime factors are 2, 3, and 5.
        /// </summary>
        /// <param name="n">The 1-based ugly number index.</param>
        /// <returns>The nth ugly number.</returns>
        public int NthUglyNumber(int n)
        {
            int[] ugly = new int[n];
            ugly[0] = 1;
            int two = 0, three = 0, five = 0;

            for (int i = 1; i < n; i++)
            {
                int nextTwo = ugly[two] * 2;
                int nextThree = ugly[three] * 3;
                int nextFive = ugly[five] * 5;
                int next = Math.Min(nextTwo, Math.Min(nextThree, nextFive));
                ugly[i] = next;

                if (next == nextTwo) two++;
                if (next == nextThree) three++;
                if (next == nextFive) five++;
            }

            return ugly[n - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/missing-number/">268. Missing Number (easy)</a>
        /// Find the one missing value from the set 0 through n using XOR cancellation.
        /// </summary>
        /// <param name="nums">The n distinct numbers drawn from 0 through n.</param>
        /// <returns>The missing number.</returns>
        public int MissingNumber(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
                missing ^= i ^ nums[i];

            return missing;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/perfect-squares/">279. Perfect Squares (medium)</a>
        /// Compute the fewest perfect square numbers that sum to n using dynamic programming.
        /// </summary>
        /// <param name="n">The positive target sum.</param>
        /// <returns>The minimum number of perfect squares needed.</returns>
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = i;
                for (int square = 1; square * square <= i; square++)
                    dp[i] = Math.Min(dp[i], dp[i - square * square] + 1);
            }

            return dp[n];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/bulb-switcher/">319. Bulb Switcher (medium)</a>
        /// Count bulbs left on after n rounds, which are exactly bulbs at perfect-square positions.
        /// </summary>
        /// <param name="n">The number of bulbs and rounds.</param>
        /// <returns>The number of bulbs that remain on.</returns>
        public int BulbSwitch(int n)
        {
            return (int)Math.Sqrt(n);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/counting-bits/">338. Counting Bits (easy)</a>
        /// Count set bits for every integer from 0 through n using the lowest set bit recurrence.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>An array where each index stores that value's set-bit count.</returns>
        public int[] CountBits(int n)
        {
            int[] result = new int[n + 1];
            for (int i = 1; i <= n; i++)
                result[i] = result[i & (i - 1)] + 1;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/power-of-four/">342. Power of Four (easy)</a>
        /// Determine whether a positive integer is a power of four.
        /// </summary>
        /// <param name="n">The integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="n"/> is a power of four; otherwise, <see langword="false"/>.</returns>
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/integer-break/">343. Integer Break (medium)</a>
        /// Break n into at least two positive integers to maximize their product.
        /// </summary>
        /// <param name="n">The integer to split.</param>
        /// <returns>The maximum product possible.</returns>
        public int IntegerBreak(int n)
        {
            if (n <= 3)
                return n - 1;

            int product = 1;
            while (n > 4)
            {
                product *= 3;
                n -= 3;
            }

            return product * n;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-numbers-with-unique-digits/">357. Count Numbers with Unique Digits (medium)</a>
        /// Count numbers x where 0 &lt;= x &lt; 10^n and every decimal digit in x is unique.
        /// </summary>
        /// <param name="n">The number of decimal places to consider.</param>
        /// <returns>The count of numbers with all unique digits.</returns>
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n == 0)
                return 1;

            int total = 10;
            int current = 9;
            for (int digits = 2; digits <= Math.Min(n, 10); digits++)
            {
                current *= 11 - digits;
                total += current;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-perfect-square/">367. Valid Perfect Square (easy)</a>
        /// Determine whether num is a perfect square using binary search.
        /// </summary>
        /// <param name="num">The positive integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="num"/> is a perfect square; otherwise, <see langword="false"/>.</returns>
        public bool IsPerfectSquare(int num)
        {
            long left = 1;
            long right = num;
            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long square = mid * mid;
                if (square == num)
                    return true;
                if (square < num)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-two-integers/">371. Sum of Two Integers (medium)</a>
        /// Add two integers using bitwise carry propagation instead of arithmetic addition.
        /// </summary>
        /// <param name="a">The first addend.</param>
        /// <param name="b">The second addend.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = (a & b) << 1;
                a ^= b;
                b = carry;
            }

            return a;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/super-pow/">372. Super Pow (medium)</a>
        /// Compute a^b modulo 1337 where b is provided as decimal digits.
        /// </summary>
        /// <param name="a">The base integer.</param>
        /// <param name="b">The exponent digits in most-significant to least-significant order.</param>
        /// <returns>The modular exponentiation result.</returns>
        public int SuperPow(int a, int[] b)
        {
            const int mod = 1337;
            int result = 1;
            a %= mod;
            foreach (int digit in b)
                result = ModPow(result, 10, mod) * ModPow(a, digit, mod) % mod;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/integer-replacement/">397. Integer Replacement (medium)</a>
        /// Find the minimum replacements to turn n into 1 by halving even numbers and adjusting odd numbers.
        /// </summary>
        /// <param name="n">The positive integer to reduce.</param>
        /// <returns>The minimum operation count.</returns>
        public int IntegerReplacement(int n)
        {
            long value = n;
            int steps = 0;
            while (value != 1)
            {
                if ((value & 1) == 0)
                    value >>= 1;
                else if (value == 3 || ((value >> 1) & 1) == 0)
                    value--;
                else
                    value++;

                steps++;
            }

            return steps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/nth-digit/">400. Nth Digit (medium)</a>
        /// Find the nth digit in the infinite sequence 123456789101112...
        /// </summary>
        /// <param name="n">The 1-based digit position.</param>
        /// <returns>The digit at position <paramref name="n"/>.</returns>
        public int FindNthDigit(int n)
        {
            long digits = 1;
            long count = 9;
            long start = 1;
            while (n > digits * count)
            {
                n -= (int)(digits * count);
                digits++;
                count *= 10;
                start *= 10;
            }

            long number = start + (n - 1) / digits;
            int index = (int)((n - 1) % digits);
            return number.ToString()[index] - '0';
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-a-number-to-hexadecimal/">405. Convert a Number to Hexadecimal (easy)</a>
        /// Convert a 32-bit integer to its lowercase hexadecimal representation.
        /// </summary>
        /// <param name="num">The signed integer to convert.</param>
        /// <returns>The hexadecimal representation without leading zeroes.</returns>
        public string ToHex(int num)
        {
            if (num == 0)
                return "0";

            const string digits = "0123456789abcdef";
            uint value = unchecked((uint)num);
            StringBuilder result = new StringBuilder();
            while (value != 0)
            {
                result.Insert(0, digits[(int)(value & 15)]);
                value >>= 4;
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-moves-to-equal-array-elements/">453. Minimum Moves to Equal Array Elements (medium)</a>
        /// Count increments of n - 1 elements needed to equalize an array by summing distances from the minimum.
        /// </summary>
        /// <param name="nums">The integers to equalize.</param>
        /// <returns>The minimum number of moves.</returns>
        public int MinMoves(int[] nums)
        {
            int min = nums[0];
            foreach (int num in nums)
                min = Math.Min(min, num);

            int moves = 0;
            foreach (int num in nums)
                moves += num - min;

            return moves;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/poor-pigs/">458. Poor Pigs (hard)</a>
        /// Determine the fewest pigs needed by treating each pig as one dimension with multiple test outcomes.
        /// </summary>
        /// <param name="buckets">The number of buckets to distinguish.</param>
        /// <param name="minutesToDie">Minutes after drinking that a pig dies.</param>
        /// <param name="minutesToTest">Total minutes available for testing.</param>
        /// <returns>The minimum number of pigs required.</returns>
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            if (buckets <= 1)
                return 0;

            int states = minutesToTest / minutesToDie + 1;
            int pigs = 0;
            int capacity = 1;
            while (capacity < buckets)
            {
                capacity *= states;
                pigs++;
            }

            return pigs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/hamming-distance/">461. Hamming Distance (easy)</a>
        /// Count positions where two integers have different bits.
        /// </summary>
        /// <param name="x">The first integer.</param>
        /// <param name="y">The second integer.</param>
        /// <returns>The Hamming distance between <paramref name="x"/> and <paramref name="y"/>.</returns>
        public int HammingDistance(int x, int y)
        {
            int xor = x ^ y;
            int distance = 0;
            while (xor != 0)
            {
                xor &= xor - 1;
                distance++;
            }

            return distance;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-complement/">476. Number Complement (easy)</a>
        /// Flip all bits in the significant binary representation of a positive integer.
        /// </summary>
        /// <param name="num">The positive integer to complement.</param>
        /// <returns>The bitwise complement within the highest set bit.</returns>
        public int FindComplement(int num)
        {
            int mask = 0;
            int value = num;
            while (value != 0)
            {
                mask = (mask << 1) | 1;
                value >>= 1;
            }

            return num ^ mask;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-hamming-distance/">477. Total Hamming Distance (medium)</a>
        /// Sum pairwise Hamming distances by counting zero and one bits at each position.
        /// </summary>
        /// <param name="nums">The integers to compare pairwise.</param>
        /// <returns>The total Hamming distance among all pairs.</returns>
        public int TotalHammingDistance(int[] nums)
        {
            int total = 0;
            for (int bit = 0; bit < 32; bit++)
            {
                int ones = 0;
                foreach (int num in nums)
                    ones += (num >> bit) & 1;

                total += ones * (nums.Length - ones);
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-the-rectangle/">492. Construct the Rectangle (easy)</a>
        /// Build rectangle dimensions with L * W equal to area and L - W minimized.
        /// </summary>
        /// <param name="area">The target rectangle area.</param>
        /// <returns>A two-element array containing length then width.</returns>
        public int[] ConstructRectangle(int area)
        {
            int width = (int)Math.Sqrt(area);
            while (area % width != 0)
                width--;

            return new[] { area / width, width };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/base-7/">504. Base 7 (easy)</a>
        /// Convert an integer to its base-7 string representation.
        /// </summary>
        /// <param name="num">The signed integer to convert.</param>
        /// <returns>The base-7 representation.</returns>
        public string ConvertToBase7(int num)
        {
            if (num == 0)
                return "0";

            bool negative = num < 0;
            int value = Math.Abs(num);
            StringBuilder result = new StringBuilder();
            while (value > 0)
            {
                result.Insert(0, value % 7);
                value /= 7;
            }

            return negative ? "-" + result : result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/perfect-number/">507. Perfect Number (easy)</a>
        /// Determine whether a positive integer equals the sum of its positive divisors excluding itself.
        /// </summary>
        /// <param name="num">The integer to test.</param>
        /// <returns><see langword="true"/> if <paramref name="num"/> is perfect; otherwise, <see langword="false"/>.</returns>
        public bool CheckPerfectNumber(int num)
        {
            if (num <= 1)
                return false;

            int sum = 1;
            for (int divisor = 2; divisor * divisor <= num; divisor++)
            {
                if (num % divisor != 0)
                    continue;

                sum += divisor;
                int paired = num / divisor;
                if (paired != divisor)
                    sum += paired;
            }

            return sum == num;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/fibonacci-number/">509. Fibonacci Number (easy)</a>
        /// Return the nth Fibonacci number using constant-space iteration.
        /// </summary>
        /// <param name="n">The zero-based Fibonacci index.</param>
        /// <returns>F(n).</returns>
        public int Fib(int n)
        {
            int previous = 0;
            int current = 1;
            for (int i = 0; i < n; i++)
            {
                int next = previous + current;
                previous = current;
                current = next;
            }

            return previous;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/next-greater-element-iii/">556. Next Greater Element III (medium)</a>
        /// Rearrange an integer's digits into the next greater permutation that still fits in 32 bits.
        /// </summary>
        /// <param name="n">The positive integer whose digits should be permuted.</param>
        /// <returns>The next greater integer using the same digits, or -1 if none exists.</returns>
        public int NextGreaterElement(int n)
        {
            char[] digits = n.ToString().ToCharArray();
            int i = digits.Length - 2;
            while (i >= 0 && digits[i] >= digits[i + 1])
                i--;

            if (i < 0)
                return -1;

            int j = digits.Length - 1;
            while (digits[j] <= digits[i])
                j--;

            char temp = digits[i];
            digits[i] = digits[j];
            digits[j] = temp;
            Array.Reverse(digits, i + 1, digits.Length - i - 1);

            long result = long.Parse(new string(digits));
            return result > int.MaxValue ? -1 : (int)result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/range-addition-ii/">598. Range Addition II (easy)</a>
        /// Find how many maximum entries remain after range increments by intersecting all operation rectangles.
        /// </summary>
        /// <param name="m">The matrix row count.</param>
        /// <param name="n">The matrix column count.</param>
        /// <param name="ops">The increment operations, each as [rows, columns].</param>
        /// <returns>The count of cells containing the maximum value.</returns>
        public int MaxCount(int m, int n, int[][] ops)
        {
            int rows = m;
            int columns = n;
            foreach (int[] op in ops)
            {
                rows = Math.Min(rows, op[0]);
                columns = Math.Min(columns, op[1]);
            }

            return rows * columns;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-square-numbers/">633. Sum of Square Numbers (medium)</a>
        /// Determine whether c can be expressed as a sum of two integer squares.
        /// </summary>
        /// <param name="c">The non-negative target sum.</param>
        /// <returns><see langword="true"/> if two squares sum to <paramref name="c"/>; otherwise, <see langword="false"/>.</returns>
        public bool JudgeSquareSum(int c)
        {
            long left = 0;
            long right = (long)Math.Sqrt(c);
            while (left <= right)
            {
                long sum = left * left + right * right;
                if (sum == c)
                    return true;
                if (sum < c)
                    left++;
                else
                    right--;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/set-mismatch/">645. Set Mismatch (easy)</a>
        /// Find the duplicated and missing values in an array that should contain 1 through n.
        /// </summary>
        /// <param name="nums">The corrupted set values.</param>
        /// <returns>A two-element array containing duplicate then missing value.</returns>
        public int[] FindErrorNums(int[] nums)
        {
            bool[] seen = new bool[nums.Length + 1];
            int duplicate = -1;
            foreach (int num in nums)
            {
                if (seen[num])
                    duplicate = num;
                seen[num] = true;
            }

            int missing = -1;
            for (int value = 1; value <= nums.Length; value++)
            {
                if (!seen[value])
                {
                    missing = value;
                    break;
                }
            }

            return new[] { duplicate, missing };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/2-keys-keyboard/">650. 2 Keys Keyboard (medium)</a>
        /// Minimize copy/paste operations by summing prime factors of n.
        /// </summary>
        /// <param name="n">The target number of A characters.</param>
        /// <returns>The minimum operation count.</returns>
        public int MinSteps(int n)
        {
            int steps = 0;
            for (int factor = 2; factor * factor <= n; factor++)
            {
                while (n % factor == 0)
                {
                    steps += factor;
                    n /= factor;
                }
            }

            return n > 1 ? steps + n : steps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/bulb-switcher-ii/">672. Bulb Switcher II (medium)</a>
        /// Count distinct bulb states reachable after a number of presses using the four switch operations' periodicity.
        /// </summary>
        /// <param name="n">The number of bulbs.</param>
        /// <param name="presses">The exact number of button presses.</param>
        /// <returns>The number of distinct possible states.</returns>
        public int FlipLights(int n, int presses)
        {
            if (presses == 0)
                return 1;

            n = Math.Min(n, 3);
            if (n == 1)
                return 2;
            if (n == 2)
                return presses == 1 ? 3 : 4;
            if (presses == 1)
                return 4;
            if (presses == 2)
                return 7;
            return 8;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-number-with-alternating-bits/">693. Binary Number with Alternating Bits (easy)</a>
        /// Determine whether adjacent bits in n always differ.
        /// </summary>
        /// <param name="n">The positive integer to test.</param>
        /// <returns><see langword="true"/> if the binary representation alternates bits; otherwise, <see langword="false"/>.</returns>
        public bool HasAlternatingBits(int n)
        {
            int xor = n ^ (n >> 1);
            return (xor & (xor + 1)) == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/self-dividing-numbers/">728. Self Dividing Numbers (easy)</a>
        /// Return all numbers in a range whose every digit is non-zero and divides the number.
        /// </summary>
        /// <param name="left">The inclusive lower bound.</param>
        /// <param name="right">The inclusive upper bound.</param>
        /// <returns>All self-dividing numbers in ascending order.</returns>
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            var result = new List<int>();
            for (int number = left; number <= right; number++)
            {
                int value = number;
                bool selfDividing = true;
                while (value > 0)
                {
                    int digit = value % 10;
                    if (digit == 0 || number % digit != 0)
                    {
                        selfDividing = false;
                        break;
                    }

                    value /= 10;
                }

                if (selfDividing)
                    result.Add(number);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/">762. Prime Number of Set Bits in Binary Representation (easy)</a>
        /// Count values in a range whose binary representation has a prime number of set bits.
        /// </summary>
        /// <param name="left">The inclusive lower bound.</param>
        /// <param name="right">The inclusive upper bound.</param>
        /// <returns>The count of values with a prime popcount.</returns>
        public int CountPrimeSetBits(int left, int right)
        {
            int count = 0;
            for (int value = left; value <= right; value++)
            {
                int bits = 0;
                int current = value;
                while (current != 0)
                {
                    current &= current - 1;
                    bits++;
                }

                if (IsSmallPrime(bits))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reach-a-number/">754. Reach a Number (medium)</a>
        /// Find the fewest signed steps of lengths 1, 2, 3, ... needed to land on target.
        /// </summary>
        /// <param name="target">The destination on the number line.</param>
        /// <returns>The minimum number of steps required.</returns>
        public int ReachNumber(int target)
        {
            target = Math.Abs(target);
            int steps = 0;
            int sum = 0;
            while (sum < target || ((sum - target) & 1) == 1)
            {
                steps++;
                sum += steps;
            }

            return steps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rabbits-in-forest/">781. Rabbits in Forest (medium)</a>
        /// Count the minimum rabbits by grouping identical answers into batches of answer + 1.
        /// </summary>
        /// <param name="answers">Each rabbit's count of other rabbits with the same color.</param>
        /// <returns>The minimum possible number of rabbits in the forest.</returns>
        public int NumRabbits(int[] answers)
        {
            var counts = new Dictionary<int, int>();
            foreach (int answer in answers)
            {
                counts.TryGetValue(answer, out int count);
                counts[answer] = count + 1;
            }

            int total = 0;
            foreach (var pair in counts)
            {
                int groupSize = pair.Key + 1;
                total += ((pair.Value + groupSize - 1) / groupSize) * groupSize;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotated-digits/">788. Rotated Digits (medium)</a>
        /// Count numbers from 1 through n that remain valid and change after a 180-degree rotation.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The number of good rotated digits.</returns>
        public int RotatedDigits(int n)
        {
            int count = 0;
            for (int value = 1; value <= n; value++)
            {
                int current = value;
                bool changed = false;
                bool valid = true;
                while (current > 0)
                {
                    int digit = current % 10;
                    if (digit == 3 || digit == 4 || digit == 7)
                    {
                        valid = false;
                        break;
                    }

                    if (digit == 2 || digit == 5 || digit == 6 || digit == 9)
                        changed = true;

                    current /= 10;
                }

                if (valid && changed)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/preimage-size-of-factorial-zeroes-function/">793. Preimage Size of Factorial Zeroes Function (hard)</a>
        /// Return the size of the set of x where x! has exactly k trailing zeroes.
        /// </summary>
        /// <param name="k">The desired trailing zero count.</param>
        /// <returns>5 when a preimage exists; otherwise 0.</returns>
        public int PreimageSizeFZF(int k)
        {
            return CountFactorialZeroes(FirstWithAtLeastZeroes(k + 1) - 1) == k ? 5 : 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/chalkboard-xor-game/">810. Chalkboard XOR Game (hard)</a>
        /// Decide if the first player can win using xor parity properties.
        /// </summary>
        /// <param name="nums">The numbers initially written on the chalkboard.</param>
        /// <returns><see langword="true"/> if the first player can force a win; otherwise, <see langword="false"/>.</returns>
        public bool XorGame(int[] nums)
        {
            int xor = 0;
            foreach (int num in nums)
                xor ^= num;

            return xor == 0 || nums.Length % 2 == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-triangle-area/">812. Largest Triangle Area (easy)</a>
        /// Find the largest area formed by any three points using the shoelace formula.
        /// </summary>
        /// <param name="points">The two-dimensional integer points.</param>
        /// <returns>The maximum triangle area.</returns>
        public double LargestTriangleArea(int[][] points)
        {
            double best = 0;
            for (int i = 0; i < points.Length - 2; i++)
            {
                for (int j = i + 1; j < points.Length - 1; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        int twiceArea = Math.Abs(
                            points[i][0] * (points[j][1] - points[k][1]) +
                            points[j][0] * (points[k][1] - points[i][1]) +
                            points[k][0] * (points[i][1] - points[j][1]));
                        best = Math.Max(best, twiceArea / 2.0);
                    }
                }
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/consecutive-numbers-sum/">829. Consecutive Numbers Sum (hard)</a>
        /// Count ways to express n as a sum of consecutive positive integers.
        /// </summary>
        /// <param name="n">The positive integer to represent.</param>
        /// <returns>The number of valid consecutive sums.</returns>
        public int ConsecutiveNumbersSum(int n)
        {
            int ways = 0;
            for (long length = 1; length * (length + 1) / 2 <= n; length++)
            {
                if ((n - length * (length - 1) / 2) % length == 0)
                    ways++;
            }

            return ways;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rectangle-overlap/">836. Rectangle Overlap (easy)</a>
        /// Determine whether two axis-aligned rectangles have positive-area overlap.
        /// </summary>
        /// <param name="rec1">The first rectangle as [x1, y1, x2, y2].</param>
        /// <param name="rec2">The second rectangle as [x1, y1, x2, y2].</param>
        /// <returns><see langword="true"/> if the rectangles overlap with positive area; otherwise, <see langword="false"/>.</returns>
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return Math.Max(rec1[0], rec2[0]) < Math.Min(rec1[2], rec2[2]) &&
                   Math.Max(rec1[1], rec2[1]) < Math.Min(rec1[3], rec2[3]);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/mirror-reflection/">858. Mirror Reflection (medium)</a>
        /// Find which receptor a laser meets by reducing room size and extension count by their GCD.
        /// </summary>
        /// <param name="p">The square room side length.</param>
        /// <param name="q">The vertical distance to the first reflection point.</param>
        /// <returns>The receptor number: 0, 1, or 2.</returns>
        public int MirrorReflection(int p, int q)
        {
            long gcd = GreatestCommonDivisor(p, q);
            int roomExtensions = (int)(q / gcd);
            int receptorSide = (int)(p / gcd);
            if ((roomExtensions & 1) == 0)
                return 0;

            return (receptorSide & 1) == 1 ? 1 : 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-gap/">868. Binary Gap (easy)</a>
        /// Find the largest distance between adjacent set bits in an integer.
        /// </summary>
        /// <param name="n">The positive integer to inspect.</param>
        /// <returns>The maximum gap between consecutive 1 bits, or 0 when fewer than two exist.</returns>
        public int BinaryGap(int n)
        {
            int last = -1;
            int best = 0;
            for (int index = 0; n > 0; index++, n >>= 1)
            {
                if ((n & 1) == 0)
                    continue;

                if (last != -1)
                    best = Math.Max(best, index - last);
                last = index;
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reordered-power-of-2/">869. Reordered Power of 2 (medium)</a>
        /// Determine whether the digits of n can be reordered to form a power of two.
        /// </summary>
        /// <param name="n">The positive integer whose digits may be reordered.</param>
        /// <returns><see langword="true"/> if a reordered value is a power of two; otherwise, <see langword="false"/>.</returns>
        public bool ReorderedPowerOf2(int n)
        {
            string signature = DigitSignature(n);
            for (int power = 1; power > 0; power <<= 1)
            {
                if (DigitSignature(power) == signature)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/">914. X of a Kind in a Deck of Cards (easy)</a>
        /// Determine whether card counts share a greatest common divisor of at least two.
        /// </summary>
        /// <param name="deck">The card values.</param>
        /// <returns><see langword="true"/> if the deck can be partitioned into equal-size groups; otherwise, <see langword="false"/>.</returns>
        public bool HasGroupsSizeX(int[] deck)
        {
            var counts = new Dictionary<int, int>();
            foreach (int card in deck)
            {
                counts.TryGetValue(card, out int count);
                counts[card] = count + 1;
            }

            long gcd = 0;
            foreach (int count in counts.Values)
                gcd = GreatestCommonDivisor(gcd, count);

            return gcd >= 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/powerful-integers/">970. Powerful Integers (medium)</a>
        /// List all unique values x^i + y^j not exceeding a bound.
        /// </summary>
        /// <param name="x">The first base.</param>
        /// <param name="y">The second base.</param>
        /// <param name="bound">The inclusive upper bound for sums.</param>
        /// <returns>The unique powerful integers not larger than <paramref name="bound"/>.</returns>
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            var result = new HashSet<int>();
            for (int a = 1; a < bound; a *= x)
            {
                for (int b = 1; a + b <= bound; b *= y)
                {
                    result.Add(a + b);
                    if (y == 1)
                        break;
                }

                if (x == 1)
                    break;
            }

            return new List<int>(result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/broken-calculator/">991. Broken Calculator (medium)</a>
        /// Work backward from target to start using inverse operations greedily.
        /// </summary>
        /// <param name="startValue">The calculator's starting value.</param>
        /// <param name="target">The desired target value.</param>
        /// <returns>The minimum number of operations.</returns>
        public int BrokenCalc(int startValue, int target)
        {
            int operations = 0;
            while (target > startValue)
            {
                operations++;
                if ((target & 1) == 1)
                    target++;
                else
                    target >>= 1;
            }

            return operations + startValue - target;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/clumsy-factorial/">1006. Clumsy Factorial (medium)</a>
        /// Evaluate the clumsy factorial expression using the repeating operator pattern.
        /// </summary>
        /// <param name="n">The positive integer at the start of the expression.</param>
        /// <returns>The clumsy factorial result.</returns>
        public int Clumsy(int n)
        {
            var stack = new Stack<int>();
            stack.Push(n);
            int operation = 0;
            for (int value = n - 1; value >= 1; value--, operation++)
            {
                if (operation % 4 == 0)
                    stack.Push(stack.Pop() * value);
                else if (operation % 4 == 1)
                    stack.Push(stack.Pop() / value);
                else if (operation % 4 == 2)
                    stack.Push(value);
                else
                    stack.Push(-value);
            }

            int result = 0;
            while (stack.Count > 0)
                result += stack.Pop();

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-integer-divisible-by-k/">1015. Smallest Integer Divisible by K (medium)</a>
        /// Find the length of the smallest repunit divisible by k using remainders.
        /// </summary>
        /// <param name="k">The positive divisor.</param>
        /// <returns>The length of the smallest all-ones multiple, or -1 if none exists.</returns>
        public int SmallestRepunitDivByK(int k)
        {
            if (k % 2 == 0 || k % 5 == 0)
                return -1;

            int remainder = 0;
            for (int length = 1; length <= k; length++)
            {
                remainder = (remainder * 10 + 1) % k;
                if (remainder == 0)
                    return length;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-to-base-2/">1017. Convert to Base -2 (medium)</a>
        /// Convert an integer to its base -2 representation.
        /// </summary>
        /// <param name="n">The non-negative integer to convert.</param>
        /// <returns>The base -2 representation without leading zeroes.</returns>
        public string BaseNeg2(int n)
        {
            if (n == 0)
                return "0";

            var result = new StringBuilder();
            while (n != 0)
            {
                int remainder = n & 1;
                result.Insert(0, remainder);
                n = (n - remainder) / -2;
            }

            return result.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divisor-game/">1025. Divisor Game (easy)</a>
        /// Decide the divisor game winner from the parity of n.
        /// </summary>
        /// <param name="n">The starting number.</param>
        /// <returns><see langword="true"/> if Alice wins with optimal play; otherwise, <see langword="false"/>.</returns>
        public bool DivisorGame(int n)
        {
            return (n & 1) == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/moving-stones-until-consecutive/">1033. Moving Stones Until Consecutive (easy)</a>
        /// Compute the minimum and maximum moves to make three stone positions consecutive.
        /// </summary>
        /// <param name="a">The first stone position.</param>
        /// <param name="b">The second stone position.</param>
        /// <param name="c">The third stone position.</param>
        /// <returns>A two-element array containing minimum then maximum moves.</returns>
        public int[] NumMovesStones(int a, int b, int c)
        {
            int[] stones = { a, b, c };
            Array.Sort(stones);
            int leftGap = stones[1] - stones[0] - 1;
            int rightGap = stones[2] - stones[1] - 1;
            int minMoves = leftGap == 0 && rightGap == 0 ? 0 : (leftGap <= 1 || rightGap <= 1 ? 1 : 2);
            return new[] { minMoves, leftGap + rightGap };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-boomerang/">1037. Valid Boomerang (easy)</a>
        /// Determine whether three points are distinct and not collinear.
        /// </summary>
        /// <param name="points">Exactly three two-dimensional points.</param>
        /// <returns><see langword="true"/> if the points form a boomerang; otherwise, <see langword="false"/>.</returns>
        public bool IsBoomerang(int[][] points)
        {
            return (points[1][0] - points[0][0]) * (points[2][1] - points[0][1]) !=
                   (points[2][0] - points[0][0]) * (points[1][1] - points[0][1]);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distribute-candies-to-people/">1103. Distribute Candies to People (easy)</a>
        /// Simulate giving increasing candy counts around a circular line of people.
        /// </summary>
        /// <param name="candies">The total candies to distribute.</param>
        /// <param name="numPeople">The number of people in line.</param>
        /// <returns>The candies received by each person.</returns>
        public int[] DistributeCandies(int candies, int numPeople)
        {
            int[] result = new int[numPeople];
            for (int give = 1, index = 0; candies > 0; give++, index = (index + 1) % numPeople)
            {
                int current = Math.Min(give, candies);
                result[index] += current;
                candies -= current;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-th-tribonacci-number/">1137. N-th Tribonacci Number (easy)</a>
        /// Return the nth Tribonacci number using constant-space iteration.
        /// </summary>
        /// <param name="n">The zero-based Tribonacci index.</param>
        /// <returns>T(n).</returns>
        public int Tribonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n <= 2)
                return 1;

            int first = 0;
            int second = 1;
            int third = 1;
            for (int i = 3; i <= n; i++)
            {
                int next = first + second + third;
                first = second;
                second = third;
                third = next;
            }

            return third;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/prime-arrangements/">1175. Prime Arrangements (easy)</a>
        /// Count permutations where prime numbers occupy prime indices and composites occupy non-prime indices.
        /// </summary>
        /// <param name="n">The number of positions and values.</param>
        /// <returns>The arrangement count modulo 1,000,000,007.</returns>
        public int NumPrimeArrangements(int n)
        {
            const int mod = 1_000_000_007;
            int primes = 0;
            for (int value = 2; value <= n; value++)
            {
                if (IsPrime(value))
                    primes++;
            }

            long result = 1;
            for (int value = 2; value <= primes; value++)
                result = result * value % mod;
            for (int value = 2; value <= n - primes; value++)
                result = result * value % mod;

            return (int)result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/day-of-the-week/">1185. Day of the Week (easy)</a>
        /// Compute the weekday for a Gregorian calendar date.
        /// </summary>
        /// <param name="day">The day of month.</param>
        /// <param name="month">The month number.</param>
        /// <param name="year">The full year.</param>
        /// <returns>The English weekday name.</returns>
        public string DayOfTheWeek(int day, int month, int year)
        {
            string[] names = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            int[] daysBeforeMonth = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int total = 365 * (year - 1) + (year - 1) / 4 - (year - 1) / 100 + (year - 1) / 400;
            total += daysBeforeMonth[month - 1] + day;
            if (month > 2 && IsLeapYear(year))
                total++;

            return names[total % 7];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/ugly-number-iii/">1201. Ugly Number III (medium)</a>
        /// Find the nth positive integer divisible by at least one of a, b, or c.
        /// </summary>
        /// <param name="n">The 1-based ugly number index.</param>
        /// <param name="a">The first divisor.</param>
        /// <param name="b">The second divisor.</param>
        /// <param name="c">The third divisor.</param>
        /// <returns>The nth ugly number under the given divisors.</returns>
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            long ab = LeastCommonMultiple(a, b);
            long ac = LeastCommonMultiple(a, c);
            long bc = LeastCommonMultiple(b, c);
            long abc = LeastCommonMultiple(ab, c);
            long left = 1;
            long right = 2_000_000_000;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                long count = mid / a + mid / b + mid / c - mid / ab - mid / ac - mid / bc + mid / abc;
                if (count >= n)
                    right = mid;
                else
                    left = mid + 1;
            }

            return (int)left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-move-chips-to-the-same-position/">1217. Minimum Cost to Move Chips to The Same Position (easy)</a>
        /// Minimize chip movement cost by moving all chips to either odd or even parity.
        /// </summary>
        /// <param name="position">The chip positions.</param>
        /// <returns>The minimum movement cost.</returns>
        public int MinCostToMoveChips(int[] position)
        {
            int odd = 0;
            foreach (int value in position)
            {
                if ((value & 1) == 1)
                    odd++;
            }

            return Math.Min(odd, position.Length - odd);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-it-is-a-straight-line/">1232. Check If It Is a Straight Line (easy)</a>
        /// Determine whether all coordinates lie on one line.
        /// </summary>
        /// <param name="coordinates">The two-dimensional points.</param>
        /// <returns><see langword="true"/> if all points are collinear; otherwise, <see langword="false"/>.</returns>
        public bool CheckStraightLine(int[][] coordinates)
        {
            int dx = coordinates[1][0] - coordinates[0][0];
            int dy = coordinates[1][1] - coordinates[0][1];
            for (int i = 2; i < coordinates.Length; i++)
            {
                if (dx * (coordinates[i][1] - coordinates[0][1]) != dy * (coordinates[i][0] - coordinates[0][0]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-it-is-a-good-array/">1250. Check If It Is a Good Array (hard)</a>
        /// Determine whether a non-negative integer combination can make 1 by checking the array GCD.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns><see langword="true"/> if the array is good; otherwise, <see langword="false"/>.</returns>
        public bool IsGoodArray(int[] nums)
        {
            long gcd = 0;
            foreach (int num in nums)
            {
                gcd = GreatestCommonDivisor(gcd, num);
                if (gcd == 1)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/">1281. Subtract the Product and Sum of Digits of an Integer (easy)</a>
        /// Subtract the sum of digits from the product of digits.
        /// </summary>
        /// <param name="n">The positive integer to evaluate.</param>
        /// <returns>The digit product minus the digit sum.</returns>
        public int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                product *= digit;
                sum += digit;
                n /= 10;
            }

            return product - sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-numbers-with-even-number-of-digits/">1295. Find Numbers with Even Number of Digits (easy)</a>
        /// Count how many numbers have an even number of decimal digits.
        /// </summary>
        /// <param name="nums">The positive integers to inspect.</param>
        /// <returns>The count of values with even digit length.</returns>
        public int FindNumbers(int[] nums)
        {
            int count = 0;
            foreach (int num in nums)
            {
                if ((num >= 10 && num <= 99) || (num >= 1000 && num <= 9999) || num == 100000)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/">1317. Convert Integer to the Sum of Two No-Zero Integers (easy)</a>
        /// Split n into two positive integers that contain no zero digits.
        /// </summary>
        /// <param name="n">The integer to split.</param>
        /// <returns>A two-element array containing no-zero addends whose sum is n.</returns>
        public int[] GetNoZeroIntegers(int n)
        {
            for (int first = 1; first < n; first++)
            {
                int second = n - first;
                if (!HasZeroDigit(first) && !HasZeroDigit(second))
                    return new[] { first, second };
            }

            return Array.Empty<int>();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-69-number/">1323. Maximum 69 Number (easy)</a>
        /// Change at most one digit 6 to 9 to maximize the number.
        /// </summary>
        /// <param name="num">The number consisting only of digits 6 and 9.</param>
        /// <returns>The maximum number obtainable.</returns>
        public int Maximum69Number(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == '6')
                {
                    digits[i] = '9';
                    break;
                }
            }

            return int.Parse(new string(digits));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/">1342. Number of Steps to Reduce a Number to Zero (easy)</a>
        /// Count steps to repeatedly halve even numbers and decrement odd numbers until zero.
        /// </summary>
        /// <param name="num">The non-negative integer to reduce.</param>
        /// <returns>The number of reduction steps.</returns>
        public int NumberOfSteps(int num)
        {
            int steps = 0;
            while (num != 0)
            {
                steps++;
                if ((num & 1) == 0)
                    num >>= 1;
                else
                    num--;
            }

            return steps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/closest-divisors/">1362. Closest Divisors (medium)</a>
        /// Find closest factor pairs for num + 1 or num + 2.
        /// </summary>
        /// <param name="num">The base integer.</param>
        /// <returns>A two-element array containing the closest divisors.</returns>
        public int[] ClosestDivisors(int num)
        {
            int[] first = ClosestFactorPair(num + 1);
            int[] second = ClosestFactorPair(num + 2);
            return first[1] - first[0] <= second[1] - second[0] ? first : second;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/four-divisors/">1390. Four Divisors (medium)</a>
        /// Sum divisors for every number that has exactly four positive divisors.
        /// </summary>
        /// <param name="nums">The numbers to inspect.</param>
        /// <returns>The total divisor sum for values with exactly four divisors.</returns>
        public int SumFourDivisors(int[] nums)
        {
            int total = 0;
            foreach (int num in nums)
            {
                int count = 0;
                int sum = 0;
                for (int divisor = 1; divisor * divisor <= num; divisor++)
                {
                    if (num % divisor != 0)
                        continue;

                    int paired = num / divisor;
                    count++;
                    sum += divisor;
                    if (paired != divisor)
                    {
                        count++;
                        sum += paired;
                    }

                    if (count > 4)
                        break;
                }

                if (count == 4)
                    total += sum;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-largest-group/">1399. Count Largest Group (easy)</a>
        /// Group numbers by digit sum and count groups with the largest size.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The number of largest digit-sum groups.</returns>
        public int CountLargestGroup(int n)
        {
            var groups = new Dictionary<int, int>();
            int largest = 0;
            int largestGroups = 0;
            for (int value = 1; value <= n; value++)
            {
                int sum = DigitSum(value);
                groups.TryGetValue(sum, out int count);
                count++;
                groups[sum] = count;
                if (count > largest)
                {
                    largest = count;
                    largestGroups = 1;
                }
                else if (count == largest)
                {
                    largestGroups++;
                }
            }

            return largestGroups;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/simplified-fractions/">1447. Simplified Fractions (medium)</a>
        /// Generate all simplified proper fractions with denominators up to n.
        /// </summary>
        /// <param name="n">The maximum denominator.</param>
        /// <returns>The simplified fractions as strings.</returns>
        public IList<string> SimplifiedFractions(int n)
        {
            var result = new List<string>();
            for (int denominator = 2; denominator <= n; denominator++)
            {
                for (int numerator = 1; numerator < denominator; numerator++)
                {
                    if (GreatestCommonDivisor(numerator, denominator) == 1)
                        result.Add(numerator + "/" + denominator);
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/xor-operation-in-an-array/">1486. XOR Operation in an Array (easy)</a>
        /// Compute the XOR of nums[i] = start + 2 * i for i from 0 to n - 1.
        /// </summary>
        /// <param name="n">The number of generated values.</param>
        /// <param name="start">The first generated value.</param>
        /// <returns>The XOR of the generated array.</returns>
        public int XorOperation(int n, int start)
        {
            int result = 0;
            for (int i = 0; i < n; i++)
                result ^= start + 2 * i;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/the-kth-factor-of-n/">1492. The kth Factor of n (medium)</a>
        /// Return the kth positive factor of n in ascending order.
        /// </summary>
        /// <param name="n">The integer whose factors are considered.</param>
        /// <param name="k">The 1-based factor index.</param>
        /// <returns>The kth factor, or -1 when fewer than k factors exist.</returns>
        public int KthFactor(int n, int k)
        {
            for (int factor = 1; factor <= n; factor++)
            {
                if (n % factor == 0 && --k == 0)
                    return factor;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-good-pairs/">1512. Number of Good Pairs (easy)</a>
        /// Count equal-value index pairs.
        /// </summary>
        /// <param name="nums">The integers to pair.</param>
        /// <returns>The number of good pairs.</returns>
        public int NumIdenticalPairs(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            int pairs = 0;
            foreach (int num in nums)
            {
                counts.TryGetValue(num, out int count);
                pairs += count;
                counts[num] = count + 1;
            }

            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/water-bottles/">1518. Water Bottles (easy)</a>
        /// Count bottles drinkable by repeatedly exchanging empty bottles for full ones.
        /// </summary>
        /// <param name="numBottles">The initial full bottle count.</param>
        /// <param name="numExchange">The number of empty bottles required for one full bottle.</param>
        /// <returns>The total number of bottles that can be drunk.</returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int total = 0;
            int empty = 0;
            while (numBottles > 0)
            {
                total += numBottles;
                empty += numBottles;
                numBottles = empty / numExchange;
                empty %= numExchange;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/">1523. Count Odd Numbers in an Interval Range (easy)</a>
        /// Count odd integers in an inclusive interval.
        /// </summary>
        /// <param name="low">The inclusive lower bound.</param>
        /// <param name="high">The inclusive upper bound.</param>
        /// <returns>The number of odd integers in the range.</returns>
        public int CountOdds(int low, int high)
        {
            return (high + 1) / 2 - low / 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-make-array-equal/">1551. Minimum Operations to Make Array Equal (medium)</a>
        /// Count operations needed to make the odd-valued array equal to n.
        /// </summary>
        /// <param name="n">The array length.</param>
        /// <returns>The minimum number of operations.</returns>
        public int MinOperations(int n)
        {
            return (n / 2) * ((n + 1) / 2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-one-bit-operations-to-make-integers-zero/">1611. Minimum One Bit Operations to Make Integers Zero (hard)</a>
        /// Compute the inverse Gray-code rank giving the minimum operations to reduce n to zero.
        /// </summary>
        /// <param name="n">The non-negative integer to reduce.</param>
        /// <returns>The minimum number of one-bit operations.</returns>
        public int MinimumOneBitOperations(int n)
        {
            int result = 0;
            while (n != 0)
            {
                result ^= n;
                n >>= 1;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-sorted-vowel-strings/">1641. Count Sorted Vowel Strings (medium)</a>
        /// Count lexicographically sorted vowel strings of length n using combinations with repetition.
        /// </summary>
        /// <param name="n">The target string length.</param>
        /// <returns>The number of sorted vowel strings.</returns>
        public int CountVowelStrings(int n)
        {
            return (n + 4) * (n + 3) * (n + 2) * (n + 1) / 24;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/">1680. Concatenation of Consecutive Binary Numbers (medium)</a>
        /// Concatenate binary representations from 1 through n and return the value modulo 1,000,000,007.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The concatenated binary value modulo 1,000,000,007.</returns>
        public int ConcatenatedBinary(int n)
        {
            const int mod = 1_000_000_007;
            long result = 0;
            int bitLength = 0;
            for (int value = 1; value <= n; value++)
            {
                if ((value & (value - 1)) == 0)
                    bitLength++;

                result = ((result << bitLength) + value) % mod;
            }

            return (int)result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-of-matches-in-tournament/">1688. Count of Matches in Tournament (easy)</a>
        /// Count matches required to reduce n teams to one winner.
        /// </summary>
        /// <param name="n">The number of teams.</param>
        /// <returns>The number of matches played.</returns>
        public int NumberOfMatches(int n)
        {
            return n - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/calculate-money-in-leetcode-bank/">1716. Calculate Money in Leetcode Bank (easy)</a>
        /// Sum the staged weekly deposits made over n days.
        /// </summary>
        /// <param name="n">The number of deposit days.</param>
        /// <returns>The total money saved after <paramref name="n"/> days.</returns>
        public int TotalMoney(int n)
        {
            int weeks = n / 7;
            int days = n % 7;
            return weeks * 28 + 7 * weeks * (weeks - 1) / 2 + days * weeks + days * (days + 1) / 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decode-xored-array/">1720. Decode XORed Array (easy)</a>
        /// Reconstruct the original array from adjacent XOR values and the first element.
        /// </summary>
        /// <param name="encoded">The adjacent XOR values.</param>
        /// <param name="first">The first value in the decoded array.</param>
        /// <returns>The decoded original array.</returns>
        public int[] Decode(int[] encoded, int first)
        {
            int[] result = new int[encoded.Length + 1];
            result[0] = first;
            for (int i = 0; i < encoded.Length; i++)
                result[i + 1] = result[i] ^ encoded[i];

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-rectangles-that-can-form-the-largest-square/">1725. Number Of Rectangles That Can Form The Largest Square (easy)</a>
        /// Count rectangles whose smaller side can make the maximum possible square side.
        /// </summary>
        /// <param name="rectangles">The rectangle dimensions [length, width].</param>
        /// <returns>The number of rectangles that can form a largest square.</returns>
        public int CountGoodRectangles(int[][] rectangles)
        {
            int best = 0;
            int count = 0;
            foreach (int[] rectangle in rectangles)
            {
                int side = Math.Min(rectangle[0], rectangle[1]);
                if (side > best)
                {
                    best = side;
                    count = 1;
                }
                else if (side == best)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/decode-xored-permutation/">1734. Decode XORed Permutation (medium)</a>
        /// Reconstruct a permutation of 1 through n from adjacent XOR values.
        /// </summary>
        /// <param name="encoded">The adjacent XOR values for an odd-length permutation.</param>
        /// <returns>The decoded permutation.</returns>
        public int[] Decode(int[] encoded)
        {
            int n = encoded.Length + 1;
            int total = 0;
            for (int value = 1; value <= n; value++)
                total ^= value;

            int oddEncoded = 0;
            for (int i = 1; i < encoded.Length; i += 2)
                oddEncoded ^= encoded[i];

            return Decode(encoded, total ^ oddEncoded);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-from-removing-stones/">1753. Maximum Score From Removing Stones (medium)</a>
        /// Maximize pair removals from three piles by bounding the score by both total pairs and the two smaller piles.
        /// </summary>
        /// <param name="a">The first pile size.</param>
        /// <param name="b">The second pile size.</param>
        /// <param name="c">The third pile size.</param>
        /// <returns>The maximum obtainable score.</returns>
        public int MaximumScore(int a, int b, int c)
        {
            int total = a + b + c;
            int largest = Math.Max(a, Math.Max(b, c));
            return Math.Min(total / 2, total - largest);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three/">1780. Check if Number is a Sum of Powers of Three (medium)</a>
        /// Determine whether n has only 0 and 1 digits in base three.
        /// </summary>
        /// <param name="n">The positive integer to check.</param>
        /// <returns><see langword="true"/> if n is a sum of distinct powers of three; otherwise, <see langword="false"/>.</returns>
        public bool CheckPowersOfThree(int n)
        {
            while (n > 0)
            {
                if (n % 3 == 2)
                    return false;
                n /= 3;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/determine-color-of-a-chessboard-square/">1812. Determine Color of a Chessboard Square (easy)</a>
        /// Determine a chessboard square's color from coordinate parity.
        /// </summary>
        /// <param name="coordinates">The square coordinate such as "a1".</param>
        /// <returns><see langword="true"/> if the square is white; otherwise, <see langword="false"/>.</returns>
        public bool SquareIsWhite(string coordinates)
        {
            return ((coordinates[0] - 'a') + (coordinates[1] - '1')) % 2 == 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-nice-pairs-in-an-array/">1814. Count Nice Pairs in an Array (medium)</a>
        /// Count pairs whose value-minus-reversed-value keys match.
        /// </summary>
        /// <param name="nums">The integers to pair.</param>
        /// <returns>The number of nice pairs modulo 1,000,000,007.</returns>
        public int CountNicePairs(int[] nums)
        {
            const int mod = 1_000_000_007;
            var counts = new Dictionary<int, int>();
            long pairs = 0;
            foreach (int num in nums)
            {
                int key = num - ReverseDecimal(num);
                counts.TryGetValue(key, out int count);
                pairs = (pairs + count) % mod;
                counts[key] = count + 1;
            }

            return (int)pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle/">1828. Queries on Number of Points Inside a Circle (medium)</a>
        /// Count points inside each query circle using squared distances.
        /// </summary>
        /// <param name="points">The point coordinates.</param>
        /// <param name="queries">The circles as [x, y, radius].</param>
        /// <returns>The number of contained points for each query.</returns>
        public int[] CountPoints(int[][] points, int[][] queries)
        {
            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                long radiusSquared = (long)queries[i][2] * queries[i][2];
                foreach (int[] point in points)
                {
                    long dx = point[0] - queries[i][0];
                    long dy = point[1] - queries[i][1];
                    if (dx * dx + dy * dy <= radiusSquared)
                        result[i]++;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-digits-in-base-k/">1837. Sum of Digits in Base K (easy)</a>
        /// Convert n conceptually to base k and sum its digits.
        /// </summary>
        /// <param name="n">The decimal integer.</param>
        /// <param name="k">The target base.</param>
        /// <returns>The sum of base-k digits.</returns>
        public int SumBase(int n, int k)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % k;
                n /= k;
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/incremental-memory-leak/">1860. Incremental Memory Leak (medium)</a>
        /// Simulate assigning each increasing allocation to the larger memory stick until allocation fails.
        /// </summary>
        /// <param name="memory1">The first memory stick capacity.</param>
        /// <param name="memory2">The second memory stick capacity.</param>
        /// <returns>[crash time, remaining memory1, remaining memory2].</returns>
        public int[] MemLeak(int memory1, int memory2)
        {
            int time = 1;
            while (Math.Max(memory1, memory2) >= time)
            {
                if (memory1 >= memory2)
                    memory1 -= time;
                else
                    memory2 -= time;
                time++;
            }

            return new[] { time, memory1, memory2 };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-good-numbers/">1922. Count Good Numbers (medium)</a>
        /// Count digit strings where even positions are even digits and odd positions are prime digits.
        /// </summary>
        /// <param name="n">The string length.</param>
        /// <returns>The count modulo 1,000,000,007.</returns>
        public int CountGoodNumbers(long n)
        {
            const int mod = 1_000_000_007;
            return (int)(ModPow(5, (n + 1) / 2, mod) * ModPow(4, n / 2, mod) % mod);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-square-sum-triples/">1925. Count Square Sum Triples (easy)</a>
        /// Count ordered triples where a squared plus b squared equals c squared.
        /// </summary>
        /// <param name="n">The inclusive upper bound for each value.</param>
        /// <returns>The number of square-sum triples.</returns>
        public int CountTriples(int n)
        {
            int count = 0;
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    int square = a * a + b * b;
                    int c = (int)Math.Sqrt(square);
                    if (c <= n && c * c == square)
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/three-divisors/">1952. Three Divisors (easy)</a>
        /// Determine whether n is the square of a prime.
        /// </summary>
        /// <param name="n">The positive integer to inspect.</param>
        /// <returns><see langword="true"/> if n has exactly three divisors; otherwise, <see langword="false"/>.</returns>
        public bool IsThree(int n)
        {
            int root = (int)Math.Sqrt(n);
            return root * root == n && IsPrime(root);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-non-zero-product-of-the-array-elements/">1969. Minimum Non-Zero Product of the Array Elements (medium)</a>
        /// Compute the formula for the minimum non-zero product of values from 1 to 2^p - 1.
        /// </summary>
        /// <param name="p">The bit width.</param>
        /// <returns>The minimum product modulo 1,000,000,007.</returns>
        public int MinNonZeroProduct(int p)
        {
            const int mod = 1_000_000_007;
            long max = (1L << p) - 1;
            long pairValue = max - 1;
            long exponent = (1L << (p - 1)) - 1;
            return (int)(ModPow(pairValue % mod, exponent, mod) * (max % mod) % mod);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-greatest-common-divisor-of-array/">1979. Find Greatest Common Divisor of Array (easy)</a>
        /// Find the GCD of the minimum and maximum values in an array.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The greatest common divisor of the array's minimum and maximum.</returns>
        public int FindGCD(int[] nums)
        {
            int min = nums[0];
            int max = nums[0];
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            return (int)GreatestCommonDivisor(min, max);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-pairs-of-interchangeable-rectangles/">2001. Number of Pairs of Interchangeable Rectangles (medium)</a>
        /// Count pairs of rectangles with equal reduced width-to-height ratios.
        /// </summary>
        /// <param name="rectangles">The rectangle dimensions [width, height].</param>
        /// <returns>The number of interchangeable pairs.</returns>
        public long InterchangeableRectangles(int[][] rectangles)
        {
            var counts = new Dictionary<(int width, int height), int>();
            long pairs = 0;
            foreach (int[] rectangle in rectangles)
            {
                int gcd = (int)GreatestCommonDivisor(rectangle[0], rectangle[1]);
                var key = (rectangle[0] / gcd, rectangle[1] / gcd);
                counts.TryGetValue(key, out int count);
                pairs += count;
                counts[key] = count + 1;
            }

            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-missing-observations/">2028. Find Missing Observations (medium)</a>
        /// Recover any valid missing dice rolls that make the overall mean possible.
        /// </summary>
        /// <param name="rolls">The observed dice rolls.</param>
        /// <param name="mean">The required mean of all rolls.</param>
        /// <param name="n">The number of missing rolls.</param>
        /// <returns>A valid set of missing rolls, or an empty array when impossible.</returns>
        public int[] MissingRolls(int[] rolls, int mean, int n)
        {
            int missingSum = mean * (rolls.Length + n);
            foreach (int roll in rolls)
                missingSum -= roll;

            if (missingSum < n || missingSum > 6 * n)
                return Array.Empty<int>();

            int[] result = new int[n];
            Array.Fill(result, missingSum / n);
            int extra = missingSum % n;
            for (int i = 0; i < extra; i++)
                result[i]++;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets/">2044. Count Number of Maximum Bitwise-OR Subsets (medium)</a>
        /// Count subsets whose bitwise OR equals the maximum OR of all numbers.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The number of maximum-OR subsets.</returns>
        public int CountMaxOrSubsets(int[] nums)
        {
            int target = 0;
            foreach (int num in nums)
                target |= num;

            return CountMaxOrSubsets(nums, 0, 0, target);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/next-greater-numerically-balanced-number/">2048. Next Greater Numerically Balanced Number (medium)</a>
        /// Find the next integer whose non-zero digit counts equal the digits themselves.
        /// </summary>
        /// <param name="n">The lower bound, excluded.</param>
        /// <returns>The next numerically balanced number.</returns>
        public int NextBeautifulNumber(int n)
        {
            for (int value = n + 1; ; value++)
            {
                if (IsNumericallyBalanced(value))
                    return value;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-operations-to-obtain-zero/">2169. Count Operations to Obtain Zero (easy)</a>
        /// Repeatedly subtract the smaller value from the larger until one value reaches zero.
        /// </summary>
        /// <param name="num1">The first non-negative integer.</param>
        /// <param name="num2">The second non-negative integer.</param>
        /// <returns>The number of subtraction operations.</returns>
        public int CountOperations(int num1, int num2)
        {
            int operations = 0;
            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                    num1 -= num2;
                else
                    num2 -= num1;
                operations++;
            }

            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-three-consecutive-integers-that-sum-to-a-given-number/">2177. Find Three Consecutive Integers That Sum to a Given Number (medium)</a>
        /// Return the centered consecutive triple whose sum is num when divisible by three.
        /// </summary>
        /// <param name="num">The target sum.</param>
        /// <returns>Three consecutive integers summing to num, or an empty array.</returns>
        public long[] SumOfThree(long num)
        {
            return num % 3 == 0 ? new[] { num / 3 - 1, num / 3, num / 3 + 1 } : Array.Empty<long>();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-integers-with-even-digit-sum/">2180. Count Integers With Even Digit Sum (easy)</a>
        /// Count positive integers up to num whose digit sum is even.
        /// </summary>
        /// <param name="num">The inclusive upper bound.</param>
        /// <returns>The count of integers with an even digit sum.</returns>
        public int CountEven(int num)
        {
            int count = 0;
            for (int value = 1; value <= num; value++)
            {
                if ((DigitSum(value) & 1) == 0)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/append-k-integers-with-minimal-sum/">2195. Append K Integers With Minimal Sum (medium)</a>
        /// Choose the smallest missing positive integers and sum them by gaps.
        /// </summary>
        /// <param name="nums">The excluded positive integers.</param>
        /// <param name="k">The number of integers to append.</param>
        /// <returns>The minimum possible sum.</returns>
        public long MinimalKSum(int[] nums, int k)
        {
            Array.Sort(nums);
            long next = 1;
            long sum = 0;
            foreach (int num in nums)
            {
                if (num < next)
                    continue;

                long take = Math.Min(k, num - next);
                sum += (next + next + take - 1) * take / 2;
                k -= (int)take;
                next = (long)num + 1;
                if (k == 0)
                    return sum;
            }

            return sum + (next + next + k - 1) * k / 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-bit-flips-to-convert-number/">2220. Minimum Bit Flips to Convert Number (easy)</a>
        /// Count differing bits between start and goal.
        /// </summary>
        /// <param name="start">The starting integer.</param>
        /// <param name="goal">The target integer.</param>
        /// <returns>The minimum number of bit flips required.</returns>
        public int MinBitFlips(int start, int goal)
        {
            int value = start ^ goal;
            int flips = 0;
            while (value != 0)
            {
                value &= value - 1;
                flips++;
            }

            return flips;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/add-two-integers/">2235. Add Two Integers (easy)</a>
        /// Add two integer values.
        /// </summary>
        /// <param name="num1">The first integer.</param>
        /// <param name="num2">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-ways-to-buy-pens-and-pencils/">2240. Number of Ways to Buy Pens and Pencils (medium)</a>
        /// Count all non-negative combinations of pen and pencil counts within budget.
        /// </summary>
        /// <param name="total">The total budget.</param>
        /// <param name="cost1">The pen cost.</param>
        /// <param name="cost2">The pencil cost.</param>
        /// <returns>The number of valid purchase combinations.</returns>
        public long WaysToBuyPensPencils(int total, int cost1, int cost2)
        {
            long ways = 0;
            for (int spent = 0; spent <= total; spent += cost1)
                ways += (total - spent) / cost2 + 1;

            return ways;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-combination-with-bitwise-and-greater-than-zero/">2275. Largest Combination With Bitwise AND Greater Than Zero (medium)</a>
        /// Count candidates with each bit set and choose the largest count.
        /// </summary>
        /// <param name="candidates">The positive candidate values.</param>
        /// <returns>The size of the largest valid combination.</returns>
        public int LargestCombination(int[] candidates)
        {
            int best = 0;
            for (int bit = 0; bit < 31; bit++)
            {
                int count = 0;
                foreach (int candidate in candidates)
                    count += (candidate >> bit) & 1;
                best = Math.Max(best, count);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-numbers-with-units-digit-k/">2310. Sum of Numbers With Units Digit K (medium)</a>
        /// Find the smallest count of positive numbers ending in k whose sum is num.
        /// </summary>
        /// <param name="num">The target sum.</param>
        /// <param name="k">The required units digit.</param>
        /// <returns>The minimum count, or -1 if impossible.</returns>
        public int MinimumNumbers(int num, int k)
        {
            if (num == 0)
                return 0;

            for (int count = 1; count <= 10; count++)
            {
                if (count * k % 10 == num % 10 && count * k <= num)
                    return count;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-xor-after-operations/">2317. Maximum XOR After Operations (medium)</a>
        /// Compute the maximum possible XOR as the bitwise OR of all values.
        /// </summary>
        /// <param name="nums">The integers after allowed operations.</param>
        /// <returns>The maximum obtainable XOR.</returns>
        public int MaximumXOR(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
                result |= num;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-zero-filled-subarrays/">2348. Number of Zero-Filled Subarrays (medium)</a>
        /// Sum lengths of all contiguous all-zero subarrays.
        /// </summary>
        /// <param name="nums">The integers to scan.</param>
        /// <returns>The number of zero-filled subarrays.</returns>
        public long ZeroFilledSubarray(int[] nums)
        {
            long total = 0;
            long streak = 0;
            foreach (int num in nums)
            {
                streak = num == 0 ? streak + 1 : 0;
                total += streak;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-excellent-pairs/">2354. Number of Excellent Pairs (hard)</a>
        /// Count ordered unique-value pairs whose set-bit counts sum to at least k.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <param name="k">The minimum total set-bit threshold.</param>
        /// <returns>The number of excellent ordered pairs.</returns>
        public long CountExcellentPairs(int[] nums, int k)
        {
            var unique = new HashSet<int>(nums);
            int[] bits = new int[unique.Count];
            int index = 0;
            foreach (int num in unique)
                bits[index++] = CountSetBits(num);

            Array.Sort(bits);
            long pairs = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                int first = LowerBound(bits, k - bits[i]);
                pairs += bits.Length - first;
            }

            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-even-multiple/">2413. Smallest Even Multiple (easy)</a>
        /// Return the least common multiple of n and 2.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The smallest positive even multiple of n.</returns>
        public int SmallestEvenMultiple(int n)
        {
            return (n & 1) == 0 ? n : n * 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-common-factors/">2427. Number of Common Factors (easy)</a>
        /// Count positive integers that divide both a and b.
        /// </summary>
        /// <param name="a">The first positive integer.</param>
        /// <param name="b">The second positive integer.</param>
        /// <returns>The number of common factors.</returns>
        public int CommonFactors(int a, int b)
        {
            int gcd = (int)GreatestCommonDivisor(a, b);
            int count = 0;
            for (int factor = 1; factor * factor <= gcd; factor++)
            {
                if (gcd % factor != 0)
                    continue;

                count++;
                if (factor * factor != gcd)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/bitwise-xor-of-all-pairings/">2425. Bitwise XOR of All Pairings (medium)</a>
        /// Use parity of pair counts to compute the XOR of every nums1[i] XOR nums2[j].
        /// </summary>
        /// <param name="nums1">The first integer array.</param>
        /// <param name="nums2">The second integer array.</param>
        /// <returns>The XOR of all pairings.</returns>
        public int XorAllNums(int[] nums1, int[] nums2)
        {
            int result = 0;
            if ((nums2.Length & 1) == 1)
            {
                foreach (int num in nums1)
                    result ^= num;
            }

            if ((nums1.Length & 1) == 1)
            {
                foreach (int num in nums2)
                    result ^= num;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-number-and-its-reverse/">2443. Sum of Number and Its Reverse (medium)</a>
        /// Check whether num can be written as x plus reverse(x).
        /// </summary>
        /// <param name="num">The target integer.</param>
        /// <returns><see langword="true"/> if such an x exists; otherwise, <see langword="false"/>.</returns>
        public bool SumOfNumberAndReverse(int num)
        {
            for (int value = 0; value <= num; value++)
            {
                if (value + ReverseDecimal(value) == num)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/average-value-of-even-numbers-that-are-divisible-by-three/">2455. Average Value of Even Numbers That Are Divisible by Three (easy)</a>
        /// Average all values divisible by six, returning zero when none exist.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The integer average of qualifying values.</returns>
        public int AverageValue(int[] nums)
        {
            int sum = 0;
            int count = 0;
            foreach (int num in nums)
            {
                if (num % 6 == 0)
                {
                    sum += num;
                    count++;
                }
            }

            return count == 0 ? 0 : sum / count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-the-temperature/">2469. Convert the Temperature (easy)</a>
        /// Convert Celsius to Kelvin and Fahrenheit.
        /// </summary>
        /// <param name="celsius">The Celsius temperature.</param>
        /// <returns>[Kelvin, Fahrenheit].</returns>
        public double[] ConvertTemperature(double celsius)
        {
            return new[] { celsius + 273.15, celsius * 1.80 + 32.00 };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cuts-to-divide-a-circle/">2481. Minimum Cuts to Divide a Circle (easy)</a>
        /// Determine the fewest straight cuts needed to divide a circle into n equal slices.
        /// </summary>
        /// <param name="n">The number of desired slices.</param>
        /// <returns>The minimum number of cuts.</returns>
        public int NumberOfCuts(int n)
        {
            if (n == 1)
                return 0;

            return (n & 1) == 0 ? n / 2 : n;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-digits-that-divide-a-number/">2520. Count the Digits That Divide a Number (easy)</a>
        /// Count digits of num that evenly divide num.
        /// </summary>
        /// <param name="num">The positive integer to inspect.</param>
        /// <returns>The number of divisor digits.</returns>
        public int CountDigits(int num)
        {
            int original = num;
            int count = 0;
            while (num > 0)
            {
                if (original % (num % 10) == 0)
                    count++;
                num /= 10;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distinct-prime-factors-of-product-of-array/">2521. Distinct Prime Factors of Product of Array (medium)</a>
        /// Count unique prime factors present in the product of all numbers.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The number of distinct prime factors.</returns>
        public int DistinctPrimeFactors(int[] nums)
        {
            var factors = new HashSet<int>();
            foreach (int num in nums)
            {
                int value = num;
                for (int factor = 2; factor * factor <= value; factor++)
                {
                    if (value % factor != 0)
                        continue;

                    factors.Add(factor);
                    while (value % factor == 0)
                        value /= factor;
                }

                if (value > 1)
                    factors.Add(value);
            }

            return factors.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/alternating-digit-sum/">2544. Alternating Digit Sum (easy)</a>
        /// Sum digits with alternating signs from most significant to least significant.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The alternating digit sum.</returns>
        public int AlternateDigitSum(int n)
        {
            string digits = n.ToString();
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
                sum += (i & 1) == 0 ? digits[i] - '0' : '0' - digits[i];

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-distinct-numbers-on-board/">2549. Count Distinct Numbers on Board (easy)</a>
        /// Count eventual values appearing on the board under the divisor rule.
        /// </summary>
        /// <param name="n">The initial number on the board.</param>
        /// <returns>The number of distinct values that appear after many days.</returns>
        public int DistinctIntegers(int n)
        {
            return n == 1 ? 1 : n - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-collisions-of-monkeys-on-a-polygon/">2550. Count Collisions of Monkeys on a Polygon (medium)</a>
        /// Count direction assignments causing a collision by excluding the two all-same directions.
        /// </summary>
        /// <param name="n">The number of monkeys.</param>
        /// <returns>The collision count modulo 1,000,000,007.</returns>
        public int MonkeyMove(int n)
        {
            const int mod = 1_000_000_007;
            return (int)((ModPow(2, n, mod) - 2 + mod) % mod);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-difference-by-remapping-a-digit/">2566. Maximum Difference by Remapping a Digit (easy)</a>
        /// Maximize and minimize by remapping one digit value throughout the number.
        /// </summary>
        /// <param name="num">The positive integer.</param>
        /// <returns>The maximum possible difference.</returns>
        public int MinMaxDifference(int num)
        {
            char[] maxDigits = num.ToString().ToCharArray();
            char maxSource = '\0';
            foreach (char digit in maxDigits)
            {
                if (digit != '9')
                {
                    maxSource = digit;
                    break;
                }
            }

            if (maxSource != '\0')
            {
                for (int i = 0; i < maxDigits.Length; i++)
                {
                    if (maxDigits[i] == maxSource)
                        maxDigits[i] = '9';
                }
            }

            char[] minDigits = num.ToString().ToCharArray();
            char minSource = minDigits[0];
            for (int i = 0; i < minDigits.Length; i++)
            {
                if (minDigits[i] == minSource)
                    minDigits[i] = '0';
            }

            return int.Parse(new string(maxDigits)) - int.Parse(new string(minDigits));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-total-number-of-colored-cells/">2579. Count Total Number of Colored Cells (medium)</a>
        /// Count cells in the expanding diamond after n minutes.
        /// </summary>
        /// <param name="n">The minute count.</param>
        /// <returns>The total number of colored cells.</returns>
        public long ColoredCells(int n)
        {
            return 1L + 2L * n * (n - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pass-the-pillow/">2582. Pass the Pillow (easy)</a>
        /// Compute the holder after moving back and forth along n people.
        /// </summary>
        /// <param name="n">The number of people.</param>
        /// <param name="time">The elapsed seconds.</param>
        /// <returns>The 1-based index holding the pillow.</returns>
        public int PassThePillow(int n, int time)
        {
            int cycle = 2 * (n - 1);
            int offset = time % cycle;
            return offset < n ? offset + 1 : cycle - offset + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distribute-money-to-maximum-children/">2591. Distribute Money to Maximum Children (easy)</a>
        /// Maximize children with exactly eight dollars under the distribution constraints.
        /// </summary>
        /// <param name="money">The total dollars.</param>
        /// <param name="children">The number of children.</param>
        /// <returns>The maximum number of children receiving exactly eight dollars, or -1 if impossible.</returns>
        public int DistMoney(int money, int children)
        {
            money -= children;
            if (money < 0)
                return -1;

            int eights = Math.Min(money / 7, children);
            money -= eights * 7;
            children -= eights;
            if (children == 0 && money > 0)
                eights--;
            if (children == 1 && money == 3)
                eights--;

            return eights;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-multiples/">2652. Sum Multiples (easy)</a>
        /// Sum all numbers up to n divisible by 3, 5, or 7.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The sum of qualifying multiples.</returns>
        public int SumOfMultiples(int n)
        {
            int sum = 0;
            for (int value = 1; value <= n; value++)
            {
                if (value % 3 == 0 || value % 5 == 0 || value % 7 == 0)
                    sum += value;
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-punishment-number-of-an-integer/">2698. Find the Punishment Number of an Integer (medium)</a>
        /// Sum squares of values whose square digits can be partitioned to add back to the value.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The punishment number of n.</returns>
        public int PunishmentNumber(int n)
        {
            int sum = 0;
            for (int value = 1; value <= n; value++)
            {
                int square = value * value;
                if (CanPartitionSquare(square.ToString(), 0, value))
                    sum += square;
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-the-number-is-fascinating/">2729. Check if The Number is Fascinating (easy)</a>
        /// Determine whether concatenating n, 2n, and 3n uses each digit 1 through 9 exactly once and no zeroes.
        /// </summary>
        /// <param name="n">The positive integer to test.</param>
        /// <returns><see langword="true"/> if the concatenation is fascinating; otherwise, <see langword="false"/>.</returns>
        public bool IsFascinating(int n)
        {
            string value = n.ToString() + (2 * n).ToString() + (3 * n).ToString();
            if (value.Length != 9)
                return false;

            int mask = 0;
            foreach (char digit in value)
            {
                if (digit == '0')
                    return false;

                int bit = 1 << (digit - '1');
                if ((mask & bit) != 0)
                    return false;

                mask |= bit;
            }

            return mask == (1 << 9) - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-distance-traveled/">2739. Total Distance Traveled (easy)</a>
        /// Compute truck distance when every five consumed main-tank liters can transfer one liter from the additional tank.
        /// </summary>
        /// <param name="mainTank">Initial liters in the main tank.</param>
        /// <param name="additionalTank">Available refill liters.</param>
        /// <returns>The total distance traveled in kilometers.</returns>
        public int DistanceTraveled(int mainTank, int additionalTank)
        {
            int consumed = 0;
            while (mainTank > 0)
            {
                mainTank--;
                consumed++;
                if (consumed % 5 == 0 && additionalTank > 0)
                {
                    mainTank++;
                    additionalTank--;
                }
            }

            return consumed * 10;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-beautiful-pairs/">2748. Number of Beautiful Pairs (easy)</a>
        /// Count pairs whose first digit of nums[i] and last digit of nums[j] are coprime for i &lt; j.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The number of beautiful index pairs.</returns>
        public int CountBeautifulPairs(int[] nums)
        {
            int[] firstDigitCounts = new int[10];
            int result = 0;
            foreach (int num in nums)
            {
                int lastDigit = num % 10;
                for (int first = 1; first <= 9; first++)
                {
                    if (GreatestCommonDivisor(first, lastDigit) == 1)
                        result += firstDigitCounts[first];
                }

                int leading = num;
                while (leading >= 10)
                    leading /= 10;
                firstDigitCounts[leading]++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-maximum-achievable-number/">2769. Find the Maximum Achievable Number (easy)</a>
        /// Maximize x when num and x can move toward each other for t operations.
        /// </summary>
        /// <param name="num">The starting number.</param>
        /// <param name="t">The number of operations.</param>
        /// <returns>The maximum achievable value.</returns>
        public int TheMaximumAchievableX(int num, int t)
        {
            return num + 2 * t;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/account-balance-after-rounded-purchase/">2806. Account Balance After Rounded Purchase (easy)</a>
        /// Round the purchase to the nearest multiple of ten and subtract it from 100.
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount from 0 to 100.</param>
        /// <returns>The account balance after the rounded purchase.</returns>
        public int AccountBalanceAfterPurchase(int purchaseAmount)
        {
            return 100 - ((purchaseAmount + 5) / 10) * 10;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-symmetric-integers/">2843. Count Symmetric Integers (easy)</a>
        /// Count integers with an even number of digits whose left-half digit sum equals the right-half digit sum.
        /// </summary>
        /// <param name="low">The inclusive lower bound.</param>
        /// <param name="high">The inclusive upper bound.</param>
        /// <returns>The count of symmetric integers in the range.</returns>
        public int CountSymmetricIntegers(int low, int high)
        {
            int count = 0;
            for (int value = low; value <= high; value++)
            {
                string digits = value.ToString();
                if ((digits.Length & 1) == 1)
                    continue;

                int balance = 0;
                for (int i = 0; i < digits.Length; i++)
                    balance += i < digits.Length / 2 ? digits[i] - '0' : '0' - digits[i];

                if (balance == 0)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divisible-and-non-divisible-sums-difference/">2894. Divisible and Non-divisible Sums Difference (easy)</a>
        /// Subtract the sum of values divisible by m from the sum of values not divisible by m over 1..n.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <param name="m">The divisor.</param>
        /// <returns>The requested sum difference.</returns>
        public int DifferenceOfSums(int n, int m)
        {
            int total = n * (n + 1) / 2;
            int divisibleCount = n / m;
            int divisibleSum = m * divisibleCount * (divisibleCount + 1) / 2;
            return total - 2 * divisibleSum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-k-or-of-an-array/">2917. Find the K-or of an Array (easy)</a>
        /// Build the integer whose bits are set when at least k input numbers have that bit set.
        /// </summary>
        /// <param name="nums">The input numbers.</param>
        /// <param name="k">The minimum frequency required for a bit.</param>
        /// <returns>The K-or value.</returns>
        public int FindKOr(int[] nums, int k)
        {
            int result = 0;
            for (int bit = 0; bit < 31; bit++)
            {
                int count = 0;
                foreach (int num in nums)
                {
                    if (((num >> bit) & 1) == 1)
                        count++;
                }

                if (count >= k)
                    result |= 1 << bit;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distribute-candies-among-children-i/">2928. Distribute Candies Among Children I (easy)</a>
        /// Count distributions of n candies to three children with no child receiving more than limit.
        /// </summary>
        /// <param name="n">The total candies.</param>
        /// <param name="limit">The per-child maximum.</param>
        /// <returns>The number of valid distributions.</returns>
        public int DistributeCandiesAmongChildren(int n, int limit)
        {
            int ways = 0;
            for (int first = 0; first <= Math.Min(n, limit); first++)
            {
                for (int second = 0; second <= Math.Min(n - first, limit); second++)
                {
                    int third = n - first - second;
                    if (third <= limit)
                        ways++;
                }
            }

            return ways;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distribute-candies-among-children-ii/">2929. Distribute Candies Among Children II (medium)</a>
        /// Count bounded three-child candy distributions using inclusion-exclusion.
        /// </summary>
        /// <param name="n">The total candies.</param>
        /// <param name="limit">The per-child maximum.</param>
        /// <returns>The number of valid distributions.</returns>
        public long DistributeCandiesAmongChildrenII(int n, int limit)
        {
            return Combination2(n + 2) - 3 * Combination2(n - limit + 1) +
                   3 * Combination2(n - 2 * limit) - Combination2(n - 3 * limit - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/double-modular-exponentiation/">2961. Double Modular Exponentiation (medium)</a>
        /// Return indices whose nested modular exponentiation equals the target.
        /// </summary>
        /// <param name="variables">Rows [a, b, c, m] defining ((a^b mod 10)^c mod m).</param>
        /// <param name="target">The target value.</param>
        /// <returns>All good indices in increasing order.</returns>
        public IList<int> GetGoodIndices(int[][] variables, int target)
        {
            var result = new List<int>();
            for (int i = 0; i < variables.Length; i++)
            {
                int first = ModPow(variables[i][0], variables[i][1], 10);
                if (ModPow(first, variables[i][2], variables[i][3]) == target)
                    result.Add(i);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/most-expensive-item-that-can-not-be-bought/">2979. Most Expensive Item That Can Not Be Bought (medium)</a>
        /// Find the Frobenius number for two coprime prime item prices.
        /// </summary>
        /// <param name="primeOne">The first prime price.</param>
        /// <param name="primeTwo">The second prime price.</param>
        /// <returns>The largest price that cannot be formed.</returns>
        public int MostExpensiveItem(int primeOne, int primeTwo)
        {
            return primeOne * primeTwo - primeOne - primeTwo;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k/">2997. Minimum Number of Operations to Make Array XOR Equal to K (medium)</a>
        /// Count differing bits between the array XOR and k because each operation can flip one bit.
        /// </summary>
        /// <param name="nums">The input array.</param>
        /// <param name="k">The target XOR value.</param>
        /// <returns>The minimum number of bit flips.</returns>
        public int MinOperationsXor(int[] nums, int k)
        {
            int xor = 0;
            foreach (int num in nums)
                xor ^= num;

            return CountSetBits(xor ^ k);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-moves-to-capture-the-queen/">3001. Minimum Moves to Capture The Queen (medium)</a>
        /// Determine whether the rook or bishop can capture the queen immediately; otherwise two moves are enough.
        /// </summary>
        /// <param name="a">Rook row.</param>
        /// <param name="b">Rook column.</param>
        /// <param name="c">Bishop row.</param>
        /// <param name="d">Bishop column.</param>
        /// <param name="e">Queen row.</param>
        /// <param name="f">Queen column.</param>
        /// <returns>The minimum capture moves.</returns>
        public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
        {
            if ((a == e && (c != e || !Between(b, d, f))) || (b == f && (d != f || !Between(a, c, e))))
                return 1;

            if (Math.Abs(c - e) == Math.Abs(d - f) &&
                (Math.Abs(a - e) != Math.Abs(b - f) || !Between(c, a, e) || !Between(d, b, f)))
                return 1;

            return 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-elements-with-maximum-frequency/">3005. Count Elements With Maximum Frequency (easy)</a>
        /// Count all elements whose value frequency equals the maximum frequency.
        /// </summary>
        /// <param name="nums">The input values.</param>
        /// <returns>The total occurrences of maximum-frequency values.</returns>
        public int MaxFrequencyElements(int[] nums)
        {
            int[] frequencies = new int[101];
            int maxFrequency = 0;
            int total = 0;
            foreach (int num in nums)
            {
                frequencies[num]++;
                if (frequencies[num] > maxFrequency)
                {
                    maxFrequency = frequencies[num];
                    total = maxFrequency;
                }
                else if (frequencies[num] == maxFrequency)
                {
                    total += maxFrequency;
                }
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimize-length-of-array-using-operations/">3012. Minimize Length of Array Using Operations (medium)</a>
        /// Reduce the array according to modulo operations, where divisibility by the minimum controls the answer.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The minimum possible length.</returns>
        public int MinimumArrayLength(int[] nums)
        {
            int minimum = int.MaxValue;
            foreach (int num in nums)
                minimum = Math.Min(minimum, num);

            int minimumCount = 0;
            foreach (int num in nums)
            {
                if (num % minimum != 0)
                    return 1;
                if (num == minimum)
                    minimumCount++;
            }

            return (minimumCount + 1) / 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/alice-and-bob-playing-flower-game/">3021. Alice and Bob Playing Flower Game (medium)</a>
        /// Count pairs of flower counts with odd total, giving Alice a forced win.
        /// </summary>
        /// <param name="n">The maximum flowers in the first row.</param>
        /// <param name="m">The maximum flowers in the second row.</param>
        /// <returns>The number of winning pairs.</returns>
        public long FlowerGame(int n, int m)
        {
            return (long)(n / 2) * ((m + 1) / 2) + (long)((n + 1) / 2) * (m / 2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-sum-of-encrypted-integers/">3079. Find the Sum of Encrypted Integers (easy)</a>
        /// Replace each integer by repeating its maximum digit for the original digit count and sum the results.
        /// </summary>
        /// <param name="nums">The positive integers to encrypt.</param>
        /// <returns>The sum of encrypted values.</returns>
        public int SumOfEncryptedInt(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                int value = num;
                int maxDigit = 0;
                int encrypted = 0;
                int place = 1;
                while (value > 0)
                {
                    maxDigit = Math.Max(maxDigit, value % 10);
                    encrypted += place;
                    place *= 10;
                    value /= 10;
                }

                sum += encrypted * maxDigit;
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/harshad-number/">3099. Harshad Number (easy)</a>
        /// Return the digit sum of x when x is divisible by that sum.
        /// </summary>
        /// <param name="x">The positive integer.</param>
        /// <returns>The digit sum for a Harshad number; otherwise -1.</returns>
        public int SumOfTheDigitsOfHarshadNumber(int x)
        {
            int sum = DigitSum(x);
            return x % sum == 0 ? sum : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-prime-difference/">3115. Maximum Prime Difference (medium)</a>
        /// Find the distance between the first and last prime-valued elements in the array.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The maximum prime index difference.</returns>
        public int MaximumPrimeDifference(int[] nums)
        {
            int first = -1;
            int last = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!IsPrime(nums[i]))
                    continue;

                if (first == -1)
                    first = i;
                last = i;
            }

            return last - first;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-array-end/">3133. Minimum Array End (medium)</a>
        /// Fill zero bits of x with bits from n - 1 to minimize the final array value while preserving bitwise AND x.
        /// </summary>
        /// <param name="n">The array length.</param>
        /// <param name="x">The required bitwise AND.</param>
        /// <returns>The minimum possible last element.</returns>
        public long MinEnd(int n, int x)
        {
            long result = x;
            long remaining = n - 1L;
            int bit = 0;
            while (remaining > 0)
            {
                if (((result >> bit) & 1L) == 0)
                {
                    if ((remaining & 1L) == 1)
                        result |= 1L << bit;
                    remaining >>= 1;
                }

                bit++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-xor-of-numbers-which-appear-twice/">3158. Find the XOR of Numbers Which Appear Twice (easy)</a>
        /// XOR every value that appears exactly twice in the array.
        /// </summary>
        /// <param name="nums">Values in the range 1 through 50.</param>
        /// <returns>The XOR of duplicate values.</returns>
        public int DuplicateNumbersXOR(int[] nums)
        {
            bool[] seen = new bool[51];
            int result = 0;
            foreach (int num in nums)
            {
                if (seen[num])
                    result ^= num;
                else
                    seen[num] = true;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-number-of-good-pairs-ii/">3164. Find the Number of Good Pairs II (medium)</a>
        /// Count good pairs efficiently by factoring scaled nums1 values and matching nums2 frequencies.
        /// </summary>
        /// <param name="nums1">The dividend values.</param>
        /// <param name="nums2">The divisor base values.</param>
        /// <param name="k">The multiplier.</param>
        /// <returns>The number of good pairs.</returns>
        public long NumberOfPairsII(int[] nums1, int[] nums2, int k)
        {
            var frequencies = new Dictionary<int, int>();
            foreach (int num in nums2)
            {
                frequencies.TryGetValue(num, out int count);
                frequencies[num] = count + 1;
            }

            long result = 0;
            foreach (int num in nums1)
            {
                if (num % k != 0)
                    continue;

                int value = num / k;
                for (int divisor = 1; divisor * divisor <= value; divisor++)
                {
                    if (value % divisor != 0)
                        continue;

                    if (frequencies.TryGetValue(divisor, out int count))
                        result += count;

                    int other = value / divisor;
                    if (other != divisor && frequencies.TryGetValue(other, out count))
                        result += count;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-child-who-has-the-ball-after-k-seconds/">3178. Find the Child Who Has the Ball After K Seconds (easy)</a>
        /// Locate the ball after it bounces between the first and last child.
        /// </summary>
        /// <param name="n">The number of children.</param>
        /// <param name="k">The elapsed seconds.</param>
        /// <returns>The zero-based child index holding the ball.</returns>
        public int NumberOfChild(int n, int k)
        {
            int cycle = 2 * (n - 1);
            int offset = k % cycle;
            return offset < n ? offset : cycle - offset;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/">3190. Find Minimum Operations to Make All Elements Divisible by Three (easy)</a>
        /// Count elements not already divisible by three because each can be adjusted by one.
        /// </summary>
        /// <param name="nums">The input integers.</param>
        /// <returns>The minimum number of operations.</returns>
        public int MinimumOperations(int[] nums)
        {
            int operations = 0;
            foreach (int num in nums)
            {
                if (num % 3 != 0)
                    operations++;
            }

            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-height-of-a-triangle/">3200. Maximum Height of a Triangle (easy)</a>
        /// Build alternating-color rows and return the taller possible triangle height.
        /// </summary>
        /// <param name="red">The count of red balls.</param>
        /// <param name="blue">The count of blue balls.</param>
        /// <returns>The maximum complete height.</returns>
        public int MaxHeightOfTriangle(int red, int blue)
        {
            return Math.Max(MaxHeightStartingWith(red, blue), MaxHeightStartingWith(blue, red));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-winning-player-in-coin-game/">3222. Find the Winning Player in Coin Game (easy)</a>
        /// Determine the winner from the parity of turns that can spend one 75-value coin and four 10-value coins.
        /// </summary>
        /// <param name="x">The count of 75-value coins.</param>
        /// <param name="y">The count of 10-value coins.</param>
        /// <returns>"Alice" if the first player wins; otherwise "Bob".</returns>
        public string LosingPlayer(int x, int y)
        {
            return (Math.Min(x, y / 4) & 1) == 1 ? "Alice" : "Bob";
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-bit-changes-to-make-two-integers-equal/">3226. Number of Bit Changes to Make Two Integers Equal (easy)</a>
        /// Count one-bits that must be cleared from n to make k, returning -1 if k needs a new one-bit.
        /// </summary>
        /// <param name="n">The starting integer.</param>
        /// <param name="k">The target integer.</param>
        /// <returns>The minimum bit changes, or -1 when impossible.</returns>
        public int MinChanges(int n, int k)
        {
            return (n & k) == k ? CountSetBits(n ^ k) : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-if-digit-game-can-be-won/">3232. Find if Digit Game Can Be Won (easy)</a>
        /// Compare the sum of one-digit numbers with the sum of two-digit numbers.
        /// </summary>
        /// <param name="nums">Numbers from 1 through 99.</param>
        /// <returns><see langword="true"/> if Alice can choose a group with a strictly larger sum.</returns>
        public bool CanAliceWin(int[] nums)
        {
            int oneDigit = 0;
            int twoDigit = 0;
            foreach (int num in nums)
            {
                if (num < 10)
                    oneDigit += num;
                else
                    twoDigit += num;
            }

            return oneDigit != twoDigit;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-count-of-numbers-which-are-not-special/">3233. Find the Count of Numbers Which Are Not Special (medium)</a>
        /// Count values in [l, r] that are not squares of primes.
        /// </summary>
        /// <param name="l">The inclusive lower bound.</param>
        /// <param name="r">The inclusive upper bound.</param>
        /// <returns>The count of non-special numbers.</returns>
        public int NonSpecialCount(int l, int r)
        {
            int limit = (int)Math.Sqrt(r);
            bool[] composite = new bool[limit + 1];
            int special = 0;
            for (int value = 2; value <= limit; value++)
            {
                if (composite[value])
                    continue;

                long square = (long)value * value;
                if (square >= l && square <= r)
                    special++;

                for (long multiple = (long)value * value; multiple <= limit; multiple += value)
                    composite[multiple] = true;
            }

            return r - l + 1 - special;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/the-two-sneaky-numbers-of-digitville/">3289. The Two Sneaky Numbers of Digitville (easy)</a>
        /// Find the two numbers that appear twice among values that otherwise appear once.
        /// </summary>
        /// <param name="nums">The digitville numbers.</param>
        /// <returns>The two repeated numbers.</returns>
        public int[] GetSneakyNumbers(int[] nums)
        {
            bool[] seen = new bool[nums.Length];
            int[] result = new int[2];
            int index = 0;
            foreach (int num in nums)
            {
                if (seen[num])
                    result[index++] = num;
                else
                    seen[num] = true;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-element-after-replacement-with-digit-sum/">3300. Minimum Element After Replacement With Digit Sum (easy)</a>
        /// Replace each number by its digit sum and return the minimum replacement value.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <returns>The minimum digit sum.</returns>
        public int MinElement(int[] nums)
        {
            int result = int.MaxValue;
            foreach (int num in nums)
                result = Math.Min(result, DigitSum(num));

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-k-th-character-in-string-game-i/">3304. Find the K-th Character in String Game I (easy)</a>
        /// Compute the kth generated character from the number of increment operations affecting position k - 1.
        /// </summary>
        /// <param name="k">The one-based position.</param>
        /// <returns>The kth character.</returns>
        public char KthCharacter(int k)
        {
            return (char)('a' + CountSetBits(k - 1));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-possible-number-by-binary-concatenation/">3309. Maximum Possible Number by Binary Concatenation (medium)</a>
        /// Order binary representations to maximize their concatenated binary value.
        /// </summary>
        /// <param name="nums">Three positive integers.</param>
        /// <returns>The maximum decimal value after binary concatenation.</returns>
        public int MaxGoodNumber(int[] nums)
        {
            string[] binaries = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                binaries[i] = Convert.ToString(nums[i], 2);

            Array.Sort(binaries, (left, right) => string.CompareOrdinal(right + left, left + right));
            int result = 0;
            foreach (string binary in binaries)
            {
                foreach (char bit in binary)
                    result = result * 2 + bit - '0';
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-the-minimum-bitwise-array-i/">3314. Construct the Minimum Bitwise Array I (easy)</a>
        /// For each prime value, find the minimum x such that x OR (x + 1) equals that value.
        /// </summary>
        /// <param name="nums">The prime values.</param>
        /// <returns>The minimum bitwise array, using -1 when no value exists.</returns>
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int[] result = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
                result[i] = MinimumBitwiseSource(nums[i]);

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-divisible-digit-product-i/">3345. Smallest Divisible Digit Product I (easy)</a>
        /// Find the smallest integer at least n whose digit product is divisible by t.
        /// </summary>
        /// <param name="n">The lower bound.</param>
        /// <param name="t">The divisor.</param>
        /// <returns>The smallest qualifying number.</returns>
        public int SmallestNumber(int n, int t)
        {
            while (DigitProduct(n) % t != 0)
                n++;

            return n;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-number-with-all-set-bits/">3370. Smallest Number With All Set Bits (easy)</a>
        /// Return the smallest number not less than n whose binary representation consists only of set bits.
        /// </summary>
        /// <param name="n">The lower bound.</param>
        /// <returns>The smallest all-set-bits number.</returns>
        public int SmallestNumberWithAllSetBits(int n)
        {
            int value = 1;
            while (value < n)
                value = (value << 1) | 1;

            return value;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-make-array-sum-divisible-by-k/">3512. Minimum Operations to Make Array Sum Divisible by K (easy)</a>
        /// Remove the smallest possible total remainder from the array sum to make it divisible by k.
        /// </summary>
        /// <param name="nums">The positive integers.</param>
        /// <param name="k">The divisor.</param>
        /// <returns>The minimum number of decrement operations.</returns>
        public int MinOperationsDivisibleByK(int[] nums, int k)
        {
            int sum = 0;
            foreach (int num in nums)
                sum += num;

            return sum % k;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-closest-person/">3516. Find Closest Person (easy)</a>
        /// Compare two distances to the third person and identify the closer person.
        /// </summary>
        /// <param name="x">The first person's position.</param>
        /// <param name="y">The second person's position.</param>
        /// <param name="z">The third person's position.</param>
        /// <returns>1 if person one is closer, 2 if person two is closer, or 0 for a tie.</returns>
        public int FindClosest(int x, int y, int z)
        {
            int first = Math.Abs(x - z);
            int second = Math.Abs(y - z);
            if (first == second)
                return 0;

            return first < second ? 1 : 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-product-of-two-digits/">3536. Maximum Product of Two Digits (easy)</a>
        /// Find the maximum product of any two decimal digits in n.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The maximum two-digit product.</returns>
        public int MaxProduct(int n)
        {
            int first = 0;
            int second = 0;
            while (n > 0)
            {
                int digit = n % 10;
                if (digit >= first)
                {
                    second = first;
                    first = digit;
                }
                else if (digit > second)
                {
                    second = digit;
                }

                n /= 10;
            }

            return first * second;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/hexadecimal-and-hexatrigesimal-conversion/">3602. Hexadecimal and Hexatrigesimal Conversion (easy)</a>
        /// Concatenate n squared in hexadecimal with n cubed in base 36.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The uppercase concatenated representation.</returns>
        public string ConcatHex36(int n)
        {
            return Convert.ToString(n * n, 16).ToUpperInvariant() + ToBase36(n * n * n);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-no-zero-pairs-that-sum-to-n/">3704. Count No-Zero Pairs That Sum to N (hard)</a>
        /// Count ordered pairs of positive integers without zero digits whose sum equals n.
        /// </summary>
        /// <param name="n">The target sum.</param>
        /// <returns>The number of valid ordered pairs.</returns>
        public long CountNoZeroPairs(long n)
        {
            var digits = new List<int>();
            while (n > 0)
            {
                digits.Add((int)(n % 10));
                n /= 10;
            }

            long[,,] current = new long[2, 2, 2];
            current[0, 0, 0] = 1;

            for (int pos = 0; pos < digits.Count; pos++)
            {
                long[,,] next = new long[2, 2, 2];
                int targetDigit = digits[pos];

                for (int carry = 0; carry <= 1; carry++)
                {
                    for (int endedA = 0; endedA <= 1; endedA++)
                    {
                        for (int endedB = 0; endedB <= 1; endedB++)
                        {
                            long ways = current[carry, endedA, endedB];
                            if (ways == 0)
                                continue;

                            for (int digitA = 0; digitA <= 9; digitA++)
                            {
                                if (endedA == 1 && digitA != 0)
                                    continue;
                                if (endedA == 0 && digitA == 0 && pos == 0)
                                    continue;

                                int nextEndedA = endedA == 1 || digitA == 0 ? 1 : 0;

                                for (int digitB = 0; digitB <= 9; digitB++)
                                {
                                    if (endedB == 1 && digitB != 0)
                                        continue;
                                    if (endedB == 0 && digitB == 0 && pos == 0)
                                        continue;

                                    int nextEndedB = endedB == 1 || digitB == 0 ? 1 : 0;
                                    int total = digitA + digitB + carry;
                                    if (total % 10 != targetDigit)
                                        continue;

                                    next[total / 10, nextEndedA, nextEndedB] += ways;
                                }
                            }
                        }
                    }
                }

                current = next;
            }

            long result = 0;
            for (int endedA = 0; endedA <= 1; endedA++)
            {
                for (int endedB = 0; endedB <= 1; endedB++)
                    result += current[0, endedA, endedB];
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-sum-of-squares-of-digits/">3723. Maximize Sum of Squares of Digits (medium)</a>
        /// Construct the largest num-digit integer whose digit sum is sum and whose squared-digit score is maximized.
        /// </summary>
        /// <param name="num">The required number of digits.</param>
        /// <param name="sum">The required digit sum.</param>
        /// <returns>The best integer as a string, or an empty string if impossible.</returns>
        public string MaxSumOfSquares(int num, int sum)
        {
            if (num <= 0 || sum <= 0 || sum > 9 * num)
                return string.Empty;

            var result = new StringBuilder(num);
            for (int i = 0; i < num; i++)
            {
                int digit = Math.Min(9, sum);
                result.Append((char)('0' + digit));
                sum -= digit;
            }

            return sum == 0 ? result.ToString() : string.Empty;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-zeros-in-decimal-representation/">3726. Remove Zeros in Decimal Representation (easy)</a>
        /// Remove every zero digit from the decimal representation of n.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The value formed by the remaining digits.</returns>
        public long RemoveZeros(long n)
        {
            long result = 0;
            long place = 1;
            while (n > 0)
            {
                long digit = n % 10;
                if (digit != 0)
                {
                    result += digit * place;
                    place *= 10;
                }

                n /= 10;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-distinct-integers-after-removing-zeros/">3747. Count Distinct Integers After Removing Zeros (medium)</a>
        /// Count distinct positive integers not exceeding n whose decimal digits are all non-zero.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The number of distinct integers obtainable after zero removal.</returns>
        public long CountDistinct(long n)
        {
            if (n <= 0)
                return 0;

            string digits = n.ToString();
            long result = 0;
            for (int length = 1; length < digits.Length; length++)
                result += PowLong(9, length);

            for (int i = 0; i < digits.Length; i++)
            {
                int digit = digits[i] - '0';
                if (digit == 0)
                    return result;

                result += (digit - 1) * PowLong(9, digits.Length - i - 1);
            }

            return result + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-flips-to-reverse-binary-string/">3750. Minimum Number of Flips to Reverse Binary String (easy)</a>
        /// Count how many bit positions differ between n's binary representation and its reverse.
        /// </summary>
        /// <param name="n">The positive integer.</param>
        /// <returns>The minimum number of flips required.</returns>
        public int MinimumFlips(int n)
        {
            string bits = Convert.ToString(n, 2);
            int flips = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] != bits[bits.Length - 1 - i])
                    flips++;
            }

            return flips;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-waviness-of-numbers-in-range-i/">3751. Total Waviness of Numbers in Range I (medium)</a>
        /// Sum the peak-and-valley counts for every integer in the inclusive range.
        /// </summary>
        /// <param name="num1">The inclusive lower bound.</param>
        /// <param name="num2">The inclusive upper bound.</param>
        /// <returns>The total waviness of the range.</returns>
        public int TotalWaviness(int num1, int num2)
        {
            long result = 0;
            for (int value = num1; value <= num2; value++)
                result += GetWaviness(value);

            return (int)result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-waviness-of-numbers-in-range-ii/">3753. Total Waviness of Numbers in Range II (hard)</a>
        /// Sum the peak-and-valley counts for every integer in the inclusive range.
        /// </summary>
        /// <param name="num1">The inclusive lower bound.</param>
        /// <param name="num2">The inclusive upper bound.</param>
        /// <returns>The total waviness of the range.</returns>
        public long TotalWaviness(long num1, long num2)
        {
            return CountWavinessUpTo(num2) - CountWavinessUpTo(num1 - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/">3754. Concatenate Non-Zero Digits and Multiply by Sum I (easy)</a>
        /// Concatenate the non-zero digits of n and multiply the resulting value by its digit sum.
        /// </summary>
        /// <param name="n">The input integer.</param>
        /// <returns>The product of the compressed number and its digit sum.</returns>
        public long SumAndMultiply(int n)
        {
            long value = 0;
            int sum = 0;
            foreach (char digit in n.ToString())
            {
                if (digit == '0')
                    continue;

                value = value * 10 + digit - '0';
                sum += digit - '0';
            }

            return value * sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/complete-prime-number/">3765. Complete Prime Number (medium)</a>
        /// Determine whether every decimal prefix and suffix of num is prime.
        /// </summary>
        /// <param name="num">The candidate number.</param>
        /// <returns><see langword="true"/> if num is a complete prime number; otherwise, <see langword="false"/>.</returns>
        public bool CompletePrime(int num)
        {
            string digits = num.ToString();
            for (int length = 1; length <= digits.Length; length++)
            {
                if (!IsPrime(int.Parse(digits.Substring(0, length))) ||
                    !IsPrime(int.Parse(digits.Substring(digits.Length - length, length))))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/last-remaining-integer-after-alternating-deletion-operations/">3782. Last Remaining Integer After Alternating Deletion Operations (hard)</a>
        /// Simulate alternating deletions on the implicit arithmetic progression.
        /// </summary>
        /// <param name="n">The number of integers from 1 through n.</param>
        /// <returns>The final remaining integer.</returns>
        public long LastInteger(long n)
        {
            long head = 1;
            long step = 1;
            long remaining = n;
            bool deleteFromLeft = true;

            while (remaining > 1)
            {
                if (!deleteFromLeft && (remaining & 1) == 0)
                    head += step;

                step <<= 1;
                remaining = (remaining + 1) >> 1;
                deleteFromLeft = !deleteFromLeft;
            }

            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/mirror-distance-of-an-integer/">3783. Mirror Distance of an Integer (easy)</a>
        /// Return the absolute difference between n and its digit reversal.
        /// </summary>
        /// <param name="n">The integer to evaluate.</param>
        /// <returns>The mirror distance of n.</returns>
        public int MirrorDistance(int n)
        {
            return Math.Abs(n - ReverseDecimal(n));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-acquire-required-items/">3789. Minimum Cost to Acquire Required Items (medium)</a>
        /// Minimize the cost of satisfying both requirements using single-type or dual-type items.
        /// </summary>
        /// <param name="cost1">The cost of a type 1 item.</param>
        /// <param name="cost2">The cost of a type 2 item.</param>
        /// <param name="costBoth">The cost of a type 3 item that contributes to both requirements.</param>
        /// <param name="need1">The required type 1 units.</param>
        /// <param name="need2">The required type 2 units.</param>
        /// <returns>The minimum total cost.</returns>
        public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2)
        {
            int overlap = Math.Min(need1, need2);
            int remainder = Math.Abs(need1 - need2);
            long result = (long)overlap * Math.Min(costBoth, cost1 + cost2);

            if (need1 > need2)
                result += (long)remainder * Math.Min(cost1, costBoth);
            else
                result += (long)remainder * Math.Min(cost2, costBoth);

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-all-ones-multiple/">3790. Smallest All-Ones Multiple (medium)</a>
        /// Find the length of the smallest repunit divisible by k.
        /// </summary>
        /// <param name="k">The divisor.</param>
        /// <returns>The repunit length, or -1 when impossible.</returns>
        public int MinAllOneMultiple(int k)
        {
            if (k % 2 == 0 || k % 5 == 0)
                return -1;

            int remainder = 0;
            bool[] seen = new bool[k];
            for (int length = 1; length <= k; length++)
            {
                remainder = (remainder * 10 + 1) % k;
                if (remainder == 0)
                    return length;
                if (seen[remainder])
                    break;
                seen[remainder] = true;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-nth-smallest-integer-with-k-one-bits/">3821. Find Nth Smallest Integer With K One Bits (medium)</a>
        /// Return the nth smallest positive integer whose binary representation contains exactly k one bits.
        /// </summary>
        /// <param name="n">The one-based rank.</param>
        /// <param name="k">The required population count.</param>
        /// <returns>The nth qualifying integer.</returns>
        public long NthSmallest(long n, int k)
        {
            long[,] combinations = new long[51, 51];
            for (int i = 0; i <= 50; i++)
            {
                combinations[i, 0] = 1;
                combinations[i, i] = 1;
                for (int j = 1; j < i; j++)
                    combinations[i, j] = combinations[i - 1, j - 1] + combinations[i - 1, j];
            }

            long CountUpTo(long value)
            {
                long count = 0;
                int remaining = k;
                for (int bit = 49; bit >= 0; bit--)
                {
                    if (((value >> bit) & 1L) == 0)
                        continue;

                    if (remaining <= bit)
                        count += combinations[bit, remaining];

                    remaining--;
                    if (remaining < 0)
                        return count;
                }

                if (remaining == 0)
                    count++;

                return count;
            }

            long left = 1;
            long right = (1L << 50) - 1;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (CountUpTo(mid) >= n)
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-monobit-integers/">3827. Count Monobit Integers (easy)</a>
        /// Count integers in [0, n] whose binary digits are all identical.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The number of monobit integers.</returns>
        public int CountMonobit(int n)
        {
            int count = 1;
            long value = 1;
            while (value <= n)
            {
                count++;
                value = (value << 1) | 1;
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-digitorial-permutation/">3848. Check Digitorial Permutation (medium)</a>
        /// Determine whether some permutation of n equals the sum of the factorials of its digits.
        /// </summary>
        /// <param name="n">The input integer.</param>
        /// <returns><see langword="true"/> if a digitorial permutation exists; otherwise, <see langword="false"/>.</returns>
        public bool IsDigitorialPermutation(int n)
        {
            int[] factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            int value = n;
            int sum = 0;
            while (value > 0)
            {
                sum += factorials[value % 10];
                value /= 10;
            }

            return HaveSameDigitMultiset(n, sum);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-k-digit-numbers-in-a-range/">3855. Sum of K-Digit Numbers in a Range (medium)</a>
        /// Sum all length-k numbers whose digits are independently chosen from l through r.
        /// </summary>
        /// <param name="l">The minimum allowed digit.</param>
        /// <param name="r">The maximum allowed digit.</param>
        /// <param name="k">The number of digits.</param>
        /// <returns>The total sum modulo 10^9 + 7.</returns>
        public int SumOfNumbers(int l, int r, int k)
        {
            long digitCount = r - l + 1L;
            long digitSum = (long)(l + r) * digitCount / 2 % Modulo;
            long occurrences = ModPow(digitCount, k - 1, Modulo);
            long repunit = (ModPow(10, k, Modulo) - 1 + Modulo) % Modulo;
            repunit = repunit * ModPow(9, Modulo - 2, Modulo) % Modulo;
            return (int)(digitSum * occurrences % Modulo * repunit % Modulo);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-split-into-ones/">3857. Minimum Cost to Split into Ones (medium)</a>
        /// Return the minimum total split cost required to break n into n ones.
        /// </summary>
        /// <param name="n">The starting integer.</param>
        /// <returns>The minimum total cost.</returns>
        public int MinCost(int n)
        {
            return n * (n - 1) / 2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-fancy-numbers-in-a-range/">3869. Count Fancy Numbers in a Range (medium)</a>
        /// Count integers in the range that are strictly monotone in digits or whose digit sum is strictly monotone.
        /// </summary>
        /// <param name="l">The inclusive lower bound.</param>
        /// <param name="r">The inclusive upper bound.</param>
        /// <returns>The number of fancy integers.</returns>
        public long CountFancy(long l, long r)
        {
            var goodNumbers = new HashSet<long>();
            for (int mask = 1; mask < (1 << 9); mask++)
            {
                long value = 0;
                for (int digit = 1; digit <= 9; digit++)
                {
                    if ((mask & (1 << (digit - 1))) != 0)
                        value = value * 10 + digit;
                }

                goodNumbers.Add(value);
            }

            for (int mask = 1; mask < (1 << 10); mask++)
            {
                long value = 0;
                for (int digit = 9; digit >= 0; digit--)
                {
                    if ((mask & (1 << digit)) != 0)
                        value = value * 10 + digit;
                }

                if (value > 0)
                    goodNumbers.Add(value);
            }

            bool[] goodSums = new bool[145];
            for (int sum = 1; sum < goodSums.Length; sum++)
                goodSums[sum] = IsStrictMonotoneDigits(sum);

            long CountWithGoodDigitSum(long bound)
            {
                if (bound <= 0)
                    return 0;

                string digits = bound.ToString();
                long?[,] memo = new long?[digits.Length + 1, 145];

                long Dfs(int index, int sum, bool tight)
                {
                    if (index == digits.Length)
                        return goodSums[sum] ? 1L : 0L;
                    if (!tight && memo[index, sum].HasValue)
                        return memo[index, sum].Value;

                    int limit = tight ? digits[index] - '0' : 9;
                    long total = 0;
                    for (int digit = 0; digit <= limit; digit++)
                        total += Dfs(index + 1, sum + digit, tight && digit == limit);

                    if (!tight)
                        memo[index, sum] = total;

                    return total;
                }

                return Dfs(0, 0, true);
            }

            long CountUpTo(long bound)
            {
                if (bound <= 0)
                    return 0;

                long result = CountWithGoodDigitSum(bound);
                foreach (long value in goodNumbers)
                {
                    if (value <= bound && !goodSums[DigitSumLong(value)])
                        result++;
                }

                return result;
            }

            return CountUpTo(r) - CountUpTo(l - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-commas-in-range/">3870. Count Commas in Range (easy)</a>
        /// Count the commas needed to write every integer from 1 through n.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The total number of commas.</returns>
        public int CountCommas(int n)
        {
            return (int)CountCommas((long)n);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-commas-in-range-ii/">3871. Count Commas in Range II (medium)</a>
        /// Count the commas needed to write every integer from 1 through n.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The total number of commas.</returns>
        public long CountCommas(long n)
        {
            long result = 0;
            for (long threshold = 1_000; threshold <= n; threshold *= 1_000)
                result += n - threshold + 1;

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/direction-assignments-with-exactly-k-visible-people/">3881. Direction Assignments with Exactly K Visible People (medium)</a>
        /// Count direction assignments so that the person at pos sees exactly k people.
        /// </summary>
        /// <param name="n">The number of people in the line.</param>
        /// <param name="pos">The observed person's index.</param>
        /// <param name="k">The required visible count.</param>
        /// <returns>The number of valid assignments modulo 10^9 + 7.</returns>
        public int CountVisiblePeople(int n, int pos, int k)
        {
            return (int)(2L * CombinationModuloPrime(n - 1, k) % Modulo);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/integers-with-multiple-sum-of-two-cubes/">3890. Integers With Multiple Sum of Two Cubes (medium)</a>
        /// Find all integers not exceeding n that can be expressed as a sum of two cubes in at least two distinct ways.
        /// </summary>
        /// <param name="n">The inclusive upper bound.</param>
        /// <returns>The qualifying integers in ascending order.</returns>
        public IList<int> FindGoodIntegers(int n)
        {
            int limit = 1;
            while ((long)(limit + 1) * (limit + 1) * (limit + 1) <= n)
                limit++;

            var counts = new Dictionary<int, int>();
            for (int a = 1; a <= limit; a++)
            {
                long cubeA = (long)a * a * a;
                for (int b = a; b <= limit; b++)
                {
                    long sum = cubeA + (long)b * b * b;
                    if (sum > n)
                        break;

                    int key = (int)sum;
                    counts.TryGetValue(key, out int current);
                    counts[key] = current + 1;
                }
            }

            var result = new List<int>();
            foreach (var pair in counts)
            {
                if (pair.Value >= 2)
                    result.Add(pair.Key);
            }

            result.Sort();
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/traffic-signal-color/">3894. Traffic Signal Color (easy)</a>
        /// Return the traffic signal color associated with the remaining timer value.
        /// </summary>
        /// <param name="timer">The remaining time in seconds.</param>
        /// <returns>The signal color, or Invalid when no rule applies.</returns>
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
        /// <a href="https://leetcode.com/problems/valid-digit-number/">3908. Valid Digit Number (easy)</a>
        /// Determine whether n contains x and does not start with x.
        /// </summary>
        /// <param name="n">The number to inspect.</param>
        /// <param name="x">The required digit.</param>
        /// <returns><see langword="true"/> if n is valid; otherwise, <see langword="false"/>.</returns>
        public bool ValidDigit(int n, int x)
        {
            if (n == 0)
                return false;

            int firstDigit = n;
            while (firstDigit >= 10)
                firstDigit /= 10;

            if (firstDigit == x)
                return false;

            int value = n;
            while (value > 0)
            {
                if (value % 10 == x)
                    return true;
                value /= 10;
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-primes-between-number-and-its-reverse/">3918. Sum of Primes Between Number and Its Reverse (easy)</a>
        /// Sum every prime in the inclusive range between n and its digit reversal.
        /// </summary>
        /// <param name="n">The reference integer.</param>
        /// <returns>The sum of all primes in the induced range.</returns>
        public int SumOfPrimesInRange(int n)
        {
            int reversed = ReverseDecimal(n);
            int left = Math.Min(n, reversed);
            int right = Math.Max(n, reversed);
            int sum = 0;
            for (int value = left; value <= right; value++)
            {
                if (IsPrime(value))
                    sum += value;
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-k-th-roots-in-a-range/">3932. Count K-th Roots in a Range (medium)</a>
        /// Count perfect k-th powers in the inclusive range.
        /// </summary>
        /// <param name="l">The inclusive lower bound.</param>
        /// <param name="r">The inclusive upper bound.</param>
        /// <param name="k">The power.</param>
        /// <returns>The number of perfect k-th powers in the range.</returns>
        public int CountKthRoots(int l, int r, int k)
        {
            long lower = l == 0 ? -1 : FloorKthRoot(l - 1L, k);
            return (int)(FloorKthRoot(r, k) - lower);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/digit-frequency-score/">3945. Digit Frequency Score (easy)</a>
        /// Return the digit-frequency score of n, which equals the sum of its digits.
        /// </summary>
        /// <param name="n">The input integer.</param>
        /// <returns>The digit-frequency score.</returns>
        public int DigitFrequencyScore(int n)
        {
            return DigitSum(n);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/exactly-one-consecutive-set-bits-pair/">3950. Exactly One Consecutive Set Bits Pair (easy)</a>
        /// Determine whether n contains exactly one adjacent pair of set bits in binary.
        /// </summary>
        /// <param name="n">The integer to inspect.</param>
        /// <returns><see langword="true"/> if exactly one adjacent set-bit pair exists; otherwise, <see langword="false"/>.</returns>
        public bool ConsecutiveSetBits(int n)
        {
            int pairs = n & (n >> 1);
            return pairs != 0 && (pairs & (pairs - 1)) == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-compatible-numbers-in-range-i/">3954. Sum of Compatible Numbers in Range I (medium)</a>
        /// Sum positive integers within distance k of n that share no common set bit with n.
        /// </summary>
        /// <param name="n">The reference integer.</param>
        /// <param name="k">The allowed distance.</param>
        /// <returns>The sum of compatible integers.</returns>
        public int SumOfGoodIntegers(int n, int k)
        {
            int result = 0;
            for (int value = Math.Max(1, n - k); value <= n + k; value++)
            {
                if ((n & value) == 0)
                    result += value;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-good-integer/">3959. Check Good Integer (easy)</a>
        /// Determine whether the squared-digit sum exceeds the digit sum by at least 50.
        /// </summary>
        /// <param name="n">The input integer.</param>
        /// <returns><see langword="true"/> if n is good; otherwise, <see langword="false"/>.</returns>
        public bool CheckGoodInteger(int n)
        {
            int digitSum = 0;
            int squareSum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                digitSum += digit;
                squareSum += digit * digit;
                n /= 10;
            }

            return squareSum - digitSum >= 50;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-good-integers-in-a-range/">3966. Count Good Integers in a Range (medium)</a>
        /// Count numbers whose adjacent digits differ by at most k.
        /// </summary>
        /// <param name="l">The inclusive lower bound.</param>
        /// <param name="r">The inclusive upper bound.</param>
        /// <param name="k">The maximum allowed adjacent difference.</param>
        /// <returns>The number of good integers in the range.</returns>
        public long GoodIntegers(long l, long r, int k)
        {
            long CountUpTo(long bound)
            {
                if (bound <= 0)
                    return 0;

                string digits = bound.ToString();
                long?[,,,] memo = new long?[digits.Length + 1, 11, 2, 2];

                long Dfs(int index, int previous, int started, bool tight)
                {
                    if (index == digits.Length)
                        return started == 1 ? 1L : 0L;
                    if (!tight && memo[index, previous, started, 0].HasValue)
                        return memo[index, previous, started, 0].Value;

                    int limit = tight ? digits[index] - '0' : 9;
                    long total = 0;
                    for (int digit = 0; digit <= limit; digit++)
                    {
                        if (started == 0)
                        {
                            if (digit == 0)
                                total += Dfs(index + 1, 10, 0, tight && digit == limit);
                            else
                                total += Dfs(index + 1, digit, 1, tight && digit == limit);
                        }
                        else if (Math.Abs(previous - digit) <= k)
                        {
                            total += Dfs(index + 1, digit, 1, tight && digit == limit);
                        }
                    }

                    if (!tight)
                        memo[index, previous, started, 0] = total;

                    return total;
                }

                return Dfs(0, 10, 0, true);
            }

            return CountUpTo(r) - CountUpTo(l - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-elapsed-seconds-between-two-times/">3986. Number of Elapsed Seconds Between Two Times (easy)</a>
        /// Compute the elapsed seconds between two HH:MM:SS timestamps.
        /// </summary>
        /// <param name="startTime">The earlier time.</param>
        /// <param name="endTime">The later time.</param>
        /// <returns>The elapsed seconds.</returns>
        public int SecondsBetweenTimes(string startTime, string endTime)
        {
            return ParseTimeInSeconds(endTime) - ParseTimeInSeconds(startTime);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-value-of-an-alternating-sequence/">3993. Maximum Value of an Alternating Sequence (medium)</a>
        /// Return the largest element achievable in any valid alternating sequence.
        /// </summary>
        /// <param name="n">The sequence length.</param>
        /// <param name="s">The starting value.</param>
        /// <param name="m">The maximum adjacent absolute difference.</param>
        /// <returns>The maximum possible element.</returns>
        public long MaximumValue(int n, int s, int m)
        {
            if (n == 1)
                return s;

            long startUp = s + m + (long)((n - 2) / 2) * (m - 1);
            long startDown = s + (long)((n - 1) / 2) * (m - 1);
            return Math.Max(startUp, startDown);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-integer-with-given-digit-sum/">4000. Largest Integer With Given Digit Sum (easy)</a>
        /// Construct the largest integer with at most n digits whose digit sum is s.
        /// </summary>
        /// <param name="n">The maximum number of digits.</param>
        /// <param name="s">The target digit sum.</param>
        /// <returns>The largest qualifying integer, or -1 when impossible.</returns>
        public int LargestInteger(int n, int s)
        {
            if (s == 0)
                return 0;
            if (s > 9 * n)
                return -1;

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                int digit = Math.Min(9, s);
                result = result * 10 + digit;
                s -= digit;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-valid-sequences/">4002. Count Valid Sequences (medium)</a>
        /// Count positive length-k compositions of n whose product is even.
        /// </summary>
        /// <param name="n">The required sum.</param>
        /// <param name="k">The sequence length.</param>
        /// <returns>The number of valid sequences modulo 10^9 + 7.</returns>
        public int CountValidSequences(int n, int k)
        {
            long total = CombinationModuloPrime(n - 1, k - 1);
            long oddOnly = 0;
            if (((n - k) & 1) == 0)
                oddOnly = CombinationModuloPrime((n + k) / 2 - 1, k - 1);

            return (int)((total - oddOnly + Modulo) % Modulo);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/k-th-digit-in-infinite-string/">4022. K-th Digit in Infinite String (medium)</a>
        /// Return the kth digit of the infinite block-wise concatenated integer string.
        /// </summary>
        /// <param name="k">The one-based digit index.</param>
        /// <returns>The digit at position k.</returns>
        public int KthDigit(long k)
        {
            if (k <= 9)
                return (int)k;

            k -= 9;
            int digitsPerNumber = 2;
            long firstNumber = 10;
            while (true)
            {
                long groupDigits = 9L * firstNumber * digitsPerNumber;
                if (k <= groupDigits)
                    break;

                k -= groupDigits;
                digitsPerNumber++;
                firstNumber *= 10;
            }

            long zeroBased = k - 1;
            long blockIndex = zeroBased / (10L * digitsPerNumber);
            long indexWithinBlock = zeroBased % (10L * digitsPerNumber);
            long blockNumber = firstNumber / 10 + blockIndex;
            long blockStart = blockNumber * 10;
            long numberIndex = indexWithinBlock / digitsPerNumber;
            int digitIndex = (int)(indexWithinBlock % digitsPerNumber);
            long value = (blockNumber & 1) == 0 ? blockStart + numberIndex : blockStart + 9 - numberIndex;
            return value.ToString()[digitIndex] - '0';
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-days-to-score-exactly-n-points/">4050. Minimum Days to Score Exactly N Points (medium)</a>
        /// Minimize total days needed to reach score n using streaks separated by skipped days.
        /// </summary>
        /// <param name="n">The target score.</param>
        /// <returns>The minimum number of days.</returns>
        public int MinDays(int n)
        {
            var scores = new List<(int points, int days)>();
            for (int length = 1, total = 1; total <= n; length++, total += length)
                scores.Add((total, length + 1));

            int[] dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue / 4);
            dp[0] = 0;

            for (int score = 1; score <= n; score++)
            {
                foreach (var option in scores)
                {
                    if (option.points > score)
                        break;

                    dp[score] = Math.Min(dp[score], dp[score - option.points] + option.days);
                }
            }

            return dp[n] - 1;
        }

        private static long ModPow(long value, long exponent, int mod)
        {
            long result = 1;
            value %= mod;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = result * value % mod;

                value = value * value % mod;
                exponent >>= 1;
            }

            return result;
        }

        private static int ReverseDecimal(int value)
        {
            int reversed = 0;
            while (value > 0)
            {
                reversed = reversed * 10 + value % 10;
                value /= 10;
            }

            return reversed;
        }

        private static int CountMaxOrSubsets(int[] nums, int index, int current, int target)
        {
            if (index == nums.Length)
                return current == target ? 1 : 0;

            return CountMaxOrSubsets(nums, index + 1, current | nums[index], target) +
                   CountMaxOrSubsets(nums, index + 1, current, target);
        }

        private static bool IsNumericallyBalanced(int value)
        {
            int[] counts = new int[10];
            while (value > 0)
            {
                counts[value % 10]++;
                value /= 10;
            }

            for (int digit = 0; digit < counts.Length; digit++)
            {
                if (counts[digit] != 0 && counts[digit] != digit)
                    return false;
            }

            return true;
        }

        private static int CountSetBits(int value)
        {
            int count = 0;
            while (value != 0)
            {
                value &= value - 1;
                count++;
            }

            return count;
        }

        private static long Combination2(long value)
        {
            return value < 2 ? 0 : value * (value - 1) / 2;
        }

        private static bool Between(int endpointA, int blocker, int endpointB)
        {
            return Math.Min(endpointA, endpointB) < blocker && blocker < Math.Max(endpointA, endpointB);
        }

        private static int MaxHeightStartingWith(int firstColor, int secondColor)
        {
            int height = 0;
            for (int row = 1; ; row++)
            {
                if ((row & 1) == 1)
                {
                    if (firstColor < row)
                        return height;

                    firstColor -= row;
                }
                else
                {
                    if (secondColor < row)
                        return height;

                    secondColor -= row;
                }

                height++;
            }
        }

        private static int MinimumBitwiseSource(int value)
        {
            if ((value & 1) == 0)
                return -1;

            int trailingOnes = 0;
            int current = value;
            while ((current & 1) == 1)
            {
                trailingOnes++;
                current >>= 1;
            }

            return value ^ (1 << (trailingOnes - 1));
        }

        private static int DigitProduct(int value)
        {
            int product = 1;
            while (value > 0)
            {
                product *= value % 10;
                value /= 10;
            }

            return product;
        }

        private static string ToBase36(int value)
        {
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = new StringBuilder();
            while (value > 0)
            {
                result.Insert(0, digits[value % 36]);
                value /= 36;
            }

            return result.ToString();
        }

        private static int LowerBound(int[] values, int target)
        {
            int left = 0;
            int right = values.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }

        private static bool CanPartitionSquare(string digits, int index, int remaining)
        {
            if (index == digits.Length)
                return remaining == 0;

            int value = 0;
            for (int i = index; i < digits.Length; i++)
            {
                value = value * 10 + digits[i] - '0';
                if (value > remaining)
                    break;
                if (CanPartitionSquare(digits, i + 1, remaining - value))
                    return true;
            }

            return false;
        }

        private static int ModPow(int value, int exponent, int mod)
        {
            long result = 1;
            long current = value % mod;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = result * current % mod;

                current = current * current % mod;
                exponent >>= 1;
            }

            return (int)result;
        }

        private static bool IsSmallPrime(int value)
        {
            return value == 2 || value == 3 || value == 5 || value == 7 || value == 11 ||
                   value == 13 || value == 17 || value == 19 || value == 23 || value == 29 || value == 31;
        }

        private static long FirstWithAtLeastZeroes(long zeroes)
        {
            long left = 0;
            long right = 5 * (zeroes + 1);
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (CountFactorialZeroes(mid) >= zeroes)
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        private static long CountFactorialZeroes(long value)
        {
            long count = 0;
            while (value > 0)
            {
                value /= 5;
                count += value;
            }

            return count;
        }

        private static string DigitSignature(int value)
        {
            int[] counts = new int[10];
            while (value > 0)
            {
                counts[value % 10]++;
                value /= 10;
            }

            return string.Join(",", counts);
        }

        private static bool IsPrime(int value)
        {
            for (int divisor = 2; divisor * divisor <= value; divisor++)
            {
                if (value % divisor == 0)
                    return false;
            }

            return value >= 2;
        }

        private static bool IsLeapYear(int year)
        {
            return year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }

        private static bool HasZeroDigit(int value)
        {
            while (value > 0)
            {
                if (value % 10 == 0)
                    return true;

                value /= 10;
            }

            return false;
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

        private static long PowLong(long value, int exponent)
        {
            long result = 1;
            while (exponent-- > 0)
                result *= value;

            return result;
        }

        private static int GetWaviness(long value)
        {
            string digits = value.ToString();
            int waviness = 0;
            for (int i = 1; i + 1 < digits.Length; i++)
            {
                if ((digits[i] > digits[i - 1] && digits[i] > digits[i + 1]) ||
                    (digits[i] < digits[i - 1] && digits[i] < digits[i + 1]))
                    waviness++;
            }

            return waviness;
        }

        private static long CountWavinessUpTo(long bound)
        {
            if (bound <= 0)
                return 0;

            string digits = bound.ToString();
            var memo = new Dictionary<long, (long count, long total)>();

            (long count, long total) Dfs(int index, int placed, int previousTwo, int previousOne, bool started, bool tight)
            {
                if (index == digits.Length)
                    return (1, 0);

                if (!tight)
                {
                    long key = (((((index * 3L + placed) * 11 + previousTwo) * 11 + previousOne) * 2 +
                                 (started ? 1 : 0)));
                    if (memo.TryGetValue(key, out (long count, long total) cached))
                        return cached;

                    (long count, long total) result = Explore();
                    memo[key] = result;
                    return result;
                }

                return Explore();

                (long count, long total) Explore()
                {
                    int limit = tight ? digits[index] - '0' : 9;
                    long count = 0;
                    long total = 0;
                    for (int digit = 0; digit <= limit; digit++)
                    {
                        bool nextTight = tight && digit == limit;
                        if (!started && digit == 0)
                        {
                            var child = Dfs(index + 1, 0, 10, 10, false, nextTight);
                            count += child.count;
                            total += child.total;
                            continue;
                        }

                        if (!started)
                        {
                            var child = Dfs(index + 1, 1, 10, digit, true, nextTight);
                            count += child.count;
                            total += child.total;
                            continue;
                        }

                        if (placed == 1)
                        {
                            var child = Dfs(index + 1, 2, previousOne, digit, true, nextTight);
                            count += child.count;
                            total += child.total;
                            continue;
                        }

                        int added = (previousOne > previousTwo && previousOne > digit) ||
                                    (previousOne < previousTwo && previousOne < digit)
                            ? 1
                            : 0;

                        var next = Dfs(index + 1, 2, previousOne, digit, true, nextTight);
                        count += next.count;
                        total += next.total + added * next.count;
                    }

                    return (count, total);
                }
            }

            return Dfs(0, 0, 10, 10, false, true).total;
        }

        private static int DigitSumLong(long value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += (int)(value % 10);
                value /= 10;
            }

            return sum;
        }

        private static bool IsStrictMonotoneDigits(int value)
        {
            if (value <= 0)
                return false;
            if (value < 10)
                return true;

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

        private static bool HaveSameDigitMultiset(long left, long right)
        {
            int[] counts = new int[10];
            if (left == 0)
                counts[0]--;
            while (left > 0)
            {
                counts[(int)(left % 10)]--;
                left /= 10;
            }

            if (right == 0)
                counts[0]++;
            while (right > 0)
            {
                counts[(int)(right % 10)]++;
                right /= 10;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] != 0)
                    return false;
            }

            return true;
        }

        private static long FloorKthRoot(long value, int exponent)
        {
            long left = 0;
            long right = value;
            while (left < right)
            {
                long mid = left + (right - left + 1) / 2;
                if (PowerWithLimit(mid, exponent, value) <= value)
                    left = mid;
                else
                    right = mid - 1;
            }

            return left;
        }

        private static long PowerWithLimit(long value, int exponent, long limit)
        {
            long result = 1;
            while (exponent-- > 0)
            {
                if (value != 0 && result > limit / value)
                    return limit + 1;

                result *= value;
            }

            return result;
        }

        private static long CombinationModuloPrime(int n, int k)
        {
            if (k < 0 || k > n)
                return 0;

            long[] factorial = new long[n + 1];
            long[] inverseFactorial = new long[n + 1];
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
                factorial[i] = factorial[i - 1] * i % Modulo;

            inverseFactorial[n] = ModPow(factorial[n], Modulo - 2, Modulo);
            for (int i = n; i >= 1; i--)
                inverseFactorial[i - 1] = inverseFactorial[i] * i % Modulo;

            return factorial[n] * inverseFactorial[k] % Modulo * inverseFactorial[n - k] % Modulo;
        }

        private static int ParseTimeInSeconds(string value)
        {
            return ParseTwoDigits(value, 0) * 3600 + ParseTwoDigits(value, 3) * 60 + ParseTwoDigits(value, 6);
        }

        private static int ParseTwoDigits(string value, int index)
        {
            return (value[index] - '0') * 10 + (value[index + 1] - '0');
        }

        private static int[] ClosestFactorPair(int value)
        {
            for (int lower = (int)Math.Sqrt(value); lower >= 1; lower--)
            {
                if (value % lower == 0)
                    return new[] { lower, value / lower };
            }

            return new[] { 1, value };
        }
    }
}
